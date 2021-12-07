namespace WinFormsApp1
{
    partial class LoginForm
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
            this.ServerTB = new System.Windows.Forms.TextBox();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.DataBaseTB = new System.Windows.Forms.TextBox();
            this.ConnectionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerTB
            // 
            this.ServerTB.Location = new System.Drawing.Point(88, 52);
            this.ServerTB.Name = "ServerTB";
            this.ServerTB.Size = new System.Drawing.Size(217, 20);
            this.ServerTB.TabIndex = 0;
            this.ServerTB.Text = "Server";
            this.ServerTB.Click += new System.EventHandler(this.ServerTB_Click);
            this.ServerTB.TextChanged += new System.EventHandler(this.ServerTB_TextChanged);
            this.ServerTB.Visible = false;
            // 
            // UserNameTB
            // 
            this.UserNameTB.Location = new System.Drawing.Point(88, 299);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.Size = new System.Drawing.Size(217, 20);
            this.UserNameTB.TabIndex = 1;
            this.UserNameTB.Text = "UserName";
            this.UserNameTB.Click += new System.EventHandler(this.UserNameTB_Click);
            this.UserNameTB.TextChanged += new System.EventHandler(this.UserNameTB_TextChanged);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(88, 206);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(217, 20);
            this.PasswordTB.TabIndex = 2;
            this.PasswordTB.Text = "Password";
            this.PasswordTB.Click += new System.EventHandler(this.PasswordTB_Click);
            this.PasswordTB.TextChanged += new System.EventHandler(this.PasswordTB_TextChanged);
            // 
            // DataBaseTB
            // 
            this.DataBaseTB.Location = new System.Drawing.Point(88, 123);
            this.DataBaseTB.Name = "DataBaseTB";
            this.DataBaseTB.Size = new System.Drawing.Size(217, 20);
            this.DataBaseTB.TabIndex = 3;
            this.DataBaseTB.Text = "Database";
            this.DataBaseTB.Click += new System.EventHandler(this.DataBaseTB_Click);
            this.DataBaseTB.TextChanged += new System.EventHandler(this.DataBaseTB_TextChanged);
            // 
            // ConnectionBtn
            // 
            this.ConnectionBtn.Enabled = false;
            this.ConnectionBtn.Location = new System.Drawing.Point(178, 345);
            this.ConnectionBtn.Name = "ConnectionBtn";
            this.ConnectionBtn.Size = new System.Drawing.Size(127, 23);
            this.ConnectionBtn.TabIndex = 4;
            this.ConnectionBtn.Text = "Connect";
            this.ConnectionBtn.UseVisualStyleBackColor = true;
            this.ConnectionBtn.Click += new System.EventHandler(this.ConnectionBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 450);
            this.Controls.Add(this.ConnectionBtn);
            this.Controls.Add(this.DataBaseTB);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UserNameTB);
            this.Controls.Add(this.ServerTB);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerTB;
        private System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.TextBox DataBaseTB;
        private System.Windows.Forms.Button ConnectionBtn;
    }
}