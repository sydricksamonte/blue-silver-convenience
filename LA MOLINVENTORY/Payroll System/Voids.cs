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
    public partial class Voids : Form
    {
        string user = "";
        public Voids(string a)
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
        private void glassButton1_Click(object sender, EventArgs e)
        {
            bool thereexist = false;
            dataGridView1.Rows.Clear();
            if (textBox1.Text.Contains("TRANS"))
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
                query = "Select trans_items.item_name,trans_items.trans_item_id,trans_items.quan, itemlist.srp, transaction.dat_trans from trans_items  INNER JOIN itemlist ON trans_items.item_id = itemlist.item_no INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id WHERE trans_items.trans_id = '" + textBox1.Text + "' ";
                dbFill(query);
                while (dbReader.Read())
                {
                    //// MessageBox.Show("a");
                    // if (dbReader["notes"].ToString() == "")
                    {
                        dataGridView1.Rows.Add(false, dbReader["item_name"].ToString(), "0", dbReader["trans_item_id"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), "", dbReader["dat_trans"].ToString());

                    }
                    thereexist = true;
                   // MessageBox.Show(dbReader["item_name"].ToString());
                    glassButton2.Enabled = true;
                    glassButton5.Enabled = true;
                    glassButton3.Enabled = true;
                }
                dbReader.Close();
                dbConn.Close();
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
                query = "Select trans_items.item_name,trans_items.trans_item_id,trans_items.quan, itemlist.srp, transaction.dat_trans from trans_items  INNER JOIN itemlist ON trans_items.item_id = itemlist.item_no INNER JOIN transaction ON trans_items.trans_id = transaction.trans_id WHERE trans_items.trans_id = '" +"TRANS"+ textBox1.Text + "' ";
                dbFill(query);
                while (dbReader.Read())
                {
                    //// MessageBox.Show("a");
                    // if (dbReader["notes"].ToString() == "")
                    {
                        dataGridView1.Rows.Add(false, dbReader["item_name"].ToString(), "0", dbReader["trans_item_id"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), "", dbReader["dat_trans"].ToString());

                    }
                   
                    thereexist = true;
                    glassButton2.Enabled = true;
                    glassButton5.Enabled = true;
                    glassButton3.Enabled = true;
                }
                dbReader.Close();
                dbConn.Close();
            }
            if (thereexist == false)
            {
                 MessageBox.Show("Transaction ID does not exist.");
                 textBox1.Text = "";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

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
                query = "Select * from trans_items WHERE trans_id= '" + textBox1.Text + "' ";
                dbFill(query);
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(true, dbReader["item_name"].ToString(),"0", dbReader["trans_item_id"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }
        private string datecomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Day.ToString();
            return ax;
        }
        private string dateparser(DateTime axx)
        {
            string ax = "";
            if (axx.Month.ToString().Length == 2)
            {
                if (axx.Day.ToString().Length == 2)
                {
                    ax = axx.Year.ToString() + "-" + axx.Month.ToString() + "-" + axx.Day.ToString();
                }
                else
                {
                    ax = axx.Year.ToString() + "-" + axx.Month.ToString() + "-0" + axx.Day.ToString();
                }
            }
            else
            {
                if (axx.Day.ToString().Length == 2)
                {
                    ax = axx.Year.ToString() + "-0" + axx.Month.ToString() + "-" + axx.Day.ToString();
                }
                else
                {
                    ax = axx.Year.ToString() + "-0" + axx.Month.ToString() + "-0" + axx.Day.ToString();
                }
            }
            return ax;
        }
        private void glassButton5_Click(object sender, EventArgs e)
        {
            int supr = 0;
            bool chngeoccur = false;
            decimal cashamount = 0;
            decimal cashamount2 = 0;
            for (int ii = 0; ii < dataGridView1.Rows.Count; ii++)
            {

                if (dataGridView1.Rows[ii].Cells[2].Value.ToString() != "0")
                {
                    chngeoccur = true;
                }

            }
            if (chngeoccur==true)
            {
                if (MessageBox.Show("Are you sure you want to void selected Item(s)?", "Void Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //try
                    {
                        for (int ii = 0; ii < dataGridView1.Rows.Count; ii++)
                        {
                            // MessageBox.Show(dataGridView1.Rows[ii].Cells[0].Value.ToString());
                            if (dataGridView1.Rows[ii].Cells[4].Value.ToString().Contains("Void"))
                            {
                                MessageBox.Show(dataGridView1.Rows[ii].Cells[1].Value.ToString() + " is already void");
                            }
                            else
                            {
                                if (dataGridView1.Rows[ii].Cells[2].Value.ToString() != "0")
                                {
                                    int quandif = 0;
                                    int quandif2 = 0;
                                    decimal newamount = Convert.ToDecimal(dataGridView1.Rows[ii].Cells[5].Value.ToString());
                                    decimal newamount2 = 0;
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
                                        query = "Select * from trans_items WHERE trans_item_id = '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' ";
                                        dbFill(query);
                                        while (dbReader.Read())
                                        {
                                            quandif2 = Convert.ToInt32(dbReader["quan"].ToString());
                                            quandif = quandif2 - Convert.ToInt32(dataGridView1.Rows[ii].Cells[2].Value.ToString());

                                            newamount2 = newamount * quandif;
                                        }
                                        dbReader.Close();
                                        dbConn.Close();
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

                                        {
                                            //  query33 = " Update trans_items Set sum_amount = '" + dataGridView1.Rows[ii].Cells[6].Value.ToString() + "',quan = '" + quandif + "', notes = '" + "Void " + "(" + System.DateTime.Now.ToShortDateString() + ")" + "' Where  trans_item_id  = '" + dataGridView1.Rows[ii].Cells[3].Value.ToString() + "'";
                                            query33 = " Update trans_items Set sum_amount = '" + dataGridView1.Rows[ii].Cells[6].Value.ToString() + "',quan = '" + quandif + "'  Where  trans_item_id  = '" + dataGridView1.Rows[ii].Cells[3].Value.ToString() + "'";

                                        }

                                        dbQuery(query33);
                                        if (supr == 0)
                                        {
                                            MessageBox.Show("Item(s) are now void.");
                                        }
                                        supr++;

                                    }
                                    {
                                        {
                                            decimal qq1 = 0;
                                            decimal qq2 = 0;
                                            int qq3 = 0;
                                            int qq4 = 0;

                                            string query;
                                            string newdate = dateparser(Convert.ToDateTime(dataGridView1.Rows[ii].Cells[7].Value)).ToString();
                                            //  MessageBox.Show(newdate);
                                            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                                            line = sr.ReadLine();
                                            StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                                            dbP = sr3.ReadLine();
                                            StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                                            dbU = sr4.ReadLine();
                                            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                                            MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                                            query = "Select * from totaltrans Where time_sum  LIKE '" + newdate + "%' AND item_name = '" + dataGridView1.Rows[ii].Cells[1].Value.ToString() + "'";
                                            dbFill(query);
                                            while (dbReader.Read())
                                            {
                                                qq1 = Convert.ToDecimal(dbReader["sum_amount"].ToString());
                                                qq2 = qq1 - (Convert.ToDecimal(dataGridView1.Rows[ii].Cells[2].Value.ToString()) * (Convert.ToDecimal(dataGridView1.Rows[ii].Cells[5].Value.ToString())));
                                                qq3 = Convert.ToInt32(dbReader["quan"].ToString());
                                                qq4 = qq3 - (Convert.ToInt32(dataGridView1.Rows[ii].Cells[2].Value.ToString()));
                                                // MessageBox.Show(qq2.ToString() + qq4.ToString());

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

                                                    {
                                                        query33 = " Update totaltrans Set sum_amount = '" + qq2.ToString() + "',quan = '" + qq4.ToString() + "'WHERE time_sum  LIKE '" + newdate + "%' AND item_name = '" + dataGridView1.Rows[ii].Cells[1].Value.ToString() + "'";

                                                    }

                                                    dbQuery(query33);
                                                }
                                            }
                                            dbReader.Close();
                                            dbConn.Close();

                                        }



                                    }
                                    {
                                        {

                                            int qq3 = 0;
                                            int qq4 = 0;

                                            string query;
                                            string newdate = dateparser(Convert.ToDateTime(dataGridView1.Rows[ii].Cells[7].Value)).ToString();
                                            //  MessageBox.Show(newdate);
                                            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                                            line = sr.ReadLine();
                                            StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                                            dbP = sr3.ReadLine();
                                            StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                                            dbU = sr4.ReadLine();
                                            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                                            MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                                            query = "Select * from itemlist Where  item_name = '" + dataGridView1.Rows[ii].Cells[1].Value.ToString() + "'";
                                            dbFill(query);
                                            while (dbReader.Read())
                                            {
                                                qq3 = Convert.ToInt32(dbReader["quan"].ToString());
                                                qq4 = qq3 + (Convert.ToInt32(dataGridView1.Rows[ii].Cells[2].Value.ToString()));
                                                // MessageBox.Show(qq2.ToString() + qq4.ToString());

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

                                                    {
                                                        query33 = " Update itemlist Set quan = '" + qq4.ToString() + "'WHERE  item_name = '" + dataGridView1.Rows[ii].Cells[1].Value.ToString() + "'";

                                                    }

                                                    dbQuery(query33);
                                                }
                                            }
                                            dbReader.Close();
                                            dbConn.Close();

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

                                        try
                                        {
                                            query33 = "Insert Into voidtable Values('" + "VOID" + idcomponent() + ":" + textBox1.Text + "','" + dataGridView1.Rows[ii].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[ii].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[ii].Cells[2].Value.ToString() + "','" + datecomponent() + "','" + "Void" + "')";

                                            dbQuery(query33);
                                        }
                                        catch
                                        {
                                            upvoidtable(dataGridView1.Rows[ii].Cells[3].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[ii].Cells[2].Value.ToString()));

                                        }
                                    }
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
                                            query = "Select * from trans_items Where trans_id = '" + textBox1.Text + "'";
                                            dbFill(query);
                                            while (dbReader.Read())
                                            {
                                                cashamount = (Convert.ToDecimal(dbReader["sum_amount"].ToString())) + cashamount;

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
                                            query = "Select * from trans_misc Where trans_id = '" + textBox1.Text + "'";
                                            dbFill(query);
                                            while (dbReader.Read())
                                            {
                                                cashamount2 = (Convert.ToDecimal(dbReader["payment"].ToString())) - cashamount;



                                            }
                                            dbReader.Close();
                                            dbConn.Close();

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

                                            {
                                                query33 = "Update trans_misc Set trans_misc.change = '" + cashamount2 + "'Where trans_id = '" + textBox1.Text + "'";
                                                //  query33 = " Update totaltrans Set sum_amount = '" + qq2.ToString() + "',quan = '" + qq4.ToString() + "'WHERE time_sum  LIKE '" + newdate + "%' AND item_name = '" + dataGridView1.Rows[ii].Cells[1].Value.ToString() + "'";

                                            }

                                            dbQuery(query33);
                                        }

                                        string name = "";
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
                                            string query33;


                                            StreamReader sr33 = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                                            line = sr33.ReadLine();
                                            StreamReader sr34 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                                            dbP = sr34.ReadLine();
                                            StreamReader sr35 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                                            dbU = sr35.ReadLine();
                                            string sConnection33 = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                                            MySqlConnection sqlConnection33 = new MySqlConnection(sConnection33);
                                            query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + name + "','" + "Voided Transaction ID: " + textBox1.Text + "','" + System.DateTime.Now.ToString() + "','" + name + "','" + terms() + "')";

                                            dbQuery(query33);

                                        }



                                    }
                                    ReceiptForm rc = new ReceiptForm(textBox1.Text, user, "void");
                                    rc.Show();
                                    {
                                        dataGridView1.Rows.Clear();
                                        glassButton2.Enabled = false;
                                        glassButton5.Enabled = false;
                                        glassButton3.Enabled = false;
                                        textBox1.Text = "";
                                    }


                                }

                            }
                        }

                    }
                }

                //  catch { }

            }
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
        private void upvoidtable(string ids,int qq2)
        {
            {
               
                int qq3 = 0;
                int qq4 = 0;

                string query;
              
                //  MessageBox.Show(newdate);
                StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
                line = sr.ReadLine();
                StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
                dbP = sr3.ReadLine();
                StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
                dbU = sr4.ReadLine();
                string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
                MySqlConnection sqlConnection = new MySqlConnection(sConnection);
                query = "Select * from voidtable Where trans_item_id  = '" + ids + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                   qq3 = Convert.ToInt32(dbReader["quanvoid"].ToString());
                   qq4 = qq3 + qq2;
                    // MessageBox.Show(qq2.ToString() + qq4.ToString());

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

                        {
                            query33 = " Update voidtable Set quanvoid = '" + qq4.ToString() + "' Where trans_item_id  = '" + ids + "'";
           
                        }

                        dbQuery(query33);
                    }
                }
                dbReader.Close();
                dbConn.Close();

            }
           
        }
        private void glassButton3_Click(object sender, EventArgs e)
        {
            int upd = 0;
            if (MessageBox.Show("Are you sure you want to replace selected Item(s)?", "Replace Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int ii = 0; ii < dataGridView1.Rows.Count; ii++)
                {
                    // MessageBox.Show(dataGridView1.Rows[ii].Cells[0].Value.ToString());
                    if (dataGridView1.Rows[ii].Cells[4].Value.ToString().Contains ( "Replaced"))
                    {
                        MessageBox.Show(dataGridView1.Rows[ii].Cells[1].Value.ToString() + " is already replaced");
                    }
                    else
                    {
                        if (dataGridView1.Rows[ii].Cells[0].Value.ToString() == "True")
                        {

                            int quandif = 0;
                            int quandif2 = 0;
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
                                query = "Select * from trans_items WHERE trans_item_id= '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' ";
                                dbFill(query);
                                while (dbReader.Read())
                                {
                                    quandif2 = Convert.ToInt32(dbReader["quan"].ToString());
                                    quandif = quandif2 - Convert.ToInt32(dataGridView1.Rows[ii].Cells[2].Value.ToString());

                                }
                                dbReader.Close();
                                dbConn.Close();
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

                                {
                                    query33 = " Update trans_items Set  sum_amount = '" + dataGridView1.Rows[ii].Cells[6].Value.ToString() + "', quan = '" + quandif + "', notes = '" + "Replaced " + "(" + System.DateTime.Now.ToShortDateString() + ")" + "' Where  trans_item_id  = '" + dataGridView1.Rows[ii].Cells[2].Value.ToString() + "'";
                                }

                                dbQuery(query33);
                                if (upd == 0)
                                {
                                    MessageBox.Show("Item(s) was successfuly updated");
                                }
                                upd++;
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

                            query33 = "Insert Into voidtable Values('" + "REP" + idcomponent() + ":" + textBox1.Text + "','" + dataGridView1.Rows[ii].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[ii].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[ii].Cells[2].Value.ToString() + "','" + datecomponent() + "','" + "Replaced" + "')";

                            dbQuery(query33);

                        }
                    }
                }
                
                {
                    dataGridView1.Rows.Clear();
                    glassButton2.Enabled = false;
                    glassButton5.Enabled = false;
                    glassButton3.Enabled = false;
                    textBox1.Text = "";
                }

            }
        }
        private string idcomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            return ax;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
              //  decimal trynum = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                decimal newamount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                decimal newamount2 = 0;
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
                    query = "Select * from trans_items WHERE trans_item_id= '" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "' ";
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        int mak = Convert.ToInt32(dbReader["quan"].ToString());
                        decimal newAm = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                        if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString()) > mak)
                        {
                            MessageBox.Show("Invalid. There are only (" + mak + ") quantities bought by the buyer");
                            dataGridView1.CurrentRow.Cells[2].Value = "0";
                        }
                        else
                        {
                            decimal totalam = mak - newAm;
                            newamount2 = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[5].Value.ToString() )*totalam;
                            dataGridView1.CurrentRow.Cells[6].Value = newamount2.ToString();
                        }
                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
            catch { }
        }

        private void Voids_Load(object sender, EventArgs e)
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
                query = "Select trans_id FROM transaction ORDER BY dat_trans DESC ";
                dbFill(query);
                while (dbReader.Read())
                {


                    textBox1.AutoCompleteCustomSource.Add(dbReader["trans_id"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
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

                {
                    query33 = "DELETE FROM totaltrans Where quan = '0' ";

                }

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

                {
                    query33 = "DELETE FROM trans_items Where quan = '0' ";

                }

                dbQuery(query33);


            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Regex nums = new Regex(@"^[0123456789]*$");
            if (nums.IsMatch(dataGridView1.CurrentRow.Cells[2].Value.ToString()))
            {
            }
            else
            {
                dataGridView1.CurrentRow.Cells[2].Value = "0";
            }
        }
       
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Regex nums = new Regex(@"^[0123456789]*$");
            if (nums.IsMatch(dataGridView1.CurrentRow.Cells[2].Value.ToString()))
            {
            }
            else
            {
                dataGridView1.CurrentRow.Cells[2].Value = "0";
            }
        }

    }
}