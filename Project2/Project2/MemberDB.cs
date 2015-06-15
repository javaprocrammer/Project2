using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Added using namespaces for SQL Server
using System.Data;
using System.Data.SqlClient;

namespace Project2
{
    public static class MemberDB
    {
        public static List<Member> GetMember()
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Member> memberList = new List<Member>();

            string memberSQL = "SELECT member_number, joindate, firstname, lastname, address, city, state," +
                                " zipcode, phone, member_status, password, employee FROM Member";

            SqlCommand objMemCommand = null;
            SqlConnection objMemConn = null;
            SqlDataReader memReader = null;

            try
            {
                using (objMemConn = new SqlConnection(connectionString))
                {
                    //Opens the connection to the database
                    objMemConn.Open();
                    //Command object created with the SQL statement
                    using (objMemCommand = new SqlCommand(memberSQL, objMemConn))
                    {
                        //SQL executes and returns a DataReader
                        using ((memReader = objMemCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (memReader.Read())
                            {
                                Member objMember = new Member();
                                objMember.MemberNumber = memReader["member_number"].ToString();
                                objMember.JoinDate = memReader["joindate"].ToString();
                                objMember.FirstName = memReader["firstname"].ToString();
                                objMember.LastName = memReader["lastname"].ToString();
                                objMember.Address = memReader["address"].ToString();
                                objMember.City = memReader["city"].ToString();
                                objMember.State = memReader["state"].ToString();
                                objMember.Zipcode = memReader["zipcode"].ToString();
                                objMember.Phone = memReader["phone"].ToString();
                                objMember.Status = memReader["member_status"].ToString();
                                objMember.Password = memReader["password"].ToString();
                                objMember.Employee = memReader["employee"].ToString();

                                //Add Member to collection
                                memberList.Add(objMember);
                            }
                        }
                    }
                    return memberList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objMemConn != null)
                {
                    objMemConn.Close();
                }
            }
        }

        public static Member GetMember(int memNumber)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            string memberSQL = "SELECT member_number, joindate, firstname, lastname, address, city, state," +
                                " zipcode, phone, member_status, password, employee FROM Member" +
                                " WHERE member_number = @member_number";

            SqlCommand objMemCommand = null;
            SqlConnection objMemConn = null;
            SqlDataReader memReader = null;
            Member objMember = null;
            try
            {
                using (objMemConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objMemConn.Open();
                    //Create a command object with the SQL statement
                    using (objMemCommand = new SqlCommand(memberSQL, objMemConn))
                    {
                        //Set command parameter
                        objMemCommand.Parameters.AddWithValue("@member_number", memNumber);
                        //Execute the SQL and return a DataReader
                        using ((memReader = objMemCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (memReader.Read())
                            {
                                objMember = new Member();
                                //Fill the customer object if found
                                objMember.MemberNumber = memReader["member_number"].ToString();
                                objMember.JoinDate = memReader["joindate"].ToString();
                                objMember.FirstName = memReader["firstname"].ToString();
                                objMember.LastName = memReader["lastname"].ToString();
                                objMember.Address = memReader["address"].ToString();
                                objMember.City = memReader["city"].ToString();
                                objMember.State = memReader["state"].ToString();
                                objMember.Zipcode = memReader["zipcode"].ToString();
                                objMember.Phone = memReader["phone"].ToString();
                                objMember.Status = memReader["member_status"].ToString();
                                objMember.Password = memReader["password"].ToString();
                                objMember.Employee = memReader["employee"].ToString();
                            }
                        }
                    }
                    return objMember;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objMemConn != null)
                {
                    objMemConn.Close();
                }
            }
        }

        public static bool UpdateMemMember(Member objMember)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string memberSQL;

            SqlCommand objUpCommand = null;
            SqlConnection objUpConn = null;

            try
            {
                using (objUpConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objUpConn.Open();
                    memberSQL = "UPDATE Member " + Environment.NewLine +
                                " SET firstname = @FirstName, " + Environment.NewLine +
                                "     lastname = @LastName, " + Environment.NewLine +
                                "     address = @Address, " + Environment.NewLine +
                                "     city = @City, " + Environment.NewLine +
                                "     state = @State, " + Environment.NewLine +
                                "     zipcode = @Zipcode, " + Environment.NewLine +
                                "     phone = @Phone, " + Environment.NewLine +
                                "     password = @Password " + Environment.NewLine +
                                " WHERE member_number = @MemberNumber ";

                    //Create a command object with the SQL statement
                    using (objUpCommand = new SqlCommand(memberSQL, objUpConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objUpCommand.Parameters.AddWithValue("@MemberNumber",Convert.ToInt16(objMember.MemberNumber));
                        objUpCommand.Parameters.AddWithValue("@FirstName", objMember.FirstName);
                        objUpCommand.Parameters.AddWithValue("@LastName", objMember.LastName);
                        objUpCommand.Parameters.AddWithValue("@Address", objMember.Address);
                        objUpCommand.Parameters.AddWithValue("@City", objMember.City);
                        objUpCommand.Parameters.AddWithValue("@State", objMember.State);
                        objUpCommand.Parameters.AddWithValue("@Zipcode", objMember.Zipcode);
                        objUpCommand.Parameters.AddWithValue("@Phone", objMember.Phone);
                        objUpCommand.Parameters.AddWithValue("@Password", objMember.Password);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objUpCommand.ExecuteNonQuery();
                    }
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objUpConn != null)
                {
                    objUpConn.Close();
                }
            }
        }

