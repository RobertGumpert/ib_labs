using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IB1
{
    public partial class DialogContinueExit : Form
    {
        public String LabelMessageValue { set
            {
                this.labelMessage.Text = value;
                this.labelMessage.Visible = true;
            }
        }

        public DialogContinueExit()
        {
            InitializeComponent();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
