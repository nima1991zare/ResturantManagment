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
    public partial class personels : Form
    {
        land l = new land();
        public personels()
        {
            InitializeComponent();
        }

        private void personels_Load(object sender, EventArgs e)
        {
            listboxShow();
        }
        public void listboxShow()
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT * FROM Table", sc);
            SqlDataReader reader;
            try
            {
                sc.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string pname = (string)reader["personelName"];
                    string whour = (string)reader["workHours"];
                    string pos = (string)reader["positions"];
                    string salary = (string)reader["salery"];
                    listBox1.Items.Add(pname + "\t" + whour + "\t" + pos + "\t" + salary);
                }
                sc.Close();
                this.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox3.Text;
                int whour = int.Parse(textBox1.Text);
                string pos = textBox4.Text;
                int salery = int.Parse(textBox6.Text);
                string queryAdd = ("INSERT INTO Table (personelName,workHours,positions,salery)" +
                    "VALUES('" + name + "','" + whour + "','" + pos + "','" + salery + "')");
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand(queryAdd, sc);
                command.ExecuteNonQuery();
                sc.Close();
                textBox1.Text = textBox3.Text = textBox4.Text = textBox6.Text = "";
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = comboBox1.Text;
                int whour = int.Parse(textBox2.Text);
                string pos = textBox5.Text;
                int salery = int.Parse(textBox7.Text);
                string queryAdd = ("UPDATE Table SET(personelName,workHours,positions,salery)" +
                    "VALUES('" + name + "','" + whour + "','" + pos + "','" + salery + "')" +
                    "WHERE personelName='" + name + "'");
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand(queryAdd, sc);
                command.ExecuteNonQuery();
                sc.Close();
                comboBox1.Text = textBox2.Text = textBox5.Text = textBox7.Text = "";
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            string querydel = ("DELTE FROM Table WHERE personelName='" + name + "'");
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
            sc.Open();
            SqlCommand command = new SqlCommand(querydel, sc);
            command.ExecuteNonQuery();
            sc.Close();
            comboBox1.Text = textBox2.Text = textBox5.Text = textBox7.Text = "";
            this.Refresh();
        }

        private void personels_FormClosing(object sender, FormClosingEventArgs e)
        {
            l.Show();
            this.Hide();
            e.Cancel = true;
        }
    }
}
