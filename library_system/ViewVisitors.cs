using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system
{
    public partial class ViewVisitors : Form
    {
        public ViewVisitors()
        {
            InitializeComponent();
        }

        private void txtSearchUNumber_TextChanged(object sender, EventArgs e)
        {

            if (txtSearchUNumber.Text != "")

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM AddNewVisitor WHERE VNumber LIKE '" + txtSearchUNumber.Text + "%' ";
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

                cmd.CommandText = "SELECT * FROM AddNewVisitor";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchUNumber.Clear();
        }

        private void ViewVisitors_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM AddNewVisitor";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            // Check if ViewVisitors form is open
            if (Application.OpenForms.OfType<ViewVisitors>().Any())
            {
                // If LoanProcess form is open, hide the Dashboard form
                var dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                if (dashboardForm != null)
                {
                    dashboardForm.Hide();
                }

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
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

            cmd.CommandText = "SELECT * FROM AddNewVisitor WHERE VUserID = " + bid + " ";
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


            String VNumber = txtUNumber.Text;
            String VName = txtUName.Text;
            String VSex = txtUSex.Text;
            String VNIC = txtUNIC.Text;
            String VAddress = txtUAddress.Text;

            if (MessageBox.Show("Data will be updated ! Are You Sure ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "UPDATE AddNewVisitor SET VNumber = '" + VNumber + "', VName = '" + VName + "', VSex = '" + VSex + "', VNIC = '" + VNIC + "', VAddress = '" + VAddress + "' where VUserID = " + rowid + " ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                ViewVisitors_Load(this, null);

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted ! Are You Sure ?", "Warning !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)

            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM AddNewVisitor WHERE VUserID = " + rowid + " ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                ViewVisitors_Load(this, null);

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

        }

    }

}
