using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResturantManagment
{
    public partial class land : Form
    {

        public land()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Foods food = new Foods();
            food.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personels ps = new personels();
            ps.Show();
            this.Hide();
        }
    }
}
