/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceição Nº 11903
 * Gonçalo Lampreia Nº 11906
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
        /// Number of tests to realize with sorting algorithms
        /// </summary>
        public byte NumberOfTests { get; set; }

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
        /// Array initial size (First array size)
        /// </summary>
        public int ArrayInitialSize { get; set; }

        /// <summary>
        /// Array grow factor
        /// </summary>
        public double ArrayGrowFactor { get; set; }

        /// <summary>
        /// Array min random number
        /// </summary>
        public int ArrayMinRandomNumber { get; set; }

        /// <summary>
        /// Array max random number
        /// </summary>
        public int ArrayMaxRandomNumber { get; set; }

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
        /// Constructor
        /// </summary>
        public ApplicationSettings()
        {
            NumberOfTests = 10;
            ReportsPath = "reports";
            GnuplotFullPath = null;
            AutoOpenPlot = true;

            ArrayInitialSize = 2;
            ArrayGrowFactor = 2;

            ArrayMinRandomNumber = 100;
            ArrayMaxRandomNumber = Int32.MaxValue;
            ArrayNumberGrowFactor = 5.0;
            ArrayRandomBetweenValues = true;
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
