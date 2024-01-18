
// Add New Books Process

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

    public partial class AddBooks : Form
    {

        public AddBooks()
        {

            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBNumber.Text != "" && txtBookTitle.Text != "" && txtBPublisher.Text != "" && txtAuthor.Text != "" && txtISBN.Text != "" && txtCopies.Text != "" && txtreforbor.Text != "" )

            {

                String bookNumber = txtBNumber.Text;
                String bookTitle = txtBookTitle.Text;
                String bookPublisher = txtBPublisher.Text;
                String bookAuthor = txtAuthor.Text;
                String bookISBN = txtISBN.Text;
                Int64 numofcopies = Int64.Parse(txtCopies.Text);
                String reforbor = txtreforbor.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Insert into AddNewBook (bookNumber, bookTitle, bookPublisher, bookAuthor, bookISBN, numofcopies, reforbor) values ('"+ bookNumber + "', '" + bookTitle + "', '"+ bookPublisher + "', '" + bookAuthor + "', '" + bookISBN + "', " + numofcopies + ", '"+ reforbor + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book Registered Successfully...!!", "Success...!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBNumber.Clear();
                txtBookTitle.Clear();
                txtBPublisher.Clear();
                txtAuthor.Clear();
                txtISBN.Clear();
                txtCopies.Clear();
                txtreforbor.Clear();

            }

            else

            {

                // Display a message to user fill empty fields.
                MessageBox.Show("Empty Fields are not allowed", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            txtBNumber.Clear();
            txtBookTitle.Clear() ;
            txtAuthor.Clear() ;
            txtISBN.Clear() ;
            txtCopies.Clear() ;
            txtreforbor.Clear() ;
            txtBPublisher.Clear();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Check if AddBooks form is open
            if (Application.OpenForms.OfType<AddBooks>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
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

    }

}
