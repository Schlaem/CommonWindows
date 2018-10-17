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
        public string CurrentProgressMessage { get; set; }

        /// <summary>
        /// Default-Konstruktor
        /// </summary>
        public ProgressReport()
        {
            // empty...
        }
    }
}
