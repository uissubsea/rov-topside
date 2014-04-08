using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using UisSubsea.RovTopside.Data;

namespace UisSubsea.RovTopside.Presentation
{
    public partial class LoadingView : Form
    {

        BackgroundWorker backgroundWorker;

        public LoadingView()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        public void WaitForRovToPowerUp()
        {
            while (Camera.CamerasConnected().Count < 3)
            {
                System.Threading.Thread.Sleep(1000);
            }     
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WaitForRovToPowerUp(); 
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
