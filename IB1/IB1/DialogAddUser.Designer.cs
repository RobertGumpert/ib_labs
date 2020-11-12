namespace IB1
{
    partial class DialogAddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelRestrict = new System.Windows.Forms.Label();
            this.checkBoxAdd = new System.Windows.Forms.CheckBox();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(12, 40);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(315, 20);
            this.textBoxUserName.TabIndex = 0;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(12, 13);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(72, 13);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "Введите имя";
            // 
            // labelRestrict
            // 
            this.labelRestrict.AutoSize = true;
            this.labelRestrict.Location = new System.Drawing.Point(12, 77);
            this.labelRestrict.Name = "labelRestrict";
            this.labelRestrict.Size = new System.Drawing.Size(127, 13);
            this.labelRestrict.TabIndex = 2;
            this.labelRestrict.Text = "Ограничения на пароль";
            // 
            // checkBoxAdd
            // 
            this.checkBoxAdd.AutoSize = true;
            this.checkBoxAdd.Location = new System.Drawing.Point(12, 107);
            this.checkBoxAdd.Name = "checkBoxAdd";
            this.checkBoxAdd.Size = new System.Drawing.Size(76, 17);
            this.checkBoxAdd.TabIndex = 3;
            this.checkBoxAdd.Text = "Добавить";
            this.checkBoxAdd.UseVisualStyleBackColor = true;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(220, 176);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(107, 47);
            this.buttonAddUser.TabIndex = 4;
            this.buttonAddUser.Text = "Добавить";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(12, 193);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(51, 13);
            this.labelError.TabIndex = 5;
            this.labelError.Text = "labelError";
            this.labelError.Visible = false;
            // 
            // DialogAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 235);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.checkBoxAdd);
            this.Controls.Add(this.labelRestrict);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.textBoxUserName);
            this.Name = "DialogAddUser";
            this.Text = "Добавить пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelRestrict;
        private System.Windows.Forms.CheckBox checkBoxAdd;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label labelError;
    }
}