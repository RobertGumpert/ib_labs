using IB1.Models;
using IB1.Services;
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
    public partial class FormMain : Form
    {
        private AccountRoots roots;
        private AccessService accessService;

        public AccessService AccessService { set {
                accessService = value;
                roots = accessService.RootsAuthorizedUser;
                if (roots == AccountRoots.ADMIN)
                {
                    buttonUserList.Visible = true;
                }
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            var dialog = new DialogUpdatePassword();
            dialog.User = accessService.AuthorizedUser;
            dialog.accessService = accessService;
            if (dialog.ShowDialog() == DialogResult.No)
            {
                Clear("При смене пароля возникла ошибка.");
                return;
            }
        }

       
        private void buttonUserList_Click(object sender, EventArgs e)
        {
            var form = new FormUserList();
            form.AccessService = accessService;
            form.Show();
        }

        private void Clear(String message)
        {
            labelError.Text = message;
            labelError.Visible = true;
        }

        private void buttonReference_Click(object sender, EventArgs e)
        {
            (new DialogArcticle()).Show();
        }
    }
}
