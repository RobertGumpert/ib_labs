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
    public partial class DialogAddUser : Form
    {

        private AccessService accessService;

        public AccessService AccessService
        {
            set
            {
                accessService = value;
            }
        }

        public DialogAddUser()
        {
            InitializeComponent();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            String userName = textBoxUserName.Text;
            if (userName.Equals(string.Empty))
            {
                Clear("Имя пользователя не должно быть пустым");
                return;
            }
            if (accessService.UserIsExist(userName))
            {
                Clear("Такой пользователь существует");
                return;
            }
            UserModel user = new UserModel();
            user.UserName = userName;
            if (checkBoxAdd.Checked)
            {
                user.PasswordRestriction = PasswordRestriction.MustBe;
            }
            else
            {
                user.PasswordRestriction = PasswordRestriction.ShouldNot;
            }
            try
            {
                accessService.Register(user);
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.No;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Clear(String message)
        {
            labelError.Text = message;
            labelError.Visible = true;
            textBoxUserName.Text = string.Empty;
        }
    }
}
