
// Loan Process

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using ComboBox = System.Windows.Forms.ComboBox;

namespace library_system
{

    public partial class LoanProcess : Form
    {

        public LoanProcess()
        {

            InitializeComponent();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to exit ?", "Are you sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {

                this.Close();

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            // Get the selected date from the first DateTimePicker
            DateTime selectedDate = txtIssueDate.Value;

            // Calculate the date after two weeks
            DateTime dateAfterTwoWeeks = selectedDate.AddDays(14);

            // Display the calculated date in the TextBox
            txtReturnDate.Text = dateAfterTwoWeeks.ToShortDateString();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            // Attach the event handler
            txtIssueDate.ValueChanged += dateTimePicker1_ValueChanged;

        }

        private void txtReturnDate_TextChanged(object sender, EventArgs e)
        {

            // Attach the event handler
            txtIssueDate.ValueChanged += dateTimePicker1_ValueChanged;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoanProcess_Load(object sender, EventArgs e)
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
                    comboB1.Items.Add(sdr.GetString(i));
                    comboB2.Items.Add(sdr.GetString(i));
                    comboB3.Items.Add(sdr.GetString(i));
                    comboB4.Items.Add(sdr.GetString(i));
                    comboB5.Items.Add(sdr.GetString(i));

                }

            }

            sdr.Close();
            con.Close();

            comboB1.SelectedIndexChanged += comboB1_SelectedIndexChanged;
            comboB2.SelectedIndexChanged += comboB2_SelectedIndexChanged;
            comboB3.SelectedIndexChanged += comboB3_SelectedIndexChanged;
            comboB4.SelectedIndexChanged += comboB4_SelectedIndexChanged;
            comboB5.SelectedIndexChanged += comboB5_SelectedIndexChanged;

            // Check if LoanProcess form is open
            if (Application.OpenForms.OfType<LoanProcess>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }
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

