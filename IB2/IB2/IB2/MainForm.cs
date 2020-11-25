using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IB2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }
            String result = RunPython(filePath);
            this.textBoxResult.Text = result;
        }

        private String RunPython(String file)
        {
            String result = "";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:/Labs/ib/ib_labs/IB2/py/venv/Scripts/python.exe";
            start.Arguments = string.Format("{0} {1}", "C:/Labs/ib/ib_labs/IB2/py/main.py", "report -f " + file);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        private void buttonReference_Click(object sender, EventArgs e)
        {
            var dialog = new DialogReference();
            dialog.Show();
        }
    }
}
