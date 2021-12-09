using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        private string dbName = string.Empty;
        private string tableName = string.Empty;
        SqlConnection sqlConnection = new SqlConnection();
        Connection connection = new Connection();
        List<Connection> connections = new List<Connection>();
        
        public LoginForm()
        {
            InitializeComponent();
            this.ServerTB.Visible = true;
            connections = connection.ReadJson();
            foreach (var item in connections)
            {
                this.comboBox1.Items.Add(item.Name);
            }
        }
        private void Connection(string connectionstr)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection = new SqlConnection(connectionstr);
            sqlConnection.Open();
        }

        private void ServerTB_Click(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if(text.Text== "Server")
            {
                this.ServerTB.Text = string.Empty;
                MessageBox.Show("Enter server name");
            }
            else
            {
                MessageBox.Show("Enter server name");
            }
           
        }

        private void DataBaseTB_Click(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if(text.Text=="Database")
            {
                this.DataBaseTB.Text = string.Empty;
                MessageBox.Show("Enter database name");
            }
            else
            {
                MessageBox.Show("Enter database name");
            }
          
        }

        private void PasswordTB_Click(object sender, EventArgs e)
        {
            this.PasswordTB.PasswordChar = '*';
            TextBox text = sender as TextBox;
            if(text.Text=="Password")
            {
                this.PasswordTB.Text = string.Empty;
                MessageBox.Show("Enter password");
            }
            else
            {
                MessageBox.Show("Enter password");
            }
           
        }

        private void UserNameTB_Click(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if(text.Text=="UserName")
            {
                this.UserNameTB.Text = string.Empty;
                MessageBox.Show("Enter your UID name");
            }
            else
            {
                MessageBox.Show("Enter your UID name");
            }
           
        }

        private void ConnectionBtn_Click(object sender, EventArgs e)
        {
            Connection jsonCon = new Connection();
            try
            {

                Connection($@"Data Source={this.ServerTB.Text};Initial Catalog={this.DataBaseTB.Text};UID={this.UserNameTB.Text};Password={this.PasswordTB.Text}");
                jsonCon.Server = this.ServerTB.Text;
                jsonCon.DataBase = this.DataBaseTB.Text;
                jsonCon.Name = this.UserNameTB.Text;
                jsonCon.SaveJson(jsonCon);
                Form1 form = new Form1(sqlConnection);
                this.Hide();
                form.ShowDialog();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connection");
            }
        }

        private void UserNameTB_TextChanged(object sender, EventArgs e)
        {
            if (ServerTB.Text != string.Empty && DataBaseTB.Text != string.Empty && PasswordTB.Text != string.Empty && UserNameTB.Text != string.Empty)
            {
                this.ConnectionBtn.Enabled = true;
            }
            else
            {
                this.ConnectionBtn.Enabled = false;
            }
        }

        private void PasswordTB_TextChanged(object sender, EventArgs e)
        {
            if (ServerTB.Text != string.Empty && DataBaseTB.Text != string.Empty && PasswordTB.Text != string.Empty && UserNameTB.Text != string.Empty)
            {
                this.ConnectionBtn.Enabled = true;
            }
            else
            {
                this.ConnectionBtn.Enabled = false;
            }
        }

        private void DataBaseTB_TextChanged(object sender, EventArgs e)
        {
            if (ServerTB.Text != string.Empty && DataBaseTB.Text != string.Empty && PasswordTB.Text != string.Empty && UserNameTB.Text != string.Empty)
            {
                this.ConnectionBtn.Enabled = true;
            }
            else
            {
                this.ConnectionBtn.Enabled = false;
            }
        }

        private void ServerTB_TextChanged(object sender, EventArgs e)
        {
            if (ServerTB.Text != string.Empty && DataBaseTB.Text != string.Empty && PasswordTB.Text != string.Empty && UserNameTB.Text != string.Empty)
            {
                this.ConnectionBtn.Enabled = true;
            }
            else
            {
                this.ConnectionBtn.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in connections)
            {
                if (this.comboBox1.SelectedItem.ToString() == item.Name)
                {
                    this.DataBaseTB.Text = item.DataBase;
                    this.ServerTB.Text = item.Server;
                    this.UserNameTB.Text = item.Name;
                }
            }
          
        }
    }
}
