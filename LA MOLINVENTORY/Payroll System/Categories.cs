using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using MySql.Data.MySqlClient;
namespace Payroll_System
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
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
        private void Categories_Load(object sender, EventArgs e)
        {
            try
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
                    query = "Select * from categories ORDER BY categ";
                    dbFill(query);
                    while (dbReader.Read())
                    {

                        dataGridView1.Rows.Add(dbReader["categ"].ToString(), dbReader["categ_id"].ToString());


                    }
                    dbReader.Close();
                    dbConn.Close();
                }
            }
            catch { }
        }
        private string idcomponent()
        {
            string ax = System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            return ax;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add this category?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    query33 = "Insert Into categories Values('" + textBox1.Text.Substring(0,3).ToUpper() + idcomponent() + "','" + textBox1.Text + "')";
                }

                dbQuery(query33);
                
                MessageBox.Show("Category was successfuly added.");
               
                this.Hide();


            }
        
           
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                        {
                            query33 = "DELETE FROM categories Where categ_id = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";

                        }

                        dbQuery(query33);

                        MessageBox.Show("Item was successfuly deleted.");
                        this.Hide();

                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string innames = "";
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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

                {
                    query33 = "UPDATE itemlist SET categ  = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' Where item_no IN ('" + innames + "')";

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
                    query33 = "UPDATE categories SET categ  = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' Where categ_id = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";

                }

                dbQuery(query33);

                MessageBox.Show("Item was successfuly updated.");
                this.Hide();

            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                innames = "";
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
                    query = "Select * from itemlist WHERE categ = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    dbFill(query);
                    while (dbReader.Read())
                    {



                        innames = dbReader["item_no"].ToString() + "','" + innames;

                    }
                    dbReader.Close();
                    dbConn.Close();
                    
                    //MessageBox.Show(innames);
                }
            }
            catch { }
        }
    }
}