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
    public partial class issueBook : Form
    {
        public issueBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IssueBookForStudent newform = new IssueBookForStudent();
            newform.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IssueBookForTeacher newform = new IssueBookForTeacher();
            newform.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            feature newform = new feature();
            newform.Show();
            Visible = false;
        }
    }
}
