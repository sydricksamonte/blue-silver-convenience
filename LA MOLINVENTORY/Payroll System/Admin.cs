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
    public partial class Admin : Form
    {
        string user;
        public Admin(string a)
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
        int crit = 0;
        private void Admin_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;//eto
            timer2.Enabled = true;//at eto pti date ng pc april 13 2012
            {
                string query;


                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                query = "Select * from logs WHERE userna = '" + user + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    name = dbReader["names"].ToString();
                   


                }
                dbReader.Close();
                dbConn.Close();
            }
            {
                string query;


                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                query = "Select * from itemlist WHERE quan < origprice ORDER BY categ ASC,srp ASC";
                dbFill(query);
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["categ"].ToString(), dbReader["item_name"].ToString(), dbReader["supp"].ToString(), dbReader["origprice"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["item_no"].ToString());
                    crit++;
                    label9.Text = "You need to refill " + crit + " items!";

                    //{
                    //    string query2;


                    //    StreamReader sr2 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    //    line = sr2.ReadLine();
                    //    StreamReader sr32 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    //    dbP = sr32.ReadLine();
                    //    StreamReader sr42 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    //    dbU = sr42.ReadLine();
                    //    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    //    MySqlConnection sqlConnection2 = new MySqlConnection(sConnection2);
                    //    query2 = "Select * from itemlist WHERE quan < '" + 20 + "' ORDER BY quan ASC";
                    //    dbFill(query2);
                    //    while (dbReader2.Read())
                    //    {
                    //        dataGridView1.Rows.Add(dbReader["categ"].ToString(), dbReader["item_name"].ToString(), dbReader["srp"].ToString(), dbReader["supp"].ToString(), dbReader["quan"].ToString(), dbReader["item_no"].ToString());
                    //        crit++;
                    //        label9.Text = "You need to refill " + crit + " items!";



                    //    }
                    //    dbReader2.Close();
                    //    dbConn2.Close();
                    //}
                   


                }
                dbReader.Close();
                dbConn.Close();
            }
        }
        //int ticking = 2;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //ticking++;
            label1.Text = System.DateTime.Now.ToLongDateString();
            label2.Text = System.DateTime.Now.ToLongTimeString();
           
            //if (ticking == 2)
            //{
            //    label9.Visible = false;
            //}
            //else if (ticking ==4)
            //{
            //    label9.Visible = true;
            //    ticking = -1;
              
            //}
        }
        private string terms()
        {
            string year1 = "";
            string year2 = "";
            string termCur = "";

            if ((System.DateTime.Now.Month.ToString() == "6") || (System.DateTime.Now.Month.ToString() == "7") || (System.DateTime.Now.Month.ToString() == "8") || (System.DateTime.Now.Month.ToString() == "9"))
            {
                year1 = System.DateTime.Now.Year.ToString();
                year2 = System.DateTime.Now.AddYears(1).Year.ToString();
                termCur = "1T";
            }
            else if ((System.DateTime.Now.Month.ToString() == "10") || (System.DateTime.Now.Month.ToString() == "11") || (System.DateTime.Now.Month.ToString() == "12"))
            {
                year1 = System.DateTime.Now.Year.ToString();
                year2 = System.DateTime.Now.AddYears(1).Year.ToString();
                termCur = "2T";
            }
            else if ((System.DateTime.Now.Month.ToString() == "1") || (System.DateTime.Now.Month.ToString() == "2") || (System.DateTime.Now.Month.ToString() == "3"))
            {
                year2 = System.DateTime.Now.Year.ToString();
                year1 = System.DateTime.Now.AddYears(-1).Year.ToString();
                termCur = "3T";
            }
            else
            {
                year2 = System.DateTime.Now.Year.ToString();
                year1 = System.DateTime.Now.AddYears(-1).Year.ToString();
                termCur = "3T";
            }

            string termyear = year1 + "-" + year2 + "/" + termCur;
            return termyear;
        }
        private void changeAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                string query33;


                StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr33.ReadLine();
                StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr34.ReadLine();
                StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr35.ReadLine();
                string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);
                query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + name + "','" + "The user logged out." + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

                dbQuery(query33);

            }
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users fm = new Users(user);
            fm.Show();

        }

        private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logs fm = new Logs(user);
            fm.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items fm = new Items(user, "","");
            fm.ShowDialog();
        }

        private void weeklyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("tsales", user, "");
            fm.Show();
            fm.Text = "Reports [Total Sales]";
        }

        private void totalGrossAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("rem", user, "");
            fm.Show();
            fm.Text = "Reports [Items Remaining]";
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("log", user, "");
            fm.Show();
            fm.Text = "Reports [System Log]";
        }

        private void outOfStockItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("out", user, "");
            fm.Show();
            fm.Text = "Reports [Out Of Stock/ Low Stock Items]";
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("trans", user, "");
            fm.Show();
            fm.Text = "Reports [Transactions]";
        }

        private void systemResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the entire system database?\nOnce you proceed, you cannot retrieve the previous data.", "System Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Reset fm = new Reset(user);
                fm.Show();
            }
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query33;
            StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
            line = sr33.ReadLine();
            StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
            dbP = sr34.ReadLine();
            StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
            dbU = sr35.ReadLine();
            string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
            MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);
            query33 = "Update status set IsOpen = '0'";
            dbQuery(query33);
            this.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Items fm = new Items(user,"","");
            fm.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Users fm = new Users(user);
            fm.Show();

        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("out", user, "");
            fm.Show();
            fm.Text = "Reports [Out Of Stock/ Low Stock Items]";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Stocks fm = new Stocks(user, dataGridView1.CurrentRow.Cells[6].Value.ToString());
            fm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About fm = new About();
            fm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Suppliers fm = new Suppliers(user);
            fm.Show();
        }

        private void payrollSystemHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            TransactionsForm fm = new TransactionsForm(user);
            fm.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            {
                string query;

                dataGridView1.Rows.Clear();
                crit = 0;
                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                query = "Select * from itemlist WHERE quan < origprice ORDER BY categ ASC,srp ASC";
                dbFill(query);
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["categ"].ToString(), dbReader["item_name"].ToString(), dbReader["supp"].ToString(), dbReader["origprice"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["item_no"].ToString());
                    crit++;
                    label9.Text = "You need to refill " + crit + " items!";



                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmBcode fm = new FrmBcode();
            fm.Show();
        }

        private void salesChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("cha", user, "");
            fm.Show();
            fm.Text = "Reports [Sales Chart]";
        }

        private void topSellingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("top", user, "");
            fm.Show();
            fm.Text = "Reports [Top Sellers]";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barcodeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBcode bcod = new FrmBcode();
            bcod.Show();
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("tsales", user, "");
            fm.Show();
            fm.Text = "Reports [Total Sales]";
        }

        private void voidTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("voids", user, "");
            fm.Show();
            fm.Text = "Reports [Void Transactions]";
        }

        private void voidItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Voids ss = new Voids(user);
            ss.Show();
        }

        private void criticalItemsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Warning ss = new Warning();
            ss.ShowDialog();
        }

        private void remainingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remaining ss = new Remaining();
            ss.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}