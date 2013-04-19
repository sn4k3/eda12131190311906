/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace eda12131190311906
{
    /// <summary>
    /// Main program
    /// </summary>
    static class Program
    {
        public const string PROJECT_URL = "https://code.google.com/p/eda12131190311906/";
        /// <summary>
        /// All algorithms avaliable to run
        /// </summary>
        public static string[] ALGORTIHMS = new[]            {"Insertion",
															"Bubble",
															"Heap",
															"Merge",
															"Quick",
															"Bucket",
															"Counting",
															"Comb",
															"Selection",
															"Shell"};
        /// <summary>
        /// Number of tests to realize with sorting algorithms
        /// </summary>
        public static byte NUMBER_OF_TESTS = 15;
        
        /// <summary>
        /// Where to save reports to load with gnuplot
        /// </summary>
        public static string REPORTS_PATH = "Report/plot";

        /// <summary>
        /// Gnuplot executable path
        /// </summary>
        public static string GNUPLOT_PATH = null;

        /// <summary>
        /// GNUPLOT Graf generator file
        /// </summary>
        public const string GNUPLOT_GENERATOR_FILE = "plot_results";

        /// <summary>
        /// Auto open generated plot files (Gnuplot required)
        /// </summary>
        public static bool AUTO_OPEN_PLOT = true;

        /// <summary>
        /// Array initial size (First array size)
        /// </summary>
        public static int ARRAY_INITIAL_SIZE = 15;

        /// <summary>
        /// Array grow factor
        /// </summary>
        public static double ARRAY_GROW_FACTOR = 2;

        /// <summary>
        /// Collection of reports
        /// </summary>
        public static List<Report> Reports { get; private set; }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Setup();
            GenerateGnuplotFiles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        /// <summary>
        /// Run common tasks to setup the application
        /// </summary>
        public static void Setup()
        {
            Reports = new List<Report>();
            if (!string.IsNullOrEmpty(GNUPLOT_PATH)) return;

            GNUPLOT_PATH = SystemHelper.GetProgramFilesX86Path();
            if (GNUPLOT_PATH != "")
            {
                GNUPLOT_PATH += "\\gnuplot\\bin\\wgnuplot.exe";
            }
            else // No windows
            {
                GNUPLOT_PATH = "gnuplot";
            }
        }

        /// <summary>
        /// Get a report by name
        /// </summary>
        /// <param name="name"> Report name</param>
        /// <returns>Report, null if no exists</returns>
        public static Report GetReport(string name)
        {
            return Reports.FirstOrDefault(report => report.Name.Equals(name));
        }

        /// <summary>
        /// Run algorithms, measure execution time and report to a file
        /// </summary>
        public static void RunAlgorithms()
        {
            // Create a list with multiple arrays holding random numbers
            var testArray = new List<int[]>(NUMBER_OF_TESTS);
            int size = 1;
            for (int i = 1; i <= NUMBER_OF_TESTS; i++)
            {
                size *= 2;
                if (size == 0)
                {
                    size = i * 10;
                }
                int maxvalue = Math.Min(size * 5, int.MaxValue);
                if (maxvalue == 0)
                {
                    maxvalue = i * 50;
                }
                testArray.Add(SystemHelper.RandomIntegerArray(size, maxvalue));
            }
            var testArrayCopy = SystemHelper.CloneListIntArray(testArray);
            for (int i = 0; i < ALGORTIHMS.Length; i++)
            {
                Report report = RunOneAlgorithm(ALGORTIHMS[i], testArrayCopy);
                testArrayCopy = SystemHelper.CloneListIntArray(testArray);
            }
        }

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

                    var profiler = report.AddProfiler("Sort " + count);
                    m.Invoke(null, methodparams);
                    profiler.Stop();
                    report.Comments.Add("Sorted array " +
                            count +
                            ": " +
                            SystemHelper.ArrayToString(intA));

                    var profiler1 = report.AddProfiler("Sort-Sorted " + count);
                    m.Invoke(null, methodparams);
                    profiler1.Stop();
                    report.Comments.Add("Sorted-sorted array " +
                            count +
                            ": " +
                            SystemHelper.ArrayToString(intA));
                    count++;
                }

                report.WriteToFile();
                

                return report;
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

        /// <summary>
        /// Generate Gnuplot graf files
        /// </summary>
        public static void GenerateGnuplotFiles()
        {
            try
            {
                if (!Directory.Exists(REPORTS_PATH))
                {
                    Directory.CreateDirectory(REPORTS_PATH);
                }
                using (TextWriter fstream = new StreamWriter(Path.Combine(REPORTS_PATH, GNUPLOT_GENERATOR_FILE) +
                                                                 (SystemHelper.IsWindows() ? ".bat" : ".sh")))
                {
                    string gnuvar = "%GNUPLOT_PATH%";
                    if (SystemHelper.IsWindows())
                    {
                        fstream.Write("@echo off\n" + 
                                        "title \"Relatorio de grafos com GNUPLOT\"\n" + 
                                        "set GNUPLOT_PATH=\"{0}\"\n", GNUPLOT_PATH);
                    }
                    else
                    {
                        fstream.Write("echo \"Relatorio de grafos com GNUPLOT\"\n" + 
                                        "GNUPLOT_PATH=\"{0}\"\n", GNUPLOT_PATH);
                        gnuvar = "$GNUPLOT_PATH";
                    }
                    for (int i = 0; i < ALGORTIHMS.Length; i++)
                    {
                        fstream.Write("echo Running {0} sort plot\n" + 
                                        "{1} \"{0}.plt\"\n", ALGORTIHMS[i], gnuvar);
                        
                    }
                    fstream.Write("\npause");

                    fstream.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
