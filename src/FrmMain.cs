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

            tbGnuplotExecutable.Text = Program.GNUPLOT_PATH;
            nmNumberOfTests.Value = Program.NUMBER_OF_TESTS;
            tbSaveReportsTo.Text = Program.REPORTS_PATH;
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
                    openDialog.CheckFileExists = true;
                    openDialog.AddExtension = false;
                    openDialog.CheckPathExists = true;
                    openDialog.RestoreDirectory = true;
                    openDialog.InitialDirectory = Path.GetDirectoryName(Program.GNUPLOT_PATH);
                    openDialog.FileName = (SystemHelper.IsWindows() ? "wgnuplot.exe" : "gnuplot");
                    openDialog.Filter = SystemHelper.IsWindows() ? "Gnuplot windows executable (wgnuplot.exe)|wgnuplot.exe" : "Gnuplot executable (gnuplot*)|gnuplot*";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        tbGnuplotExecutable.Text = openDialog.FileName;
                    }
                }
                return;
            }
            if (sender == btnSaveReportsTo)
            {
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Folder to save all reports and algorithm work";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        tbSaveReportsTo.Text = folderDialog.SelectedPath;
                    }
                }
                return;
            }

            if (sender == cbAutoOpenPlots)
            {
                Program.AUTO_OPEN_PLOT = cbAutoOpenPlots.Checked;
                return;
            }

            if (sender == btnStart)
            {
                if (bgWorker.IsBusy)
                {
                    return;
                }
                btnStart.Enabled = false;
                btnStop.Enabled = btnPause.Enabled = true;
                pbLoad.Value = 0;
                pbLoad.Text = "Starting";
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
                                    "Cancellation",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                bgWorker.CancelAsync();
                btnPause.Enabled = btnStop.Enabled = false;
                lbStatus.Text += " -> Cancel Requested -> Waiting for finish";
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
                Program.GNUPLOT_PATH = tbGnuplotExecutable.Text;
                return;
            }
            if (sender == tbSaveReportsTo)
            {
                Program.REPORTS_PATH = tbSaveReportsTo.Text;
                return;
            }
            if (sender == nmNumberOfTests)
            {
                byte number;
                if (byte.TryParse(nmNumberOfTests.Value.ToString(CultureInfo.InvariantCulture), out number))
                {
                    Program.NUMBER_OF_TESTS = number;
                }
                return;
            }
            if (sender == nmArrayInitialSize)
            {
                int number;
                if (int.TryParse(nmArrayInitialSize.Value.ToString(CultureInfo.InvariantCulture), out number))
                {
                    Program.ARRAY_INITIAL_SIZE = number;
                }
                return;
            }
            if (sender == nmArrayGrowFactor)
            {
                double number;
                if (double.TryParse(nmArrayGrowFactor.Value.ToString(CultureInfo.InvariantCulture), out number))
                {
                    Program.ARRAY_GROW_FACTOR = number;
                }
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
                var testArray = new List<int[]>(Program.NUMBER_OF_TESTS);
                double size = Program.ARRAY_INITIAL_SIZE;
                for (int i = 1; i <= Program.NUMBER_OF_TESTS; i++)
                {
                    size *= Program.ARRAY_GROW_FACTOR;
                    if (size <= 0)
                    {
                        size = i * 10;
                    }
                    int maxvalue = Math.Min((int)(size * 5), int.MaxValue);
                    if (maxvalue == 0)
                    {
                        maxvalue = i * 50;
                    }
                    testArray.Add(SystemHelper.RandomIntegerArray((int)size, maxvalue));
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
                    bgWorker.ReportProgress(i * 100 / cblAlgorithms.CheckedItems.Count, string.Format("Executing {0}/{1} {2}", (i+1), cblAlgorithms.CheckedItems.Count, name));
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
            btnStart.Enabled = true;
            btnStop.Enabled = btnPause.Enabled = false;
            btnPause.Text = "Pause";
            pbLoad.Value = 100;
            Stopwatcher.Stop();
            tmClock.Stop();
            TmClockTick(null, null);
            if (e.Cancelled)
            {
                lbStatus.Text += " -> Cancelled";
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
                lbTimeElapsed.Text += " (Paused)";
            }
            if (!tmClock.Enabled)
            {
                lbTimeElapsed.Text += " (Done)";
            }
        }

    }
}
