using System.ComponentModel;
using System.Threading;

namespace eda12131190311906
{
    /// <summary>
    /// Executes an operation on a separate thread.
    /// Can be aborted without a wait time
    /// </summary>
    class AbortableBackgroundWorker : BackgroundWorker 
    {
        /// <summary>
        /// Thread to manage background operation
        /// </summary>
        private Thread _workerThread;

        /// <summary>
        /// Occurs when <see cref="M:System.ComponentModel.BackgroundWorker.RunWorkerAsync"/> is called.
        /// </summary>
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            _workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true; //We must set Cancel property to true!
                Thread.ResetAbort(); //Prevents ThreadAbortException propagation
            }
        }

        /// <summary>
        /// Abort operation immediately
        /// </summary>
        public void Abort()
        {
            if (_workerThread == null) return;
            _workerThread.Abort();
            _workerThread = null;
        }

        /// <summary>
        /// Abort operation immediately and try to cancel first
        /// </summary>
        public void AbortCancel()
        {
            if (WorkerSupportsCancellation && !CancellationPending)
            {
                CancelAsync();
            }
            Abort();
        }
    }
}
