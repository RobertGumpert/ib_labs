namespace IB1
{
    partial class FormMain
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
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.buttonReference = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonUserList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(12, 12);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(87, 48);
            this.buttonChangePassword.TabIndex = 0;
            this.buttonChangePassword.Text = "Сменить пароль";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // buttonReference
            // 
            this.buttonReference.Location = new System.Drawing.Point(194, 12);
            this.buttonReference.Name = "buttonReference";
            this.buttonReference.Size = new System.Drawing.Size(87, 48);
            this.buttonReference.TabIndex = 1;
            this.buttonReference.Text = "Справка";
            this.buttonReference.UseVisualStyleBackColor = true;
            this.buttonReference.Click += new System.EventHandler(this.buttonReference_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(12, 176);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(51, 13);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "labelError";
            this.labelError.Visible = false;
            // 
            // buttonUserList
            // 
            this.buttonUserList.Location = new System.Drawing.Point(12, 94);
            this.buttonUserList.Name = "buttonUserList";
            this.buttonUserList.Size = new System.Drawing.Size(119, 50);
            this.buttonUserList.TabIndex = 4;
            this.buttonUserList.Text = "Список пользователей";
            this.buttonUserList.UseVisualStyleBackColor = true;
            this.buttonUserList.Visible = false;
            this.buttonUserList.Click += new System.EventHandler(this.buttonUserList_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 198);
            this.Controls.Add(this.buttonUserList);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonReference);
            this.Controls.Add(this.buttonChangePassword);
            this.Name = "FormMain";
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Button buttonReference;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonUserList;
    }
}