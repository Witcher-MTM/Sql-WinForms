using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{

    public partial class Procedures : Form
    {
        public Connection MyConn { get; set; }
        public SqlConnection sqlConnection { get; set; }
        public string DBname { get; set; }
        public string TableName { get; set; }
        public Procedures()
        {
            MyConn = new Connection();
            InitializeComponent();
        }
        public Procedures(procAction proc, SqlConnection sql, string dbName, string table)
        {
            MyConn = new Connection();
            MyConn.Action = proc;
            DBname = dbName;
            sqlConnection = sql;
            TableName = table;
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"{this.QueryTB.Text}","Send Query?",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(this.QueryTB.Text, sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {

            }
            
        }

        private void Procedures_Load(object sender, EventArgs e)
        {
            switch (MyConn.Action)
            {
                case procAction.INSERT:
                    {
                        string data = "(";
                        using (SqlCommand command = new SqlCommand($@"SELECT * FROM [{TableName}]", sqlConnection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    data += $"{reader.GetName(i)},";
                                }
                                data += ")";
                            }
                        }
                        this.QueryTB.Text = $"INSERT INTO {TableName}{data} VALUES\r\n'Enter values'";
                        break;
                    }
                case procAction.DELETE:
                    {
                        this.QueryTB.Text =
                        $"DELETE value FROM {TableName}";
                        break;
                    }
                case procAction.DROP:
                    {
                        this.QueryTB.Text =
                        $"DROP {TableName}\r\n";
                        break;
                    }
                case procAction.SELECT:
                    {
                        this.QueryTB.Text =
                         $"SELECT * FROM {TableName}\r\n";
                        break;
                    }
                case procAction.CREATE:
                    {
                        this.QueryTB.Text =
                            "CREATE TABLE NAME\r\n" +
                            "(\r\n" +
                            " [ID] INT PRIMARY KEY IDENTITY,\r\n" +
                            ")\r\n";

                        break;
                    }
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
