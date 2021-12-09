using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{

    public partial class Procedures : Form
    {
        public Connection MyConn { get; set; }
        public Procedures()
        {
            MyConn = new Connection();
            InitializeComponent();
        }
        public Procedures(procAction proc)
        {
            MyConn = new Connection();
            MyConn.Action = proc;
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Procedures_Load(object sender, EventArgs e)
        {
            switch (MyConn.Action)
            {
                case procAction.INSERT:
                    {

                        break;
                    }
                case procAction.DELETE:
                    {

                        break;
                    }
                case procAction.DROP:
                    {

                        break;
                    }
                case procAction.SELECT:
                    {

                        break;
                    }
                case procAction.CREATE:
                    {
                        this.QueryTB.Text =
                            "CREATE TABLE NAME\n" +
                            "(\n" +
                            " [ID] INT PRIMARY KEY IDENTITY,\n" +
                            ")\n";
                           
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
