using System.ServiceProcess;
using System.Threading;

namespace WebsiteMonitoring
{
    public partial class Service1: ServiceBase
    {
        private System.ComponentModel.IContainer components = null;
   
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "Service1";
        }

        LoggerFileSystemWatcher loggerFileSystemWatcher;
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
           
        }

        protected override void OnStart(string[] args)
        {
            loggerFileSystemWatcher = new LoggerFileSystemWatcher();
            Thread loggerThread = new Thread(new ThreadStart(loggerFileSystemWatcher.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            loggerFileSystemWatcher.Stop();
            Thread.Sleep(1000);
        }
    }
}

