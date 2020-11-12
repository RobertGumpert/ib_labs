using IB1.Models;
using IB1.Services;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IB1
{
    public partial class DialogUpdatePassword : Form
    {
        public AccessService accessService { get; set; }
        private String newPassword;

        public UserModel User{ get; set; }
        public String NewPassword { get { return newPassword; } }

        public DialogUpdatePassword()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
            if (User == null)
            {
                this.DialogResult = DialogResult.No;
                return;
            }

            String textOldValue = this.oldPasswordTextBox.Text;
            String textNewValue = this.newPasswordTextBox.Text;

            if (User.Password.Equals(string.Empty) || User.Password == null)
            {
                if (!textOldValue.Equals(string.Empty))
                {
                    Clear();
                    return;
                }
                if (textNewValue.Equals(string.Empty))
                {
                    Clear();
                    return;
                }      
            }
            else
            {              
                if (textOldValue.Equals(string.Empty) || textNewValue.Equals(string.Empty))
                {
                    Clear();
                    return;
                }
                var oldHash = accessService.GetPasswordHash(textOldValue);
                if (!oldHash.Equals(User.Password))
                {
                    Clear();
                    return;
                }
                if (textOldValue.Equals(textNewValue))
                {
                    Clear();
                    return;
                }
            }
            if (User.PasswordRestriction == PasswordRestriction.MustBe) {
                if (!Regex.IsMatch(textNewValue, @"^(?=.*\d)(?=.*[a-z])(?!.*\s).*$"))
                {
                    Clear();
                    return;
                }
            }
            try
            {
                accessService.UpdatePassword(User, textNewValue, textOldValue);
            }
            catch (Exception) {
                Clear();
                return;
            }
            newPassword = textNewValue;
            DialogResult = DialogResult.OK;
        }

        private void Clear() {
            oldPasswordTextBox.Text = string.Empty;
            newPasswordTextBox.Text = string.Empty;
            labelError.Visible = true;
            var dialog = new DialogContinueExit();
            dialog.LabelMessageValue = "При смене пароля возникла ошибка.";
            if (dialog.ShowDialog() == DialogResult.No)
            {
                Environment.Exit(0);
            }
        }
    }
}
