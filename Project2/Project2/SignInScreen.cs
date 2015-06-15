using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;


namespace Project2
{
    public partial class SignInScreen : Form
    {
        int memNum = 0;
        public SignInScreen()
        {
            InitializeComponent();            
        }

        private void SignInScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void memberBtn_Click(object sender, EventArgs e)
        {
            ValidMember();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            ValidAdmin();           
        }

        private void ValidMember()
        {
            string user = "";
            string pass = "";
            string p = "";

            if (txtUsername.Text.Trim() == String.Empty || txtPassword.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please ensure both Username and Password are filled in.",
                                        "Sign-In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtUsername.Text.Trim() == String.Empty)
                {
                    txtUsername.Focus();
                }
                else
                {
                    txtPassword.Focus();
                }
            }
            else
            {
                user = txtUsername.Text.Trim();
                pass = txtPassword.Text.Trim();
                string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

                SqlCommand objCommand;
                SqlDataReader custReader;
                string sqlString;
                try
                {
                    using (SqlConnection objConn = new SqlConnection(connectionString))
                    {
                        //Open the connection to the datbase
                        objConn.Open();
                        // MessageBox.Show("Connection to database is " + objConn.State.ToString());
                        sqlString = "SELECT password, member_number FROM Member WHERE lastname = '" + txtUsername.Text + "'";
                        //Create a command object with the SQL statement
                        using (objCommand = new SqlCommand(sqlString, objConn))
                        {
                            //Execute the SQL and return a DataReader
                            using ((custReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                            {
                                while (custReader.Read())
                                {
                                    p = custReader["password"].ToString();
                                    if (p.Equals(pass))
                                    {
                                        txtUsername.Clear();
                                        txtPassword.Clear();                                       
                                        memNum = Convert.ToInt16(custReader["member_number"].ToString());
                                        MembersScreenBuild(memNum);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong Password");
                                    }
                                }
                            }
                        }
                        //Close the connection
                        objConn.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ValidAdmin()
        {
            string user = "";
            string pass = "";
            string p = "";
            int emp = 0;

            if (txtUsername.Text.Trim() == String.Empty || txtPassword.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please ensure both Username and Password are filled in.",
                                        "Sign-In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtUsername.Text.Trim() == String.Empty)
                {
                    txtUsername.Focus();
                }
                else
                {
                    txtPassword.Focus();
                }
            }
            else
            {
                user = txtUsername.Text.Trim();
                pass = txtPassword.Text.Trim();
                string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

                SqlCommand objCommand;
                SqlDataReader custReader;
                string sqlString;
                try
                {
                    using (SqlConnection objConn = new SqlConnection(connectionString))
                    {
                        //Open the connection to the datbase
                        objConn.Open();
                        // MessageBox.Show("Connection to database is " + objConn.State.ToString());
                        sqlString = "SELECT password, employee FROM Member WHERE lastname = '" + txtUsername.Text + "'";
                        //Create a command object with the SQL statement
                        using (objCommand = new SqlCommand(sqlString, objConn))
                        {
                            //Execute the SQL and return a DataReader
                            using ((custReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                            {
                                while (custReader.Read())
                                {
                                    p = custReader["password"].ToString();
                                    emp = Convert.ToInt16(custReader["employee"]);
                                    if (p.Equals(pass))
                                    {
                                        if (emp == 1)
                                        {
                                            txtUsername.Clear();
                                            txtPassword.Clear();
                                            AdminScreenBuild();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Account does not have Admin access.");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Wrong Password");
                                    }
                                }
                            }
                        }
                        //Close the connection
                        objConn.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MembersScreenBuild(int memNum)
        {
            //Call the New Customer Form as a dialog 
            MembersScreen objMemScrn = new MembersScreen(memNum);
            objMemScrn.ShowDialog();
            //Get the New customer object
            objMemScrn = null;
        }

        private void AdminScreenBuild()
        {
            //Call the New Customer Form as a dialog 
            AdminScreen objAdminScrn = new AdminScreen();
            objAdminScrn.ShowDialog();
            //Get the New customer object
            objAdminScrn = null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("To become a member, please speak to an STLCC-Meramec librarian. ", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
    }
}
