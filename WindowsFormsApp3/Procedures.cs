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
            if (MessageBox.Show($"{this.QueryTb.Text}", "Send Query?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(this.QueryTb.Text, sqlConnection))
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
                        this.QueryTb.Text = $"INSERT INTO {TableName}{data} VALUES\r\n'Enter values'";
                        break;
                    }
                case procAction.DELETE:
                    {
                        this.QueryTb.Text =
                        $"DELETE value FROM {TableName}";
                        break;
                    }
                case procAction.DROP:
                    {
                        this.QueryTb.Text =
                        $"DROP {TableName}\r\n";
                        break;
                    }
                case procAction.SELECT:
                    {
                        this.QueryTb.Text =
                         $"SELECT * FROM {TableName}\r\n";
                        break;
                    }
                case procAction.CREATE:
                    {
                        this.QueryTb.Text =
                            "CREATE TABLE --NAME--\r\n" +
                            "(\r\n" +
                            " [ID] INT PRIMARY KEY IDENTITY,\r\n" +
                            ")\r\n";

                        break;
                    }
                case procAction.CHANGE:
                    {
                        using (SqlCommand command = new SqlCommand($@"SELECT * FROM {TableName};", sqlConnection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    object name = reader.GetValue(0);
                                    this.LB_TableInfo.Items.Add(name.ToString());
                                }
                            }
                            if (this.LB_TableInfo.Items.Count <= 0)
                            {
                                this.LB_TableInfo.Items.Add("This table is empty");
                                this.QueryBtn.Enabled = false;
                            }
                           
                        }
                        this.treeView1.Nodes.Add(TableName);

                        foreach (var item in Select(DBname, TableName))
                        {
                            this.treeView1.Nodes[0].Nodes.Add(item);

                        }
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
        private bool isDatabaseExists(string name)
        {
            using (SqlCommand command = new SqlCommand($@"if Exists(select 1 from master.dbo.sysdatabases where name='{name}') 
                       select 1 else select 0", sqlConnection))
            {
                int exists = Convert.ToInt32(command.ExecuteScalar());

                if (exists > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private List<string> Select(string dbname, string tableName)
        {
            List<string> list = new List<string>();
            string commandstring = string.Empty;
            try
            {
                if (tableName != string.Empty)
                    commandstring = Command(tableName);
                else
                    commandstring = Command(dbname);

                if (commandstring != string.Empty)
                {
                    using (SqlCommand command = new SqlCommand(commandstring, sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                object names = reader.GetValue(0);
                                list.Add(names.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return list;
        }
        private string Command(string name)
        {
            if (isDatabaseExists(name))
            {
                return $@"SELECT name FROM [{name}].sys.tables;";
            }
            else
            {
                return $@"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{name}';";
            }
        }

        private void LB_TableInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> NodesL = new List<string>();
            this.QueryTb.Text = "GO\r\n" +
                                $"CREATE PROC [ChangeRowIn{TableName}]\r\n";
            using (SqlCommand command = new SqlCommand($@"SELECT * FROM {TableName};", sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        this.QueryTb.Text += $"@{reader.GetName(i)}\r\n";
                    }
                   
                    this.QueryTb.Text += "AS";
                }
            }

        }
    }
}
