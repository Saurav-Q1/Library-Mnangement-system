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
    public partial class TeacherDetails : Form
    {
        public TeacherDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTeacher newform = new AddTeacher();
            newform.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeacherInfo newform = new TeacherInfo();
            newform.Show();
            Visible = false;
        }
    }
}
