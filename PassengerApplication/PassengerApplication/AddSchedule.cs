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
    public partial class AddSchedule : Form
    {
        List<Trains> customers = new List<Trains>();
        List<Schedule> schedules = new List<Schedule>();
        public AddSchedule()
        {
            InitializeComponent();
        }

        private void AddSchedule_Load(object sender, EventArgs e)
        {

            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];


            var command = "Select * from Trains";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
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
            }

            var cmd = "Select * from Schedules";
            OleDbDataAdapter adapter2 = new OleDbDataAdapter();
            OleDbCommand cmd2 = new OleDbCommand(cmd, oleDbConnection);
            adapter2.SelectCommand = cmd2;
            var ds1 = new DataSet();
            adapter2.Fill(ds1);
            var dt1 = ds1.Tables[0];

            foreach (DataRow dr in dt1.Rows)
            {
                var tempUser = new Schedule
                {
                    Id = Convert.ToInt32(dr["ScheduleID"]),
                    ArrivalTime = dr["Arrival Time"].ToString(),
                    DepartureTime = dr["Departure Time"].ToString(),
                    TrainId = Convert.ToInt32(dr["TrainID"])
                };
                if (tempUser != null)
                {
                    schedules.Add(tempUser);
                }
            }

            //foreach(var x in customers)
            //{
            //    foreach(var y in schedules)
            //    {
            //        if(y.TrainId != x.Id)
            //        {
            //            comboBox1.Items.Add(x.TrainName);
            //            break;
            //        }
            //    }

            //}

            foreach(var x in customers)
            {
                var train = schedules.Where(y => y.TrainId == x.Id).ToList();

                if(train.Count == 0)
                {
                    comboBox1.Items.Add(x.TrainName);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var trainID = customers.Where(x => x.TrainName == this.comboBox1.Text).FirstOrDefault().Id;
            var oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];
            oleDbConnection.Open();
            var command = String.Format("Insert INTO [Schedules] ([Arrival Time], [Departure Time], [Platform Number], [TrainID]) VALUES ('{0}', '{1}', '{2}', '{3}')", textBox4.Text, textBox1.Text, textBox2.Text, trainID);
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
            MessageBox.Show("Schedule Added !!");
            this.Close();
        }
    }
}
