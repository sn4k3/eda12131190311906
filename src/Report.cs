/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace eda12131190311906
{
    /// <summary>
    /// Report algorithm execution to file and grafs
    /// </summary>
    public sealed class Report {
        /// <summary>
        /// Report name
        /// </summary>
        public string Name { get; set; }
	
        /// <summary>
        /// Comments to write on file header
        /// </summary>
        public List<string> Comments { get; private set; }
	
        /// <summary>
        /// Collection of profilers
        /// </summary>
        private readonly Dictionary<string, Stopwatch> _profilers;
	
        /// <summary>
        /// Plot columns text
        /// </summary>
        public List<string> PlotColumns { get; private set; }
	
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Report name</param>
        public Report(string name)
        {
            Name = name;
            Comments = new List<string>();
            _profilers = new Dictionary<string, Stopwatch>();
            PlotColumns = new List<string>();
        }

        /// <summary>
        /// Add a profiler
        /// </summary>
        /// <param name="name">Profiler name</param>
        /// <param name="profiler">Profiler to add</param>
        /// <returns>True if added, otherwise false (Duplicated name)</returns>
        public bool AddProfiler(string name, Stopwatch profiler)
        {
            if(_profilers.ContainsKey(name))
            {
                return false;
            }
            _profilers.Add(name, profiler);
            return true;
        }

        /// <summary>
        /// Add a profiler
        /// </summary>
        /// <param name="name">Profiler name</param>
        /// <param name="run">Start profiling or not</param>
        /// <returns>Profiler added to map</returns>
        public Stopwatch AddProfiler(string name, bool run)
        {
            if(_profilers.ContainsKey(name))
            {
                return _profilers[name];
            }
            var profiler = new Stopwatch();
            _profilers.Add(name, profiler);
            if (run)
            {
                profiler.Start();
            }
            return profiler;
        }

        /// <summary>
        /// Add a profiler 
        /// </summary>
        /// <param name="name">Profiler name</param>
        /// <returns>Profiler added to map</returns>
        public Stopwatch AddProfiler(string name)
        {
            return AddProfiler(name, true);
        }

        /// <summary>
        /// Get a profiler
        /// </summary>
        /// <param name="name">Profiler name</param>
        /// <returns>Profiler, null if not exists</returns>
        public Stopwatch GetProfiler(string name)
        {
            return _profilers.ContainsKey(name) 
                       ? _profilers[name] 
                       : null;
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
			
                fstreamPlot.Write("set title \""+Name+" Sort Algorithm\"\n" +
                                  "set xlabel \"Execution Number\"\n" +
                                  "set ylabel \"Execution Time (ms)\"\n" +
                                  "set style fill transparent solid 0.5 noborder\n" +
                                  "plot ");

                TextWriter fstream = new StreamWriter(Path.Combine(path, Name) + ".txt");
                fstream.WriteLine("# Relatório do algoritmo " + Name);
                fstream.WriteLine("# All times are milliseconds (ms)");
                foreach(string comment in Comments)
                {
                    fstream.WriteLine("# " + comment);
                }
                fstream.Write("# Nº");
                foreach(string column in PlotColumns)
                {
                    fstream.Write("\t"+column);
                }
                fstream.WriteLine();
			
                int count = 1;
                int i = 2;
                foreach(string column in PlotColumns)
                {
                    fstreamPlot.Write("\"{0}.txt\" using 1:{1} title '{2}' with lines", Name, i, column);
                    if(PlotColumns.Count >= i)
                    {
                        fstreamPlot.Write(", ");
                    }
                    i++;
                }
                fstreamPlot.WriteLine();
                //fstreamPlot.WriteLine("pause -1");
                i = 1;


                //for (Map.Entry<String, Profiler> e : this.profilers.entrySet())
                foreach(var profiler in _profilers)
                {
                    //Profiler profiler = e.getValue();
                    fstream.Write("{0}\t\t{1}", count, profiler.Value.ElapsedTicks / 10000D);
				
                    if(i % PlotColumns.Count == 0)
                    {
                        count++;
                        fstream.WriteLine();
                    }
				
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
    }
}
