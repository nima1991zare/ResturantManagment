using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResturantManagment
{
    public partial class Form1 : Form
    {
        land l = new land();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string un = textBox1.Text;
                string pa = textBox2.Text;
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand("SELECT password FROM users WHERE username='" + un + "' and password ='" + pa + "'", sc);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                string pass = reader["password"].ToString();
                if (pa == pass)
                {
                    l.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorect");
                }
                sc.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("incorect");
            }
        }

    }
}
