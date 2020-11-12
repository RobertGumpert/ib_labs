namespace IB1
{
    partial class DialogUpdatePassword
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
            this.labelAction1 = new System.Windows.Forms.Label();
            this.labelAction2 = new System.Windows.Forms.Label();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.oldPasswordTextBox = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAction1
            // 
            this.labelAction1.AutoSize = true;
            this.labelAction1.Location = new System.Drawing.Point(27, 18);
            this.labelAction1.Name = "labelAction1";
            this.labelAction1.Size = new System.Drawing.Size(123, 13);
            this.labelAction1.TabIndex = 0;
            this.labelAction1.Text = "Введите новый пароль";
            // 
            // labelAction2
            // 
            this.labelAction2.AutoSize = true;
            this.labelAction2.Location = new System.Drawing.Point(27, 92);
            this.labelAction2.Name = "labelAction2";
            this.labelAction2.Size = new System.Drawing.Size(128, 13);
            this.labelAction2.TabIndex = 1;
            this.labelAction2.Text = "Введите старый пароль";
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(30, 50);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.PasswordChar = '*';
            this.newPasswordTextBox.Size = new System.Drawing.Size(279, 20);
            this.newPasswordTextBox.TabIndex = 2;
            // 
            // oldPasswordTextBox
            // 
            this.oldPasswordTextBox.Location = new System.Drawing.Point(30, 126);
            this.oldPasswordTextBox.Name = "oldPasswordTextBox";
            this.oldPasswordTextBox.PasswordChar = '*';
            this.oldPasswordTextBox.Size = new System.Drawing.Size(279, 20);
            this.oldPasswordTextBox.TabIndex = 3;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(204, 176);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(105, 44);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.SystemColors.Control;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(27, 192);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(158, 13);
            this.labelError.TabIndex = 5;
            this.labelError.Text = "Ошибка. Попробуйте еще раз";
            this.labelError.Visible = false;
            // 
            // DialogUpdatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 246);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.oldPasswordTextBox);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.labelAction2);
            this.Controls.Add(this.labelAction1);
            this.Name = "DialogUpdatePassword";
            this.Text = "Обновить текущий пароль";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAction1;
        private System.Windows.Forms.Label labelAction2;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox oldPasswordTextBox;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelError;
    }
}