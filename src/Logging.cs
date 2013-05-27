/**
 * Estruturas de Dados e Algoritmos (EDA) - Project I
 * Tiago Conceicao N 11903
 * Goncalo Lampreia N 11906
 * https://code.google.com/p/eda12131190311906/
 */

using System;
using System.IO;

namespace eda12131190311906
{
    /// <summary>
    /// Loggin class, provide a log model to the application
    /// </summary>
    public sealed class Logging
    {
        #region Event
        /// <summary>
        /// Log event hander class
        /// </summary>
        public sealed class LogEventArgs
        {
            /// <summary>
            /// New text added to log
            /// </summary>
            public string AddedText { get; private set; }

            /// <summary>
            /// Is text write using WriteLine
            /// </summary>
            public bool IsWriteLine { get; private set; }

            /// <summary>
            /// Is text cleared and set to empty
            /// </summary>
            public bool Cleared { get; private set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="text">Text</param>
            /// <param name="isWriteLine">Is text write using WriteLine</param>
            /// <param name="cleared">Is text cleared and set to empty</param>
            public LogEventArgs(string text, bool isWriteLine, bool cleared)
            {
                AddedText = text;
                IsWriteLine = isWriteLine;
                Cleared = cleared;
            }
        }

        /// <summary>
        /// Log event handler delegate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void LogEventHandler(Object sender, LogEventArgs e);

        /// <summary>
        /// Log event handler
        /// </summary>
        private LogEventHandler _log;

        /// <summary>
        /// Log event, raised when something writes to log
        /// </summary>
        public event LogEventHandler Log
        {
            add
            {
                _log += value;
            }

            remove
            {
                _log -= value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected void OnLog(LogEventArgs args)
        {
            if (_log != null)
            {
                _log(this, args);
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the log header text
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets the string holding log
        /// </summary>
        public string LogText { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Logging()
        {
            Header = string.Empty;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Write to log
        /// </summary>
        /// <param name="text">Text to write</param>
        public void Write(string text)
        {
            LogText += text;
            OnLog(new LogEventArgs(text, false, false));
        }

        /// <summary>
        /// Write a new line to log
        /// </summary>
        public void WriteLine()
        {
            LogText += Environment.NewLine;
            OnLog(new LogEventArgs(Environment.NewLine, true, false));
        }

        /// <summary>
        /// Write to log
        /// </summary>
        /// <param name="text">Text to write</param>
        public void WriteLine(string text)
        {
            LogText += text + Environment.NewLine;
            OnLog(new LogEventArgs(text + Environment.NewLine, true, false));
        }

        /// <summary>
        /// Clear log text
        /// </summary>
        public void Clear()
        {
            LogText = string.Empty;
            OnLog(new LogEventArgs(string.Empty, false, true));
        }

        /// <summary>
        /// Write log to a default file (debug.log)
        /// </summary>
        /// <param name="path">Path to save file</param>
        /// <returns>True if file write successfully, ortherwise false</returns>
        public bool WriteToFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = ApplicationSettings.Instance.ReportsPath;
            }

            if (Program.Logging.IsEmpty())
            {
                return false;
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            // Create file 
            using (TextWriter textWriter = new StreamWriter(Path.Combine(path, "debug.log")))
            {
                textWriter.WriteLine(Program.Logging.Header);
                textWriter.WriteLine(Program.Logging.LogText);
                textWriter.Close();
            }
            return true;
        }

        /// <summary>
        /// Write log to a default file (debug.log)
        /// </summary>
        /// <returns>True if file write successfully, ortherwise false</returns>
        public void WriteToFile()
        {
            WriteToFile(null);
        }

        /// <summary>
        /// Check if log is empty or have anything in
        /// </summary>
        /// <returns>True if empty, otherwise false</returns>
        private bool IsEmpty()
        {
            return string.IsNullOrEmpty(LogText);
        }

        #endregion
    }
}
