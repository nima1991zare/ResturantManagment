using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ResturantManagment
{
    public partial class Foods : Form
    {
        public Foods()
        {
            InitializeComponent();
        }

        private void Foods_Load(object sender, EventArgs e)
        {
            listboxShow();
            comboboxItems();
        }
        public void comboboxItems()
        {

            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT * FROM foods", sc);
            SqlDataReader reader;
            try
            {
                sc.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string fname = (string)reader["foodName"];
                    comboBox1.Items.Add(fname);
                }
                sc.Close();
                this.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void listboxShow()
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT * FROM foods", sc);
            SqlDataReader reader;
            try
            {
                sc.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string fname = (string)reader["foodName"];
                    string fprice = (string)reader["foodPrice"];
                    listBox1.Items.Add(fname+"\t"+fprice);
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
                long price = long.Parse(textBox1.Text);
                string queryAdd = ("INSERT INTO foods (foodName,foodPrice)" +
                    "VALUES('" + name + "','" + price + "')");
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand(queryAdd, sc);
                command.ExecuteNonQuery();
                sc.Close();
                textBox1.Text = textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = comboBox1.Text;
                long price = long.Parse(textBox2.Text);
                string queryUpd = ("UPDATE foods SET (foodName, foodPrice)" +
                    "VALUES('" + name + "','" + price + "')" +
                    "WHERE foodName='" + name + "'");
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand(queryUpd, sc);
                command.ExecuteNonQuery();
                sc.Close();
                comboBox1.Text = textBox2.Text = "";
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string name = comboBox1.Text;
                string querydel = ("DELETE FROM foods WHERE foodName='"+name+"'");
                SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nima1\source\repos\ResturantManagment\ResturantManagment\ResturantDB.mdf;Integrated Security=True");
                sc.Open();
                SqlCommand command = new SqlCommand(querydel, sc);
                command.ExecuteNonQuery();
                sc.Close();
                comboBox1.Text = textBox2.Text = "";
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Foods_FormClosing(object sender, FormClosingEventArgs e)
        {  
            land l = new land();
            l.Show();
            this.Hide();
            e.Cancel = true;

        }
    }
}
