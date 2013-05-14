using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Payroll_System
{
    public partial class TransactionsForm : Form
    {
        string user;
       
        public TransactionsForm(string a)
        {
            InitializeComponent();
            user = a;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        string name = "";
        public void dbFill(string statement)
        {

            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";

            dbConn = new MySqlConnection(sConnection);


            MySqlCommand dbCmd = new MySqlCommand();
            dbConn.Open();

            string sql = statement;

            dbCmd.CommandText = sql;
            dbCmd.CommandTimeout = 45;
            dbCmd.Connection = dbConn;
            dbCmd.ExecuteNonQuery();
            dbReader = dbCmd.ExecuteReader();
        }
        public void dbQuery(string statement)
        {

            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";


            dbConn = new MySqlConnection(sConnection);
            MySqlCommand dbCmd = new MySqlCommand();
            dbConn.Open();
            string sql = statement;
            dbCmd.CommandText = sql;
            dbCmd.Connection = dbConn;
            dbCmd.ExecuteNonQuery();
            dbConn.Close();
        }
      
        private void fillit()
        {
            counter = 0;
            {
                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
           //     query = "SELECT trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, logs.names, transaction.dat_trans FROM ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna) ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                query = " SELECT        trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, transaction.dat_trans, logs_1.addr , logs_1.eadd ,  logs.names, logs_1.names AS Expr1 FROM    ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna), logs logs_1 WHERE  logs.names LIKE '%" + textBox1.Text + "%' and logs_1.userna='" + user + "' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                 
                dbFill(query);
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["trans_id"].ToString(), dbReader["names"].ToString(), dbReader["dat_trans"].ToString(), dbReader["item_name"].ToString());
                    counter++;
                }
                dbReader.Close();
                dbConn.Close();



            }
            label3.Text = counter.ToString() + " item(s) were found";
            textBox1.Focus();
        }
        private void TransactionsForm_Load(object sender, EventArgs e)
        {
            fillit();
            textBox1.Focus();
            timer1.Enabled = true;
        }
        int counter = 0;
        private void clicknow()
        {
            counter = 0;
            if (radioButton1.Checked == true)
            {

                {
                    dataGridView1.Rows.Clear();
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                 //   query = "SELECT trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, logs.names, transaction.dat_trans FROM ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna)WHERE  logs.names LIKE '%" + textBox1.Text + "%' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                    query = " SELECT        trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, transaction.dat_trans, logs_1.addr , logs_1.eadd ,  logs.names, logs_1.names AS Expr1 FROM    ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna), logs logs_1 WHERE  logs.names LIKE '%" + textBox1.Text + "%' and logs_1.userna='" + user + "' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                   
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        dataGridView1.Rows.Add(dbReader["trans_id"].ToString(), dbReader["names"].ToString(), dbReader["dat_trans"].ToString(), dbReader["item_name"].ToString());
                        counter++;
                    }
                    dbReader.Close();
                    dbConn.Close();



                }
            }
            else if (radioButton3.Checked == true)
            {

                {
                    dataGridView1.Rows.Clear();
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
            //        query = "SELECT trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, logs.names, transaction.dat_trans FROM ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna)WHERE  trans_items.item_name LIKE '%" + textBox1.Text + "%' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                    query = " SELECT        trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, transaction.dat_trans, logs_1.addr , logs_1.eadd ,  logs.names, logs_1.names AS Expr1 FROM    ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna), logs logs_1 WHERE   trans_items.item_name LIKE '%" + textBox1.Text + "%' and logs_1.userna='" + user + "' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                   
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        dataGridView1.Rows.Add(dbReader["trans_id"].ToString(), dbReader["names"].ToString(), dbReader["dat_trans"].ToString(), dbReader["item_name"].ToString());
                        counter++;
                    }
                    dbReader.Close();
                    dbConn.Close();



                }
            }
            else if (radioButton4.Checked == true)
            {
                string fille = textBox1.Text.Replace("/", "");

                {
                    dataGridView1.Rows.Clear();
                    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    line = sr.ReadLine();
                    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    dbP = sr3.ReadLine();
                    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    dbU = sr4.ReadLine();
                    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
            //        query = "SELECT trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, logs.names, transaction.dat_trans FROM ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna)WHERE trans_items.trans_id LIKE '%" + textBox1.Text + "%' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                    query = " SELECT        trans_items.trans_item_id, trans_items.item_id, trans_items.item_name, trans_items.trans_id, trans_items.quan, transaction.dat_trans, logs_1.addr , logs_1.eadd ,  logs.names, logs_1.names AS Expr1 FROM    ((trans_items INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id) INNER JOIN logs ON transaction.user_code = logs.userna), logs logs_1 WHERE  trans_items.trans_id LIKE '%" + fille+ "%' and logs_1.userna='" + user + "' ORDER BY transaction.dat_trans DESC,transaction.trans_id ASC ";
                 
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        dataGridView1.Rows.Add(dbReader["trans_id"].ToString(), dbReader["names"].ToString(), dbReader["dat_trans"].ToString(), dbReader["item_name"].ToString());
                        counter++;

                    }
                    dbReader.Close();
                    dbConn.Close();



                }
            }
            aa = textBox1.Text;
            label3.Text = counter.ToString() + " item(s) were found";
            textBox1.Focus();
        }
        private void glassButton1_Click(object sender, EventArgs e)
        {
            clicknow();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
         string query;
        string aa;
        private void glassButton4_Click(object sender, EventArgs e)
        {
            fillit();
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("trans", user,query);
            fm.Show();
            fm.Text = "Reports [Transactions]";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == (Keys.Enter)))
            {

                clicknow();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                dataGridView1.Rows.Clear();
                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                  dbFill(query);
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["trans_id"].ToString(), dbReader["names"].ToString(), dbReader["dat_trans"].ToString(), dbReader["item_name"].ToString());
                    counter++;

                }
                dbReader.Close();
                dbConn.Close();



            }
        }

        private void glassButton5_Click(object sender, EventArgs e)
        {
            ReceiptForm rc = new ReceiptForm(dataGridView1.CurrentRow.Cells[0].Value.ToString(), user, "rec");
            rc.ShowDialog();
        }
    }
}