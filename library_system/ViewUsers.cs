
// View Users Process

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
using System.Xml.Linq;

namespace library_system
{

    public partial class ViewUsers : Form
    {

        public ViewUsers()
        {

            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchUNumber_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchUNumber.Text != "")

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from AddNewUser where UNumber LIKE '"+txtSearchUNumber.Text+"%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

            else

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from AddNewUser";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {

            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from AddNewUser";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            // Check if ViewUsers form is open
            if (Application.OpenForms.OfType<ViewUsers>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }

            }

        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)

            {

                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            

            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from AddNewUser where UserID = "+bid+" ";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());


            txtUNumber.Text = ds.Tables[0].Rows[0][1].ToString();
            txtUName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtUSex.Text = ds.Tables[0].Rows[0][3].ToString();
            txtUNIC.Text = ds.Tables[0].Rows[0][4].ToString();
            txtUAddress.Text = ds.Tables[0].Rows[0][5].ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            String UNumber = txtUNumber.Text;
            String UName = txtUName.Text;
            String USex = txtUSex.Text;
            String UNIC = txtUNIC.Text;
            String UAddress = txtUAddress.Text;

            if (MessageBox.Show("Data will be updated ! Are You Sure ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update AddNewUser set UNumber = '" + UNumber + "', UName = '" + UName + "', USex = '" + USex + "', UNIC = '" + UNIC + "', UAddress = '" + UAddress + "' where UserID = " + rowid + " ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                ViewUsers_Load(this, null);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            txtSearchUNumber.Clear();
            panel2.Visible = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data will be Deleted ! Are You Sure ?", "Warning !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from AddNewUser where UserID = "+rowid+" ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                ViewUsers_Load(this, null);

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewVisitors viewvisitors = new ViewVisitors();
            viewvisitors.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
 