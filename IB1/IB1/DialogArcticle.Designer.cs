namespace IB1
{
    partial class DialogArcticle
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
            this.buttonAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(12, 63);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(185, 23);
            this.buttonAbout.TabIndex = 0;
            this.buttonAbout.Text = "О программе";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // DialogArcticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 98);
            this.Controls.Add(this.buttonAbout);
            this.Name = "DialogArcticle";
            this.Text = "Справка";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAbout;
    }
}