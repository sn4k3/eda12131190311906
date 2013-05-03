/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */
using System;
using System.Collections.Generic;
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
        public const string PROJECT_URL = "https://code.google.com/p/eda12131190311906";
        /// <summary>
        /// All algorithms avaliable to run
        /// </summary>
        public static string[] ALGORTIHMS = new[]            {"Insertion",
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
        /// <param name="A">List with arrays to sort</param>
        /// <returns>Report log</returns>
        public static Report RunOneAlgorithm(string classname, string method, List<int[]> A)
        {
            try
            {
                Type t = Type.GetType(string.Format("eda12131190311906.{0}", classname));
                if (t == null)
                {
                    return null;
                }
                MethodInfo m = t.GetMethod(method, new[] { typeof(int[]) });
              
                Report report = new Report(classname);
                report.PlotColumns.Add("Sort");
                report.PlotColumns.Add("Sort-sorted");
                Reports.Add(report);
                int count = 1;
                foreach (var intA in A)
                {
                    report.Comments.Add("");
                    report.Comments.Add("Array(" + intA.Length + ") " + count + ": " + SystemHelper.ArrayToString(intA));

                    var methodparams = new object[] { intA };

                    if (ApplicationSettings.Instance.ComputeAverageValueWith <= 1)
                    {
                        var profiler = report.AddProfiler("Sort " + count);
                        m.Invoke(null, methodparams);
                        profiler.Stop();
                    }
                    else
                    {
                        var avgList = new List<StopwatchEx>(ApplicationSettings.Instance.ComputeAverageValueWith);
                        for (int i = 0; i < ApplicationSettings.Instance.ComputeAverageValueWith; i++)
                        {
                            StopwatchEx stopwatch = StopwatchEx.StartNew();
                            m.Invoke(null, methodparams);
                            stopwatch.Stop();
                            avgList.Add(stopwatch);
                        }
                        report.AddProfiler("Sort " + count, StopwatchEx.ComputeAverage(avgList, ApplicationSettings.Instance.CutLowerHigherAverageValue));
                    }
                    
                        
                    
                    report.Comments.Add("Sorted array " +
                            count +
                            ": " +
                            SystemHelper.ArrayToString(intA));

                    if (ApplicationSettings.Instance.ComputeAverageValueWith <= 1)
                    {
                        var profiler1 = report.AddProfiler("Sort-Sorted " + count);
                        m.Invoke(null, methodparams);
                        profiler1.Stop();
                    }
                    else
                    {
                        var avgList = new List<StopwatchEx>(ApplicationSettings.Instance.ComputeAverageValueWith);
                        for (int i = 0; i < ApplicationSettings.Instance.ComputeAverageValueWith; i++)
                        {
                            StopwatchEx stopwatch = StopwatchEx.StartNew();
                            m.Invoke(null, methodparams);
                            stopwatch.Stop();
                            avgList.Add(stopwatch);
                        }
                        report.AddProfiler("Sort-Sorted " + count, StopwatchEx.ComputeAverage(avgList, ApplicationSettings.Instance.CutLowerHigherAverageValue));
                    }

                    report.Comments.Add("Sorted-sorted array " +
                            count +
                            ": " +
                            SystemHelper.ArrayToString(intA));
                    count++;
                }

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
