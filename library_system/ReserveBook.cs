
//Reserve Book Process

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace library_system
{
    public partial class ReserveBook : Form
    {
        public ReserveBook()
        {
            InitializeComponent();
        }

        private void ReserveBook_Load(object sender, EventArgs e)
        {
            // database connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("SELECT bookTitle FROM AddNewBook", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                for (int i = 0; i < sdr.FieldCount; i++)
                {

                    // Getting the bookTitles from the database table "AddNewBook"
                    comboBSelect.Items.Add(sdr.GetString(i));

                }
            }
            sdr.Close();
            con.Close();

           comboBSelect.SelectedIndexChanged += comboBSelect_SelectedIndexChanged;

            // Check if ReserveBook form is open
            if (Application.OpenForms.OfType<ReserveBook>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }
            }
        }   

       /* int bookid;
        Int64 rowid;*/
        

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        

      
        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReferesh_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearchBar.Text != "")
            {

                string userNumber1 = txtSearchBar.Text;

                using (SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS; database=master; integrated security=True"))
                {

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT UName, UNIC FROM AddNewUser WHERE UNumber = @UserNumber", con))
                    {

                        cmd.Parameters.AddWithValue("@UserNumber", userNumber1);

                        using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                        {

                            DataSet DS = new DataSet();
                            DA.Fill(DS);


                            if (DS.Tables[0].Rows.Count != 0)
                            {

                                txtUserName.Text = DS.Tables[0].Rows[0]["UName"].ToString();
                                txtNIC.Text = DS.Tables[0].Rows[0]["UNIC"].ToString();

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
            else if (string.IsNullOrEmpty(txtSearchBar.Text))
            {
                // Show an error message
                MessageBox.Show("Enter Your User Number First.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void comboBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Check if a book is selected
            if (comboBSelect.SelectedIndex != -1)

            {

                string selectedBookTitle = comboBSelect.SelectedItem.ToString();

                // database connection code
                using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))

                {

                    con.Open();

                    // parameters to prevent SQL injection
                    string query = "SELECT bookNumber, bookPublisher, bookAuthor, bookISBN, reforbor, numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle";
                    using (SqlCommand cmd = new SqlCommand(query, con))

                    {

                        cmd.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                        // Execute the query
                        using (SqlDataReader reader = cmd.ExecuteReader())

                        {

                            // Check if there are rows
                            if (reader.Read())

                            {

                                // Display the bookNumber in txtBNumber
                                txtBNumber.Text = reader["bookNumber"].ToString();

                                // Display the Book Publisher in txtBPublisher
                                txtBPublisher.Text = reader["bookPublisher"].ToString();

                                //Display the Author of the book in txtBAuthor
                                txtBAuthor.Text = reader["bookAuthor"].ToString();

                                //Display the ISBN of the book in txtBISBN
                                txtBISBN.Text = reader["bookISBN"].ToString();

                                //Display the ISBN of the book in txtBISBN
                                txtBcopies.Text = reader["numofcopies"].ToString();

                                //Display the Reference or Borrowable status of the book in txtBISBN
                                txtBRefBor.Text = reader["reforbor"].ToString();

                            }
                            
                            else

                            {

                                // Handle the case where the book title is not found
                                txtBNumber.Text = "Information not available";
                                txtBPublisher.Text = "Information not available";
                                txtBAuthor.Text = "Information not available";
                                txtBISBN.Text = "Information not available";
                                txtBcopies.Text = "Information not available";
                                txtBRefBor.Text = "Information not available";
                            }

                        }

                    }

                }

            }

            else

            {

                // Handle the case where no book is selected
                txtBNumber.Text = string.Empty;
                txtBPublisher.Text = string.Empty;
                txtBAuthor.Text = string.Empty;
                txtBISBN.Text = string.Empty;
                txtBcopies.Text = string.Empty;
                txtBRefBor.Text = string.Empty;
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {

            bool errorOccurred = false;

            // Check user's details fields IsEmpty
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtNIC.Text))

            {

                MessageBox.Show("Please search and select a valid user.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            // Check Comboboxes IsEmpty
            else if (comboBSelect.SelectedIndex == -1)

            {

                MessageBox.Show("Empty Fields not allowed.!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (!errorOccurred)
            {

                ComboBox[] comboBoxes = { comboBSelect };

                foreach (ComboBox comboBox in comboBoxes)

                {

                    if (comboBox.SelectedItem != null)

                    {
                        SqlConnection conn = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True");
                        string bookTitle = comboBox.SelectedItem.ToString();
                        SqlCommand cmd = new SqlCommand("SELECT reforbor FROM AddNewBook WHERE bookTitle = @bookTitle", conn);
                        cmd.Parameters.AddWithValue("@bookTitle", bookTitle);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string reforbor = reader.GetString(0);

                                if (reforbor != "Borrowable")
                                {

                                    MessageBox.Show("Reference Books are not allowed to Reserve.!", "ERROR.!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    errorOccurred = true;
                                    break;

                                }

                            }

                        }

                        else

                        {

                            MessageBox.Show("No book found with the title: " + bookTitle, "ERROR.!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorOccurred = true;

                        }

                        reader.Close();
                        conn.Close();

                        if (errorOccurred)

                        {

                            break;

                        }

                    }

                }

                if (!errorOccurred)
                {

                    ComboBox[] comboBoxx = { comboBSelect };
                    bool errorOccurred1 = false;

                    foreach (ComboBox comboBox in comboBoxes)

                    {

                        if (comboBox.SelectedItem != null)

                        {
                            SqlConnection conn = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True");
                            string bookTitle = comboBox.SelectedItem.ToString();
                            SqlCommand cmd = new SqlCommand("SELECT numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle", conn);
                            cmd.Parameters.AddWithValue("@bookTitle", bookTitle);

                            conn.Open();
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)

                            {

                                while (reader.Read())

                                {
                                    long numofcopies = reader.GetInt64(0);

                                    if (numofcopies <= 0)
                                    {

                                        if (MessageBox.Show("No copies left for the selected book. You need to reserve and collect later ? "  , "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            int userNumber = int.Parse(txtSearchBar.Text);

                                            //database connection 
                                            using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
                                            {
                                                con.Open();

                                                // Insert into LoanedBook table
                                                string insertQuery = @"
                                               INSERT INTO ResvBookNotAvail 

                                               (ResNotAvail_UserNumber,
                                                ResNotAvail_UserName,
                                                ResNotAvail_UserNIC,
                                                ResNotAvail_BookTitle,
                                                ResNotAvail_BookNumber,
                                                ResNotAvail_BookPublisher,
                                                ResNotAvail_BookAuthor,
                                                ResNotAvail_BookISBN )

                                               VALUES

                                               (@ResNotAvail_UserNumber,
                                                @ResNotAvail_UserName,
                                                @ResNotAvail_UserNIC,
                                                @ResNotAvail_BookTitle,
                                                @ResNotAvail_BookNumber,
                                                @ResNotAvail_BookPublisher,
                                                @ResNotAvail_BookAuthor,
                                                @ResNotAvail_BookISBN );";

                                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                                                {
                                                    // Parameters
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_UserNumber", txtSearchBar.Text);
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_UserName", txtUserName.Text);
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_UserNIC", txtNIC.Text);
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_BookTitle", comboBSelect.Text);
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_BookNumber", txtBNumber.Text);
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_BookPublisher", txtBPublisher.Text);
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_BookAuthor", txtBAuthor.Text);
                                                    insertCmd.Parameters.AddWithValue("@ResNotAvail_BookISBN", txtBISBN.Text);


                                                    // Execute the query
                                                    insertCmd.ExecuteNonQuery();
                                                }

                                                /*// Update numofcopies in AddNewBook table
                                                string[] selectedBooks = new string[1] { comboBSelect.Text };
                                                foreach (string book in selectedBooks)
                                                {
                                                    if (!string.IsNullOrEmpty(book))
                                                    {
                                                        string updateCopiesQuery = "UPDATE AddNewBook SET numofcopies = numofcopies - 1 WHERE bookTitle = @bookTitle";
                                                        using (SqlCommand command = new SqlCommand(updateCopiesQuery, con))
                                                        {
                                                            command.Parameters.AddWithValue("@bookTitle", book);
                                                            command.ExecuteNonQuery();


                                                        }

                                                    }

                                                }*/

                                                // Display the successfull message to user if the Book reserve process got successful.
                                                MessageBox.Show("Reserved Success.You will be notified when the reserved book available", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                txtUserName.Clear();
                                                txtNIC.Clear();
                                                comboBSelect.SelectedIndex = -1;
                                                txtBNumber.Clear();
                                                txtBPublisher.Clear();
                                                txtBAuthor.Clear();
                                                txtBISBN.Clear();
                                                txtBcopies.Clear();
                                                txtBRefBor.Clear();
                                                txtSearchBar.Clear();

                                            }
                                            
                                        }
                                        errorOccurred1 = true;
                                        break;

                                    }

                                }

                            }

                            else

                            {

                                MessageBox.Show("No book found with the title: " + bookTitle, "ERROR.!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                errorOccurred1 = true;

                            }

                            reader.Close();
                            conn.Close();

                            if (errorOccurred1)

                            {

                                break;

                            }

                        }

                    }

                    if (!errorOccurred1)
                    {
                        int userNumber = int.Parse(txtSearchBar.Text);

                        //database connection 
                        using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
                        {
                            con.Open();

                            // Insert into LoanedBook table
                            string insertQuery = @"
                       INSERT INTO ReservedBooks 
                       (Reserved_UserNumber,
                        Reserved_UserName,
                        Reserved_UserNIC,
                        Reserved_BookTitle,
                        Reserved_BookNumber,
                        Reserved_BookPublisher,
                        Reserved_BookAuthor,
                        Reserved_BookISBN )

                       VALUES

                       (@Reserved_UserNumber,
                        @Reserved_UserName,
                        @Reserved_UserNIC,
                        @Reserved_BookTitle,
                        @Reserved_BookNumber,
                        @Reserved_BookPublisher,
                        @Reserved_BookAuthor,
                        @Reserved_BookISBN );";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                            {
                                // Parameters
                                insertCmd.Parameters.AddWithValue("@Reserved_UserNumber", txtSearchBar.Text);
                                insertCmd.Parameters.AddWithValue("@Reserved_UserName", txtUserName.Text);
                                insertCmd.Parameters.AddWithValue("@Reserved_UserNIC", txtNIC.Text);
                                insertCmd.Parameters.AddWithValue("@Reserved_BookTitle", comboBSelect.Text);
                                insertCmd.Parameters.AddWithValue("@Reserved_BookNumber", txtBNumber.Text);
                                insertCmd.Parameters.AddWithValue("@Reserved_BookPublisher", txtBPublisher.Text);
                                insertCmd.Parameters.AddWithValue("@Reserved_BookAuthor", txtBAuthor.Text);
                                insertCmd.Parameters.AddWithValue("@Reserved_BookISBN", txtBISBN.Text);


                                // Execute the query
                                insertCmd.ExecuteNonQuery();
                            }

                            // Update numofcopies in AddNewBook table
                            string[] selectedBooks = new string[1] { comboBSelect.Text };
                            foreach (string book in selectedBooks)
                            {
                                if (!string.IsNullOrEmpty(book))
                                {
                                    string updateCopiesQuery = "UPDATE AddNewBook SET numofcopies = numofcopies - 1 WHERE bookTitle = @bookTitle";
                                    using (SqlCommand command = new SqlCommand(updateCopiesQuery, con))
                                    {
                                        command.Parameters.AddWithValue("@bookTitle", book);
                                        command.ExecuteNonQuery();


                                    }
                                }
                            }

                            // Display the successfull message to user if the Book reserve process got successful.
                            MessageBox.Show("Book Reserved Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtUserName.Clear();

                            txtNIC.Clear();

                            comboBSelect.SelectedIndex = -1;

                            txtBNumber.Clear();

                            txtBPublisher.Clear();

                            txtBAuthor.Clear();

                            txtBISBN.Clear();

                            txtBcopies.Clear();

                            txtBRefBor.Clear();

                            txtSearchBar.Clear();

                        }

                    }

                }

            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();

            txtNIC.Clear();

            comboBSelect.SelectedIndex = -1;

            txtBNumber.Clear();

            txtBPublisher.Clear();

            txtBAuthor.Clear();

            txtBISBN.Clear();

            txtBcopies.Clear();

            txtBRefBor.Clear();

            txtSearchBar.Clear();

        }

    }

}
