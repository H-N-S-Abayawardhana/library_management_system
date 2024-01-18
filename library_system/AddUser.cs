
// Add New Users Process

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

    public partial class AddUser : Form
    {

        public AddUser()
        {

            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {

            txtUNumber.Clear();
            txtUName.Clear();
            txtUSex.Clear();
            txtUNIC.Clear();
            txtUAddress.Clear();

        }

       

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtUNumber.Text != "" && txtUName.Text != "" && txtUSex.Text != "" && txtUNIC.Text != "" && txtUAddress.Text != "")

            {

                String UNumber = txtUNumber.Text;
                String UName = txtUName.Text;
                String USex = txtUSex.Text;
                String UNIC = txtUNIC.Text;
                String UAddress = txtUAddress.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Insert into AddNewUser (UNumber,UName,USex,UNIC,UAddress) values ('" + UNumber + "','" + UName + "', '" + USex + "', '" + UNIC + "', '" + UAddress + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("User Registered Successfully..!", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUNumber.Clear();
                txtUName.Clear();
                txtUSex.Clear();
                txtUNIC.Clear();
                txtUAddress.Clear();

            }

            else

            {

                MessageBox.Show("Please Fill empty fields !","Suggestion",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }

        }

        private void AddUser_Load(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Check if AddUser form is open
            if (Application.OpenForms.OfType<AddUser>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtUNumber.Text != "" && txtUName.Text != "" && txtUSex.Text != "" && txtUNIC.Text != "" && txtUAddress.Text != "")

            {

                String VNumber = txtUNumber.Text;
                String VName = txtUName.Text;
                String VSex = txtUSex.Text;
                String VNIC = txtUNIC.Text;
                String VAddress = txtUAddress.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Insert into AddNewVisitor (VNumber,VName,VSex,VNIC,VAddress) values ('" + VNumber + "','" + VName + "', '" + VSex + "', '" + VNIC + "', '" + VAddress + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Visitor Registered Successfully..!", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUNumber.Clear();
                txtUName.Clear();
                txtUSex.Clear();
                txtUNIC.Clear();
                txtUAddress.Clear();

            }

            else

            {

                MessageBox.Show("Please Fill empty fields !", "Suggestion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }

}
