using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibraryManagementSystem4
{
    public partial class IssueBookForStudent : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project file(3.1)\LibraryManagementSystem4\LibraryManagementSystem4\Database.mdf;Integrated Security=True");
        public IssueBookForStudent()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            issueBook newform = new issueBook();
            newform.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i=0;
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_table where student_id = '"+student_id.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("This Id no doesnot exsist");
            }
            else
            {
                 foreach (DataRow dr in dt.Rows)
                {
                    student_name.Text = dr["student_name"].ToString();
                    student_dept.Text = dr["student_dept"].ToString();
                    semester.Text = dr["semester"].ToString();
                    contact_no.Text = dr["contact_no"].ToString();
                    email.Text = dr["email"].ToString();
                }
            }
        }

        private void IssueBookForStudent_Load(object sender, EventArgs e)
        {
            if(sqlcon.State==ConnectionState.Open)
            {
                sqlcon.Close();
            }
            sqlcon.Open();
        }

        private void txt_bookname_KeyUp(object sender, KeyEventArgs e)
        {
            int count = 0;

            if(e.KeyCode != Keys.Enter)
            {

                listBox1.Items.Clear();

                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where name_of_the_book = '" + txt_bookname.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if(count>0)
                {
                    listBox1.Visible = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["name_of_the_book"].ToString());
                    }
                }
            }
        }

        private void txt_bookname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                //we need at least one value to select arrow key
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txt_bookname.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_bookname.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into issue_book_student values('"+student_id.Text+"','"+student_name.Text+"','"+student_dept.Text+"','"+semester.Text+"','"+contact_no.Text+"','"+email.Text+"','"+txt_bookname.Text+"','"+dateTimePicker1.Value.ToShortDateString()+"','')";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = sqlcon.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update book_info set available_copies = available_copies-1 where name_of_the_book ='"+txt_bookname.Text+"' ";
            cmd1.ExecuteNonQuery();



            MessageBox.Show("book issued successfully");
        }
    }
}