        public static bool UpdateAdminMember(Member objMember)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string memberSQL;

            SqlCommand objUpCommand = null;
            SqlConnection objUpConn = null;

            try
            {
                using (objUpConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objUpConn.Open();
                    memberSQL = "UPDATE Member " + Environment.NewLine +
                                " SET member_number = @MemberNumber, " + Environment.NewLine +
                                "     joindate = @Joindate, " + Environment.NewLine +
                                "     firstname = @FirstName, " + Environment.NewLine +
                                "     lastname = @LastName, " + Environment.NewLine +
                                "     address = @Address, " + Environment.NewLine +
                                "     city = @City, " + Environment.NewLine +
                                "     state = @State, " + Environment.NewLine +
                                "     zipcode = @Zipcode, " + Environment.NewLine +
                                "     phone = @Phone, " + Environment.NewLine +
                                "     member_status = @Status, " + Environment.NewLine +
                                "     password = @Password, " + Environment.NewLine +
                                "     employee = @Employee " + Environment.NewLine +
                                " WHERE member_number = @MemberNumber ";

                    //Create a command object with the SQL statement
                    using (objUpCommand = new SqlCommand(memberSQL, objUpConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objUpCommand.Parameters.AddWithValue("@MemberNumber", Convert.ToInt16(objMember.MemberNumber));
                        objUpCommand.Parameters.AddWithValue("@Joindate", objMember.JoinDate);
                        objUpCommand.Parameters.AddWithValue("@FirstName", objMember.FirstName);
                        objUpCommand.Parameters.AddWithValue("@LastName", objMember.LastName);
                        objUpCommand.Parameters.AddWithValue("@Address", objMember.Address);
                        objUpCommand.Parameters.AddWithValue("@City", objMember.City);
                        objUpCommand.Parameters.AddWithValue("@State", objMember.State);
                        objUpCommand.Parameters.AddWithValue("@Zipcode", objMember.Zipcode);
                        objUpCommand.Parameters.AddWithValue("@Phone", objMember.Phone);
                        objUpCommand.Parameters.AddWithValue("@Status", objMember.Status);
                        objUpCommand.Parameters.AddWithValue("@Password", objMember.Password);
                        objUpCommand.Parameters.AddWithValue("@Employee", Convert.ToInt16(objMember.Employee));
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objUpCommand.ExecuteNonQuery();
                    }
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objUpConn != null)
                {
                    objUpConn.Close();
                }
            }
        }

        public static bool AddMember(Member objMember)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string memberSQL;

            SqlCommand objMemCommand = null;
            SqlConnection objMemConn = null;

            try
            {
                using (objMemConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objMemConn.Open();
                    memberSQL = "INSERT into Member VALUES (@member_number, @joindate, @firstname, @lastname, @address," +
                                " @city, @state, @zipcode, @phone, @member_status, @password, @employee)";

                    //Create a command object with the SQL statement
                    using (objMemCommand = new SqlCommand(memberSQL, objMemConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objMemCommand.Parameters.AddWithValue("@member_number", Convert.ToInt16(objMember.MemberNumber));
                        objMemCommand.Parameters.AddWithValue("@joindate", objMember.JoinDate);
                        objMemCommand.Parameters.AddWithValue("@firstName", objMember.FirstName);
                        objMemCommand.Parameters.AddWithValue("@lastName", objMember.LastName);
                        objMemCommand.Parameters.AddWithValue("@address", objMember.Address);
                        objMemCommand.Parameters.AddWithValue("@city", objMember.City);
                        objMemCommand.Parameters.AddWithValue("@state", objMember.State);
                        objMemCommand.Parameters.AddWithValue("@zipcode", objMember.Zipcode);
                        objMemCommand.Parameters.AddWithValue("@phone", objMember.Phone);
                        objMemCommand.Parameters.AddWithValue("@member_status", objMember.Status);
                        objMemCommand.Parameters.AddWithValue("@password", objMember.Password);
                        objMemCommand.Parameters.AddWithValue("@employee", Convert.ToInt16(objMember.Employee));
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objMemCommand.ExecuteNonQuery();
                    }
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objMemConn != null)
                {
                    objMemConn.Close();
                }
            }
        }

        public static bool DeleteMember(Member objMember)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string memberSQL;

            SqlCommand objMemCommand = null;
            SqlConnection objMemConn = null;

            try
            {
                using (objMemConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objMemConn.Open();
                    memberSQL = "DELETE Member WHERE member_number = @member_number";

                    //Create a command object with the SQL statement
                    using (objMemCommand = new SqlCommand(memberSQL, objMemConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objMemCommand.Parameters.AddWithValue("@member_number", objMember.MemberNumber);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objMemCommand.ExecuteNonQuery();
                    }
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objMemConn != null)
                {
                    objMemConn.Close();
                }
            }
        }
    }
}
