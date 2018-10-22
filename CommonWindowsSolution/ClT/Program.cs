using ProgressWindowProject;
using System;
using System.Threading.Tasks;

namespace ClT
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ProgressWindow pgWindow = new ProgressWindow();
            var progressIndicator = new Progress<ProgressReport>(pgWindow.ReportProgress);

            Task.Factory.StartNew(() => MyMethodTask(1000, progressIndicator));

            pgWindow.Show("Test", "Initializing...", false);

            Console.Write("Done...");
            //Console.ReadKey();
        }

        public static async Task MyMethodTask(int sleepTime, IProgress<ProgressReport> progress)
        {
            int totalAmount = 10000;

            for (int i = 0; i <= totalAmount;)
            {
                await Task.Delay(sleepTime / 10);
                i += sleepTime / 10;
                if(i % sleepTime == 0)
                {
                    progress.Report(new ProgressReport(i, totalAmount, string.Format("Step {0}/{1}", i / sleepTime, totalAmount / sleepTime)));
                }
                else
                {
                    progress.Report(new ProgressReport(i, totalAmount));
                }
            }
        }
    }
}
