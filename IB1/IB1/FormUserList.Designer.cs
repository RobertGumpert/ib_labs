namespace IB1
{
    partial class FormUserList
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
            this.dataGridViewList = new System.Windows.Forms.DataGridView();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewList
            // 
            this.dataGridViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewList.Name = "dataGridViewList";
            this.dataGridViewList.Size = new System.Drawing.Size(415, 256);
            this.dataGridViewList.TabIndex = 0;
            this.dataGridViewList.SelectionChanged += new System.EventHandler(this.dataGridViewList_SelectionChanged);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(329, 285);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(98, 52);
            this.buttonAddUser.TabIndex = 1;
            this.buttonAddUser.Text = "Добавить";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(12, 305);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(51, 13);
            this.labelError.TabIndex = 2;
            this.labelError.Text = "labelError";
            this.labelError.Visible = false;
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(225, 285);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(98, 52);
            this.buttonChange.TabIndex = 3;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // FormUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 349);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.dataGridViewList);
            this.Name = "FormUserList";
            this.Text = "Список пользователей";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewList;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonChange;
    }
}