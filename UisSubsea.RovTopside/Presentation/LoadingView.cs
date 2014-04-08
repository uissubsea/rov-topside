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
        public LoadingView()
        {
            InitializeComponent();   
        }

        public void WaitForRovToPowerUp()
        {
            while (Camera.CamerasConnected().Count < 3)
            {
                System.Threading.Thread.Sleep(1000);
            }     
        }

        private void LoadingView_Shown(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => WaitForRovToPowerUp());
            thread.Start();
            thread.Join();
            DialogResult = DialogResult.OK;
        }
    }
}
