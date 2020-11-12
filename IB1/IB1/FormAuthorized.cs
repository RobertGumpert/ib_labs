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
    public partial class FormAuthorized : Form
    {
        private AccessService accessService;

        public FormAuthorized()
        {
            InitializeComponent();
            accessService = new AccessService();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            labelErrorMessage.Visible = false;
            UserModel user = null;
            try {
                user = accessService.FindUser(textName.Text);
                if (user.Lockout == AccountLockout.Lockout) {
                    var dialog = new DialogContinueExit();
                    dialog.LabelMessageValue = "Ваш аккаунт заблокирован";
                    if (dialog.ShowDialog() == DialogResult.No)
                    {
                        Environment.Exit(0);
                    }
                    return;
                }
                if (user.Password.Equals(string.Empty) || user.Password == null)
                {
                    var dialog = new DialogUpdatePassword();
                    dialog.User = user;
                    dialog.accessService = accessService;
                    if (dialog.ShowDialog() == DialogResult.No)
                    {
                        Clear("При смене пароля возникла ошибка.");
                        return;
                    }
                    Clear(string.Empty);
                    return;
                }
            }
            catch (Exception)
            {
                var dialog = new DialogContinueExit();
                dialog.LabelMessageValue = "Вы ввели неправильное имя пользователя";
                if (dialog.ShowDialog() == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                Clear(string.Empty);
                return;
            }
            if (user != null) { 
            {
                    try
                    {
                        if (!accessService.Login(textName.Text, textPassword.Text))
                        {
                            Clear("Вы ввели неправильный пароль");
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        var dialog = new DialogContinueExit();
                        dialog.LabelMessageValue = "Вы истратили 3 попытки входа в приложение";
                        if (dialog.ShowDialog() == DialogResult.No)
                        {
                            Environment.Exit(0);
                        }
                        return;
                    }
                    var main = new FormMain();
                    main.AccessService = accessService;
                    main.Show();
                }
            }
        }

        private void Clear(String message) {
            labelErrorMessage.Text = message;
            labelErrorMessage.Visible = true;
            textName.Text = string.Empty;
            textPassword.Text = string.Empty;
        }
    }
}
