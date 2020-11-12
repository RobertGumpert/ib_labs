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
    public partial class DialogUpdateUserProperty : Form
    {
        private UserModel user;
        private AccessService accessService;

        public AccessService AccessService
        {
            set
            {
                accessService = value;
            }
        }

        public UserModel SeletedUser { set
            {
                user = value;
                checkBoxRestrict.Checked = (user.PasswordRestriction == PasswordRestriction.MustBe ? true : false);
                checkBoxLockout.Checked = (user.Lockout == AccountLockout.Lockout ? true : false);
                labelName.Text = user.UserName;
            }
        }

        public DialogUpdateUserProperty()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                accessService.UpdateAccountAccessRights(
                    userName: user.UserName,
                    accessRights: (checkBoxLockout.Checked ? AccountLockout.Lockout : AccountLockout.OK),
                    passwordRestriction: (checkBoxRestrict.Checked ? PasswordRestriction.MustBe : PasswordRestriction.ShouldNot)
                );
            }
            catch (Exception)
            {
                DialogResult = DialogResult.No;
            }
            DialogResult = DialogResult.OK;
        }

        private void Clear(String message)
        {
            labelError.Text = message;
            labelError.Visible = true;
            checkBoxRestrict.Checked = (user.PasswordRestriction == PasswordRestriction.MustBe ? true : false);
            checkBoxLockout.Checked = (user.Lockout == AccountLockout.Lockout ? true : false);
        }
    }
}
