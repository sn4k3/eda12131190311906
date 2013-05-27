/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceicao N 11903
 * Goncalo Lampreia N 11906
 * https://code.google.com/p/eda12131190311906/
 */
using System;
using System.IO;
using System.Xml.Serialization;

namespace eda12131190311906
{
    /// <summary>
    /// Application settings
    /// </summary>
    [Serializable]
    public class ApplicationSettings
    {
        #region Properties
        /// <summary>
        /// Default filename to save application settings
        /// </summary>
        public const string Filename = "eda12131190311906.conf.xml";

        /// <summary>
        /// Class serializer
        /// </summary>
        private static readonly XmlSerializer Serial = new XmlSerializer(typeof(ApplicationSettings));

        /// <summary>
        /// Settings instance
        /// </summary>
        private static ApplicationSettings _instance;

        /// <summary>
        /// Settings instance
        /// </summary>
        public static ApplicationSettings Instance
        {
            get 
            { 
                if (_instance == null)
                {
                    if (!File.Exists(Filename))
                    {
                        _instance = new ApplicationSettings();
                    }
                    else
                    {
                        Reload();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Where to save reports to load with gnuplot
        /// </summary>
        public string ReportsPath { get; set; }

        /// <summary>
        /// Gnuplot executable path
        /// </summary>
        public string GnuplotFullPath { get; set; }

        /// <summary>
        /// Auto open generated plot files (Gnuplot required)
        /// </summary>
        public bool AutoOpenPlot { get; set; }

        /// <summary>
        /// Number of tests to realize with sorting algorithms
        /// </summary>
        public byte NumberOfTests { get; set; }

        /// <summary>
        /// Compute time average repeating same code block x times
        /// </summary>
        public byte ComputeAverageValueWith { get; set; }

        /// <summary>
        /// Cut lower and higher time values for compute a better average
        /// </summary>
        public bool CutLowerHigherAverageValue { get; set; }

        /// <summary>
        /// Array initial size (First array size)
        /// </summary>
        public uint ArrayInitialSize { get; set; }

        /// <summary>
        /// Array grow factor type
        /// </summary>
        public char ArrayGrowFactorType { get; set; }

        /// <summary>
        /// Array grow factor
        /// </summary>
        public double ArrayGrowFactor { get; set; }

        /// <summary>
        /// Array min random number
        /// </summary>
        public uint ArrayMinRandomNumber { get; set; }

        /// <summary>
        /// Array max random number
        /// </summary>
        public uint ArrayMaxRandomNumber { get; set; }

        /// <summary>
        /// Array number grow factor type
        /// </summary>
        public char ArrayNumberGrowFactorType { get; set; }

        /// <summary>
        /// Array numbers grow factor
        /// </summary>
        public double ArrayNumberGrowFactor { get; set; }

        /// <summary>
        /// Array random numbers between min and max values
        /// </summary>
        public bool ArrayRandomBetweenValues { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor, with default settings
        /// </summary>
        public ApplicationSettings()
        {
            ReportsPath = "reports";
            GnuplotFullPath = null;
            AutoOpenPlot = true;

            NumberOfTests = 10;
            ComputeAverageValueWith = 5;
            CutLowerHigherAverageValue = true;

            ArrayInitialSize = 2500;
            ArrayGrowFactor = 2500;
            ArrayGrowFactorType = '+';

            ArrayMinRandomNumber = 100;
            ArrayMaxRandomNumber = ushort.MaxValue * 10;
            ArrayNumberGrowFactorType = '*';
            ArrayNumberGrowFactor = 5.0;
            ArrayRandomBetweenValues = true;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Get a string represetantion of this class
        /// </summary>
        /// <returns>String represetantion of this class</returns>
        public override string ToString()
        {
            return string.Format("Filename: {0}\n" +
                                 "Reports path: {1}\n" +
                                 "Gnuplot full path: {2}\n" +
                                 "Auto open plot: {3}\n" +
                                 "Number of tests: {4}\n" +
                                 "Compute average value with: {5}\n" +
                                 "Cut lower and higher average value: {6}\n" +
                                 "Array initial size: {7}\n" +
                                 "Array grow factor type: {8}\n" +
                                 "Array grow factor: {9}\n" +
                                 "Array min random number: {10}\n" +
                                 "Array max random number: {11}\n" +
                                 "Array number grow factor type: {12}\n" +
                                 "Array number grow factor: {13}\n" +
                                 "Array random between values: {14}", 
                                    Filename, 
                                    ReportsPath, 
                                    GnuplotFullPath, 
                                    AutoOpenPlot, 
                                    NumberOfTests, 
                                    ComputeAverageValueWith, 
                                    CutLowerHigherAverageValue, 
                                    ArrayInitialSize, 
                                    ArrayGrowFactorType, 
                                    ArrayGrowFactor, 
                                    ArrayMinRandomNumber, 
                                    ArrayMaxRandomNumber, 
                                    ArrayNumberGrowFactorType, 
                                    ArrayNumberGrowFactor, 
                                    ArrayRandomBetweenValues);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Save settings to file
        /// </summary>
        /// <param name="filename">File to save settings</param>
        public static void Reload(string filename)
        {
            if (!File.Exists(filename))
            {
                return;
            }
            try
            {
                using (var sr = new StreamReader(Filename))
                {
                    _instance = (ApplicationSettings)Serial.Deserialize(sr);
                    sr.Close();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Reload settings from default file
        /// </summary>
        public static void Reload()
        {
            Reload(Filename);
        }

        /// <summary>
        /// Save settings to file
        /// </summary>
        /// <param name="filename">File to save settings</param>
        public static void Save(string filename)
        {
            if (_instance == null)
            {
                return;
            }

            using (var writer = new StreamWriter(filename))
            {
                Serial.Serialize(writer, _instance);
                writer.Close();
            }
        }

        /// <summary>
        /// Save settings to default file
        /// </summary>
        public static void Save()
        {
            Save(Filename);
        }
        #endregion
    }
}
