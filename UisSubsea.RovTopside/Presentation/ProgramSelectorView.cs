using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UisSubsea.RovTopside.Presentation
{
    public partial class ProgramSelectorView : Form
    {
        public string Program { get; private set; }

        public ProgramSelectorView()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program = cmbProgram.Text;
        }
    }
}