                    using (SqlCommand cmd = new SqlCommand("SELECT UName, UNIC FROM AddNewUser WHERE UNumber = @UserNumber", con))
                    {

                        cmd.Parameters.AddWithValue("@UserNumber", userNumber1);

                        using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                        {

                            DataSet DS = new DataSet();
                            DA.Fill(DS);


                            if (DS.Tables[0].Rows.Count != 0)
                            {

                                txtUName.Text = DS.Tables[0].Rows[0]["UName"].ToString();
                                txtUNIC.Text = DS.Tables[0].Rows[0]["UNIC"].ToString();

                            }
                            else
                            {

                                txtUName.Clear();
                                txtUNIC.Clear();
                                MessageBox.Show("Invalid User Number.!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSearchBar.Clear();
                                txtnoofbooks.Clear();
                                return;

                            }

                        }

                    }

                }

            }
            // Check if the search bar is empty
            else if (string.IsNullOrEmpty(txtSearchBar.Text))
            {
                // Show an error message
                MessageBox.Show("Enter Your User Number First.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            string userNumber = txtSearchBar.Text;
            GetBorrowedBookCount(userNumber);

        }

        public void GetBorrowedBookCount(string userNumber)
        {
            string connectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
            string query = "SELECT Book_1_Title, Book_2_Title, Book_3_Title, Book_4_Title, Book_5_Title FROM LoanedBook WHERE User_Number = @User_Number";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@User_Number", userNumber);

                connection.Open();

                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());

                int totalBookCount = 0;

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(row[i].ToString()))
                        {
                            totalBookCount++;

                            string bookTitle = row[i].ToString();

                            // Fetch book details from AddNewBook table
                            string bookQuery = "SELECT bookNumber, numofcopies, reforbor FROM AddNewBook WHERE bookTitle = @bookTitle";
                            SqlCommand bookCommand = new SqlCommand(bookQuery, connection);
                            bookCommand.Parameters.AddWithValue("@bookTitle", bookTitle);

                            using (SqlDataReader bookReader = bookCommand.ExecuteReader())
                            {
                                if (bookReader.Read())
                                {
                                    string bookNumber = bookReader["bookNumber"].ToString();
                                    string numofcopies = bookReader["numofcopies"].ToString();
                                    string reforbor = bookReader["reforbor"].ToString();

                                    // Update the combobox and textboxes with the book details
                                    ComboBox comboB = (ComboBox)this.Controls.Find("comboB" + (i + 1), true)[0];
                                    System.Windows.Forms.TextBox txtcopiesB = (System.Windows.Forms.TextBox)this.Controls.Find("txtcopiesB" + (i + 1), true)[0];
                                    System.Windows.Forms.TextBox txtrefbor = (System.Windows.Forms.TextBox)this.Controls.Find("txtrefbor" + (i + 1), true)[0];
                                    System.Windows.Forms.TextBox txtBNumberB = (System.Windows.Forms.TextBox)this.Controls.Find("txtBNumberB" + (i + 1), true)[0];

                                    comboB.Text = bookTitle;
                                    txtcopiesB.Text = numofcopies;
                                    txtrefbor.Text = reforbor;
                                    txtBNumberB.Text = bookNumber;

                                    // Disable the combobox and textboxes
                                    comboB.Enabled = false;
                                    txtcopiesB.Enabled = false;
                                    txtrefbor.Enabled = false;
                                    txtBNumberB.Enabled = false;
                                }
                            }
                        }
                    }
                }

                txtnoofbooks.Text = totalBookCount.ToString();
            }


            /* string connectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
             string query = "SELECT Book_1_Title, Book_2_Title, Book_3_Title, Book_4_Title, Book_5_Title FROM LoanedBook WHERE User_Number = @User_Number";

             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                 SqlCommand command = new SqlCommand(query, connection);
                 command.Parameters.AddWithValue("@User_Number", userNumber);

                 connection.Open();

                 DataTable dt = new DataTable();
                 dt.Load(command.ExecuteReader());

                 int totalBookCount = 0;

                 foreach (DataRow row in dt.Rows)
                 {
                     for (int i = 0; i < dt.Columns.Count; i++)
                     {
                         if (!string.IsNullOrEmpty(row[i].ToString()))
                         {
                             totalBookCount++;

                             string bookTitle = row[i].ToString();

                             // Fetch book details from AddNewBook table
                             string bookQuery = "SELECT bookNumber, numofcopies, reforbor FROM AddNewBook WHERE bookTitle = @bookTitle";
                             SqlCommand bookCommand = new SqlCommand(bookQuery, connection);
                             bookCommand.Parameters.AddWithValue("@bookTitle", bookTitle);

                             using (SqlDataReader bookReader = bookCommand.ExecuteReader())
                             {
                                 if (bookReader.Read())
                                 {
                                     string bookNumber = bookReader["bookNumber"].ToString();
                                     string numofcopies = bookReader["numofcopies"].ToString();
                                     string reforbor = bookReader["reforbor"].ToString();

                                     // Update the combobox and textboxes with the book details
                                     ComboBox comboB = (ComboBox)this.Controls.Find("comboB" + (i + 1), true)[0];
                                     System.Windows.Forms.TextBox txtcopiesB = (System.Windows.Forms.TextBox)this.Controls.Find("txtcopiesB" + (i + 1), true)[0];
                                     System.Windows.Forms.TextBox txtrefbor = (System.Windows.Forms.TextBox)this.Controls.Find("txtrefbor" + (i + 1), true)[0];

                                     comboB.Text = bookTitle;
                                     txtcopiesB.Text = numofcopies;
                                     txtrefbor.Text = reforbor;

                                 }

                             }

                         }

                     }

                 }

                 txtnoofbooks.Text = totalBookCount.ToString();

             }*/



        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {

            txtSearchBar.Clear();
            txtnoofbooks.Clear();

        }

        private void comboB1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Check if a book is selected
            if (comboB1.SelectedIndex != -1)

            {

                string selectedBookTitle = comboB1.SelectedItem.ToString();

                // database connection code
                using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))

                {

                    con.Open();

                    // parameters to prevent SQL injection
                    string query = "SELECT bookNumber, reforbor, numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle";
                    using (SqlCommand cmd = new SqlCommand(query, con))

                    {

                        cmd.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                        // Execute the query
                        using (SqlDataReader reader = cmd.ExecuteReader())

                        {

                            // Check if there are rows
                            if (reader.Read())

                            {

                                // Display the bookNumber in txtBNumberB1
                                txtBNumberB1.Text = reader["bookNumber"].ToString();

                                // Display the reforbor in txtrefbor1
                                txtrefbor1.Text = reader["reforbor"].ToString();

                                //Display the available book copies amount
                                txtcopiesB1.Text = reader["numofcopies"].ToString();

                            }

                            else

                            {

                                // Handle the case where the book title is not found
                                txtBNumberB1.Text = "Information not available";
                                txtrefbor1.Text = string.Empty;
                                txtcopiesB1.Text = "No data available !";

                            }

                        }

                    }

                }

            }

            else

            {

                // Handle the case where no book is selected
                txtBNumberB1.Text = string.Empty;
                txtrefbor1.Text = string.Empty;
                txtcopiesB1.Text = string.Empty;

            }

        }

        private void comboB2_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Check if a book is selected
            if (comboB2.SelectedIndex != -1)

            {

                string selectedBookTitle = comboB2.SelectedItem.ToString();

                // database connection code
                using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))

                {

                    con.Open();

                    // parameters to prevent SQL injection
                    string query = "SELECT bookNumber, reforbor, numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle";
                    using (SqlCommand cmd = new SqlCommand(query, con))

                    {

                        cmd.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                        // Execute the query
                        using (SqlDataReader reader = cmd.ExecuteReader())

                        {

                            // Check if there are rows
                            if (reader.Read())

                            {

                                // Display the bookNumber in txtBNumberB1
                                txtBNumberB2.Text = reader["bookNumber"].ToString();

                                // Display the reforbor in txtrefbor1
                                txtrefbor2.Text = reader["reforbor"].ToString();

                                txtcopiesB2.Text = reader["numofcopies"].ToString();

                            }

                            else

                            {

                                // Handle the case where the book title is not found
                                txtBNumberB2.Text = "Information not available";
                                txtrefbor2.Text = string.Empty;
                                txtcopiesB2.Text = "Data not available.";

                            }

                        }

                    }

                }

            }

            else

            {

                // Handle the case where no book is selected
                txtBNumberB2.Text = string.Empty;
                txtrefbor2.Text = string.Empty;

            }

        }

        private void comboB3_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Check if a book is selected
            if (comboB3.SelectedIndex != -1)

            {

                string selectedBookTitle = comboB3.SelectedItem.ToString();

                // database connection code
                using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))

                {

                    con.Open();

                    //  parameters to prevent SQL injection
                    string query = "SELECT bookNumber, reforbor,numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle";
                    using (SqlCommand cmd = new SqlCommand(query, con))

                    {

                        cmd.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                        // Execute the query
                        using (SqlDataReader reader = cmd.ExecuteReader())

                        {

                            // Check if there are rows
                            if (reader.Read())

                            {

                                // Display the bookNumber in txtBNumberB1
                                txtBNumberB3.Text = reader["bookNumber"].ToString();

                                // Display the reforbor in txtrefbor1
                                txtrefbor3.Text = reader["reforbor"].ToString();

                                //Display the available copies amount
                                txtcopiesB3.Text = reader["numofcopies"].ToString();

                            }

                            else

                            {

                                // Handle the case where the book title is not found
                                txtBNumberB3.Text = "Information not available";
                                txtrefbor3.Text = string.Empty;
                                txtcopiesB3.Text = "No data available";

                            }

                        }

                    }

                }

            }

            else

            {

                // Handle the case where no book is selected
                txtBNumberB3.Text = string.Empty;
                txtrefbor3.Text = string.Empty;
                txtcopiesB3.Text = string.Empty;

            }

        }

        private void comboB4_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Check if a book is selected
            if (comboB4.SelectedIndex != -1)

            {

                string selectedBookTitle = comboB4.SelectedItem.ToString();

                // database connection code
                using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))

                {

                    con.Open();

                    // parameters to prevent SQL injection
                    string query = "SELECT bookNumber, reforbor,numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle";
                    using (SqlCommand cmd = new SqlCommand(query, con))

                    {

                        cmd.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                        // Execute the query
                        using (SqlDataReader reader = cmd.ExecuteReader())

                        {

                            // Check if there are rows
                            if (reader.Read())

                            {

                                // Display the bookNumber in txtBNumberB1
                                txtBNumberB4.Text = reader["bookNumber"].ToString();

                                // Display the reforbor in txtrefbor1
                                txtrefbor4.Text = reader["reforbor"].ToString();

                                //Display the available book copies amount
                                txtcopiesB4.Text = reader["numofcopies"].ToString();

                            }

                            else

                            {

                                // Handle the case where the book title is not found
                                txtBNumberB4.Text = "Information not available";
                                txtrefbor4.Text = string.Empty;
                                txtcopiesB4.Text = "Data not available";

                            }

                        }

                    }

                }

            }

            else

            {

                // Handle the case where no book is selected
                txtBNumberB4.Text = string.Empty;
                txtrefbor4.Text = string.Empty;
                txtcopiesB4.Text = string.Empty;

            }

        }

        private void comboB5_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Check if a book is selected
            if (comboB5.SelectedIndex != -1)

            {

                string selectedBookTitle = comboB5.SelectedItem.ToString();

                //  database connection code
                using (SqlConnection con = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))

                {

                    con.Open();

                    // parameters to prevent SQL injection
                    string query = "SELECT bookNumber, reforbor,numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle";
                    using (SqlCommand cmd = new SqlCommand(query, con))

                    {

                        cmd.Parameters.AddWithValue("@bookTitle", selectedBookTitle);

                        // Execute the query
                        using (SqlDataReader reader = cmd.ExecuteReader())

                        {

                            // Check if there are rows
                            if (reader.Read())

                            {

                                // Display the bookNumber in txtBNumberB1
                                txtBNumberB5.Text = reader["bookNumber"].ToString();

                                // Display the reforbor in txtrefbor1
                                txtrefbor5.Text = reader["reforbor"].ToString();

                                //Display the available book copies amount
                                txtcopiesB5.Text = reader["numofcopies"].ToString();

                            }

                            else

                            {

                                // Handle the case where the book title is not found
                                txtBNumberB5.Text = "Information not available";
                                txtrefbor5.Text = string.Empty;
                                txtcopiesB5.Text = "Data not available";

                            }

                        }

                    }

                }

            }

            else

            {

                // Handle the case where no book is selected
                txtBNumberB5.Text = string.Empty;
                txtrefbor5.Text = string.Empty;
                txtcopiesB5.Text = string.Empty;

            }

        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            bool errorOccurred = false;

            // Check user's details fields IsEmpty
            if (string.IsNullOrEmpty(txtUName.Text) || string.IsNullOrEmpty(txtUNIC.Text))

            {

                MessageBox.Show("Please search and select a valid user.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            // Check Comboboxes IsEmpty
            else if (comboB1.SelectedIndex == -1 && comboB2.SelectedIndex == -1 && comboB3.SelectedIndex == -1 && comboB4.SelectedIndex == -1 && comboB5.SelectedIndex == -1)

            {

                MessageBox.Show("Empty Fields not allowed.!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ((comboB1.Text == comboB2.Text && txtcopiesB1.Text == "1") || ((comboB1.Text == comboB3.Text && txtcopiesB1.Text == "1")
               || (comboB1.Text == comboB4.Text && txtcopiesB1.Text == "1")
               || (comboB1.Text == comboB5.Text && txtcopiesB1.Text == "1") || (comboB2.Text == comboB3.Text && txtcopiesB2.Text == "1")
               || (comboB2.Text == comboB4.Text && txtcopiesB2.Text == "1") || (comboB2.Text == comboB5.Text && txtcopiesB2.Text == "1")
               || (comboB3.Text == comboB4.Text && txtcopiesB3.Text == "1") || (comboB3.Text == comboB5.Text && txtcopiesB3.Text == "1")
               || (comboB4.Text == comboB5.Text && txtcopiesB4.Text == "1")))

            {

                MessageBox.Show("Only 1 Copy left", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (((comboB1.Text == comboB2.Text && comboB1.Text == comboB3.Text) && txtcopiesB1.Text == "2") || ((comboB1.Text == comboB2.Text && comboB1.Text == comboB4.Text) && txtcopiesB1.Text == "2")
                    || ((comboB1.Text == comboB2.Text && comboB1.Text == comboB5.Text) && txtcopiesB1.Text == "2") || ((comboB1.Text == comboB3.Text && comboB1.Text == comboB4.Text) && txtcopiesB1.Text == "2")
                    || ((comboB1.Text == comboB3.Text && comboB1.Text == comboB5.Text) && txtcopiesB1.Text == "2") || ((comboB2.Text == comboB3.Text && comboB2.Text == comboB4.Text) && txtcopiesB2.Text == "2")
                    || ((comboB2.Text == comboB3.Text && comboB2.Text == comboB5.Text) && txtcopiesB2.Text == "2") || ((comboB2.Text == comboB4.Text && comboB2.Text == comboB5.Text) && txtcopiesB2.Text == "2")
                    || ((comboB3.Text == comboB4.Text && comboB3.Text == comboB5.Text) && txtcopiesB3.Text == "2"))

            {

                MessageBox.Show("Only 2 Copies left", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            else if (((comboB1.Text == comboB2.Text && comboB1.Text == comboB3.Text && comboB1.Text == comboB4.Text) && txtcopiesB1.Text == "3") ||
                    ((comboB1.Text == comboB2.Text && comboB1.Text == comboB4.Text && comboB1.Text == comboB5.Text) && txtcopiesB1.Text == "3") ||
                    ((comboB1.Text == comboB3.Text && comboB1.Text == comboB4.Text && comboB1.Text == comboB5.Text) && txtcopiesB1.Text == "3") ||
                    ((comboB1.Text == comboB2.Text && comboB1.Text == comboB3.Text && comboB1.Text == comboB5.Text) && txtcopiesB1.Text == "3") ||
                    ((comboB2.Text == comboB3.Text && comboB2.Text == comboB4.Text && comboB2.Text == comboB5.Text) && txtcopiesB2.Text == "3"))

            {

                MessageBox.Show("Only 3 Copies left", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if ((comboB1.Text == comboB2.Text && comboB1.Text == comboB3.Text && comboB1.Text == comboB4.Text
                    && comboB1.Text == comboB5.Text) && txtcopiesB1.Text == "4")

            {

                MessageBox.Show("Only 4 Copies left", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            // Check the borrowed book count and display an error message if it's greater than or equal to 5
            else if (int.Parse(txtnoofbooks.Text) >= 5)
            {

                MessageBox.Show("Error: User has already borrowed 5 books. Return books and Try again..", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (!errorOccurred)
            {

                ComboBox[] comboBoxes = { comboB1, comboB2, comboB3, comboB4, comboB5 };

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

                                    MessageBox.Show("Reference Books are not allowed to Borrow.!", "ERROR.!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    errorOccurred = true;
                                    return;

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
                    ComboBox[] comboBoxx = { comboB1, comboB2, comboB3, comboB4, comboB5 };
                    bool errorOccurred1 = false;

                    foreach (ComboBox comboBox in comboBoxes)
                    {
                        if (comboBox.SelectedItem != null)
                        {
                            SqlConnection conn = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True");
                            string bookTitle = comboBox.SelectedItem.ToString();
                            SqlCommand cmd = new SqlCommand("SELECT numofcopies FROM AddNewBook WHERE bookTitle = @bookTitle", conn);
                            cmd.Parameters.AddWithValue("@bookTitle", bookTitle);

                            // New code
                            // Get the corresponding TextBox for the current ComboBox
                            System.Windows.Forms.TextBox correspondingTextBox = null;
                            if (comboBox == comboB1 && txtcopiesB1.Enabled)
                                correspondingTextBox = txtcopiesB1;
                            else if (comboBox == comboB2 && txtcopiesB2.Enabled)
                                correspondingTextBox = txtcopiesB2;
                            else if (comboBox == comboB3 && txtcopiesB3.Enabled)
                                correspondingTextBox = txtcopiesB3;
                            else if (comboBox == comboB4 && txtcopiesB4.Enabled)
                                correspondingTextBox = txtcopiesB4;
                            else if (comboBox == comboB5 && txtcopiesB5.Enabled)
                                correspondingTextBox = txtcopiesB5;

                            // Only check numofcopies if the corresponding TextBox is not null
                            if (correspondingTextBox != null)
                            {
                                // Existing code
                                conn.Open();
                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        long numofcopies = reader.GetInt64(0);

                                        if (numofcopies <= 0)
                                        {

                                            MessageBox.Show("Error: No copies left for the book: " + bookTitle, "ERROR.!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    }


                    if (!errorOccurred1)
                    {
                        int userNumber = int.Parse(txtSearchBar.Text);
                        DateTime returnDate = txtIssueDate.Value.AddDays(14);

                        //database connection 
                        using (SqlConnection con = new SqlConnection("data source=HP\\SQLEXPRESS; database = master; integrated security=True"))
                        {
                            con.Open();

                            // Insert into LoanedBook table
                            string insertQuery = @"
                                INSERT INTO LoanedBook 
                                (  User_Number, 
                                   UsrName, 
                                   UserNIC, 
                                   Book_1_Title, 
                                   Book_2_Title, 
                                   Book_3_Title, 
                                   Book_4_Title, 
                                   Book_5_Title, 
                                   Book_Loaned_Date, 
                                   Book_Return_Date )

                                VALUES

                                (  @userNumber, 
                                   @userName, 
                                   @userNIC, 
                                   @book1, 
                                   @book2, 
                                   @book3, 
                                   @book4, 
                                   @book5, 
                                   @loanedDate, 
                                   @returnDate );";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
                            {
                                // Parameters
                                insertCmd.Parameters.AddWithValue("@userNumber", userNumber);
                                insertCmd.Parameters.AddWithValue("@userName", txtUName.Text);
                                insertCmd.Parameters.AddWithValue("@userNIC", txtUNIC.Text);

                                // Check if the combobox and textboxes are enabled before adding their values as parameters
                                int numCopies;
                                bool isNumeric = int.TryParse(txtcopiesB1.Text, out numCopies);
                                if (comboB1.Enabled && txtcopiesB1.Enabled && txtrefbor1.Enabled && txtBNumberB1.Enabled && isNumeric && numCopies > 0)
                                    insertCmd.Parameters.AddWithValue("@book1", comboB1.SelectedItem ?? DBNull.Value);
                                else
                                    insertCmd.Parameters.AddWithValue("@book1", DBNull.Value);

                                isNumeric = int.TryParse(txtcopiesB2.Text, out numCopies);
                                if (comboB2.Enabled && txtcopiesB2.Enabled && txtrefbor2.Enabled && txtBNumberB2.Enabled && isNumeric && numCopies > 0)
                                    insertCmd.Parameters.AddWithValue("@book2", comboB2.SelectedItem ?? DBNull.Value);
                                else
                                    insertCmd.Parameters.AddWithValue("@book2", DBNull.Value);

                                isNumeric = int.TryParse(txtcopiesB3.Text, out numCopies);
                                if (comboB3.Enabled && txtcopiesB3.Enabled && txtrefbor3.Enabled && txtBNumberB3.Enabled && isNumeric && numCopies > 0)
                                    insertCmd.Parameters.AddWithValue("@book3", comboB3.SelectedItem ?? DBNull.Value);
                                else
                                    insertCmd.Parameters.AddWithValue("@book3", DBNull.Value);

                                isNumeric = int.TryParse(txtcopiesB4.Text, out numCopies);
                                if (comboB4.Enabled && txtcopiesB4.Enabled && txtrefbor4.Enabled && txtBNumberB4.Enabled && isNumeric && numCopies > 0)
                                    insertCmd.Parameters.AddWithValue("@book4", comboB4.SelectedItem ?? DBNull.Value);
                                else
                                    insertCmd.Parameters.AddWithValue("@book4", DBNull.Value);

                                isNumeric = int.TryParse(txtcopiesB5.Text, out numCopies);
                                if (comboB5.Enabled && txtcopiesB5.Enabled && txtrefbor5.Enabled && txtBNumberB5.Enabled && isNumeric && numCopies > 0)
                                    insertCmd.Parameters.AddWithValue("@book5", comboB5.SelectedItem ?? DBNull.Value);
                                else
                                    insertCmd.Parameters.AddWithValue("@book5", DBNull.Value);

                                insertCmd.Parameters.AddWithValue("@loanedDate", txtIssueDate.Value);
                                insertCmd.Parameters.AddWithValue("@returnDate", returnDate);

                                // Execute the query
                                insertCmd.ExecuteNonQuery();

                            }

                            // Update numofcopies in AddNewBook table
                            System.Windows.Forms.ComboBox[] issueComboBoxes = { comboB1, comboB2, comboB3, comboB4, comboB5 };
                            System.Windows.Forms.TextBox[] textBoxes = { txtcopiesB1, txtcopiesB2, txtcopiesB3, txtcopiesB4, txtcopiesB5 };

                            for (int i = 0; i < issueComboBoxes.Length; i++)
                            {
                                System.Windows.Forms.ComboBox comboBox = issueComboBoxes[i];
                                System.Windows.Forms.TextBox textBox = textBoxes[i];

                                if (comboBox.Enabled && textBox.Enabled && !string.IsNullOrEmpty(comboBox.Text))
                                {
                                    string updateCopiesQuery = "UPDATE AddNewBook SET numofcopies = CASE WHEN numofcopies > 0 THEN numofcopies - 1 ELSE 0 END WHERE bookTitle = @bookTitle";
                                    using (SqlCommand command = new SqlCommand(updateCopiesQuery, con))
                                    {

                                        command.Parameters.AddWithValue("@bookTitle", comboBox.Text);
                                        command.ExecuteNonQuery();

                                    }

                                }

                            }










                            // Display the successfull message to user if the Book issue process got successful.
                            MessageBox.Show($"Book(s) Issued Successfully...Expected Return Date : {returnDate.ToString("yyyy-MM-dd")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtUName.Clear();
                            txtUNIC.Clear();
                            comboB1.SelectedIndex = -1; txtcopiesB1.Clear(); txtrefbor1.Clear(); txtBNumberB1.Clear();
                            comboB2.SelectedIndex = -1; txtcopiesB2.Clear(); txtrefbor2.Clear(); txtBNumberB2.Clear();
                            comboB3.SelectedIndex = -1; txtcopiesB3.Clear(); txtrefbor3.Clear(); txtBNumberB3.Clear();
                            comboB4.SelectedIndex = -1; txtcopiesB4.Clear(); txtrefbor4.Clear(); txtBNumberB4.Clear();
                            comboB5.SelectedIndex = -1; txtcopiesB5.Clear(); txtrefbor5.Clear(); txtBNumberB5.Clear();
                            txtReturnDate.Clear();
                            txtIssueDate.Value = DateTime.Now;
                            txtReturnDate.Clear();
                            txtSearchBar.Clear();
                            txtnoofbooks.Clear();
                        }

                    }

                }

            }
            
        }

            private bool CheckNumOfCopies(string bookTitle)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
                    {
                        connection.Open();

                        
                        string query = "SELECT numofcopies FROM AddNewBook WHERE bookTitle = @BookTitle";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@BookTitle", bookTitle);

                            object result = command.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {

                                int numOfCopies = Convert.ToInt32(result);
                                return numOfCopies > 0;

                            }

                            else

                            {

                                return false;

                            }

                        }
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking numofcopies: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
       

        private void btnclear_Click(object sender, EventArgs e)
       {   
           // Clear the filled data in textboxes
            txtUName.Clear();
            txtUNIC.Clear();
            comboB1.SelectedIndex = -1;   txtcopiesB1.Clear();  txtrefbor1.Clear();  txtBNumberB1.Clear();
            comboB2.SelectedIndex = -1;   txtcopiesB2.Clear();  txtrefbor2.Clear();  txtBNumberB2.Clear();
            comboB3.SelectedIndex = -1;   txtcopiesB3.Clear();  txtrefbor3.Clear();  txtBNumberB3.Clear();
            comboB4.SelectedIndex = -1;   txtcopiesB4.Clear();  txtrefbor4.Clear();  txtBNumberB4.Clear();
            comboB5.SelectedIndex = -1;   txtcopiesB5.Clear();  txtrefbor5.Clear();  txtBNumberB5.Clear();
            txtReturnDate.Clear();
            txtIssueDate.Value = DateTime.Now;
            txtReturnDate.Clear();
            txtSearchBar.Clear();
            txtnoofbooks.Clear();

            comboB1.Enabled = true;
            comboB2.Enabled = true;
            comboB3.Enabled = true;
            comboB4.Enabled = true;
            comboB5.Enabled = true;

            txtcopiesB1.Enabled = true;
            txtcopiesB2.Enabled = true;
            txtcopiesB3.Enabled = true;
            txtcopiesB4.Enabled = true;
            txtcopiesB5.Enabled = true;

            txtrefbor1.Enabled = true;
            txtrefbor2.Enabled = true;
            txtrefbor3.Enabled = true;
            txtrefbor4.Enabled = true;
            txtrefbor5.Enabled = true;

            txtBNumberB1.Enabled = true;
            txtBNumberB2.Enabled = true;
            txtBNumberB3.Enabled = true;
            txtBNumberB4.Enabled = true;
            txtBNumberB5.Enabled = true;
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBNumberB1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtrefbor1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {

        }

    }

}

