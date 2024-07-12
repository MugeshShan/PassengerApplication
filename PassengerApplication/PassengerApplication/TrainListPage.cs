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
    public partial class TrainListPage : Form
    {
        public TrainListPage()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TrainListPage_Load(object sender, EventArgs e)
        {
            Utility.TrainsList = new List<Trains>();
            Utility.Train = new Trains();
            Utility.SelectedTrain = new Trains();
            Utility.Price = 0;
            Utility.Count = 0;
            Utility.JourneyDate = new DateTime();
            Utility.Class = null;

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
                    Utility.TrainsList.Add(tempUser);
                }

            }


            foreach (var cust in customers)
            {
               comboBox1.Items.Add(cust.From.ToString());
               comboBox2.Items.Add(cust.To.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trains train = new Trains();

            if(comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                Utility.Train = Utility.TrainsList[comboBox1.SelectedIndex];
            }

            if(Utility.Train.Id == 0)
            {
                MessageBox.Show("There is no train available for selected location.");
            }
            else
            {
                MessageBox.Show("Trains is available");
                OleDbConnection oleDbConnection = new OleDbConnection();
                oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];

                var command = "Select * from Schedules where TrainID = " + Utility.Train.Id;
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
                adapter.SelectCommand = command2;
                var ds = new DataSet();
                adapter.Fill(ds);
                var dt = ds.Tables[0];
                Utility.Train.ArrivalTimings = new List<string>();
                Utility.Train.DepatureTimings = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    Utility.Train.ArrivalTimings.Add(Convert.ToDateTime(dr["Arrival Time"]).ToLongTimeString());
                    Utility.Train.DepatureTimings.Add(Convert.ToDateTime(dr["Departure Time"]).ToLongTimeString());

                    Utility.Train.PlatformNumber = Convert.ToInt32(dr["Platform Number"]);
                }

                comboBox3.Items.AddRange(Utility.Train.ArrivalTimings.ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utility.SelectedTrain.From = Utility.Train.From;
            Utility.SelectedTrain.To = Utility.Train.To;
            Utility.SelectedTrain.Id = Utility.Train.Id;
            Utility.SelectedTrain.TrainName = Utility.Train.TrainName;
            Utility.SelectedTrain.ArrivalTimings = new List<string>();
            Utility.SelectedTrain.ArrivalTimings.Add(comboBox3.SelectedItem.ToString());
            Utility.SelectedTrain.DepatureTimings = new List<string>();
            Utility.SelectedTrain.DepatureTimings.Add(Utility.Train.DepatureTimings[comboBox3.SelectedIndex]);

            BookingPage page = new BookingPage();
            page.Show();
            this.Close();
        }
    }
}
