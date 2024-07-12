using PassengerApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassengerApplication
{
    public partial class BookingPage : Form
    {
        public BookingPage()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void BookingPage_Load(object sender, EventArgs e)
        {
            label2.Text = Utility.SelectedTrain.TrainName;
            label4.Text = Utility.SelectedTrain.From;
            label6.Text = Utility.SelectedTrain.To;
            label8.Text = Utility.SelectedTrain.ArrivalTimings[0];
            label10.Text = Utility.SelectedTrain.DepatureTimings[0];
            comboBox1.Items.Add("Sleeper");
            comboBox1.Items.Add("1 AC");
            comboBox1.Items.Add("2 AC");
            comboBox1.Items.Add("3 AC");

            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];


            var command = "Select * from Price where TrainID = " + Utility.SelectedTrain.Id + "and Class = " + "'" + this.comboBox1.Text + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                label15.Text = dr["Price"].ToString();
                Utility.Price = Convert.ToInt32(label15.Text);
            }

          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];


            var command = "Select * from Price where TrainID = " + Utility.SelectedTrain.Id + "and Class = "+"'" + this.comboBox1.Text + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                label15.Text = dr["Price"].ToString();
                Utility.Price = Convert.ToInt32(label15.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utility.JourneyDate = dateTimePicker1.Value;
            Utility.Count = Convert.ToInt32(textBox1.Text);
            Utility.Class = comboBox1.Text;
            PaymentPage page = new PaymentPage();
            page.Show();
            this.Close();
            //OleDbConnection oleDbConnection = new OleDbConnection();
            //oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];


            //var command = String.Format("Insert INTO [Booking] ([first_name], [last_name], [email], [mobile], [Address], [username], [password], [role]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, maskedTextBox1.Text, 2);
            //OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            //command2.ExecuteNonQuery();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
