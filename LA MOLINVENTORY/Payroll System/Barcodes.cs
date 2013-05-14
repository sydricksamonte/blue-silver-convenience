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
    public partial class Barcodes : Form
    {
        public Barcodes()
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
        private void Barcodes_Load(object sender, EventArgs e)
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
                query = "Select * from barcodes WHERE bartype = '"+1+"' ";
                dbFill(query);
                while (dbReader.Read())
                {
                    if (dbReader["types"].ToString() == "manual")
                    {
                        radioButton2.Checked = true;
                        typer = "manual";
                    }
                    else
                    {
                        radioButton1.Checked = true;
                        typer = "barcode";
                    }




                }
                dbReader.Close();
                dbConn.Close();
            }
        }

        private void glassButton2_Click(object sender, EventArgs e)
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
                    query33 = " Update barcodes Set types = '" + typer + "' Where  bartype  = '" + 1 + "'";
                }

                dbQuery(query33);
                MessageBox.Show("Successfully updated encoding type");
                this.Close();
               
            }
        }
        string typer = "";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                typer = "barcode";
            }
            else
            {
                typer = "manual";
            }
        }
    }
}