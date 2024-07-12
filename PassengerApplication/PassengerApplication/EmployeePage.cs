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
    public partial class EmployeePage : Form
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void EmployeePage_Load(object sender, EventArgs e)
        {
            List<Trains> customers = new List<Trains>();
            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];


            var command = "Select * from Trains";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            Utility.TrainsList = new List<Trains>();
            foreach (DataRow dr in dt.Rows)
            {

                var tempUser = new Trains
                {
                    Id = Convert.ToInt32(dr["TrainId"]),
                    TrainName = dr["name"].ToString(),
                    From = dr["From"].ToString(),
                    To = dr["To"].ToString()
                };
                if (tempUser != null)
                {
                    customers.Add(tempUser);
                }

                Utility.TrainsList.AddRange(customers);
            }


            foreach (var cust in customers)
            {
                comboBox1.Items.Add(cust.TrainName.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {  
 
            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];
            var command1 = "Select * from Trains where name = " + "'" + this.comboBox1.Text + "'";
            OleDbDataAdapter adapter1 = new OleDbDataAdapter();
            OleDbCommand command21 = new OleDbCommand(command1, oleDbConnection);
            adapter1.SelectCommand = command21;
            var ds = new DataSet();
            adapter1.Fill(ds);
            var dt = ds.Tables[0];

            int trainId = 0;
            foreach (DataRow dr in dt.Rows)
            {
                trainId = Convert.ToInt32(dr["TrainId"]);
            }

           // var trainId = Utility.TrainsList.Single(x => x.TrainName == this.comboBox1.Text).Id;
           

            var date = Convert.ToDateTime(dateTimePicker1.Text).Date;

            var cmd = "Select * from Passengers where TrainID = " + trainId;
            OleDbDataAdapter adp = new OleDbDataAdapter();
            OleDbCommand cmd2 = new OleDbCommand(cmd, oleDbConnection);
            adp.SelectCommand = cmd2;
           var ds1 = new DataSet();
            adp.Fill(ds1);
            var dt1 = ds1.Tables[0];

            var passInfo = new List<PassengerInfo>();
            foreach (DataRow dr in dt1.Rows)
            {
                var info = new PassengerInfo
                {
                    PassengerId = dr["PassengerID"].ToString(),
                    FirstName = dr["first_name"].ToString(),
                    LastName = dr["last_name"].ToString(),
                    TrainName = this.comboBox1.Text,
                    TicketCount = dr["TicketCount"].ToString(),
                    Amount = dr["Amount"].ToString(),
                    Class = dr["Class"].ToString(),
                    PaymentMode = dr["PaymentMode"].ToString(),
                    DOJ = dr["DOJ"].ToString(),
                    DOB = dr["DOB"].ToString(),
                };
                passInfo.Add(info);
            }

            this.dataGridView1.DataSource = passInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEmployee emp = new AddEmployee();
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddSchedule sch = new AddSchedule();
            sch.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddPrice prc = new AddPrice();
            prc.Show();
        }
    }
}
