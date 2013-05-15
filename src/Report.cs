/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace eda12131190311906
{
    /// <summary>
    /// Report algorithm execution to file and grafs
    /// </summary>
    public sealed class Report
    {

        #region Classes
        /// <summary>
        /// Report item class, represents a single line on gnuplot files
        /// </summary>
        public sealed class PlotLine
        {
            #region Properties
            /// <summary>
            /// X axis value for this line of results, 1st column on file
            /// </summary>
            public string XAxis { get; set; }

            /// <summary>
            /// Line columns data, each column represents a <see cref="StopwatchEx"/> holding a <see cref="TimeSpan"/> with execution time
            /// </summary>
            public List<StopwatchEx> Columns { get; private set; }
            #endregion

            #region Constructor
            /// <summary>
            /// Constructor
            /// </summary>
            public PlotLine()
            {
                Columns = new List<StopwatchEx>();
            }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="xAxis">X axis name for this line</param>
            public PlotLine(string xAxis) : this()
            {
                XAxis = xAxis;
            }
            #endregion

            #region Methods
            /// <summary>
            /// Add a profiler
            /// </summary>
            /// <param name="profiler">Profiler to add</param>
            /// <returns>True if added, otherwise false (Duplicated name)</returns>
            public bool AddProfiler(StopwatchEx profiler)
            {
                Columns.Add(profiler);
                return true;
            }

            /// <summary>
            /// Add a profiler
            /// </summary>
            /// <param name="run">Start profiling or not</param>
            /// <returns>Profiler added to map</returns>
            public StopwatchEx AddProfiler(bool run)
            {
                var profiler = new StopwatchEx();
                Columns.Add(profiler);
                if (run)
                {
                    profiler.Start();
                }
                return profiler;
            }

            /// <summary>
            /// Add a profiler and run
            /// </summary>
            /// <returns>Profiler added to map</returns>
            public StopwatchEx AddProfiler()
            {
                return AddProfiler(true);
            }

            #endregion
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the report name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the X axis name / data name
        /// </summary>
        public string XAxisLabel { get; set; }

        /// <summary>
        ///  Gets or sets the Y axis name / data name
        /// </summary>
        public string YAxisLabel { get; set; }
	
        /// <summary>
        /// Comments to write on file header
        /// </summary>
        public List<string> Comments { get; private set; }
	
        /// <summary>
        /// Plot data titles
        /// </summary>
        public List<string> PlotTitles { get; private set; }

        /// <summary>
        /// Plot lines holding all data
        /// </summary>
        public List<PlotLine> PlotLines { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Report name</param>
        public Report(string name)
        {
            Name = name;
            Comments = new List<string>();
            PlotTitles = new List<string>();
            PlotLines = new List<PlotLine>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get plot line based on X Axis value
        /// </summary>
        /// <param name="xAxis">X Axis value</param>
        /// <returns>PlotLine holding line data</returns>
        public PlotLine GetPlotLine(string xAxis)
        {
            for (int i = 0; i < PlotLines.Count; i++)
            {
                if (PlotLines[i].XAxis == xAxis)
                {
                    return PlotLines[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Write reports to a file
        /// </summary>
        /// <param name="path">Path to save the file</param>
        public void WriteToFile(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // Create file 
                TextWriter fstreamPlot = new StreamWriter(Path.Combine(path, Name) + ".plt");
			
                fstreamPlot.Write("set title \""+Name+" Sort Algorithm\"" + Environment.NewLine +
                                  "set xlabel \""+XAxisLabel+"\"" + Environment.NewLine +
                                  "set ylabel \""+YAxisLabel+"\"" + Environment.NewLine +
                                  "set style fill transparent solid 0.5 noborder" + Environment.NewLine +
                                  "plot ");

                TextWriter fstream = new StreamWriter(string.Format("{0}.txt", Path.Combine(path, Name)));
                fstream.WriteLine("# Relatório do algoritmo {0}", Name);
                fstream.WriteLine("# All times are milliseconds (ms)");
                foreach(string comment in Comments)
                {
                    fstream.WriteLine("# {0}", comment);
                }
                fstream.Write("# Nº");
                int i = 2;
                foreach (string column in PlotTitles)
                {
                    fstream.Write("\t{0}", column);
                    fstreamPlot.Write("\"{0}.txt\" using 1:{1} title '{2}' with lines", Name, i, column);
                    if (PlotTitles.Count >= i)
                    {
                        fstreamPlot.Write(", ");
                    }
                    i++;
                }
                fstream.WriteLine();
                fstreamPlot.WriteLine();
                //fstreamPlot.WriteLine("pause -1");


                i = 1;
                //for (Map.Entry<String, Profiler> e : this.profilers.entrySet())
                foreach (var plotLine in PlotLines)
                {
                    fstream.Write(plotLine.XAxis);
                    //Profiler profiler = e.getValue();
                    //fstream.Write("{0}\t\t{1}", count, (profiler.Value.ElapsedTicks / (double)TimeSpan.TicksPerMillisecond).ToString(CultureInfo.InvariantCulture));
                    foreach (var column in plotLine.Columns)
                    {
                        fstream.Write("\t{0}", column.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
                    }
                    fstream.WriteLine();			
                    i++;
                }
			
                //Close the output stream
                fstream.Close();
                fstreamPlot.Close();

                if (ApplicationSettings.Instance.AutoOpenPlot)
                {
                    using (var proc = new Process())
                    {
                        //proc.StartInfo.CreateNoWindow = true;
                        proc.StartInfo.WorkingDirectory = path;
                        proc.StartInfo.FileName = ApplicationSettings.Instance.GnuplotFullPath;
                        proc.StartInfo.Arguments = string.Format("-p \"{0}.plt\"", Name);
                        proc.StartInfo.UseShellExecute = false;
                        proc.Start();
                        proc.Close();
                    }
                   
                }
            }catch (Exception e){ //Catch exception if any
                MessageBox.Show(string.Format(@"Error: {0}", e.Message));
            }
        }
	
        /// <summary>
        /// Write reports to a file
        /// </summary>
        public void WriteToFile()
        {
            WriteToFile(ApplicationSettings.Instance.ReportsPath);
        }

        #endregion

        #region Static Methods
        /// <summary>
        /// Build a master report holding and comparing all reports
        /// </summary>
        /// <param name="reports">List with all reports to include</param>
        /// <returns>Master report</returns>
        public static Report BuildMaster(List<Report> reports)
        {
            if (reports.Count == 0)
            {
                return null;
            }
            Report masterReport = new Report("All")
                                      {
                                          XAxisLabel = reports[0].XAxisLabel,
                                          YAxisLabel = reports[0].YAxisLabel
                                      };


            foreach (var report in reports)
            {
                if (report.PlotLines.Count == 0)
                {
                    continue;
                }

                masterReport.PlotTitles.Add(report.Name);

                for (int x = 0; x < report.PlotLines.Count; x++)
                {
                    PlotLine line = masterReport.GetPlotLine(report.PlotLines[x].XAxis);
                    if (line == null)
                    {
                        line = new PlotLine {XAxis = report.PlotLines[x].XAxis};
                        masterReport.PlotLines.Add(line);
                    }
                    
                    if (report.PlotLines[x].Columns.Count == 0)
                    {
                        continue;
                    }

                    line.Columns.Add(report.PlotLines[x].Columns[0]);
                }
            }
            return masterReport;
        }

        /// <summary>
        /// Generate Gnuplot graf files
        /// </summary>
        public static void GenerateGnuplotFiles()
        {
            try
            {
                if (!Directory.Exists(ApplicationSettings.Instance.ReportsPath))
                {
                    Directory.CreateDirectory(ApplicationSettings.Instance.ReportsPath);
                }
                using (TextWriter fstream = new StreamWriter(Path.Combine(ApplicationSettings.Instance.ReportsPath, Program.GNUPLOT_GENERATOR_FILE) +
                                                                 (SystemHelper.IsWindows() ? ".bat" : ".sh")))
                {
                    string gnuvar = "%GNUPLOT_PATH%";
                    if (SystemHelper.IsWindows())
                    {
                        fstream.Write("@echo off\n" +
                                        "title \"Relatorio de grafos com GNUPLOT\"\n" +
                                        "set GNUPLOT_PATH=\"{0}\"\n", ApplicationSettings.Instance.GnuplotFullPath);
                    }
                    else
                    {
                        fstream.Write("echo \"Relatorio de grafos com GNUPLOT\"\n" +
                                        "GNUPLOT_PATH=\"{0}\"\n", ApplicationSettings.Instance.GnuplotFullPath);
                        gnuvar = "$GNUPLOT_PATH";
                    }
                    for (int i = 0; i < Program.ALGORTIHMS.Length; i++)
                    {
                        fstream.Write("echo Running {0} sort plot\n" +
                                        "{1} -p \"{0}.plt\"\n", Program.ALGORTIHMS[i], gnuvar);

                    }
                    fstream.Write("echo Running All sort plot\n" +
                                        "{0} -p \"All.plt\"\n", gnuvar);

                    fstream.Write("\npause");

                    fstream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
