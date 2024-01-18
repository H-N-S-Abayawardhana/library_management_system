//SignUp Form

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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            Dashboard dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();

            if (MessageBox.Show("Do you want to exit ?", "Are You Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        public void SaveUserDetails(string adminFullName, string adminNic, string adminMobileNo, string adminRole, string username, string create_password, string confirm_password)
        {
            string connectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security=True"; 
            string query = "INSERT INTO LoginTable (adminfullname, adminnic, adminmobileno, adminrole, username, create_password, confirm_password) VALUES (@adminFullName, @adminNic, @adminMobileNo, @adminRole, @username, @password, @confirmpassword)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@adminFullName", adminFullName);
                    command.Parameters.AddWithValue("@adminNic", adminNic);
                    command.Parameters.AddWithValue("@adminMobileNo", adminMobileNo);
                    command.Parameters.AddWithValue("@adminRole", adminRole);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", create_password);
                    command.Parameters.AddWithValue("@confirmpassword", confirm_password);

                    connection.Open();
                    command.ExecuteNonQuery();

                }

            }

        }
        

        private void btnsave_Click_1(object sender, EventArgs e)
        {

            string adminFullName = txtadminfullname.Text;
            string adminNic = txtadminNIC.Text;
            string adminMobileNo = txtcontactno.Text;
            string adminRole = txtadminrole.Text;
            string username = txtUsername.Text;
            string create_password = txtPassword.Text;
            string confirm_password = txtconfirmpassword.Text;

            
            if (create_password == confirm_password)
            {
                SaveUserDetails(adminFullName, adminNic, adminMobileNo, adminRole, username, create_password, confirm_password);
                MessageBox.Show("User details saved successfully.","Success.!",MessageBoxButtons.OK,MessageBoxIcon.Information);


                txtadminfullname.Clear();
                txtadminNIC.Clear() ;
                txtcontactno.Clear();
                txtadminrole.Clear();
                txtUsername.Clear(); 
                txtPassword.Clear();
                txtconfirmpassword.Clear();


            }
            else
            {
                //Display the error Message if Passwords are Mismatch.

                MessageBox.Show("Passwords Mismatch.Please try again.","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtadminfullname.Clear();
            txtadminNIC.Clear();
            txtcontactno.Clear();
            txtadminrole.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtconfirmpassword.Clear();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            // Check if SignUp form is open
            if (Application.OpenForms.OfType<SignUp>().Any())
            {
                // If SignUp form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }

            }

        }

    }

}

    
