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
    public partial class ReturnBookstudent : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project file(3.1)\LibraryManagementSystem4\LibraryManagementSystem4\Database.mdf;Integrated Security=True");
        public ReturnBookstudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnBook newform = new ReturnBook();
            newform.Show();
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fill_grid(textBox1.Text);
        }

        private void ReturnBookstudent_Load(object sender, EventArgs e)
        {

            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
            sqlcon.Open();
        }
        public void fill_grid(string id)
        {
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_book_student where student_id ='"+id.ToString()+"' and return_date ='' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());


            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_book_student where id = '"+i+"' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                lbl_booksName.Text = dr["book_name"].ToString();
                lbl_issueDate.Text = Convert.ToString(dr["issue_date"].ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update issue_book_student set return_date = '"+dateTimePicker1.Value.ToString() +"' where id = '" + i + "' ";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = sqlcon.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update book_info set available_copies = available_copies + 1 where name_of_the_book ='"+lbl_booksName.Text+"'";
            cmd1.ExecuteNonQuery();


            MessageBox.Show("Books return successfully");

            fill_grid(textBox1.Text);

        }
    }
}
