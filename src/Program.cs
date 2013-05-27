/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceicao N 11903
 * Goncalo Lampreia N 11906
 * https://code.google.com/p/eda12131190311906/
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace eda12131190311906
{
    /// <summary>
    /// Main program
    /// </summary>
    static class Program
    {
        #region Constants
        public const string PROJECT_URL         = "https://code.google.com/p/eda12131190311906";
        public static readonly string[] PROJECT_AUTHORS = new[] { "Tiago Conceição Nº11903", "Gonçalo Lampreia Nº11906" };
        /// <summary>
        /// All algorithms avaliable to run
        /// </summary>
        public static readonly string[] ALGORTIHMS = new[]  {"Insertion",
															"Bubble",
															"Heap",
															"Merge",
															"Quick",
                                                            "Radix",
															"Bucket",
															"Counting",
															"Comb",
															"Selection",
															"Shell",};
        #endregion

        #region Properties
        /// <summary>
        /// GNUPLOT Graf generator file
        /// </summary>
        public const string GNUPLOT_GENERATOR_FILE = "plot_results";

        /// <summary>
        /// Collection of reports
        /// </summary>
        public static List<Report> Reports { get; private set; }

        public static Logging Logging { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Setup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logging = new Logging();
            Application.Run(new FrmMain());
            ApplicationSettings.Save();
        }
        #endregion

        #region Setup
        /// <summary>
        /// Run common tasks to setup the application
        /// </summary>
        public static void Setup()
        {
            Reports = new List<Report>();
            if (!string.IsNullOrEmpty(ApplicationSettings.Instance.GnuplotFullPath)) return;

            ApplicationSettings.Instance.GnuplotFullPath = SystemHelper.GetProgramFilesX86Path();
            if (ApplicationSettings.Instance.GnuplotFullPath != "")
            {
                ApplicationSettings.Instance.GnuplotFullPath += "\\gnuplot\\bin\\wgnuplot.exe";
            }
            else // No windows
            {
                ApplicationSettings.Instance.GnuplotFullPath = "gnuplot";
            }
        }
        #endregion

        #region Get report method
        /// <summary>
        /// Get a report by name
        /// </summary>
        /// <param name="name"> Report name</param>
        /// <returns>Report, null if no exists</returns>
        public static Report GetReport(string name)
        {
            return Reports.FirstOrDefault(report => report.Name.Equals(name));
        }
        #endregion

        #region Run algorithm methods
        /// <summary>
        /// Run a algorithm and log execution
        /// </summary>
        /// <param name="classname">Class name</param>
        /// <param name="method">Method name (sort)</param>
        /// <param name="intList">List with arrays to sort</param>
        /// <returns>Report log</returns>
        public static Report RunOneAlgorithm(string classname, string method, List<int[]> intList)
        {
            try
            {
                GC.Collect();
                Logging.WriteLine("################################");
                Logging.WriteLine(string.Format("Algorithm: {0}", classname));
                Logging.WriteLine(string.Format("Arrays to test: {0}", intList.Count));
                Logging.WriteLine("################################");
                Type t = Type.GetType(string.Format("eda12131190311906.{0}", classname));
                if (t == null)
                {
                    return null;
                }
                MethodInfo m = t.GetMethod(method, new[] { typeof(int[]) });
              
                Report report = new Report(classname)
                                    {
                                        XAxisLabel = "Array number of elements",
                                        YAxisLabel = "Execution Time (ms)"
                                    };
                report.PlotTitles.Add("Sort");
                report.PlotTitles.Add("Sort-sorted");
                Reports.Add(report);
                int count = 1;
                foreach (var intA in intList)
                {
                    var plotLine = new Report.PlotLine(intA.Length.ToString(CultureInfo.InvariantCulture));
                    report.PlotLines.Add(plotLine);

                    Logging.WriteLine(string.Format("Array nº{0} with {1} elements", count, intA.Length));
                    var A = (int[])intA.Clone();
                    report.Comments.Add("");
                    report.Comments.Add("Array(" + A.Length + ") " + count + ": " + SystemHelper.ArrayToString(A));

                    Logging.Write("Sorting");
                    var methodparams = new object[] { A };
                    if (ApplicationSettings.Instance.ComputeAverageValueWith <= 1)
                    {
                        var profiler = plotLine.AddProfiler();
                        m.Invoke(null, methodparams);
                        profiler.Stop();
                        Logging.WriteLine(string.Format(", Sorted after {0}ms", profiler.ElapsedMilliseconds));
                    }
                    else
                    {
                        Logging.WriteLine();
                        Logging.WriteLine(string.Format("------Computing Average for {0} executions------", ApplicationSettings.Instance.ComputeAverageValueWith));
                        var avgList = new List<StopwatchEx>(ApplicationSettings.Instance.ComputeAverageValueWith);
                        for (int i = 0; i < ApplicationSettings.Instance.ComputeAverageValueWith; i++)
                        {
                            Logging.Write(string.Format("{0}: ", i));
                            A = (int[])intA.Clone();
                            methodparams = new object[] { A };
                            StopwatchEx stopwatch = StopwatchEx.StartNew();
                            m.Invoke(null, methodparams);
                            stopwatch.Stop();
                            Logging.WriteLine(string.Format("{0}ms", stopwatch.ElapsedMilliseconds));
                            avgList.Add(stopwatch);
                        }
                        var averageStopWatch = StopwatchEx.ComputeAverage(avgList,
                                                                    ApplicationSettings.Instance
                                                                                       .CutLowerHigherAverageValue);
                        plotLine.AddProfiler(averageStopWatch);
                        Logging.WriteLine(string.Format("-----------Computed Average: {0}ms-----------", averageStopWatch.ElapsedMilliseconds));
                    }


                    Logging.Write("Sorting sorted array");
                    report.Comments.Add("Sorted array " +
                            count +
                            ": " +
                            SystemHelper.ArrayToString(A));

                    if (ApplicationSettings.Instance.ComputeAverageValueWith <= 1)
                    {
                        var profiler1 = plotLine.AddProfiler();
                        m.Invoke(null, methodparams);
                        profiler1.Stop();
                        Logging.WriteLine(string.Format(", Sorted after {0}ms", profiler1.ElapsedMilliseconds));
                    }
                    else
                    {
                        Logging.WriteLine();
                        Logging.WriteLine(string.Format("------Computing Average for {0} executions------", ApplicationSettings.Instance.ComputeAverageValueWith));
                        var avgList = new List<StopwatchEx>(ApplicationSettings.Instance.ComputeAverageValueWith);
                        for (int i = 0; i < ApplicationSettings.Instance.ComputeAverageValueWith; i++)
                        {
                            Logging.Write(string.Format("{0}: ", i));
                            StopwatchEx stopwatch = StopwatchEx.StartNew();
                            m.Invoke(null, methodparams);
                            stopwatch.Stop();
                            Logging.WriteLine(string.Format("{0}ms", stopwatch.ElapsedMilliseconds));
                            avgList.Add(stopwatch);
                        }
                        var averageStopWatch = StopwatchEx.ComputeAverage(avgList,
                                                                    ApplicationSettings.Instance
                                                                                       .CutLowerHigherAverageValue);
                        Logging.WriteLine(string.Format("-----------Computed Average: {0}ms-----------", averageStopWatch.ElapsedMilliseconds));
                        plotLine.AddProfiler(averageStopWatch);
                    }

                    report.Comments.Add("Sorted-sorted array " +
                            count +
                            ": " +
                            SystemHelper.ArrayToString(A));
                    count++;
                }
                Logging.WriteLine("################################");
                Logging.WriteLine(string.Format("End of {0} algorithmn", classname));
                Logging.WriteLine("################################");

                report.WriteToFile();
                

                return report;
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            return null;
        }


        /// <summary>
        /// Run a algorithm and log execution
        /// </summary>
        /// <param name="classname">Class name</param>
        /// <param name="method">Method name (sort)</param>
        /// <param name="A">Array to sort</param>
        /// <returns>Report log</returns>
        public static Report RunOneAlgorithm(string classname, string method, int[] A)
        {
            var arrayList = new List<int[]>(1) {A};
            return RunOneAlgorithm(classname, method, arrayList);
        }

        /// <summary>
        /// Run a algorithm and log execution
        /// </summary>
        /// <param name="classname">Class name</param>
        /// <param name="A">List with arrays to sort</param>
        /// <returns>Report log</returns>
        public static Report RunOneAlgorithm(string classname, List<int[]> A)
        {
            return RunOneAlgorithm(classname, "Sort", A);
        }

        /// <summary>
        /// Run a algorithm and log execution
        /// </summary>
        /// <param name="classname">Class name</param>
        /// <param name="A">List with arrays to sort</param>
        /// <returns>Report log</returns>
        public static Report RunOneAlgorithm(string classname, int[] A)
        {
            return RunOneAlgorithm(classname, "Sort", A);
        }
        #endregion
    }
}
