using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class PaymentPage : Form
    {
        public PaymentPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];

            oleDbConnection.Open();
            var command = String.Format("Insert INTO [Passengers] ([first_name], [last_name], [email], [TrainID], [TicketCount], [Amount], [DOJ], [DOB], [Class], [PaymentMode]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", textBox1.Text, textBox2.Text, textBox3.Text, Utility.SelectedTrain.Id, Utility.Count, Utility.Price * Utility.Count, Utility.JourneyDate.Date, DateTime.Now.Date, Utility.Class,comboBox2.Text );
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();


            //var command23 = String.Format("Insert INTO [Booking] ([first_name], [last_name], [email], [TrainID], [TicketCount], [Amount], [DOJ], [DOB], [Class]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", textBox1.Text, textBox2.Text, textBox3.Text, Utility.SelectedTrain.Id, Utility.Count, Utility.Price * Utility.Count, Utility.JourneyDate, DateTime.Now, comboBox2.SelectedValue);
            //OleDbCommand command33 = new OleDbCommand(command23, oleDbConnection);
            //command33.ExecuteNonQuery();

            MessageBox.Show("Payment Sucessfull");

            TrainListPage page = new TrainListPage();
            page.Show();
            this.Close();
        }

        private void PaymentPage_Load(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(Utility.Price * Utility.Count);
            comboBox2.Items.Add("Debit Card");
            comboBox2.Items.Add("Credit Card");
            comboBox2.Items.Add("Pay Later");
        }
    }
}
