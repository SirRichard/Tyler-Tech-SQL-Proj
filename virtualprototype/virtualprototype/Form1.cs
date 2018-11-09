using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace virtualprototype
{
    public partial class Form1 : Form
    {

        private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();

        public Form1()
        {   
            InitializeComponent();
            String waitTimeScript = File.ReadAllText(@"..\..\..\..\Resources\Scripts\Script2_waitTime.sql");
            String IOUtilization = File.ReadAllText(@"..\..\..\..\Resources\Scripts\Script3_IOutilization.sql");
          
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "10.31.171.74";   // update 
                builder.UserID = "sa";              // update me
                builder.Password = "your_password";      // update me
               builder.InitialCatalog = "master";

                 //Connect to SQL
                // Console.Write("Connecting to SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    SqlCommand WaitTimeScriptCommand= connection.CreateCommand();
                    WaitTimeScriptCommand.CommandText = waitTimeScript;
                    SqlDataReader WaitTimeResult = WaitTimeScriptCommand.ExecuteReader();
                    fillChart(WaitTimeResult,"wait time");
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.ToString());
            }
            
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Disk_Click(object sender, EventArgs e)
        {

        }

        private void Memory_Click(object sender, EventArgs e)
        {

        }

        private void CPU_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void Print_Click(Object sender, EventArgs e)
        {
           
            printDialog1.AllowSomePages = true;
           
            printDialog1.ShowHelp = true;
          
            printDialog1.Document = docToPrint;

            DialogResult result = printDialog1.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }

        }
        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

         
            string text = "In document_PrintPage method.";
            System.Drawing.Font printFont = new System.Drawing.Font
                ("Arial", 35, System.Drawing.FontStyle.Regular);

            e.Graphics.DrawString(text, printFont,
                System.Drawing.Brushes.Black, 10, 10);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void fillChart(SqlDataReader Result,String seriesType)
        {
            while (Result.Read())
            {
                chart1.Series[seriesType].Points.AddXY((string)Result[0],(string)Result[1]);
                //AddXY value in chart1 in series named as Salary  
                //chart title  
                chart1.Titles.Add("Salary Chart");
            }
        }
    }
}
