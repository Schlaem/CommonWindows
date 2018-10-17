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

        public new void Show() => this.ShowDialog("[Untitled]", "Initializing...", true);
        public void Show(string title, bool isIndeterminate) => this.ShowDialog(title, "Initializing...", isIndeterminate);
        public void Show(string title, string updateText, bool isIndeterminate = false) => this.ShowDialog(title, updateText, isIndeterminate);

        public new void ShowDialog() => this.ShowDialog("[Untitled]", "Initializing...", true);
        public void ShowDialog(string title) => this.ShowDialog(title, "Initializing...", true);
        public void ShowDialog(string title, bool isIndeterminate) => this.ShowDialog(title, "Initializing...", isIndeterminate);
        public void ShowDialog(string title, string updateText, bool isIndeterminate = false)
        {
            this.LbTitle.Content = title;
            this.PbProgress.IsIndeterminate = isIndeterminate;
            this.TbUpdate.Text = updateText;
            base.ShowDialog();
        }

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
                    if(progress.CurrentProgressMessage != null && progress.CurrentProgressMessage != string.Empty)
                    {
                        this.TbUpdate.Text = this.MessageHistory ? progress.CurrentProgressMessage + "\n" + this.TbUpdate.Text : progress.CurrentProgressMessage;
                    }
                }
            });
        }
    }
}
