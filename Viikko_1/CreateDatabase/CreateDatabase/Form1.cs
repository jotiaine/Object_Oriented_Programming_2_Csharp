using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CreateDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();

        }

        static SQLiteConnection CreateConnection() 
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=customer.db; Version=3; New=True; Compress=True");
            sqlite_conn.Open();

            MessageBox.Show("Database created succesfully");

            return sqlite_conn;
        }


        private void frmDatabase_Load (object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;

            sqlite_conn = new SQLiteConnection("Data Source=customer.db; Version=3; New=False; Compress=True");
            sqlite_conn.Open();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = "SELECT * FROM customer ORDER BY lastname";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sqlite_datareader);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                cmbCustomers.Items.Add(row["customerID"] + " " + row["lastname"] + row["firstname"] + row["email"]);
            }

            sqlite_conn.Close();
        }

        
    }
}
