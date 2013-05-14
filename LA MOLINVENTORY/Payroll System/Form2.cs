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
    public partial class Form2 : Form
    {
        string user = "";
        string itemss = "";
        public Form2(string a, string b)
        {
            InitializeComponent(); user = a;
            itemss = b;
        }
        string line, line2;
        MySqlDataReader dbReader;
        MySqlConnection dbConn;
        string dbP;
        string dbU;
        string types;
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
                if (MessageBox.Show("Are you sure you want to add this item?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                                if (adExpiir.Enabled == true)
                                {
                                    query33 = "Insert Into itemlist Values('" + label30.Text.Trim().ToUpper() + "','" + adName.Text.Trim().ToUpper() + "','" + adCateg.Text + "','" + adOrigP.Text.Trim() + "','" + adSRP.Text.Trim() + "','" + adUnit.Text.Trim() + "','" + adQuan.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox5.Text.Trim() + "')";
                                }
                                else
                                {
                                    query33 = "Insert Into itemlist Values('" + label30.Text.Trim().ToUpper() + "','" + adName.Text.Trim().ToUpper() + "','" + adCateg.Text + "','" + adOrigP.Text.Trim() + "','" + adSRP.Text.Trim() + "','" + adUnit.Text.Trim() + "','" + adQuan.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox5.Text.Trim() + "')";
                             
                                }
                            }
                            else
                            {
                                if (adExpiir.Enabled == true)
                                {
                                    query33 = "Insert Into itemlist Values('" + textBox3.Text + "','" + adName.Text.Trim().ToUpper() + "','" + adCateg.Text + "','" + adOrigP.Text.Trim() + "','" + adSRP.Text.Trim() + "','" + adUnit.Text.Trim() + "','" + adQuan.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox5.Text.Trim() + "')";
                                }
                                else
                                {
                                    query33 = "Insert Into itemlist Values('" + textBox3.Text + "','" + adName.Text.Trim().ToUpper() + "','" + adCateg.Text + "','" + adOrigP.Text.Trim() + "','" + adSRP.Text.Trim() + "','" + adUnit.Text.Trim() + "','" + adQuan.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox5.Text.Trim() + "')";

                                }
                            }

                            dbQuery(query33);

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

                            UpdateGrid();
                            textBox3.Focus();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error adding item information. \nPlease check all fields.");
                    }
                }
            }
            ii = 1;
        }
        private void glassButton3_Click(object sender, EventArgs e)
        {
            addItem();
        }
        private void UpdateGrid()
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
                query = "Select * from itemlist  WHERE item_name LIKE '%" + textBox6.Text + "%' ORDER BY item_name";
                dbFill(query);
                while (dbReader.Read())
                {

                    {
                        dataGridView1.Rows.Add(dbReader["item_no"].ToString(), dbReader["item_name"].ToString(), dbReader["categ"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["oprice"].ToString(), dbReader["exp_date"].ToString());

                    }


                }
                dbReader.Close();
                dbConn.Close();
            }
           
        }
        string typess = "";
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
                                dataGridView1.CurrentCell.Value=(itemss);
                               
                            }
                            dbReader.Close();
                            dbConn.Close();
                        }
                    }
                    catch { }
                }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                            query33 = "Update itemlist Set oprice = '"+textBox4.Text.Trim()+"', item_name = '" + edName.Text.Trim().ToUpper() + "', categ = '" + edCateg.Text + "', exp_date = '" + (edExp.Value.Year.ToString() + "/" + edExp.Value.Month.ToString() + "/" + edExp.Value.Day.ToString()) + "', origprice = '" + Convert.ToDecimal(edPri.Text.Trim().ToUpper()) + "', srp = '" + Convert.ToDecimal(edSRP.Text.Trim().ToUpper()) + "', unit = '" + edUnit.Text.Trim().ToUpper() + "', quan = '" + Convert.ToInt32(edQuan.Text.Trim().ToUpper()) + "', supp = '" + textBox2.Text.Trim().ToUpper() + "' Where item_no = '" + label25.Text + "'";

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
                        edExp.Text = dbReader["exp_date"].ToString();
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
                 adUnit.Focus();
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
                MessageBox.Show("Item code already exist.");
                label30.Text = "";
            }
            else
            {
                if ((label30.Text.Length == 0))
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
        }

        private void label30_KeyPress(object sender, KeyPressEventArgs e)
        {
          
           
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
                    mem = (markup * 0.3);
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
                            dataGridView1.Rows.Add(dbReader["item_no"].ToString(), dbReader["item_name"].ToString(), dbReader["categ"].ToString(), dbReader["quan"].ToString(), dbReader["srp"].ToString(), dbReader["oprice"].ToString(), dbReader["exp_date"].ToString());

                        }


                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
}