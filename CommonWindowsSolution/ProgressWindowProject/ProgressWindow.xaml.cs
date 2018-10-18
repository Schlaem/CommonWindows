using System.Threading.Tasks;
using System.Windows;

namespace ProgressWindowProject
{
    /// <summary>
    /// Interaktionslogik für ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        /// <summary>
        /// Ruft einen Boolean ab, der angibt, ob der Verlauf der Update-Messages angezeigt werden soll oder nicht, reps. legt diesen fest.
        /// </summary>
        public bool MessageHistory { get; set; } = false;

        /// <summary>
        /// Default-Konstruktor
        /// </summary>
        public ProgressWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <remarks>
        /// Um nicht unterbrochen zu werden, ruft diese Methode die <c>ShowDialog(string, string, bool)</c>-Methode auf.
        /// </remarks>
        /// <seealso cref="ShowDialog(string, string, bool)"/>
        public new void Show() => this.ShowDialog("[Untitled]", "Initializing...", true);

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <remarks>
        /// Um nicht unterbrochen zu werden, ruft diese Methode die <c>ShowDialog(string, string, bool)</c>-Methode auf.
        /// </remarks>
        /// <seealso cref="ShowDialog(string, string, bool)"/>
        /// <param name="title">Der angezeigte Titel des Fensters.</param>
        public void Show(string title) => this.ShowDialog(title, "Initializing...", true);

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <remarks>
        /// Um nicht unterbrochen zu werden, ruft diese Methode die <c>ShowDialog(string, string, bool)</c>-Methode auf.
        /// </remarks>
        /// <seealso cref="ShowDialog(string, string, bool)"/>
        /// <param name="title">Der angezeigte Titel des Fensters.</param>
        /// <param name="isIndeterminate">Wenn <c>TRUE</c>, zeigt der Balken keinen Fortschritt an sondern schwenkt nur durch.</param>
        public void Show(string title, bool isIndeterminate) => this.ShowDialog(title, "Initializing...", isIndeterminate);

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <remarks>
        /// Um nicht unterbrochen zu werden, ruft diese Methode die <c>ShowDialog(string, string, bool)</c>-Methode auf.
        /// </remarks>
        /// <seealso cref="ShowDialog(string, string, bool)"/>
        /// <param name="title">Der angezeigte Titel des Fensters.</param>
        /// <param name="updateText">Die Statusmeldung, welche zu Beginn angezeigt werden soll.</param>
        /// <param name="isIndeterminate">Wenn <c>TRUE</c>, zeigt der Balken keinen Fortschritt an sondern schwenkt nur durch.</param>
        public void Show(string title, string updateText, bool isIndeterminate = false) => this.ShowDialog(title, updateText, isIndeterminate);

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <seealso cref="ShowDialog(string, string, bool)"/>
        public new void ShowDialog() => this.ShowDialog("[Untitled]", "Initializing...", true);

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <seealso cref="ShowDialog(string, string, bool)"/>
        /// <param name="title">Der angezeigte Titel des Fensters.</param>
        public void ShowDialog(string title) => this.ShowDialog(title, "Initializing...", true);

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <seealso cref="ShowDialog(string, string, bool)"/>
        /// <param name="title">Der angezeigte Titel des Fensters.</param>
        /// <param name="isIndeterminate">Wenn <c>TRUE</c>, zeigt der Balken keinen Fortschritt an sondern schwenkt nur durch.</param>
        public void ShowDialog(string title, bool isIndeterminate) => this.ShowDialog(title, "Initializing...", isIndeterminate);

        /// <summary>
        /// Zeigt das Window an.
        /// </summary>
        /// <param name="title">Der angezeigte Titel des Fensters.</param>
        /// <param name="updateText">Die Statusmeldung, welche zu Beginn angezeigt werden soll.</param>
        /// <param name="isIndeterminate">Wenn <c>TRUE</c>, zeigt der Balken keinen Fortschritt an sondern schwenkt nur durch.</param>
        public void ShowDialog(string title, string updateText, bool isIndeterminate = false)
        {
            this.LbTitle.Content = title;
            this.PbProgress.IsIndeterminate = isIndeterminate;
            this.TbUpdate.Text = updateText;
            base.ShowDialog();
        }

        /// <summary>
        /// Updated die Fortschrittsanzeige.
        /// </summary>
        /// <see cref="ProgressReport"/>
        /// <param name="progress">Der Fortschrittsstatus.</param>
        public void ReportProgress(ProgressReport progress)
        {
            Dispatcher.Invoke(() =>
            {
                if(progress.CurrentProgress >= progress.TotalProgress)
                {
                    this.TbUpdate.Text = "Finish";
                    Task.Delay(200).Wait();
                    this.Close();
                }
                else
                {
                    this.PbProgress.Value = progress.CurrentProgress;
                    this.PbProgress.Maximum = progress.TotalProgress;
                    if(progress.ProgressMessage != null && progress.ProgressMessage != string.Empty)
                    {
                        this.TbUpdate.Text = this.MessageHistory ? progress.ProgressMessage + "\n" + this.TbUpdate.Text : progress.ProgressMessage;
                    }
                }
            });
        }

        /// <summary>
        /// Schliesst das <c>ProgressWindow</c>.
        /// </summary>
        public void Finished()
        {
            Dispatcher.Invoke(() =>
            {
                this.Close();
            });
        }
    }
}
