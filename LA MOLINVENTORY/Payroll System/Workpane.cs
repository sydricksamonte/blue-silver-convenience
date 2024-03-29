using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Payroll_System
{
    public partial class Workpane : Form
    {
        string user;
        public Workpane(string a)
        {
            InitializeComponent();
            user = a;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        string types;
        private void removeUserAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users fm = new Users(user);
            fm.Show();

        }

        private void employeeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee fm = new Employee();
            fm.Show();

        }

        private void weeklyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WeeklySummary fm = new WeeklySummary();
            fm.Show();

        }

        private void skilledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeList fm = new EmployeeList("Skilled");
            fm.Show();

        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeList fm = new EmployeeList("Helper");
            fm.Show();

        }

        private void skilledAndHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeList fm = new EmployeeList("");
            fm.Show();

        }

        private void systemResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the entire system database?\nOnce you proceed, you cannot retrieve the previous data.", "System Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Reset fm = new Reset(user);
                fm.Show();
            }
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
        string name = "";
        int timex = 0;
        private void Workpane_Load(object sender, EventArgs e)
        {
            

            textBox2.Focus();
            if (checkBox1.Checked == true)
            {

                textBox5.Visible = true;
                label5.Visible = false;
                textBox5.Focus();
                label7.Text = "Item Code";
            }
            else
            {
                textBox5.Visible = false;
                label5.Visible = true;
                textBox2.Focus();
                label7.Text = "Item Name";
            }
            string username;
            string password = "";
            string types = "";
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
                query = "Select * from barcodes WHERE bartype = '" + 1 + "' ";
                dbFill(query);
                while (dbReader.Read())
                {
                    if (dbReader["types"].ToString() == "manual")
                    {


                        label7.Text = "Item Name";


                        textBox5.Visible = false;
                        label5.Visible = true;
                        textBox2.Focus();
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        label7.Text = "Item Code";
                        textBox5.Visible = true;
                        label5.Visible = false;
                        textBox5.Focus();
                        checkBox1.Checked = true;
                    }




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
                query = "Select * from logs WHERE userna = '" + user + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    name = dbReader["names"].ToString();
                    types = dbReader["types"].ToString();



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
                query = "Select item_name,item_no from itemlist WHERE item_no LIKE '" + textBox2.Text + "%' OR item_name LIKE '" + textBox2.Text + "%' ";
                dbFill(query);
                while (dbReader.Read())
                {


                    textBox2.AutoCompleteCustomSource.Add(dbReader["item_name"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
            //{
            //    string query;


            //    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
            //    line = sr.ReadLine();
            //    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
            //    dbP = sr3.ReadLine();
            //    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
            //    dbU = sr4.ReadLine();
            //    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
            //    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
            //    query = "Select emp_name from employee";
            //    dbFill(query);
            //    while (dbReader.Read())
            //    {


            //        textBox1.AutoCompleteCustomSource.Add(dbReader["emp_name"].ToString());


            //    }
            //    dbReader.Close();
            //    dbConn.Close();
            //}

            if (types == "USER")
            {
                systemResetToolStripMenuItem.Enabled = false;
                createAccountToolStripMenuItem.Enabled = false;
                // employeeInformationToolStripMenuItem.Enabled = false;
                logViewToolStripMenuItem.Enabled = false;
            } 
            Warning ss = new Warning();
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

                    ss.ShowDialog();
                    ss.Focus();
                    break;


                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About fm = new About();
            fm.Show();
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

        private void skilledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void helperToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void skilledHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {

            }
            else
            {

            }
        }

        private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logs fm = new Logs(name);
            fm.Show();
        }
       
        private void glassButton2_Click(object sender, EventArgs e)
        {

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
                    // query33 = "Insert Into pays Values('" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString() + user + "','" + label11.Text + "','" + textBox1.Text.Trim().ToUpper() + "','" + System.DateTime.Now.ToString() + "','" + numericUpDown1.Value + "','" + numericUpDown2.Value + "')";

                    // dbQuery(query33);

                }
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
                    query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + name + "','" + "UNKNOWNXXX" + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

                    dbQuery(query33);
                    timer1.Enabled = true;
                    label9.Text = "Update success.";
                }

            
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int ticks = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            progressBar1.Value = ticks;
            if (ticks >= 0)
            {
                label9.ForeColor = System.Drawing.Color.Green;


                if (ticks == 40)
                {
                    timer1.Enabled = false;
                    label9.Text = "Ready";
                    label9.ForeColor = System.Drawing.Color.Black;
                    ticks = 0;
                    progressBar1.Value = ticks;
                }
            }
            else
            {

                label9.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ticks++;
            progressBar1.Value = ticks;
            if (ticks >= 0)
            {
                label9.ForeColor = System.Drawing.Color.Red;


                if (ticks == 40)
                {
                    timer2.Enabled = false;
                    label9.Text = "Ready";
                    label9.ForeColor = System.Drawing.Color.Black;
                    ticks = 0;
                    progressBar1.Value = ticks;
                }
            }
            else
            {

                label9.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items fm = new Items(user,"","");
            fm.Show();
        }
        string rubik = "";
        public void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void glassButton4_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void glassButton1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        string ai = ""; decimal pricetag = 0; int quancount = 0;
        public void AddToList()
        {
            int addeditems = 0;
           // try
            {
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
                    query = "Select * from itemlist WHERE item_name = '" + textBox2.Text.ToUpper() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        quancount = int.Parse(dbReader["quan"].ToString());

                    }
                    dbReader.Close();
                    dbConn.Close();
                    for (int q = 0; q < dataGridView1.Rows.Count; q++)
                    {
                        if (dataGridView1.Rows[q].Cells[1].Value.ToString() == textBox2.Text.Trim().ToUpper())
                        {
                            addeditems = Convert.ToInt32(dataGridView1.Rows[q].Cells[3].Value.ToString()) + addeditems;
                        }
                      //   MessageBox.Show(addeditems.ToString());
                    }
                }
                if (((quancount - addeditems) < (int.Parse(textBox3.Text.Trim()))) && ((quancount != 0)))
                {
                    if ((quancount - addeditems) == 0)
                    {
                        MessageBox.Show("Item is out of stock.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        MessageBox.Show("There are only (" + Convert.ToString(quancount - addeditems) + ") remaining item(s) of this type. \nWrong inventory information. Please contact the administrator", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //if ((quancount < int.Parse(textBox3.Text)) && ((quancount != 0)))
                //{
                //    MessageBox.Show("There are only (" + quancount.ToString() + ") remaining items of this type.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //}
                else if (textBox2.Text == "")
                {
                }
                else if ((quancount == 0))
                {
                    MessageBox.Show("Item is out of stock.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    bool exist = false;//{
                    //    string query;


                    //    StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                    //    line = sr.ReadLine();
                    //    StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                    //    dbP = sr3.ReadLine();
                    //    StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                    //    dbU = sr4.ReadLine();
                    //    string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                    //    MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                    //    query = "Select * from itemlist WHERE item_name = '" + textBox2.Text.ToUpper() + "'";
                    //    dbFill(query);
                    //    while (dbReader.Read())
                    //    {

                    //        quancount = int.Parse(dbReader["quan"].ToString());

                    //    }
                    //    dbReader.Close();
                    //    dbConn.Close();
                    //}
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
                        query = "Select * from itemlist WHERE item_name = '" + textBox2.Text.ToUpper() + "'";
                        dbFill(query);
                        while (dbReader.Read())
                        {
                            ai = dbReader["srp"].ToString();
                            pricetag = Convert.ToDecimal(ai) * Convert.ToDecimal(textBox3.Text);
                            for (int ii = 0; ii < dataGridView1.Rows.Count; ii++)
                            {
                                
                                 if (dataGridView1.Rows[ii].Cells[1].Value.ToString().ToUpper().Trim() == textBox2.Text.ToUpper().Trim())
                                {
                                    exist = true;
                                    if ((pricetag != 0))
                                    {
                                      
                                        int sat = 0;

                                        sat = Convert.ToInt32(textBox3.Text);
                                        sat = Convert.ToInt32(dataGridView1.Rows[ii].Cells[3].Value.ToString()) + sat;
                                      
                              
                                        dataGridView1.Rows[ii].Cells[3].Value = sat;

                                        double sat2 = 0;

                                   
                                        sat2 = Convert.ToDouble(dataGridView1.Rows[ii].Cells[2].Value.ToString()) * sat;


                                        dataGridView1.Rows[ii].Cells[4].Value = sat2.ToString("#0.00");
                                        label19.Text = "₱ " + pricetag.ToString();
                                        UpCash();
                                    }
                                }
                               
                            }
                           
                            if (exist == false)
                            {
                                if ((pricetag != 0))
                                {
                                    dataGridView1.Rows.Add((Convert.ToInt32(dataGridView1.Rows.Count.ToString()) + 1), textBox2.Text.ToUpper(), ai, textBox3.Text, pricetag.ToString(), dbReader["item_no"].ToString(), dbReader["categ"].ToString());
                                    label19.Text = "₱ " + pricetag.ToString();
                                }
                            }
                        }
                        dbReader.Close();
                        dbConn.Close();
                    }
                    if ((pricetag != 0))
                    {
                        textBox2.Text = "";
                        textBox3.Text = "0";
                    }
                }
                textBox2.Focus();

            }
            //catch
            //{
            //}
        }
        private void glassButton2_Click_1(object sender, EventArgs e)
        {
            AddToList();
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "0";
        }
        int countero = 0;
        decimal newval = 0;
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            if ((pricetag != 0))
            {
                UpCash();
                countero = dataGridView1.Rows.Count;// label10.Text = countero.ToString();
                try
                {
                    do
                    {
                        newval = (Convert.ToDecimal(dataGridView1.Rows[countero - 1].Cells[4].Value.ToString())) + newval;
                        countero--;
                       // label1.Text = "₱ " + newval.ToString();

                    }
                    while (countero < 0);
                }
                catch { }
            }
        }
        decimal change = 0;
        private string timecomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Day.ToString() + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString();
            return ax;
        }
        private string datecomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Day.ToString();
            return ax;
        }
        private string monthCom()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/";
            return ax;
        }
        private string yearCom()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/";
            return ax;
        }
       
        private string idcomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            return ax;
        }
        int counta = 0; int quan = 0; int minquan = 0;
        private void finalize()
        {
            timex = 0;
            bool meronmonth = false; bool meronAnnual = false;
            counta = dataGridView1.Rows.Count;
           try
            {
                if (counta == 0)
                {
                    MessageBox.Show("Please add items using Add to List button", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (pricetag2 > (Convert.ToDecimal(textBox1.Text)))
                {
                    MessageBox.Show("The cash you entered is not enough. \nPlease check if you mispelled the correct input.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to finalize?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int currentcount = 0;
                        decimal currAmount = 0;
                        decimal currAmounta = 0; int currentcounta = 0;
                        decimal currAmountmm = 0; int currentcountmm = 0;
                        decimal currAmountm = 0; int currentcountm = 0;
                        {

                            change = Convert.ToDecimal(textBox1.Text) - pricetag2;
                            label12.Text = "₱ " + Convert.ToDouble(textBox1.Text).ToString("#,##0.00");
                            label10.Text = "₱ " + change.ToString("#,##0.00");
                            rubik = "TRANS" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Millisecond.ToString();
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

                                query33 = "Insert Into transaction Values('" + rubik + "','" + timecomponent() + "','" + user + "')";

                                dbQuery(query33);
                            }
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

                                query33 = "Insert Into trans_misc Values('" + rubik + "','" + change + "','" + Convert.ToDecimal(textBox1.Text) + "')";

                                dbQuery(query33);

                            }
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
                                query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + name + "','" + "Created a transaction w/ the ID: " + rubik + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

                                dbQuery(query33);

                            }

                            {

                                do
                                {
                                    bool meron = false;

                                    {
                                        string query = "";


                                        StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                                        line = sr.ReadLine();
                                        StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                                        dbP = sr3.ReadLine();
                                        StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                                        dbU = sr4.ReadLine();
                                        string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                                        MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                                        if ((System.DateTime.Now.Month.Equals(1)) || (System.DateTime.Now.Month.Equals(3)) || (System.DateTime.Now.Month.Equals(5)) || (System.DateTime.Now.Month.Equals(7)) || (System.DateTime.Now.Month.Equals(8)) || (System.DateTime.Now.Month.Equals(10)) || (System.DateTime.Now.Month.Equals(12)))
                                        {
                                            query = "Select * from totaltrans WHERE time_sum BETWEEN '" + monthCom() + "1" + "' AND '" + monthCom() + "31 23:59:59" + "'  AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "month" + "'";
                                        }
                                        else if ((System.DateTime.Now.Month.Equals(4)) || (System.DateTime.Now.Month.Equals(6)) || (System.DateTime.Now.Month.Equals(9)) || (System.DateTime.Now.Month.Equals(11)))
                                        {
                                            query = "Select * from totaltrans WHERE time_sum BETWEEN '" + monthCom() + "1" + "' AND '" + monthCom() + "30 23:59:59" + "'  AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "month" + "'";
                                        }
                                        else if ((System.DateTime.Now.Month.Equals(2)))
                                        {
                                            query = "Select * from totaltrans WHERE time_sum BETWEEN '" + monthCom() + "1" + "' AND '" + monthCom() + "28 23:59:59" + "'  AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "month" + "'";

                                        }

                                        dbFill(query);
                                        while (dbReader.Read())
                                        {
                                            //    MessageBox.Show("may month");
                                            meronmonth = true;
                                            currentcountmm = int.Parse(dbReader["quan"].ToString());
                                            currAmountmm = decimal.Parse(dbReader["sum_amount"].ToString());
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
                                        query = "Select * from totaltrans WHERE time_sum BETWEEN '" + datecomponent() + "' AND '" + datecomponent() + " 23:59:59" + "'  AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "daily" + "'";
                                        dbFill(query);
                                        while (dbReader.Read())
                                        {

                                            meron = true;
                                            currentcountm = int.Parse(dbReader["quan"].ToString());
                                            currAmountm = decimal.Parse(dbReader["sum_amount"].ToString());
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
                                        query = "Select * from totaltrans WHERE time_sum BETWEEN '" + yearCom() + "1/1" + "' AND '" + yearCom() + "12/31 23:59:59" + "'  AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "annual" + "'";
                                        dbFill(query);
                                        while (dbReader.Read())
                                        {
                                            //   MessageBox.Show("may annu nakita");
                                            meronAnnual = true;
                                            currentcounta = int.Parse(dbReader["quan"].ToString());
                                            currAmounta = decimal.Parse(dbReader["sum_amount"].ToString());
                                        }
                                        dbReader.Close();
                                        dbConn.Close();
                                    }
                                    if (meronAnnual == false)
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

                                            query33 = "Insert Into totaltrans Values('" + "TIAN" + idcomponent() + "','" + dataGridView1.Rows[counta - 1].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[3].Value.ToString() + "','" + timecomponent() + "','" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "','" + Convert.ToDecimal(dataGridView1.Rows[counta - 1].Cells[4].Value.ToString()) + "','" + "annual" + "')";

                                            dbQuery(query33);
                                            //  MessageBox.Show("may insert annu");
                                        }
                                    }
                                    else if (meronAnnual == true)
                                    {

                                        {
                                            currAmounta = decimal.Parse(dataGridView1.Rows[counta - 1].Cells[4].Value.ToString()) + currAmounta;
                                            currentcounta = int.Parse(dataGridView1.Rows[counta - 1].Cells[3].Value.ToString()) + currentcounta;
                                            string query33;


                                            StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                                            line = sr33.ReadLine();
                                            StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                                            dbP = sr34.ReadLine();
                                            StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                                            dbU = sr35.ReadLine();
                                            string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                                            MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                                            query33 = " Update totaltrans Set quan = '" + currentcounta + "', sum_amount = '" + currAmounta + "' Where  time_sum BETWEEN '" + yearCom() + "1/1" + "' AND '" + yearCom() + "12/31 23:59:59" + "' AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "annual" + "'";

                                            dbQuery(query33);
                                            //  MessageBox.Show("may update annu");
                                        }
                                    }
                                    if (meron == false)
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

                                            query33 = "Insert Into totaltrans Values('" + "TIDA" + idcomponent() + "','" + dataGridView1.Rows[counta - 1].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[3].Value.ToString() + "','" + timecomponent() + "','" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "','" + Convert.ToDecimal(dataGridView1.Rows[counta - 1].Cells[4].Value.ToString()) + "','" + "daily" + "')";

                                            dbQuery(query33);

                                        }
                                    }
                                    else
                                    {

                                        {
                                            currAmountm = decimal.Parse(dataGridView1.Rows[counta - 1].Cells[4].Value.ToString()) + currAmountm;
                                            currentcountm = int.Parse(dataGridView1.Rows[counta - 1].Cells[3].Value.ToString()) + currentcountm;
                                            string query33;


                                            StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                                            line = sr33.ReadLine();
                                            StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                                            dbP = sr34.ReadLine();
                                            StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                                            dbU = sr35.ReadLine();
                                            string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                                            MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);

                                            query33 = " Update totaltrans Set quan = '" + currentcountm + "', sum_amount = '" + currAmountm + "' Where time_sum BETWEEN '" + datecomponent() + "' AND '" + datecomponent() + " 23:59:59" + "' AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "daily" + "'";

                                            dbQuery(query33);

                                        }
                                    }
                                    if (meronmonth == false)
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

                                            query33 = "Insert Into totaltrans Values('" + "TIMN" + idcomponent() + "','" + dataGridView1.Rows[counta - 1].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[3].Value.ToString() + "','" + timecomponent() + "','" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "','" + Convert.ToDecimal(dataGridView1.Rows[counta - 1].Cells[4].Value.ToString()) + "','" + "month" + "')";
                                            // MessageBox.Show("may month ins");
                                            dbQuery(query33);

                                        }
                                    }
                                    else if (meronmonth == true)
                                    {

                                        {
                                            currAmountmm = decimal.Parse(dataGridView1.Rows[counta - 1].Cells[4].Value.ToString()) + currAmountmm;
                                            currentcountmm = int.Parse(dataGridView1.Rows[counta - 1].Cells[3].Value.ToString()) + currentcountmm;
                                            string query33;


                                            StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                                            line = sr33.ReadLine();
                                            StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                                            dbP = sr34.ReadLine();
                                            StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                                            dbU = sr35.ReadLine();
                                            string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                                            MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);
                                            if ((System.DateTime.Now.Month.Equals(1)) || (System.DateTime.Now.Month.Equals(3)) || (System.DateTime.Now.Month.Equals(5)) || (System.DateTime.Now.Month.Equals(7)) || (System.DateTime.Now.Month.Equals(8)) || (System.DateTime.Now.Month.Equals(10)) || (System.DateTime.Now.Month.Equals(12)))
                                            {
                                                query33 = " Update totaltrans Set quan = '" + currentcountmm + "', sum_amount = '" + currAmountmm + "' Where time_sum BETWEEN '" + monthCom() + "1" + "' AND '" + monthCom() + "31 23:59:59" + "' AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "month" + "'";
                                            }
                                            else if ((System.DateTime.Now.Month.Equals(4)) || (System.DateTime.Now.Month.Equals(6)) || (System.DateTime.Now.Month.Equals(9)) || (System.DateTime.Now.Month.Equals(11)))
                                            {
                                                query33 = " Update totaltrans Set quan = '" + currentcountmm + "', sum_amount = '" + currAmountmm + "' Where time_sum BETWEEN '" + monthCom() + "1" + "' AND '" + monthCom() + "30 23:59:59" + "' AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "month" + "'";
                                            }
                                            else
                                            {
                                                query33 = " Update totaltrans Set quan = '" + currentcountmm + "', sum_amount = '" + currAmountmm + "' Where time_sum BETWEEN '" + monthCom() + "1" + "' AND '" + monthCom() + "28 23:59:59" + "' AND item_id = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "' AND typex = '" + "month" + "'";

                                            }
                                            //     MessageBox.Show("may update month");
                                            dbQuery(query33);

                                        }
                                    }
             
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

                                        query33 = "Insert Into trans_items Values('" + "ITEM" + idcomponent() + "','" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[1].Value.ToString() + "','" + rubik + "','" + dataGridView1.Rows[counta - 1].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[counta - 1].Cells[4].Value.ToString() + "','" + "" + "')";

                                        dbQuery(query33);

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
                                        query = "Select * from itemlist WHERE item_no = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "'";
                                        dbFill(query);
                                        while (dbReader.Read())
                                        {

                                            quan = int.Parse(dbReader["quan"].ToString());

                                        }
                                        dbReader.Close();
                                        dbConn.Close();

                                    }
                                    minquan = quan - (int.Parse(dataGridView1.Rows[counta - 1].Cells[3].Value.ToString()));
                                    //MessageBox.Show(minquan.ToString());
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

                                        query33 = " Update itemlist Set quan = '" + minquan + "' Where item_no = '" + dataGridView1.Rows[counta - 1].Cells[5].Value.ToString() + "'";

                                        dbQuery(query33);

                                    }
                                    counta--;
                                } while (counta > 0);
                            }
                            label15.Text = label1.Text;
                            label16.Text = label10.Text;
                            label17.Text = label12.Text;


                            ReceiptForm rc = new ReceiptForm(rubik, user, "rec");


                            //  timer3.Enabled = true;


                            if (checkBox1.Checked == true)
                            {

                                textBox5.Visible = true;
                                label5.Visible = false;
                                textBox5.Focus();
                            }
                            else
                            {
                                textBox5.Visible = false;
                                label5.Visible = true;
                                textBox2.Focus();
                            }


                            if (checkBox2.Checked == true)
                            {
                              // newTrans();

                            }
                           // newTrans();
                            textBox4.Text = "0";
                            rc.ShowDialog();

                        }



                    }
                }
               

            }
            catch
            {
                textBox1.Text = "";
                MessageBox.Show("Invalid Cash Input!", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void glassButton5_Click(object sender, EventArgs e)
        {

            finalize();
        }
   
     
        
        private void newTrans()
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox3.Text = "0";
            label1.Text = "₱ 0.00";
            label10.Text = "₱ 0.00";
            label19.Text = "₱ 0.00";
            label12.Text = "₱ 0.00";
            textBox2.Focus();
            change = 0;
            counta = 0;
            countero = 0;
            minquan = 0;
            newval = 0;
            rubik = "";

            if (checkBox1.Checked == true)
            {

                textBox5.Visible = true;
                label5.Visible = false;
                textBox5.Focus();
            }
            else
            {
                textBox5.Visible = false;
                label5.Visible = true;
                textBox2.Focus();
            }
        }
        private void glassButton6_Click(object sender, EventArgs e)
        {
            newTrans();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex nums = new Regex(@"^[0123456789]*$");
            if (nums.IsMatch(textBox3.Text))
            {
            }
            else
            {
                MessageBox.Show("Invalid value");
                textBox3.Text = "0";
                textBox3.Focus();
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("log", user, "");
            fm.Show();
            fm.Text = "Reports [System Log]";
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("trans", user, "");
            fm.Show();
            fm.Text = "Reports [Transactions]";
        }

        private void outOfStockItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports fm = new Reports("out", user, "");
            fm.Show();
            fm.Text = "Reports [Out Of Stock/ Low Stock Items]";
            
        }

        private void outOfStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void classicToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void payrollSystemHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //Introductory fm = new Introductory();
           // fm.Show();
        }
        int delir = 0;
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
         
     
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
              if ((e.KeyChar ==Convert.ToChar( Keys.Delete)) )
            {
                label19.Text = "₱ 0.00";
                int maniz = dataGridView1.CurrentRow.Index;
                
                dataGridView1.Rows.RemoveAt(maniz);
               
              
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
       
          
        }
        decimal pricetag2;
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {


            UpCash();
           
        }
        public void UpCash()
        {

            pricetag2 = 0;

            int manix = dataGridView1.Rows.Count;
            for (int i = 0; i < manix; i++)
            {
                pricetag2 = Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value.ToString()) + pricetag2;

            }
            label1.Text = "₱ " + pricetag2.ToString("#,##0.00");
            if (label1.Text == "₱ 0")
            {
                label1.Text = "₱ 0.00";
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //timex++;
            //ReceiptForm rc = new ReceiptForm(rubik, user);
            //if (timex < 20)
            //{
            //    if (timex == 1)
            //    {

            //        rc.Show();
            //    }
            //}
            //else if (timex > 5)
            //{
            //    timer3.Enabled = false;
            //    rc.Close();
            //}
                         
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
            
                textBox3.Focus();
            }
             if ((e.KeyChar == Convert.ToChar(Keys.Down)))
            {
           
                textBox3.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode ==Keys.Enter))
            {

                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                if (textBox2.Text == "")
                {
                    textBox1.Focus();
                }
                else
                {
                    AddToList();
                }
            }
        }

        private void Workpane_Deactivate(object sender, EventArgs e)
        {
          //  Application.Exit();
        }

        private void glassButton7_Click(object sender, EventArgs e)
        {
           
        }

        private void Workpane_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        private void changeit()
        {
            if (checkBox1.Checked == true)
            {

                textBox5.Visible = true;
               // label5.Visible = false;
                textBox5.Focus();
                textBox3.Visible = false;
                textBox4.Visible = true;
                label7.Text = "Item Code";
            }
            else
            {
                textBox5.Visible = false;
               // label5.Visible = true;
                textBox2.Focus();
                textBox4.Visible = false;
                textBox3.Visible = true;
                label7.Text = "Item Name";
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            changeit();
        }
        int counterss = 0;
        public void BarCOdeIt()
        {
            try
            {
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
                    query = "Select * from itemlist WHERE item_no = '" + textBox5.Text + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        quancount = int.Parse(dbReader["quan"].ToString());
                    

                    }
                    dbReader.Close();
                    dbConn.Close();
                }
                if ((quancount < 1) && ((quancount != 0)))
                {
                    MessageBox.Show("There are only (" + quancount.ToString() + ") remaining items of this type.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                else if ((quancount == 0))
                {
                    MessageBox.Show("Item is out of stock.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
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
                        query = "Select * from itemlist WHERE item_no = '" + textBox5.Text + "'";
                        dbFill(query);
                        while (dbReader.Read())
                        {

                            ai = dbReader["srp"].ToString();
                            pricetag = Convert.ToDecimal(ai) * Convert.ToDecimal(textBox3.Text);
                            if ((pricetag != 0))
                            {
                                dataGridView1.Rows.Add((Convert.ToInt32(dataGridView1.Rows.Count.ToString()) + 1), textBox2.Text.ToUpper(), ai, textBox3.Text, pricetag.ToString(), dbReader["item_no"].ToString(), dbReader["categ"].ToString());
                            }
                        }
                        dbReader.Close();
                        dbConn.Close();
                    }
                    if ((pricetag != 0))
                    {
                        textBox2.Text = "";
                        textBox3.Text = "0";
                    }
                }
                textBox5.Focus();

            }
            catch
            {
            }
        }
        bool known = false;
    
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool exist = false;
            known = false;
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)) || (e.KeyChar == Convert.ToChar(Keys.Tab)))
            {
                try
                {
                    if (textBox5.Text == "")
                    {
                        textBox1.Focus();
                    }
                    else
                    {
                        quancount = 11111111;
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
                            query = "Select * from itemlist WHERE item_no = '" + textBox5.Text.Trim() + "'";
                            dbFill(query);
                            while (dbReader.Read())
                            {


                                known = true;
                            }
                            dbReader.Close();
                            dbConn.Close();

                        }
                        if (known == false)
                        {
                            MessageBox.Show("Item barcode is unknown. \nPlease type the item name", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
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
                                query = "Select * from itemlist WHERE item_no = '" + textBox5.Text.Trim() + "'";
                                dbFill(query);
                                while (dbReader.Read())
                                {

                                    quancount = int.Parse(dbReader["quan"].ToString());
                                    // MessageBox.Show(quancount.ToString());

                                }
                                dbReader.Close();
                                dbConn.Close();
                            }


                            if ((quancount == 0))
                            {
                                MessageBox.Show("Error! \nItem is out of stock. \nPlease contact the administrator for wrong inventory information.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                textBox5.Text = "";
                                textBox5.Focus();
                            }
                            else
                            {


                                //   MessageBox.Show(quancount.ToString());
                                textBox4.Text = "1";
                                textBox4.Focus();

                            }

                        }
                    }
                }
                catch { }

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                if (checkBox1.Checked == false)
                {
                    if (textBox1.Text == "")
                    {
                        textBox2.Focus();
                    }
                    else
                    {

                        finalize();
                    }
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        textBox5.Focus();
                    }
                    else
                    {

                        finalize();
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Workpane_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
       
        private void presses(char vav)
        {

            if ((vav ==Convert.ToChar( Keys.F2)))
            {
                newTrans();

            }
            else if ((vav == Convert.ToChar(Keys.F9)))
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
                query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + name + "','" + "The user logged out." + "','" + System.DateTime.Now.ToString() + "','" + name + "','" + terms() + "')";

                dbQuery(query33);
                Form1 fm = new Form1();
                fm.Show();
                this.Hide();


            }
        }
        private void Workpane_KeyUp(object sender, KeyEventArgs e)
        {
            presses(Convert.ToChar(e.KeyValue));
 
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            //presses(Convert.ToChar(e.KeyValue));
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            presses(Convert.ToChar(e.KeyValue));
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            presses(Convert.ToChar(e.KeyValue));
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            presses(Convert.ToChar(e.KeyValue));
        }

        private void textBox2_KeyUp_1(object sender, KeyEventArgs e)
        {
            presses(Convert.ToChar(e.KeyValue));
        }

        private void Workpane_Enter(object sender, EventArgs e)
        {
            if (textBox5.Visible == true)
            {
                textBox5.Focus();
            }
            else
            {
                textBox2.Focus();
            }
        }

        private void Workpane_Activated(object sender, EventArgs e)
        {
            if (textBox5.Visible == true)
            {
                textBox5.Focus();
            }
            else
            {
                textBox2.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            bool exist = false;
              int addeditems = 0;
            if (e.KeyCode == Keys.Enter)
            {
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
                    query = "Select * from itemlist WHERE item_no = '" + textBox5.Text.Trim() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        quancount = int.Parse(dbReader["quan"].ToString());

                    }
                    dbReader.Close();
                    dbConn.Close();
                  
                    for (int q = 0; q < dataGridView1.Rows.Count; q++)
                    {
                        if (dataGridView1.Rows[q].Cells[5].Value.ToString() == textBox5.Text.Trim())
                        {
                            addeditems = Convert.ToInt32(dataGridView1.Rows[q].Cells[3].Value.ToString()) + addeditems;
                        }
                     //   MessageBox.Show(addeditems.ToString());
                    }
                }
                if (((quancount - addeditems) < (int.Parse(textBox4.Text))) && ((quancount != 0)))
                {
                    if ((quancount - addeditems) == 0)
                    {
                        MessageBox.Show("Item is out of stock.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           
                    }
                    else
                    {
                        MessageBox.Show("There are only (" + Convert.ToString(quancount - addeditems) + ") remaining item(s) of this type. \nWrong inventory information. Please contact the administrator", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (textBox5.Text == "")
                {
                }
                else if ((quancount == 0))
                {
                    MessageBox.Show("Item is out of stock.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
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
                    query = "Select * from itemlist WHERE item_no = '" + textBox5.Text.Trim() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {


                        ai = dbReader["srp"].ToString();
                        pricetag = Convert.ToDecimal(ai) * Convert.ToDecimal(textBox4.Text.Trim());
                        for (int ii = 0; ii < dataGridView1.Rows.Count; ii++)
                        {

                            if (dataGridView1.Rows[ii].Cells[5].Value.ToString().ToUpper().Trim() == textBox5.Text.ToUpper().Trim())
                            {
                                exist = true;
                                if ((pricetag != 0))
                                {

                                    int sat = 0;

                                    sat = Convert.ToInt32(textBox4.Text);
                                    sat = Convert.ToInt32(dataGridView1.Rows[ii].Cells[3].Value.ToString()) + sat;


                                    dataGridView1.Rows[ii].Cells[3].Value = sat;

                                    double sat2 = 0;


                                    sat2 = Convert.ToDouble(dataGridView1.Rows[ii].Cells[2].Value.ToString()) * sat;


                                    dataGridView1.Rows[ii].Cells[4].Value = sat2.ToString("#0.00");
                                    label19.Text = "₱ " + pricetag.ToString();
                                    UpCash();
                                }
                            }

                        }

                        if (exist == false)
                        {
                            if ((pricetag != 0))
                            {
                                dataGridView1.Rows.Add((Convert.ToInt32(dataGridView1.Rows.Count.ToString()) + 1), dbReader["item_name"].ToString().ToUpper(), ai, textBox4.Text.Trim(), pricetag.ToString(), dbReader["item_no"].ToString(), dbReader["categ"].ToString());
                                label19.Text = "₱ " + pricetag.ToString("#,##0.00");
                            }

                        }


                        known = true;
                    }
                    dbReader.Close();
                    dbConn.Close();
                    textBox5.Text = "";
                    textBox5.Focus();
                    textBox4.Text = "1";
                }
                if (known == false)
                {
                    MessageBox.Show("Item barcode is unknown. \nPlease type the item name", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Focus();
            panel5.Visible = true;
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           label20.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //Quantity fm = new Quantity( dataGridView1.CurrentRow.Cells[6].Value.ToString());
            //fm.Show();
        }

        private void Update_Click(object sender, EventArgs e)
        {

            try
            {
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
                    query = "Select * from itemlist WHERE item_name = '" + label20.Text.ToUpper() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        quancount = int.Parse(dbReader["quan"].ToString());

                    }
                    dbReader.Close();
                    dbConn.Close();
                }
                if ((quancount < Convert.ToInt32(textBox6.Text)) && ((quancount != 0)))
                {
                    MessageBox.Show("There are only (" + quancount.ToString() + ") remaining items of this type.", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel5.Visible = false;
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Quantity was not updated", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panel5.Visible = false;
                }

                else
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
                    query = "Select * from itemlist WHERE item_name = '" + label20.Text.ToUpper() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        ai = dbReader["srp"].ToString();
                        pricetag = Convert.ToDecimal(ai) * Convert.ToDecimal(textBox6.Text);
                        for (int ii = 0; ii < dataGridView1.Rows.Count; ii++)
                        {

                            if (dataGridView1.Rows[ii].Cells[1].Value.ToString().ToUpper().Trim() == label20.Text.ToUpper().Trim())
                            {

                                if ((pricetag != 0))
                                {

                                    int sat = 0;

                                    sat = Convert.ToInt32(textBox6.Text);


                                    dataGridView1.Rows[ii].Cells[3].Value = sat;

                                    double sat2 = 0;


                                    sat2 = Convert.ToDouble(dataGridView1.Rows[ii].Cells[2].Value.ToString()) * sat;


                                    dataGridView1.Rows[ii].Cells[4].Value = sat2.ToString("#0.00");
                                    label19.Text = "₱ " + pricetag.ToString();
                                    UpCash();
                                }
                            }

                        }
                        panel5.Visible = false;
                    }
                }


            }

            catch {
                MessageBox.Show("Error. Quantity was not updated", "Blue and Silver Bookshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                panel5.Visible = false;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void voidTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Voids ss = new Voids(user);
            ss.Show();
        }
         
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Regex nums = new Regex(@"^[0123456789]*$");
            if (nums.IsMatch(textBox4.Text))
            {
            }
            else
            {
                MessageBox.Show("Invalid value");
                textBox4.Text = "0";
                textBox4.Focus();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Regex nums = new Regex(@"^[0123456789.]*$");
            if (nums.IsMatch(textBox1.Text))
            {
            }
            else
            {
                MessageBox.Show("Invalid value");
                textBox1.Text = "0";
                textBox1.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpCash();
        }

        private void dataGridView1_RowsRemoved_1(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpCash();
        }

        private void criticalItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warning ss = new Warning();
            ss.ShowDialog();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void transactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TransactionsForm ss = new TransactionsForm(user);
            ss.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
    }
}