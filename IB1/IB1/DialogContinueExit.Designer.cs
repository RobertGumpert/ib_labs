namespace IB1
{
    partial class DialogContinueExit
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
            this.labelAction = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(12, 62);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(112, 13);
            this.labelAction.TabIndex = 0;
            this.labelAction.Text = "Хотите продолжить?";
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(12, 92);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 1;
            this.buttonContinue.Text = "Да";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(239, 92);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Нет";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 21);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(44, 13);
            this.labelMessage.TabIndex = 3;
            this.labelMessage.Text = "Messge";
            // 
            // DialogContinueExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 127);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.labelAction);
            this.Name = "DialogContinueExit";
            this.Text = "Продолжить или завершить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelMessage;
    }
}