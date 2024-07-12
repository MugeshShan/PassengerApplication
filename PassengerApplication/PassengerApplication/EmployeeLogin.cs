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
    public partial class EmployeeLogin : Form
    {
        public EmployeeLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && maskedTextBox1.Text == "Admin")
            {
                MessageBox.Show("Welcome Admin!!");
                AdminPage page = new AdminPage();
                page.Show();
                this.Close();
            }
            else
            {
                List<Employee> customers = new List<Employee>();
                OleDbConnection oleDbConnection = new OleDbConnection();
                oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];


                var command = "Select * from Employee";
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
                adapter.SelectCommand = command2;
                var ds = new DataSet();
                adapter.Fill(ds);
                var dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {

                    var tempUser = new Employee
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Username = dr["Username"].ToString(),
                        Password = dr["Password"].ToString(),
                        Name = dr["FirstName"].ToString(),
                        Email = dr["Email"].ToString()
                    };
                    if (tempUser != null)
                    {
                        customers.Add(tempUser);
                    }
                }

                foreach (var cust in customers)
                {
                    if (textBox1.Text == cust.Username && maskedTextBox1.Text == cust.Password)
                    {
                        MessageBox.Show("Welcome " + cust.Name + "!!!");
                        oleDbConnection.Close();
                        Utility.Employee = cust;
                        EmployeePage page = new EmployeePage();
                        page.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
