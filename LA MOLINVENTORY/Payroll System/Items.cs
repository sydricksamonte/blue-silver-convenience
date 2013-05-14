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
    public partial class Items : Form
    {
        string user = "";
        string itemss = "";
        string supps = "";
        int countitems = 0;
        public Items(string a,string b, string c)
        {
            InitializeComponent();

            user = a;
            itemss = b;
            supps = c;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        string types;
        public void dbQuery(string statement)
        {
            try
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
            catch
            {
                MessageBox.Show("System Error.");
            }
        }
        public void dbFill(string statement)
        {
            try
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
            catch
            {
                MessageBox.Show("System Error.");
            }
        
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            unitss();
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
            else if ((System.DateTime.Now.Month.ToString() == "10") || (System.DateTime.Now.Month.ToString() == "11") || (System.DateTime.Now.Month.ToString() == "12") )
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
        private void addItem()
        {
            {
                
                    try
                    {
                        if (MessageBox.Show("Are you sure you want to add this item?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                                query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + user + "','" + "Added item " + adName.Text + "','" + System.DateTime.Now.ToString() + "','" + name + "','" + terms() + "')";

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
                                if (typess == "manual")
                                {

                                    {
                                        query33 = "Insert Into itemlist Values('" + label30.Text.Trim().ToUpper() + "','" + adName.Text.Trim().ToUpper() + "','" + adCateg.Text + "','" + adOrigP.Text.Trim() + "','" + adSRP.Text.Trim() + "','" + adUnit.Text.Trim() + "','" + adQuan.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox5.Text.Trim() + "')";
                                    }

                                }
                                else
                                {

                                    {
                                        query33 = "Insert Into itemlist Values('" + textBox3.Text + "','" + adName.Text.Trim().ToUpper() + "','" + adCateg.Text + "','" + adOrigP.Text.Trim() + "','" + adSRP.Text.Trim() + "','" + adUnit.Text.Trim() + "','" + adQuan.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox5.Text.Trim() + "')";
                                    }

                                }

                                dbQuery(query33);
                                savebarcode();
                                MessageBox.Show("Item was successfuly added.");
                                label30.Text = "";
                                adName.Text = "";
                                adCateg.Text = "";
                                adOrigP.Text = "";
                                adSRP.Text = "";
                                adUnit.Text = "";
                                adQuan.Text = "";
                                textBox1.Text = "";
                                textBox3.Text = "";
                                textBox5.Text = "";
                                textBox7.Text = "30";
                                UpdateGrid();
                                textBox3.Focus();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error adding item information. \nPlease check all fields.");
                    }
                
            }
            ii = 1;
        }
        private void savebarcode()
        {
           
            {
                pictureBox1.Image.Save(Application.StartupPath.ToString() + "//Barcodes//"+textBox3.Text.Trim()+" "+adName.Text+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
               
              
            }
          
        }
        private void glassButton3_Click(object sender, EventArgs e)
        {
            addItem();
         
        }
        int countupg = 0;
        private void UpdateGrid()
        {
            countupg++;
            int countitems = 0;
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
                query = "Select * from itemlist  WHERE item_name LIKE '%" + textBox6.Text + "%' AND supp LIKE '%" + comboBox1.Text + "%' AND categ LIKE '%" + comboBox2.Text + "%' ORDER BY item_name";
                dbFill(query);
                while (dbReader.Read())
                {
                    countitems++;
                  
                    {
                        dataGridView1.Rows.Add(dbReader["item_no"].ToString(), dbReader["item_name"].ToString(), dbReader["categ"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["oprice"].ToString());

                    }
                    allitems = dbReader["quan"].ToString() + allitems;

                }
                dbReader.Close();
                dbConn.Close();
            }
            if (countupg > 1)
            {
                label37.Text = countitems.ToString() + " result(s) found";
            }
           
        }
        string typess = "";
        private void unitss()
        {
            adUnit.Items.Clear();
            edUnit.Items.Clear();
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
                query = "Select * from unittable ORDER BY unit_name";
                dbFill(query);
                while (dbReader.Read())
                {
                    adUnit.Items.Add(dbReader["unit_name"].ToString());
                    edUnit.Items.Add(dbReader["unit_name"].ToString());

                }
                dbReader.Close();
                dbConn.Close();
            }
        }
        private void newcode()
        {
            countitems = 0;
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
                query = "Select * from itemlist ORDER BY item_no ASC";
                dbFill(query);
                while (dbReader.Read())
                {
                    countitems = int.Parse(dbReader["item_no"].ToString());
                    countitems++;

                }
                dbReader.Close();
                dbConn.Close();
            }

           string itemsco = countitems.ToString();
           if (itemsco.Length == 1)
            {
                label30.Text = "0000" + countitems.ToString();
               textBox3.Text= "0000" + countitems.ToString();
            }
            else if (itemsco.Length == 2)
            {
                label30.Text = "000" + countitems.ToString();  textBox3.Text = "000" + countitems.ToString(); 
            }
            else if (itemsco.Length == 3)
            {
                label30.Text = "00" + countitems.ToString();  textBox3.Text= "00" + countitems.ToString(); 
            }
            else if (itemsco.Length == 4)
            {
                label30.Text = "0" + countitems.ToString(); textBox3.Text = "0" + countitems.ToString();
            }
            else
            {
                label30.Text = countitems.ToString(); textBox3.Text = countitems.ToString();
            }
           


        }
        int timex = 0;
        private void Items_Load(object sender, EventArgs e)
        {
            
            if (label30.Visible == true)
            {
                label30.Focus();
            }
            else
            {
                textBox3.Focus();
            }

            if ((label30.Text.Length == 0) || (textBox3.Text.Length == 0))
            {
                panel2.Enabled = false;
                adName.Enabled = false;
                adCateg.Enabled = false;
                textBox1.Enabled = false;
              //  glassButton4.Enabled = false;
            }
            else
            {
                panel2.Enabled = true;
                adName.Enabled = true;
                adCateg.Enabled = true;
                textBox1.Enabled = true;
                glassButton4.Enabled = true;
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
                query = "Select * from suppliers ORDER BY supplier";
                dbFill(query);
                while (dbReader.Read())
                {
                    comboBox1.Items.Add(dbReader["supplier"].ToString());
                    textBox2.Items.Add(dbReader["supplier"].ToString());

                }
                dbReader.Close();
                dbConn.Close();
            }
            if (supps != "")
            {
                comboBox1.Text = supps;
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
                query = "Select categ from itemlist WHERE supp = '" + comboBox1.Text + "' ORDER BY categ ";
                dbFill(query);
                while (dbReader.Read())
                {
                    edCateg.Items.Add(dbReader["categ"].ToString());
                    adCateg.Items.Add(dbReader["categ"].ToString());

                }
                dbReader.Close();
                dbConn.Close();
                
            }
            getName();
            UpdateGrid();
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
                        textBox3.Visible = false;
                        label30.Visible = true;
                        typess = "manual";
                    }
                    else
                    {
                        label30.Visible = false;
                        textBox3.Visible = true;

                        typess = "barcode";
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
                query = "Select * from categories ORDER BY categ";
                dbFill(query);
                while (dbReader.Read())
                {

                    adCateg.Items.Add(dbReader["categ"].ToString());
                    edCateg.Items.Add(dbReader["categ"].ToString());

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
                query = "Select supplier from suppliers ";
                dbFill(query);
                while (dbReader.Read())
                {


                    textBox1.AutoCompleteCustomSource.Add(dbReader["supplier"].ToString());


                    textBox2.AutoCompleteCustomSource.Add(dbReader["supplier"].ToString());

                }
                dbReader.Close();
                dbConn.Close();
            }
            if (itemss != "")
            {
                try
                {
                    if (dataGridView1.CurrentRow.Cells[5].Value.ToString().Contains("NA") == false)
                    {
                        edExp.Enabled = true;
                    }
                    else
                    {
                        edExp.Enabled = false;
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
                        query = "Select * from itemlist WHERE item_no = '" + itemss + "'";
                        dbFill(query);
                        while (dbReader.Read())
                        {

                            edName.Text = dbReader["item_name"].ToString();
                            edCateg.Text = dbReader["categ"].ToString();

                            edExp.Text = dbReader["exp_date"].ToString();
                            edPri.Text = dbReader["origprice"].ToString();
                            edSRP.Text = dbReader["srp"].ToString();
                            edUnit.Text = dbReader["unit"].ToString();
                            edQuan.Text = dbReader["quan"].ToString();
                            textBox2.Text = dbReader["supp"].ToString();
                            label25.Text = dbReader["item_no"].ToString();
                            label24.Text = dbReader["item_no"].ToString();
                            label29.Text = dbReader["item_name"].ToString();
                            dataGridView1.CurrentCell.Value = (itemss);

                        }
                        dbReader.Close();
                        dbConn.Close();
                    }
                }
                catch { }
            }
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    allitems = dataGridView1.Rows[i].Cells[3].Value.ToString() + allitems;
            //}
            timer1.Enabled = true;
            timex = 0;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            unitss();
        }
        string name = "";
        public void getName()
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
                query = "Select * from logs where userna = '" + user + "'";
                dbFill(query);
                while (dbReader.Read())
                {


                    name = (dbReader["names"].ToString());


                }
                dbReader.Close();
                dbConn.Close();
            }
        }
      
        private void glassButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this item?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
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
                        query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + user + "','" + "Updated item " + edName.Text + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

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
                            query33 = "Update itemlist Set oprice = '"+textBox4.Text.Trim()+"', item_name = '" + edName.Text.Trim().ToUpper() + "', categ = '" + edCateg.Text + "', origprice = '" + Convert.ToDecimal(edPri.Text.Trim().ToUpper()) + "', srp = '" + Convert.ToDecimal(edSRP.Text.Trim().ToUpper()) + "', unit = '" + edUnit.Text.Trim().ToUpper() + "', quan = '" + Convert.ToInt32(edQuan.Text.Trim().ToUpper()) + "', supp = '" + textBox2.Text.Trim().ToUpper() + "' Where item_no = '" + label25.Text + "'";

                        }
                       
                        dbQuery(query33);

                        MessageBox.Show("Item was successfuly updated."); UpdateGrid();

                    }
                }
                catch
                {
                    MessageBox.Show("Error updating item information. \nPlease check all fields.");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
          
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString().Contains("NA") == false)
                {
                    edExp.Enabled = true;
                }
                else
                {
                    edExp.Enabled = false;
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
                    query = "Select * from itemlist WHERE item_no = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        edName.Text = dbReader["item_name"].ToString();
                        edCateg.Text = dbReader["categ"].ToString();
                        textBox4.Text = dbReader["oprice"].ToString();
                      
                        edPri.Text = dbReader["origprice"].ToString();
                        edSRP.Text = dbReader["srp"].ToString();
                        edUnit.Text = dbReader["unit"].ToString();
                        edQuan.Text = dbReader["quan"].ToString();
                        textBox2.Text = dbReader["supp"].ToString();
                        label25.Text = dbReader["item_no"].ToString();
                        label24.Text = dbReader["item_no"].ToString();
                        label29.Text = dbReader["item_name"].ToString();
                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
            catch { }
        }
       
        private void glassButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
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
                        query33 = "Insert Into security Values('" + System.DateTime.Now.ToString() + "(" + System.DateTime.Now.Millisecond.ToString() + ")_" + user + "','" + "Deleted item " +label29.Text + "','" + System.DateTime.Now.ToString() + "','" + name + "','"+terms()+"')";

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
                            query33 = "DELETE FROM itemlist Where item_no = '" + label24.Text + "'";

                        }

                        dbQuery(query33);

                        MessageBox.Show("Item was successfuly deleted."); UpdateGrid();

                    }
                }
                catch
                {
                    MessageBox.Show("Error updating item information. \nPlease check all fields.");
                }
            }
        }

        private void edCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private string idcomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Millisecond.ToString();
            return ax;
        }
        int ii = 1;
        private void adCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cat = ""; string idtype = ""; ii = 1;
            if (typess == "manual")
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
                    query = "Select * from categories  where categ = '" + adCateg.Text + "' ";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        cat = dbReader["categ_id"].ToString().Replace("CAT", "IT");


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
                    query = "Select * from itemlist WHERE categ ='" + adCateg.Text + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        ii++;
                      //  label30.Text = cat + ii.ToString();


                    }
                    dbReader.Close();
                    dbConn.Close();
                    if (ii == 1)
                    {
                       // label30.Text = cat + "1";
                    }
                }
            }
            else
            {
            }

        }

        private void glassButton4_Click(object sender, EventArgs e)
        {
            Categories uu = new Categories();
            uu.Show();
        }

        private void adCateg_Click(object sender, EventArgs e)
        {
            adCateg.Items.Clear();
            edCateg.Items.Clear();
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
                query = "Select * from categories ORDER BY categ";
                dbFill(query);
                while (dbReader.Read())
                {

                    adCateg.Items.Add(dbReader["categ"].ToString());
                    edCateg.Items.Add(dbReader["categ"].ToString());

                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                adName.Focus();
            }
        }

        private void adName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                adCateg.Focus();
            }
        }

        private void adCateg_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                adOrigP.Focus();
            }
        }

        private void adSRP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                textBox5.Focus();
               // adUnit.Focus();
            }
        }

        private void adOrigP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                adSRP.Focus();
            }
        }

        private void adUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                adQuan.Focus();
            }
        }

        private void adQuan_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                addItem();
            }
        }

        private void adSRP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
               // textBox5.Focus();
                textBox7.Focus();
              //   adUnit.Focus();
            }
        }

        private void label30_TextChanged(object sender, EventArgs e)
        {
            bool idexist = false;
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
                query = "Select * from itemlist WHERE item_no ='" + label30.Text + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    idexist = true;


                }
                dbReader.Close();
                dbConn.Close();
            }
            if (idexist == true)
            {
                countitems++;
                string itemsco = countitems.ToString();
                if (itemsco.Length == 1)
                {
                    label30.Text = "0000" + countitems.ToString();
                    textBox3.Text = "0000" + countitems.ToString();
                }
                else if (itemsco.Length == 2)
                {
                    label30.Text = "000" + countitems.ToString(); 
                    textBox3.Text = "000" + countitems.ToString();
                }
                else if (itemsco.Length == 3)
                {
                    label30.Text = "00" + countitems.ToString(); 
                    textBox3.Text = "00" + countitems.ToString();
                }
                else if (itemsco.Length == 4)
                {
                    label30.Text = "0" + countitems.ToString(); 
                    textBox3.Text = "0" + countitems.ToString();
                }
                else
                {
                    label30.Text = countitems.ToString(); 
                    textBox3.Text = countitems.ToString();
                }
            }
            else
            {
                if ((label30.Text.Length == 0))
                {
                    newcode();

                }
                else
                {
                    panel2.Enabled = true;
                    adName.Enabled = true;
                    adCateg.Enabled = true;
                    textBox1.Enabled = true;
                    glassButton4.Enabled = true;
                }
                DisplayBarcode();
            }
        }

        private void label30_KeyPress(object sender, KeyPressEventArgs e)
        {
          
           
        }
        private void DisplayBarcode()
        {
            pictureBox1.Image = GenerateBarcode("*" + textBox3.Text.ToUpper() + "*", adName.Text);
            pictureBox1.Size = new Size(pictureBox1.Image.Width, pictureBox1.Image.Height);
          //  pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, 74);
            pictureBox1.Visible = true;
        }

        private Bitmap GenerateBarcode(string bCode, string item)
        {
            string malayan = "Malayan Colleges Laguna";
            Bitmap barCode = new Bitmap(1, 1);
            System.Drawing.Font code39 = new Font("3 of 9 Barcode", 35, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Graphics grp = Graphics.FromImage(barCode);
            SizeF dataSize = grp.MeasureString(bCode, code39);
            SizeF strSize = grp.MeasureString(bCode, new Font("Arial", 10));
            SizeF strMalayan = grp.MeasureString(malayan, new Font("Arial", 10));
            SizeF strItem = grp.MeasureString(item, new Font("Arial", 10));
            dataSize.Height += (strSize.Height + strMalayan.Height + strItem.Height);
            if (strMalayan.Width > dataSize.Width)
            {
                dataSize.Width = strMalayan.Width;
            }
            if (strItem.Width > dataSize.Width)
            {
                dataSize.Width = strItem.Width;
            }
            barCode = new Bitmap(barCode, dataSize.ToSize());
            grp = Graphics.FromImage(barCode);
            grp.Clear(Color.White);
            grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            grp.DrawString(malayan, new Font("Arial", 8), new SolidBrush(Color.Black), 0, 0);
            grp.DrawString(item, new Font("Arial", 8), new SolidBrush(Color.Black), 0, strMalayan.Height);
            grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            grp.DrawString(bCode, code39, new SolidBrush(Color.Black), 0, strItem.Height + strMalayan.Height);
            StringBuilder sb = new StringBuilder();
            foreach (char c in bCode)
            {
                if (c == '*')
                {
                    bCode = bCode.Remove(bCode.IndexOf(c), 1);
                }
            }
            grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            grp.DrawString(bCode, new Font("Arial", 8), new SolidBrush(Color.Black), ((int)dataSize.Width - (int)strSize.Width) / 2, (dataSize.Height - strSize.Height) - 5);
            grp.Flush();
            code39.Dispose();
            grp.Dispose();
            return barCode;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((label30.Text.Length == 0) || (textBox3.Text.Length == 0))
            {
                panel2.Enabled = false;
                adName.Enabled = false;
                adCateg.Enabled = false;
                textBox1.Enabled = false;
                glassButton4.Enabled = false;
            }
            else
            {
                panel2.Enabled = true;
                adName.Enabled = true;
                adCateg.Enabled = true;
                textBox1.Enabled = true;
                glassButton4.Enabled = true;
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if ((label30.Text.Length == 0) || (textBox3.Text.Length == 0))
            {
                panel2.Enabled = false;
                adName.Enabled = false;
                adCateg.Enabled = false;
                textBox1.Enabled = false;
                glassButton4.Enabled = false;
            }
            else
            {
                panel2.Enabled = true;
                adName.Enabled = true;
                adCateg.Enabled = true;
                textBox1.Enabled = true;
                glassButton4.Enabled = true;
            }
        }

        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {
             bool idexist=false;
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
                query = "Select * from itemlist WHERE item_no ='" + textBox3.Text + "'";
                dbFill(query);
                while (dbReader.Read())
                {
                    idexist = true;
                   

                }
                dbReader.Close();
                dbConn.Close();
            }
            if (idexist == true)
            {
                MessageBox.Show("Item code already exist.");
                textBox3.Text = "";
            }
            else
            {
                if ((textBox3.Text.Length == 0))
                {
                    newcode();
                }
                else
                {
                    panel2.Enabled = true;
                    adName.Enabled = true;
                    adCateg.Enabled = true;
                    textBox1.Enabled = true;
                    glassButton4.Enabled = true;
                }
                DisplayBarcode();
            }
        }

        private void label30_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {

                adName.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double markup = 0;
            if (textBox5.Text == "")
            {
            }
            else
            {
                double mem = 0;
                try
                {
                    markup = Convert.ToDouble(textBox5.Text);
                    mem = (markup * (Convert.ToDouble(textBox7.Text) * 0.01));
                    markup = markup + mem;
                    markup = Math.Round(markup, 2);
                    adSRP.Text = markup.ToString();
                }
                catch
                {
                    MessageBox.Show("Invalid Input!");
                    textBox5.Text = "0";
                    textBox5.Focus();
                }

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                UpdateGrid();
            }
            else
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
                    query = "Select * from itemlist  WHERE item_no LIKE '%" + textBox6.Text + "%' ORDER BY item_name";
                    dbFill(query);
                    while (dbReader.Read())
                    {
                        
                        {
                            dataGridView1.Rows.Add(dbReader["item_no"].ToString(), dbReader["item_name"].ToString(), dbReader["categ"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["oprice"].ToString());

                        }


                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
        }
        private void clearbox()
        {
            edCateg.Items.Clear();
            comboBox2.Items.Clear();
            adCateg.Items.Clear();
        

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            unitss();
            clearbox();
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
                query = "Select DISTINCT categ from itemlist WHERE supp = '" + comboBox1.Text + "' ORDER BY categ ";
                dbFill(query);
                while (dbReader.Read())
                {
                    edCateg.Items.Add(dbReader["categ"].ToString());
                    adCateg.Items.Add(dbReader["categ"].ToString());
                    comboBox2.Items.Add(dbReader["categ"].ToString()); 

                }
                dbReader.Close();
                dbConn.Close();
                
            }

            textBox1.Text = comboBox1.Text;
            textBox2.SelectedIndex = comboBox1.SelectedIndex;
            UpdateGrid();
            newcode();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            edCateg.Text = comboBox2.Text;
            adCateg.Text = comboBox2.Text;
            UpdateGrid();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                adUnit.Focus();
                // adUnit.Focus();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            double markup = 0;
            if (textBox7.Text == "")
            {
                textBox7.Text = "0";
            }
            else
            {
                double mem = 0;
                try
                {
                    markup = Convert.ToDouble(textBox5.Text);
                    mem = (markup * (Convert.ToDouble(textBox7.Text) * 0.01));
                    markup = markup + mem;
                    markup = Math.Round(markup, 2);
                    adSRP.Text = markup.ToString();
                }
                catch
                {
                    MessageBox.Show("Invalid Input!");
                    textBox5.Text = "0";
                    textBox5.Focus();
                }

            }
        }

        private void adName_TextChanged(object sender, EventArgs e)
        {
            DisplayBarcode();
        }

        private void glassButton5_Click(object sender, EventArgs e)
        {
            Suppliers ss = new Suppliers(user);
            ss.Show();
            this.Hide();
        }

        private void glassButton6_Click(object sender, EventArgs e)
        {
            Unit ss = new Unit();
            ss.ShowDialog();
           
        }

        private void edUnit_Click(object sender, EventArgs e)
        {
            unitss();
        }

        private void adUnit_Click(object sender, EventArgs e)
        {
            unitss();
        }
        string allitems = "";
        string allitems2 = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
        //    timex++;
        //    if (timex == 1)
        //    {


        //    }
        //    else
        //    {
        //        {
        //            string query;

        //            StreamReader sr = new StreamReader(Application.StartupPath.ToString() + "//data.txt");
        //            line = sr.ReadLine();
        //            StreamReader sr3 = new StreamReader(Application.StartupPath.ToString() + "//dataP.txt");
        //            dbP = sr3.ReadLine();
        //            StreamReader sr4 = new StreamReader(Application.StartupPath.ToString() + "//dataU.txt");
        //            dbU = sr4.ReadLine();
        //            string sConnection = "SERVER=" + line + ";" + "DATABASE=lamolinventory;" + "UID=" + dbU + ";" + "PASSWORD='" + dbP + "';";
        //            MySqlConnection sqlConnection = new MySqlConnection(sConnection);
        //            query = "Select * from itemlist  WHERE item_no LIKE '%" + textBox6.Text + "%' ORDER BY item_name";
        //            dbFill(query);
        //            while (dbReader.Read())
        //            {
        //                {
        //                    allitems2 = dbReader["quan"].ToString() + allitems2;
        //                }
        //            }
        //            dbReader.Close();
        //            dbConn.Close();
        //            if (allitems != allitems2)
        //            {
        //                UpdateGrid();
        //                allitems = allitems2;
        //            }

        //            allitems2 = "";
        //            timex = 0;
        //        }

        //    }
        }
    }
}