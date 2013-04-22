/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace eda12131190311906
{
    /// <summary>
    /// Main form / app
    /// </summary>
    public partial class FrmMain : Form
    {
        /// <summary>
        /// Background operation timer
        /// </summary>
        public Stopwatch Stopwatcher { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            Stopwatcher = new Stopwatch();

            cblAlgorithms.ItemCheck +=
                (sender, args) =>
                    {
                        int i = cblAlgorithms.CheckedItems.Count;

                        if (args.NewValue == CheckState.Checked)
                        {
                            i++;
                        }
                        else
                        {
                            i--;
                        }
                        lbAlgorithmsSelected.Text = string.Format("Selected: {0}", i);
                    };
            lbProjectUrl.LinkClicked += (sender, args) => SystemHelper.OpenLink(Program.PROJECT_URL);
        

            foreach (var algorithm in Program.ALGORTIHMS)
            {
                cblAlgorithms.BeginUpdate();
                cblAlgorithms.Items.Add(algorithm, true);
                cblAlgorithms.EndUpdate();
            }
            try
            {
                tbGnuplotExecutable.Text = ApplicationSettings.Instance.GnuplotFullPath;
                tbSaveReportsTo.Text = ApplicationSettings.Instance.ReportsPath;
                cbAutoOpenPlots.Checked = ApplicationSettings.Instance.AutoOpenPlot;
                nmNumberOfTests.Value = ApplicationSettings.Instance.NumberOfTests;
                nmArrayInitialSize.Value = ApplicationSettings.Instance.ArrayInitialSize;
                nmArrayGrowFactor.Value = Convert.ToDecimal(ApplicationSettings.Instance.ArrayGrowFactor);
                nmArrayMinRandomNumber.Value = ApplicationSettings.Instance.ArrayMinRandomNumber;
                nmArrayMaxRandomNumber.Value = ApplicationSettings.Instance.ArrayMaxRandomNumber;
                nmArrayNumberGrowFactor.Value = Convert.ToDecimal(ApplicationSettings.Instance.ArrayNumberGrowFactor);
                cbArrayRandomBetweenValues.Checked = ApplicationSettings.Instance.ArrayRandomBetweenValues;
            }
            catch
            {
            }
            
        }

        /// <summary>
        /// Triggerd when any button get clicked
        /// </summary>
        /// <param name="sender">Object who trigger event</param>
        /// <param name="e">Event arguments</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender == btnAlgorithmsSelectAll)
            {
                for (int i = 0; i < cblAlgorithms.Items.Count; i++)
                {
                    cblAlgorithms.SetItemChecked(i, true);
                }
                return;
            }
            if (sender == btnAlgorithmsDeselectAll)
            {
                for (int i = 0; i < cblAlgorithms.Items.Count; i++)
                {
                    cblAlgorithms.SetItemChecked(i, false);
                }
                return;
            }
            if (sender == btnAlgorithmsInvert)
            {
                for (int i = 0; i < cblAlgorithms.Items.Count; i++)
                {
                    cblAlgorithms.SetItemChecked(i, !cblAlgorithms.GetItemChecked(i));
                }
                return;
            }

            if (sender == btnSearchGnuplotExe)
            {
                using (var openDialog = new OpenFileDialog())
                {
                    string workingDir = SystemHelper.IsWindows()
                                            ? Path.GetDirectoryName(ApplicationSettings.Instance.GnuplotFullPath)
                                            : (ApplicationSettings.Instance.GnuplotFullPath.Equals("gnuplot") ? "/usr/bin" : Path.GetDirectoryName(ApplicationSettings.Instance.GnuplotFullPath));
                    openDialog.CheckFileExists = true;
                    openDialog.AddExtension = false;
                    openDialog.CheckPathExists = true;
                    openDialog.RestoreDirectory = true;
                    openDialog.InitialDirectory = workingDir;
                    openDialog.FileName = (SystemHelper.IsWindows() ? "wgnuplot.exe" : "gnuplot");
                    openDialog.Filter = SystemHelper.IsWindows() ? "Gnuplot windows executable (wgnuplot.exe)|wgnuplot.exe" : "Gnuplot executable (gnuplot*)|gnuplot*";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        ApplicationSettings.Instance.GnuplotFullPath = tbGnuplotExecutable.Text = openDialog.FileName;
                    }
                }
                return;
            }
            if (sender == btnSaveReportsTo)
            {
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = @"Folder to save all reports and algorithm work";
                    folderDialog.SelectedPath = Application.StartupPath;
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Absolute to partial path convertion
                        string path = folderDialog.SelectedPath.Replace(Application.StartupPath, string.Empty);
                        if (!string.IsNullOrEmpty(path) && path.Substring(0, 1) == Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture))
                        {
                            path = path.Remove(0, 1);
                        }
                        ApplicationSettings.Instance.ReportsPath = tbSaveReportsTo.Text = path;
                    }
                }
                return;
            }

            if (sender == cbAutoOpenPlots)
            {
                ApplicationSettings.Instance.AutoOpenPlot = cbAutoOpenPlots.Checked;
                return;
            }
            if (sender == cbArrayRandomBetweenValues)
            {
                ApplicationSettings.Instance.ArrayRandomBetweenValues = cbArrayRandomBetweenValues.Checked;
                nmArrayMaxRandomNumber.Enabled = cbArrayRandomBetweenValues.Checked;
                nmArrayNumberGrowFactor.Enabled = !cbArrayRandomBetweenValues.Checked;
                return;
            }

            if (sender == btnStart)
            {
                if (bgWorker.IsBusy)
                {
                    return;
                }
                gbOptions.Enabled = false;
                btnStart.Enabled = false;
                btnStop.Enabled = btnPause.Enabled = true;
                pbLoad.Value = 0;
                pbLoad.Text = @"Starting";
                Stopwatcher.Reset();
                Stopwatcher.Start();
                tmClock.Start();
                bgWorker.RunWorkerAsync();
                return;
            }

            if (sender == btnPause)
            {
                btnPause.Text = btnPause.Text.Equals("Pause") ? "Resume" : "Pause";
                return;
            }

            if (sender == btnStop)
            {
                if (bgWorker.CancellationPending)
                {
                    return;
                }
                if (
                    MessageBox.Show("Have you sure you want stop current work?\nAfter stop there are no backwards", 
                                    @"Cancellation",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                bgWorker.CancelAsync();
                btnPause.Enabled = btnStop.Enabled = false;
                btnPause.Text = "Pause";
                lbStatus.Text += @" -> Cancel Requested -> Waiting for finish";
            }
        }

        /// <summary>
        /// Triggered when any text change inside a registed component
        /// </summary>
        /// <param name="sender">Object who trigger event</param>
        /// <param name="e">Event arguments</param>
        private void ObjValueChanged(object sender, EventArgs e)
        {
            if (sender == tbGnuplotExecutable)
            {
                ApplicationSettings.Instance.GnuplotFullPath = tbGnuplotExecutable.Text;
                return;
            }
            if (sender == tbSaveReportsTo)
            {
                ApplicationSettings.Instance.ReportsPath = tbSaveReportsTo.Text;
                return;
            }
            if (sender == nmNumberOfTests)
            {
                ApplicationSettings.Instance.NumberOfTests = Convert.ToByte(nmNumberOfTests.Value);
                return;
            }
            if (sender == nmArrayInitialSize)
            {
                ApplicationSettings.Instance.ArrayInitialSize = Convert.ToUInt32(nmArrayInitialSize.Value);
                return;
            }
            if (sender == nmArrayGrowFactor)
            {
                ApplicationSettings.Instance.ArrayGrowFactor = Convert.ToDouble(nmArrayGrowFactor.Value);
                return;
            }
            if (sender == nmArrayMinRandomNumber)
            {
                ApplicationSettings.Instance.ArrayMinRandomNumber = Convert.ToUInt32(nmArrayMinRandomNumber.Value);
                return;
            }
            if (sender == nmArrayMaxRandomNumber)
            {
                ApplicationSettings.Instance.ArrayMaxRandomNumber = Convert.ToUInt32(nmArrayMaxRandomNumber.Value);
                return;
            }
            if (sender == nmArrayNumberGrowFactor)
            {
                ApplicationSettings.Instance.ArrayNumberGrowFactor = Convert.ToDouble(nmArrayNumberGrowFactor.Value);
                return;
            }
        }

        /// <summary>
        /// Triggered when background worker start the tasks
        /// </summary>
        /// <param name="sender">Object who trigger event</param>
        /// <param name="e">>Event arguments</param>
        private void BgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bgWorker.ReportProgress(1, "Generating arrays");
                var testArray = new List<int[]>(ApplicationSettings.Instance.NumberOfTests);
                double size = ApplicationSettings.Instance.ArrayInitialSize;
                int minvalue = Math.Max(100, Convert.ToInt32(ApplicationSettings.Instance.ArrayMinRandomNumber));  
                double maxvalue = ApplicationSettings.Instance.ArrayRandomBetweenValues
                                      ? Math.Min(Convert.ToInt32(ApplicationSettings.Instance.ArrayMaxRandomNumber), int.MaxValue)
                                      : minvalue;

                for (int i = 1; i <= ApplicationSettings.Instance.NumberOfTests; i++)
                {
                    if (size <= 0)
                    {
                        size = i * 10;
                    }
                                     
                    testArray.Add(SystemHelper.RandomIntegerArray(Convert.ToInt32(size), minvalue, Convert.ToInt32(maxvalue)));
                    size *= ApplicationSettings.Instance.ArrayGrowFactor;
                    if (!ApplicationSettings.Instance.ArrayRandomBetweenValues)
                    {
                        maxvalue *= ApplicationSettings.Instance.ArrayNumberGrowFactor;
                    }
                }
                var testArrayCopy = SystemHelper.CloneListIntArray(testArray);
                for (int i = 0; i < cblAlgorithms.CheckedItems.Count; i++)
                {
                    if (bgWorker.CancellationPending)
                    {
                        return;
                    }
                    while (btnPause.Text.Equals("Resume"))
                    {
                        Thread.Sleep(1000);
                    }
                    string name = cblAlgorithms.CheckedItems[i].ToString();
                    bgWorker.ReportProgress(i * 100 / cblAlgorithms.CheckedItems.Count + 2, string.Format("Executing {0}/{1} {2}", (i+1), cblAlgorithms.CheckedItems.Count, name));
                    Report report = Program.RunOneAlgorithm(name, testArrayCopy);
                    testArrayCopy = SystemHelper.CloneListIntArray(testArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        /// <summary>
        /// Triggered when background worker change the progress
        /// </summary>
        /// <param name="sender">Object who trigger event</param>
        /// <param name="e">Event arguments</param>
        private void BgWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (pbLoad.InvokeRequired)
                {
                    pbLoad.Invoke(new Action(() => BgWorkerProgressChanged(sender, e)));
                    return;
                }
                pbLoad.Value = e.ProgressPercentage;
                pbLoad.Text = e.UserState.ToString();
                lbStatus.Text = string.Format("Status: {0}", e.UserState);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Triggered when background worker finish all tasks
        /// </summary>
        /// <param name="sender">Object who trigger event</param>
        /// <param name="e">Event arguments</param>
        private void BgWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gbOptions.Enabled = true;
            btnStart.Enabled = true;
            btnStop.Enabled = btnPause.Enabled = false;
            btnPause.Text = @"Pause";
            pbLoad.Value = 100;
            Stopwatcher.Stop();
            tmClock.Stop();
            TmClockTick(null, null);
            if (e.Cancelled)
            {
                lbStatus.Text += @" -> Cancelled";
            }
        }

        /// <summary>
        /// Triggered when timer tick
        /// </summary>
        /// <param name="sender">Object who trigger event</param>
        /// <param name="e">Event arguments</param>
        private void TmClockTick(object sender, EventArgs e)
        {
            lbTimeElapsed.Text = string.Format("Time Elapsed: {0:0.##}s", Stopwatcher.Elapsed.TotalSeconds);
            if (btnPause.Text.Equals("Resume"))
            {
                lbTimeElapsed.Text += @" (Paused)";
            }
            if (!tmClock.Enabled)
            {
                lbTimeElapsed.Text += @" (Done)";
            }
        }

    }
}
