namespace ProgressWindowProject
{
    /// <summary>
    /// Erstellt einen Report über den aktuellen Fortschritt eines Prozesses.
    /// </summary>
    public class ProgressReport
    {
        /// <summary>
        /// Ruft den aktuellen Fortschritt ab resp. legt diesen fest.
        /// </summary>
        public int CurrentProgress { get; set; }

        /// <summary>
        /// Ruft den insgesamt zu machenden Fortschritt ab resp. legt diesen fest.
        /// </summary>
        public int TotalProgress { get; set; }

        /// <summary>
        /// Ruft die aktuelle Prozess-Nachricht ab resp. legt diese fest.
        /// </summary>
        public string ProgressMessage { get; set; }

        /// <summary>
        /// Default-Konstruktor
        /// </summary>
        public ProgressReport()
        {
            // empty...
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="currentProgress">Der aktuelle Fortschritt.</param>
        /// <param name="totalProgress">Der total zu machende Fortschritt.</param>
        public ProgressReport(int currentProgress, int totalProgress) : this(currentProgress, totalProgress, string.Empty) { }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="currentProgress">Der aktuelle Fortschritt.</param>
        /// <param name="totalProgress">Der total zu machende Fortschritt.</param>
        /// <param name="progressMessage">Der Fortschrittsstatus.</param>
        public ProgressReport(int currentProgress, int totalProgress, string progressMessage)
        {
            this.CurrentProgress = currentProgress;
            this.TotalProgress = totalProgress;
            this.ProgressMessage = progressMessage;
        }
    }
}
