namespace WinFormsApp1
{
    partial class Procedures
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
            this.QueryBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.LB_TableInfo = new System.Windows.Forms.ListBox();
            this.QueryTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // QueryBtn
            // 
            this.QueryBtn.Location = new System.Drawing.Point(713, 12);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(75, 23);
            this.QueryBtn.TabIndex = 1;
            this.QueryBtn.Text = "SendQuery";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 41);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(183, 136);
            this.treeView1.TabIndex = 3;
            // 
            // LB_TableInfo
            // 
            this.LB_TableInfo.FormattingEnabled = true;
            this.LB_TableInfo.Location = new System.Drawing.Point(13, 184);
            this.LB_TableInfo.Name = "LB_TableInfo";
            this.LB_TableInfo.Size = new System.Drawing.Size(479, 264);
            this.LB_TableInfo.TabIndex = 4;
            this.LB_TableInfo.SelectedIndexChanged += new System.EventHandler(this.LB_TableInfo_SelectedIndexChanged);
            // 
            // QueryTb
            // 
            this.QueryTb.Location = new System.Drawing.Point(515, 56);
            this.QueryTb.Multiline = true;
            this.QueryTb.Name = "QueryTb";
            this.QueryTb.Size = new System.Drawing.Size(273, 370);
            this.QueryTb.TabIndex = 5;
            // 
            // Procedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.QueryTb);
            this.Controls.Add(this.LB_TableInfo);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.QueryBtn);
            this.Name = "Procedures";
            this.Text = "Procedures";
            this.Load += new System.EventHandler(this.Procedures_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox LB_TableInfo;
        private System.Windows.Forms.TextBox QueryTb;
    }
}