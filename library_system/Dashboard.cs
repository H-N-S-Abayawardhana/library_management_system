// Dashboard Form

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system
{

    public partial class Dashboard : Form
    {

        public Dashboard()
        {

            InitializeComponent();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           

        }

        private void registerBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Button to Exit from the application
            if (MessageBox.Show("Are you sure you want to Exit ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes )
            {

                Application.Exit();

            }
           
        }

        private void aDDANEWBOOKToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Button to Add New Books
            AddBooks addbooks = new AddBooks();
            addbooks.Show();

        }

        private void btnclosedashboard_Click(object sender, EventArgs e)
        { 
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

          /* //Button to ViewBooks
            ViewBook viewbook = new ViewBook();
            viewbook.Show();*/

        }

        private void adToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Button to Add New Users
            AddUser adduser = new AddUser();
            adduser.Show();

        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Button to ViewUsers
            ViewUsers viewusers = new ViewUsers();
            viewusers.Show();

        }

        private void loanABookToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Button to Loan Process
            LoanProcess loanprocess = new LoanProcess();
            loanprocess.Show();

        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook returnbook = new ReturnBook();
            returnbook.Show();
        }

        private void loanBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reserveBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vIEWBOOKSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Button to ViewBooks
            ViewBook viewbook = new ViewBook();
            viewbook.Show();

        }

        private void vIEWLOANEDBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLoanBooks viewloanedbooks = new ViewLoanBooks();
            viewloanedbooks.Show();
        }

        private void rESERVEABOOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReserveBook reservebook = new ReserveBook();
            reservebook.Show();
        }

        private void vIEWRESERVEDBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReservedBook viewreservedbook = new ViewReservedBook();
            viewreservedbook.Show();
        }

        private void inquiriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookStatusLabel inquiryProcess = new BookStatusLabel();
            inquiryProcess.Show();
        }
    }

}
