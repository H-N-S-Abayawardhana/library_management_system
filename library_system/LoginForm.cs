// Login Form

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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Database connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HP\\SQLEXPRESS; database = master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //Validate process (Check Username and Password are correct)
            cmd.CommandText = "SELECT * FROM LoginTable WHERE username = '"+txtusername.Text+ "' and create_password ='" + txtpassword.Text+"' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count !=0)

            {

                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();

            }

            else

            {
                // If the Password or Username is wrong Display and error message

                MessageBox.Show("Wrong Username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Ask from user need to exit
            if (MessageBox.Show("Do you want to exit ?", "Are You Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {

                this.Close();

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            // Clear the Username textbox when click on the textbox
            if (txtusername.Text == "Username")

            {

                txtusername.Clear();

            }

        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            // Clear the password textbox when click on the textbox
            if (txtpassword.Text == "Password")

            {

                txtpassword.Clear();
                txtpassword.PasswordChar = '*';


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show SignUp page after click Sign Up button 
            SignUp sp = new SignUp();
            sp.Show();

        }

    }

}
