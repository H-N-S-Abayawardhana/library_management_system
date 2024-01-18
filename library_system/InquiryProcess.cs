using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace library_system
{
    public partial class BookStatusLabel : Form
    {
        public BookStatusLabel()
        {
            InitializeComponent();
        }

        private void InquiryProcess_Load(object sender, EventArgs e)
        {



            // Check if InquiryProcess form is open
            if (Application.OpenForms.OfType<BookStatusLabel>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }
            }
            // Make Invisible all the textbox regarding book details
            ComboLabel.Visible = false;
            comboBSelect.Visible = false;
            CopiesLabel.Visible = false;
            txtcopies.Visible = false;
            statusLabel.Visible = false;
            txtBstatus.Visible = false;
            ReservedLabel.Visible = false;
            txtIsReserved.Visible = false;

            //Populate the combobox (comboBSelect) with bookTitle from AddNewBook table
            using (SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS; database=master; integrated security=True"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT bookTitle FROM AddNewBook", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBSelect.Items.Add(reader["bookTitle"].ToString());
                        }

                    }

                }

            }

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

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearchBar.Text != "")
            {
                string userNumber1 = txtSearchBar.Text;

                using (SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS; database=master; integrated security=True"))
                {
                    con.Open();

                    // Check in AddNewUser table
                    using (SqlCommand cmd = new SqlCommand("SELECT UName, UNIC FROM AddNewUser WHERE UNumber = @UserNumber", con))
                    {
                        cmd.Parameters.AddWithValue("@UserNumber", userNumber1);

                        using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                        {
                            DataSet DS = new DataSet();
                            DA.Fill(DS);

                            if (DS.Tables[0].Rows.Count != 0)
                            {
                                label3.Visible = true;
                                txtUserName.Visible = true;
                                label4.Visible = true;
                                txtNIC.Visible = true;

                                txtUserName.Text = DS.Tables[0].Rows[0]["UName"].ToString();
                                txtNIC.Text = DS.Tables[0].Rows[0]["UNIC"].ToString();


                                txtUserStatus.Text = "Registered Member";

                                ComboLabel.Visible = true;
                                comboBSelect.Visible = true;
                                CopiesLabel.Visible = true;
                                txtcopies.Visible = true;
                                statusLabel.Visible = true;
                                txtBstatus.Visible = true;
                                ReservedLabel.Visible = true;
                                txtIsReserved.Visible = true;
                            }
                            else
                            {
                                // If not found in AddNewUser table, check in AddNewVisitor table
                                using (SqlCommand cmdVisitor = new SqlCommand("SELECT VName, VNIC FROM AddNewVisitor WHERE VNumber = @VisitorNumber", con))
                                {
                                    cmdVisitor.Parameters.AddWithValue("@VisitorNumber", userNumber1);

                                    using (SqlDataAdapter DAV = new SqlDataAdapter(cmdVisitor))
                                    {
                                        DataSet DSV = new DataSet();
                                        DAV.Fill(DSV);

                                        if (DSV.Tables[0].Rows.Count != 0)
                                        {
                                            label3.Visible = true;
                                            txtUserName.Visible = true;
                                            label4.Visible = true;
                                            txtNIC.Visible = true;

                                            txtUserName.Text = DSV.Tables[0].Rows[0]["VName"].ToString();
                                            txtNIC.Text = DSV.Tables[0].Rows[0]["VNIC"].ToString();
                                            ComboLabel.Visible = true;

                                            txtUserStatus.Text = "Registered Visitor";

                                            ComboLabel.Visible = true;
                                            comboBSelect.Visible = true;
                                            CopiesLabel.Visible = true;
                                            txtcopies.Visible = true;
                                            statusLabel.Visible = true;
                                            txtBstatus.Visible = true;
                                            ReservedLabel.Visible = true;
                                            txtIsReserved.Visible = true;
                                        }
                                        else
                                        {
                                            txtUserName.Clear();
                                            txtNIC.Clear();
                                            MessageBox.Show("Invalid User Number.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtSearchBar.Clear();
                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }

            else if (string.IsNullOrEmpty(txtSearchBar.Text))
            {
                // Show an error message
                MessageBox.Show("Enter Your User Number First.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtNIC.Clear();
            txtSearchBar.Clear();
            txtUserStatus.Clear();

            comboBSelect.SelectedIndex = -1;
            txtcopies.Clear();
            txtBstatus.Clear();
            txtIsReserved.Clear();

            ComboLabel.Visible = false;
            comboBSelect.Visible = false;
            CopiesLabel.Visible = false;
            txtcopies.Visible = false;
            statusLabel.Visible = false;
            txtBstatus.Visible = false;
            ReservedLabel.Visible = false;
            txtIsReserved.Visible = false;


        }

        private void comboBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if a book is selected
            if (comboBSelect.SelectedIndex != -1)
            {
                string selectedBookTitle = comboBSelect.SelectedItem.ToString();

                // database connection code
                using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True; MultipleActiveResultSets=True"))
                {
                    con.Open();

                    // parameters to prevent SQL injection
                    string query = "SELECT numofcopies, reforbor FROM AddNewBook WHERE bookTitle = @bookTitle";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                        // Execute the query
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if there are rows
                            if (reader.Read())
                            {
                                // Display the numofcopies in txtBNumberB1
                                txtcopies.Text = reader["numofcopies"].ToString();

                                // Display the Book status in txtrefbor1
                                txtBstatus.Text = reader["reforbor"].ToString();

                                // Check if the number of copies is 0
                                if (int.Parse(txtcopies.Text) == 0)
                                {
                                    // Check in ReservedBooks table
                                    using (SqlCommand cmdReserved = new SqlCommand("SELECT Reserved_BookTitle FROM ReservedBooks WHERE Reserved_BookTitle = @bookTitle", con))
                                    {
                                        cmdReserved.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                                        using (SqlDataReader readerReserved = cmdReserved.ExecuteReader())
                                        {
                                            if (readerReserved.Read())
                                            {
                                                // Book is reserved
                                                txtIsReserved.Text = "Book is Reserved";
                                            }
                                            else
                                            {
                                                // If not found in ReservedBooks table, check in ResvBookNotAvail table
                                                using (SqlCommand cmdResvNotAvail = new SqlCommand("SELECT ResNotAvail_BookTitle FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = @bookTitle", con))
                                                {
                                                    cmdResvNotAvail.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                                                    using (SqlDataReader readerResvNotAvail = cmdResvNotAvail.ExecuteReader())
                                                    {
                                                        if (readerResvNotAvail.Read())
                                                        {
                                                            // Book is reserved
                                                            txtIsReserved.Text = "Book is Reserved";
                                                        }
                                                        else
                                                        {
                                                            // Book is not reserved
                                                            txtIsReserved.Text = "Not Reserved";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // If the number of copies is greater than or equal to 1, the book is not reserved
                                    txtIsReserved.Text = "Not Reserved";
                                }
                            }
                            else
                            {
                                // Handle the case where the book title is not found
                                txtcopies.Text = "Information not available";
                                txtBstatus.Text = "Information not available";
                            }
                        }
                    }
                }
            }
            else
            {
                // Handle the case where no book is selected
                txtcopies.Text = string.Empty;
                txtBstatus.Text = string.Empty;
            }



        }

    }
}
