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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;



namespace library_system
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {

            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            // Check if ReturnBook form is open
            if (Application.OpenForms.OfType<ReturnBook>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }
            }



        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtEnterUNumber.Clear();
            txtBorrowedBooks.Clear();
            txtNameUser.Clear();
            txtNumberNIC.Clear();
            txtborrowedB1.Clear(); txtborrowedDate1.Clear(); txtreturnDate1.Clear();
            txtborrowedB2.Clear(); txtborrowedDate2.Clear(); txtreturnDate2.Clear();
            txtborrowedB3.Clear(); txtborrowedDate3.Clear(); txtreturnDate3.Clear();
            txtborrowedB4.Clear(); txtborrowedDate4.Clear(); txtreturnDate4.Clear();
            txtborrowedB5.Clear(); txtborrowedDate5.Clear(); txtreturnDate5.Clear();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            if (txtEnterUNumber.Text != "")
            {

                string userNumber1 = txtEnterUNumber.Text;

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

                                txtNameUser.Text = DS.Tables[0].Rows[0]["UName"].ToString();
                                txtNumberNIC.Text = DS.Tables[0].Rows[0]["UNIC"].ToString();

                            }
                            else
                            {

                                txtNameUser.Clear();
                                txtNumberNIC.Clear();
                                MessageBox.Show("Invalid User Number.!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEnterUNumber.Clear();
                                txtBorrowedBooks.Clear();
                                return;

                            }

                        }

                    }

                }

            }
            // Check if the search bar is empty
            else if (string.IsNullOrEmpty(txtEnterUNumber.Text))
            {
                // Show an error message
                MessageBox.Show("Enter Your User Number First.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string userNumber = txtEnterUNumber.Text;
            GetBorrowedBookCount(userNumber);

        }

        public void GetBorrowedBookCount(string userNumber)
        {
            string connectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
    string query = "SELECT Book_1_Title, Book_2_Title, Book_3_Title, Book_4_Title, Book_5_Title, Book_Loaned_Date, Book_Return_Date FROM LoanedBook WHERE User_Number = @User_Number";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@User_Number", userNumber);

        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        int totalBookCount = 0;
        string[] borrowedBooks = new string[5];
        string[] loanedDates = new string[5];
        string[] returnDates = new string[5];

        while (reader.Read())
        {
            string loanedDate = reader["Book_Loaned_Date"].ToString();
            string returnDate = reader["Book_Return_Date"].ToString();

            for (int i = 0; i < reader.FieldCount - 2; i++)
            {
                if (!reader.IsDBNull(i))
                {
                    totalBookCount++;
                    borrowedBooks[i] += reader[i].ToString() + "\n";
                    loanedDates[i] += loanedDate + "\n";
                    returnDates[i] += returnDate + "\n";
                }
            }
        }

        reader.Close();

        if (totalBookCount == 0)
        {
            MessageBox.Show("User has no books to return.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtEnterUNumber.Clear();
            return;
        }
        else
        {
            txtBorrowedBooks.Text = totalBookCount.ToString();
            txtborrowedB1.Text = borrowedBooks[0];
            txtborrowedDate1.Text = loanedDates[0];
            txtreturnDate1.Text = returnDates[0];
            txtborrowedB2.Text = borrowedBooks[1];
            txtborrowedDate2.Text = loanedDates[1];
            txtreturnDate2.Text = returnDates[1];
            txtborrowedB3.Text = borrowedBooks[2];
            txtborrowedDate3.Text = loanedDates[2];
            txtreturnDate3.Text = returnDates[2];
            txtborrowedB4.Text = borrowedBooks[3];
            txtborrowedDate4.Text = loanedDates[3];
            txtreturnDate4.Text = returnDates[3];
            txtborrowedB5.Text = borrowedBooks[4];
            txtborrowedDate5.Text = loanedDates[4];
            txtreturnDate5.Text = returnDates[4];

        }

    }

        }
        private void btnreturn1_Click(object sender, EventArgs e)
        {
            string userNumber = txtEnterUNumber.Text;
            int oldestReservationId; // Define the variable here

            using (SqlConnection connection = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
            {
                connection.Open();

                // Step 1: Update LoanedBook table
                string updateQuery = $"UPDATE LoanedBook SET Book_1_Title = NULL WHERE User_Number = '{userNumber}'";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }

                // Step 2: Increase numofcopies in AddNewBook table
                string bookTitle = txtborrowedB1.Text.Trim(); // Trim to remove leading/trailing whitespaces
                string increaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies + 1 WHERE bookTitle = @BookTitle";

                using (SqlCommand increaseCopiesCommand = new SqlCommand(increaseCopiesQuery, connection))
                {
                    increaseCopiesCommand.Parameters.AddWithValue("@BookTitle", bookTitle); // Use parameterized query
                    increaseCopiesCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtborrowedB1.Clear(); txtborrowedDate1.Clear(); txtreturnDate1.Clear();

                // Step 3: Check if the returned book is reserved
                string checkReservedQuery = $"SELECT COUNT(*) FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}'";
                using (SqlCommand checkReservedCommand = new SqlCommand(checkReservedQuery, connection))
                {
                    int count = (int)checkReservedCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Step 4: Generate a notification for the borrower with the oldest reservation for the title
                        string oldestReservationQuery = $"SELECT TOP 1 ResNotAvail_ID FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}' ORDER BY ResNotAvail_ID";
                        using (SqlCommand oldestReservationCommand = new SqlCommand(oldestReservationQuery, connection))
                        {
                            oldestReservationId = (int)oldestReservationCommand.ExecuteScalar();
                            MessageBox.Show($"Returned book '{bookTitle}' is reserved by user number '{oldestReservationId}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        // Extra step (step 7)
                        string insertQuery = $"INSERT INTO ReservedBooks (Reserved_UserNumber, Reserved_UserName, Reserved_UserNIC, Reserved_BookTitle, Reserved_BookNumber, Reserved_BookPublisher, Reserved_BookAuthor, Reserved_BookISBN)" +
                         $" SELECT ResNotAvail_UserNumber, ResNotAvail_UserName, ResNotAvail_UserNIC, ResNotAvail_BookTitle, ResNotAvail_BookNumber, ResNotAvail_BookPublisher, ResNotAvail_BookAuthor, ResNotAvail_BookISBN FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                        // Step 5: Delete the oldest reservation for the title
                        string deleteOldestReservationQuery = $"DELETE FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                        using (SqlCommand deleteOldestReservationCommand = new SqlCommand(deleteOldestReservationQuery, connection))
                        {
                            deleteOldestReservationCommand.ExecuteNonQuery();
                        }

                        // Step 6: Decrease numofcopies in AddNewBook table after successful reservation
                        string decreaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies - 1 WHERE bookTitle = '{bookTitle}'";
                        using (SqlCommand decreaseCopiesCommand = new SqlCommand(decreaseCopiesQuery, connection))
                        {

                            decreaseCopiesCommand.ExecuteNonQuery();

                        }

                    }

                }

            }

        }

        private void btnreturn2_Click_1(object sender, EventArgs e)
        {

            string userNumber = txtEnterUNumber.Text;

            using (SqlConnection connection = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
            {
                connection.Open();

                // Step 1: Update LoanedBook table
                string updateQuery = $"UPDATE LoanedBook SET Book_2_Title = NULL WHERE User_Number = '{userNumber}'";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }

                // Step 2: Increase numofcopies in AddNewBook table
                string bookTitle = txtborrowedB2.Text.Trim(); // Trim to remove leading/trailing whitespaces
                string increaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies + 1 WHERE bookTitle = @BookTitle";

                using (SqlCommand increaseCopiesCommand = new SqlCommand(increaseCopiesQuery, connection))
                {
                    increaseCopiesCommand.Parameters.AddWithValue("@BookTitle", bookTitle); // Use parameterized query
                    increaseCopiesCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtborrowedB2.Clear(); txtborrowedDate2.Clear(); txtreturnDate2.Clear();
                // Step 3: Check if the returned book is reserved
                string checkReservedQuery = $"SELECT COUNT(*) FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}'";
                using (SqlCommand checkReservedCommand = new SqlCommand(checkReservedQuery, connection))
                {
                    int count = (int)checkReservedCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Step 4: Generate a notification for the borrower with the oldest reservation for the title
                        string oldestReservationQuery = $"SELECT TOP 1 ResNotAvail_ID FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}' ORDER BY ResNotAvail_ID";
                        using (SqlCommand oldestReservationCommand = new SqlCommand(oldestReservationQuery, connection))
                        {
                            int oldestReservationId = (int)oldestReservationCommand.ExecuteScalar();
                            MessageBox.Show($"Returned book '{bookTitle}' is reserved by user number '{oldestReservationId}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Extra step (step 7)
                            string insertQuery = $"INSERT INTO ReservedBooks (Reserved_UserNumber, Reserved_UserName, Reserved_UserNIC, Reserved_BookTitle, Reserved_BookNumber, Reserved_BookPublisher, Reserved_BookAuthor, Reserved_BookISBN)" +
                             $" SELECT ResNotAvail_UserNumber, ResNotAvail_UserName, ResNotAvail_UserNIC, ResNotAvail_BookTitle, ResNotAvail_BookNumber, ResNotAvail_BookPublisher, ResNotAvail_BookAuthor, ResNotAvail_BookISBN FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }

                            // Step 5: Delete the oldest reservation for the title
                            string deleteOldestReservationQuery = $"DELETE FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand deleteOldestReservationCommand = new SqlCommand(deleteOldestReservationQuery, connection))
                            {
                                deleteOldestReservationCommand.ExecuteNonQuery();
                            }

                            // Step 6: Decrease numofcopies in AddNewBook table after successful reservation
                            string decreaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies - 1 WHERE bookTitle = '{bookTitle}'";
                            using (SqlCommand decreaseCopiesCommand = new SqlCommand(decreaseCopiesQuery, connection))
                            {
                                decreaseCopiesCommand.ExecuteNonQuery();
                            }

                        }

                    }

                }

            }

        }

        private void btnreturn3_Click_1(object sender, EventArgs e)
        {
            string userNumber = txtEnterUNumber.Text;

            using (SqlConnection connection = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
            {
                connection.Open();

                // Step 1: Update LoanedBook table
                string updateQuery = $"UPDATE LoanedBook SET Book_3_Title = NULL WHERE User_Number = '{userNumber}'";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }

                // Step 2: Increase numofcopies in AddNewBook table
                string bookTitle = txtborrowedB3.Text.Trim(); // Trim to remove leading/trailing whitespaces
                string increaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies + 1 WHERE bookTitle = @BookTitle";

                using (SqlCommand increaseCopiesCommand = new SqlCommand(increaseCopiesQuery, connection))
                {
                    increaseCopiesCommand.Parameters.AddWithValue("@BookTitle", bookTitle); // Use parameterized query
                    increaseCopiesCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtborrowedB3.Clear(); txtborrowedDate3.Clear(); txtreturnDate3.Clear();
                // Step 3: Check if the returned book is reserved
                string checkReservedQuery = $"SELECT COUNT(*) FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}'";
                using (SqlCommand checkReservedCommand = new SqlCommand(checkReservedQuery, connection))
                {
                    int count = (int)checkReservedCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Step 4: Generate a notification for the borrower with the oldest reservation for the title
                        string oldestReservationQuery = $"SELECT TOP 1 ResNotAvail_ID FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}' ORDER BY ResNotAvail_ID";
                        using (SqlCommand oldestReservationCommand = new SqlCommand(oldestReservationQuery, connection))
                        {
                            int oldestReservationId = (int)oldestReservationCommand.ExecuteScalar();
                            MessageBox.Show($"Returned book '{bookTitle}' is reserved by user number '{oldestReservationId}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Extra step (step 7)
                            string insertQuery = $"INSERT INTO ReservedBooks (Reserved_UserNumber, Reserved_UserName, Reserved_UserNIC, Reserved_BookTitle, Reserved_BookNumber, Reserved_BookPublisher, Reserved_BookAuthor, Reserved_BookISBN)" +
                             $" SELECT ResNotAvail_UserNumber, ResNotAvail_UserName, ResNotAvail_UserNIC, ResNotAvail_BookTitle, ResNotAvail_BookNumber, ResNotAvail_BookPublisher, ResNotAvail_BookAuthor, ResNotAvail_BookISBN FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }

                            // Step 5: Delete the oldest reservation for the title
                            string deleteOldestReservationQuery = $"DELETE FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand deleteOldestReservationCommand = new SqlCommand(deleteOldestReservationQuery, connection))
                            {
                                deleteOldestReservationCommand.ExecuteNonQuery();
                            }

                            // Step 6: Decrease numofcopies in AddNewBook table after successful reservation
                            string decreaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies - 1 WHERE bookTitle = '{bookTitle}'";
                            using (SqlCommand decreaseCopiesCommand = new SqlCommand(decreaseCopiesQuery, connection))
                            {
                                decreaseCopiesCommand.ExecuteNonQuery();

                            }

                        }

                    }

                }

            }

        }

        private void btnreturn4_Click_1(object sender, EventArgs e)
        {
            string userNumber = txtEnterUNumber.Text;

            using (SqlConnection connection = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
            {
                connection.Open();

                // Step 1: Update LoanedBook table
                string updateQuery = $"UPDATE LoanedBook SET Book_4_Title = NULL WHERE User_Number = '{userNumber}'";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }

                // Step 2: Increase numofcopies in AddNewBook table
                string bookTitle = txtborrowedB4.Text.Trim(); // Trim to remove leading/trailing whitespaces
                string increaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies + 1 WHERE bookTitle = @BookTitle";

                using (SqlCommand increaseCopiesCommand = new SqlCommand(increaseCopiesQuery, connection))
                {
                    increaseCopiesCommand.Parameters.AddWithValue("@BookTitle", bookTitle); // Use parameterized query
                    increaseCopiesCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtborrowedB4.Clear(); txtborrowedDate4.Clear(); txtreturnDate4.Clear();
                // Step 3: Check if the returned book is reserved
                string checkReservedQuery = $"SELECT COUNT(*) FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}'";
                using (SqlCommand checkReservedCommand = new SqlCommand(checkReservedQuery, connection))
                {
                    int count = (int)checkReservedCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Step 4: Generate a notification for the borrower with the oldest reservation for the title
                        string oldestReservationQuery = $"SELECT TOP 1 ResNotAvail_ID FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}' ORDER BY ResNotAvail_ID";
                        using (SqlCommand oldestReservationCommand = new SqlCommand(oldestReservationQuery, connection))
                        {
                            int oldestReservationId = (int)oldestReservationCommand.ExecuteScalar();
                            MessageBox.Show($"Returned book '{bookTitle}' is reserved by user number '{oldestReservationId}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Extra step (step 7)
                            string insertQuery = $"INSERT INTO ReservedBooks (Reserved_UserNumber, Reserved_UserName, Reserved_UserNIC, Reserved_BookTitle, Reserved_BookNumber, Reserved_BookPublisher, Reserved_BookAuthor, Reserved_BookISBN)" +
                             $" SELECT ResNotAvail_UserNumber, ResNotAvail_UserName, ResNotAvail_UserNIC, ResNotAvail_BookTitle, ResNotAvail_BookNumber, ResNotAvail_BookPublisher, ResNotAvail_BookAuthor, ResNotAvail_BookISBN FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }

                            // Step 5: Delete the oldest reservation for the title
                            string deleteOldestReservationQuery = $"DELETE FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand deleteOldestReservationCommand = new SqlCommand(deleteOldestReservationQuery, connection))
                            {
                                deleteOldestReservationCommand.ExecuteNonQuery();
                            }

                            // Step 6: Decrease numofcopies in AddNewBook table after successful reservation
                            string decreaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies - 1 WHERE bookTitle = '{bookTitle}'";
                            using (SqlCommand decreaseCopiesCommand = new SqlCommand(decreaseCopiesQuery, connection))
                            {
                                decreaseCopiesCommand.ExecuteNonQuery();
                            }

                        }

                    }

                }

            }

        }

        private void btnreturn5_Click_1(object sender, EventArgs e)
        {
            string userNumber = txtEnterUNumber.Text;

            using (SqlConnection connection = new SqlConnection("data source = HP\\SQLEXPRESS; database = master; integrated security = True"))
            {
                connection.Open();

                // Step 1: Update LoanedBook table
                string updateQuery = $"UPDATE LoanedBook SET Book_5_Title = NULL WHERE User_Number = '{userNumber}'";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.ExecuteNonQuery();
                }

                // Step 2: Increase numofcopies in AddNewBook table
                string bookTitle = txtborrowedB5.Text.Trim(); // Trim to remove leading/trailing whitespaces
                string increaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies + 1 WHERE bookTitle = @BookTitle";

                using (SqlCommand increaseCopiesCommand = new SqlCommand(increaseCopiesQuery, connection))
                {
                    increaseCopiesCommand.Parameters.AddWithValue("@BookTitle", bookTitle); // Use parameterized query
                    increaseCopiesCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtborrowedB5.Clear(); txtborrowedDate5.Clear(); txtreturnDate5.Clear();
                // Step 3: Check if the returned book is reserved
                string checkReservedQuery = $"SELECT COUNT(*) FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}'";
                using (SqlCommand checkReservedCommand = new SqlCommand(checkReservedQuery, connection))
                {
                    int count = (int)checkReservedCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Step 4: Generate a notification for the borrower with the oldest reservation for the title
                        string oldestReservationQuery = $"SELECT TOP 1 ResNotAvail_ID FROM ResvBookNotAvail WHERE ResNotAvail_BookTitle = '{bookTitle}' ORDER BY ResNotAvail_ID";
                        using (SqlCommand oldestReservationCommand = new SqlCommand(oldestReservationQuery, connection))
                        {
                            int oldestReservationId = (int)oldestReservationCommand.ExecuteScalar();
                            MessageBox.Show($"Returned book '{bookTitle}' is reserved by user number '{oldestReservationId}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Extra step (step 7)
                            string insertQuery = $"INSERT INTO ReservedBooks (Reserved_UserNumber, Reserved_UserName, Reserved_UserNIC, Reserved_BookTitle, Reserved_BookNumber, Reserved_BookPublisher, Reserved_BookAuthor, Reserved_BookISBN)" +
                             $" SELECT ResNotAvail_UserNumber, ResNotAvail_UserName, ResNotAvail_UserNIC, ResNotAvail_BookTitle, ResNotAvail_BookNumber, ResNotAvail_BookPublisher, ResNotAvail_BookAuthor, ResNotAvail_BookISBN FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }

                            // Step 5: Delete the oldest reservation for the title
                            string deleteOldestReservationQuery = $"DELETE FROM ResvBookNotAvail WHERE ResNotAvail_ID = {oldestReservationId}";
                            using (SqlCommand deleteOldestReservationCommand = new SqlCommand(deleteOldestReservationQuery, connection))
                            {
                                deleteOldestReservationCommand.ExecuteNonQuery();
                            }

                            // Step 6: Decrease numofcopies in AddNewBook table after successful reservation
                            string decreaseCopiesQuery = $"UPDATE AddNewBook SET numofcopies = numofcopies - 1 WHERE bookTitle = '{bookTitle}'";
                            using (SqlCommand decreaseCopiesCommand = new SqlCommand(decreaseCopiesQuery, connection))
                            {

                                decreaseCopiesCommand.ExecuteNonQuery();

                            }

                        }

                    }

                }

            }

        }
        private void txtborrowedB1_TextChanged(object sender, EventArgs e)
        {

        }

    }

}






