using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class AddTrain : Form
    {
        public AddTrain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["Railway"];
            oleDbConnection.Open();
            var command = String.Format("Insert INTO [Trains] ([Name], [Type], [Description], [From], [To]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox2.Text);
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
            MessageBox.Show("Train Added !!");
            this.Close();
        }
    }
}
