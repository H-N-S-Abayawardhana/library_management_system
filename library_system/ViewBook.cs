
// View Books Process

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

namespace library_system
{

    public partial class ViewBook : Form
    {

        public ViewBook()
        {

            InitializeComponent();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            // Initially make botton panel as invisible
            panel2.Visible = false;
            // database connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = " data source = HP\\SQLEXPRESS; database = master; integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM AddNewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            // Check if ViewBook form is open
            if (Application.OpenForms.OfType<ViewBook>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }

            }

        }

        int bookid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                bookid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                
            }

            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM AddNewBook WHERE bookid = " + bookid + " ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtBNumber.Text = ds.Tables[0].Rows[0][1].ToString();
            txtBTitle.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPublisher.Text = ds.Tables[0].Rows[0][3].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][4].ToString();
            txtBISBN.Text = ds.Tables[0].Rows[0][5].ToString();
            txtCopies.Text = ds.Tables[0].Rows[0][6].ToString();
            txtreforbor.Text = ds.Tables[0].Rows[0][7].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

            if (txtBookName.Text != "")

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM AddNewBook WHERE bookTitle LIKE '" + txtBookName.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

            else

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM AddNewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be updated. Confirm ?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                String bookNumber = txtBNumber.Text;
                String bookTitle = txtBTitle.Text;
                String bookPublisher = txtPublisher.Text;
                String bookAuthor = txtAuthor.Text;
                String bookISBN = txtBISBN.Text;
                Int64 numofcopies = Int64.Parse(txtCopies.Text);
                String reforbor = txtreforbor.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "UPDATE AddNewBook SET bookNumber = '"+ bookNumber + "', bookTitle = '" + bookTitle + "', bookPublisher = '"+ bookPublisher + "', bookAuthor = '" + bookAuthor + "', bookISBN = '" + bookISBN + "', numofcopies = " + numofcopies + ", reforbor = '"+ reforbor + "' where bookid = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewBook_Load(this, null);

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be Deleted. Confirm ?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Delete from AddNewBook where bookid = " + bookid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewBook_Load(this, null);

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assuming you have a reference to the Dashboard form
            Dashboard dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();

            if (MessageBox.Show("Do you want to exit ?", "Are You Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Show the Dashboard form
                if (dashboardForm != null)
                {
                    dashboardForm.Show();
                }

                this.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
