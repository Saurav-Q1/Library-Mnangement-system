using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem4
{
    public partial class feature : Form
    {
        public feature()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addbook newform = new addbook();
            newform.Show();
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BookInformation newform = new BookInformation();
            newform.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            issueBook newform = new issueBook();
            newform.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReturnBook newform = new ReturnBook();
            newform.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddStudent newform = new AddStudent();
            newform.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddTeacher newform = new AddTeacher();
            newform.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            login newform = new login();
            newform.Show();
            Visible = false;
        }
    }
}
