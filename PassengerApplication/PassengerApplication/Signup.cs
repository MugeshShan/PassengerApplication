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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];
            oleDbConnection.Open();
            var command = String.Format("Insert INTO [Passengers] ([first_name], [last_name], [email], [mobile], [Address], [username], [password], [role]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, maskedTextBox1.Text, 2);
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();

            //command = "SELECT TOP 1 * FROM CustomerInfo ORDER BY Cid DESC";

            //OleDbDataAdapter adapter = new OleDbDataAdapter();
            //command2 = new OleDbCommand(command, oleDbConnection);
            //command2 = new OleDbCommand(command, oleDbConnection);
            //adapter.SelectCommand = command2;
            //var ds = new DataSet();
            //adapter.Fill(ds);
            //var dt = ds.Tables[0];
            //var id = dt.Rows[0]["Cid"];
            //command = String.Format("Insert INTO [Customer] ([UserName], [Password], [Role_Id], [Cid]) VALUES ('{0}', '{1}', {2}, {3})", textBox6.Text, maskedTextBox1.Text, 1, id);
            //command2 = new OleDbCommand(command, oleDbConnection);
            //command2.ExecuteNonQuery();
            MessageBox.Show("Please login !!!");
            this.Close();
        }
    }
}
