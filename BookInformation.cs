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
    public partial class BookInformation : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\project file(3.1)\LibraryManagementSystem4\LibraryManagementSystem4\Database.mdf;Integrated Security=True");
        public BookInformation()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {

                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where id = "+i+"";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

               foreach(DataRow dr in dt.Rows)
                {
                    booksid.Text = dr["Book_id"].ToString();
                    subject.Text = dr["subject"].ToString();
                    booksname.Text = dr["name_of_the_book"].ToString();
                    author.Text = dr["author"].ToString();
                    publisher.Text = dr["publisher"].ToString();
                    edition.Text = dr["edition"].ToString();
                    copies.Text = dr["copies"].ToString();
                    cost.Text = dr["cost"].ToString();



                }
               
                sqlcon.Close();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            feature newform = new feature();
            newform.Show();
            Visible = false;

        }

        private void BookInformation_Load(object sender, EventArgs e)
        {
            display_books();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {

                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where name_of_the_book like('%"+textBox4.Text+"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;
                sqlcon.Close();

                if(i==0)
                {
                    MessageBox.Show("no books found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {

                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where author like('%" + textBox7.Text + "%')";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;
                sqlcon.Close();


                if (i == 0)
                {
                    MessageBox.Show("no books found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {

                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book_info set book_id ='"+booksid.Text+"',subject ='"+subject.Text+"',name_of_the_book = '"+booksname.Text+"',author = '"+author.Text+"',publisher = '"+publisher.Text+"',edition = '"+edition.Text+"',copies = '"+copies.Text+"',cost = '"+cost.Text+"' where id = "+i+" ";
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                display_books();
                MessageBox.Show("Record updated successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void display_books()
        {

            try
            {

                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
