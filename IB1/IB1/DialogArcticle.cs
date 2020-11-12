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
    public partial class DialogArcticle : Form
    {
        public DialogArcticle()
        {
            InitializeComponent();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            (new DialogAbout()).Show();
        }
    }
}
