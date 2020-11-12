namespace IB1
{
    partial class FormAuthorized
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelErrorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(12, 34);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(399, 20);
            this.textName.TabIndex = 0;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(12, 94);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(399, 20);
            this.textPassword.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 69);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(45, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Пароль";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Имя";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(302, 152);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(109, 45);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Войти";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelErrorMessage
            // 
            this.labelErrorMessage.AutoSize = true;
            this.labelErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.labelErrorMessage.Location = new System.Drawing.Point(12, 168);
            this.labelErrorMessage.Name = "labelErrorMessage";
            this.labelErrorMessage.Size = new System.Drawing.Size(100, 13);
            this.labelErrorMessage.TabIndex = 5;
            this.labelErrorMessage.Text = "Неверные данные";
            this.labelErrorMessage.Visible = false;
            // 
            // FormAuthorized
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 209);
            this.Controls.Add(this.labelErrorMessage);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textName);
            this.Name = "FormAuthorized";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelErrorMessage;
    }
}

