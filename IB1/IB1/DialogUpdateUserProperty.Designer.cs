namespace IB1
{
    partial class DialogUpdateUserProperty
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
            this.label2 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxRestrict = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxLockout = new System.Windows.Forms.CheckBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Имя пользователя:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(15, 38);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(16, 16);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Установить ограничения для пароля";
            // 
            // checkBoxRestrict
            // 
            this.checkBoxRestrict.AutoSize = true;
            this.checkBoxRestrict.Location = new System.Drawing.Point(18, 99);
            this.checkBoxRestrict.Name = "checkBoxRestrict";
            this.checkBoxRestrict.Size = new System.Drawing.Size(41, 17);
            this.checkBoxRestrict.TabIndex = 3;
            this.checkBoxRestrict.Text = "Да";
            this.checkBoxRestrict.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Заблокировать";
            // 
            // checkBoxLockout
            // 
            this.checkBoxLockout.AutoSize = true;
            this.checkBoxLockout.Location = new System.Drawing.Point(18, 175);
            this.checkBoxLockout.Name = "checkBoxLockout";
            this.checkBoxLockout.Size = new System.Drawing.Size(41, 17);
            this.checkBoxLockout.TabIndex = 5;
            this.checkBoxLockout.Text = "Да";
            this.checkBoxLockout.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(52, 277);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(173, 39);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Применить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(15, 230);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(51, 13);
            this.labelError.TabIndex = 7;
            this.labelError.Text = "labelError";
            this.labelError.Visible = false;
            // 
            // DialogUpdateUserProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 328);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.checkBoxLockout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxRestrict);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label2);
            this.Name = "DialogUpdateUserProperty";
            this.Text = "Обновить св-ва пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxRestrict;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxLockout;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelError;
    }
}