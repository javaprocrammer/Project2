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
    public static class RentalDB
    {
        public static List<Rental> GetRental()
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Rental> rentalList = new List<Rental>();

            string rentalSQL = "SELECT movie_number, member_number, media_checkout_date," +
                                " media_return_date, media_exp_return_date, media_rental_cost FROM Rental";

            SqlCommand objRCommand = null;
            SqlConnection objRConn = null;
            SqlDataReader rentReader = null;

            try
            {
                using (objRConn = new SqlConnection(connectionString))
                {
                    //Opens the connection to the database
                    objRConn.Open();
                    //Command object created with the SQL statement
                    using (objRCommand = new SqlCommand(rentalSQL, objRConn))
                    {
                        //SQL executes and returns a DataReader
                        using ((rentReader = objRCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (rentReader.Read())
                            {
                                Rental objRent = new Rental();
                                objRent.MovieNumber = rentReader["movie_number"].ToString();
                                objRent.MemberNumber = rentReader["member_number"].ToString();
                                objRent.Checkedout = rentReader["media_checkout_date"].ToString();
                                objRent.Returned = rentReader["media_return_date"].ToString();
                                objRent.ExpectedReturn = rentReader["media_exp_return_date"].ToString();
                                objRent.RentalCost = rentReader["media_rental_cost"].ToString();

                                //Add Rental to collection
                                rentalList.Add(objRent);
                            }
                        }
                    }
                    return rentalList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objRConn != null)
                {
                    objRConn.Close();
                }
            }
        }

        public static Rental GetRental(int memNumber, int movNumber)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            string rentalSQL = "SELECT movie_number, member_number, media_checkout_date, media_return_date, " +
                               " media_exp_return_date, media_rental_cost FROM Rental" +
                               " WHERE member_number = @member_number AND movie_number = @movie_number";

            SqlCommand objRCommand = null;
            SqlConnection objRConn = null;
            SqlDataReader rentReader = null;
            Rental objRental = null;
            try
            {
                using (objRConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objRConn.Open();
                    //Create a command object with the SQL statement
                    using (objRCommand = new SqlCommand(rentalSQL, objRConn))
                    {
                        //Set command parameter
                        objRCommand.Parameters.AddWithValue("@member_number", memNumber);
                        objRCommand.Parameters.AddWithValue("@movie_number", movNumber);
                        //Execute the SQL and return a DataReader
                        using ((rentReader = objRCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (rentReader.Read())
                            {
                                objRental = new Rental();
                                //Fill the customer object if found
                                objRental.MovieNumber = rentReader["movie_number"].ToString();
                                objRental.MemberNumber = rentReader["member_number"].ToString();
                                objRental.Checkedout = rentReader["media_checkout_date"].ToString();
                                objRental.Returned = rentReader["media_return_date"].ToString();
                                objRental.ExpectedReturn = rentReader["media_exp_return_date"].ToString();
                                objRental.RentalCost = rentReader["media_rental_cost"].ToString();
                            }
                        }
                    }
                    return objRental;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objRConn != null)
                {
                    objRConn.Close();
                }
            }
        }

        public static bool AddRental(Rental objRental)
        {
            //string dateReturned = "";
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;

            SqlCommand objRCommand = null;
            SqlConnection objRConn = null;

            string rentalSQL;
            try
            {
                using (objRConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objRConn.Open();
                    rentalSQL = "INSERT into Rental values ("
                             + "@movie_number, @member_number, @media_checkout_date, @media_return_date," + 
                                    " @media_exp_return_date, @media_rental_cost)";

                    //Create a command object with the SQL statement
                    using (objRCommand = new SqlCommand(rentalSQL, objRConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objRCommand.Parameters.AddWithValue("@movie_number", Convert.ToInt16(objRental.MovieNumber));
                        objRCommand.Parameters.AddWithValue("@member_number", Convert.ToInt16(objRental.MemberNumber));
                        objRCommand.Parameters.AddWithValue("@media_checkout_date", objRental.Checkedout);
                        objRCommand.Parameters.AddWithValue("@media_return_date", objRental.Returned);
                        objRCommand.Parameters.AddWithValue("@media_exp_return_date", objRental.ExpectedReturn);
                        objRCommand.Parameters.AddWithValue("@media_rental_cost", Convert.ToDouble(objRental.RentalCost));
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objRCommand.ExecuteNonQuery();
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
                if (objRConn != null)
                {
                    objRConn.Close();
                }
            }
        }

        public static bool UpdateRental(Rental objRental)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;

            SqlCommand objRCommand = null;
            SqlConnection obRjConn = null;

            string rentalSQL;
            try
            {
                using (obRjConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    obRjConn.Open();
                    rentalSQL = "UPDATE rental " + Environment.NewLine +
                                " SET movie_number = @movie_number, " + Environment.NewLine +
                                "    member_number = @member_number, " + Environment.NewLine +
                                "    media_checkout_date = @media_checkout_date, " + Environment.NewLine +
                                "    media_return_date = @media_return_date, " + Environment.NewLine +
                                "    media_exp_return_date = @media_exp_return_date, " + Environment.NewLine +
                                "    media_rental_cost = @media_rental_cost " + Environment.NewLine +
                                " WHERE member_number = @member_number AND movie_number = @movie_number ";

                    //Create a command object with the SQL statement
                    using (objRCommand = new SqlCommand(rentalSQL, obRjConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objRCommand.Parameters.AddWithValue("@movie_number", Convert.ToInt16(objRental.MovieNumber));
                        objRCommand.Parameters.AddWithValue("@member_number", Convert.ToInt16(objRental.MemberNumber));
                        objRCommand.Parameters.AddWithValue("@media_checkout_date", objRental.Checkedout);
                        objRCommand.Parameters.AddWithValue("@media_return_date", objRental.Returned);
                        objRCommand.Parameters.AddWithValue("@media_exp_return_date", objRental.ExpectedReturn);
                        objRCommand.Parameters.AddWithValue("@media_rental_cost", Convert.ToDouble(objRental.RentalCost));
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objRCommand.ExecuteNonQuery();
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
                if (obRjConn != null)
                {
                    obRjConn.Close();
                }
            }
        }

        public static bool DeleteRental(Rental objRental)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;

            SqlConnection objConn = null;
            SqlCommand objCommand = null;

            string sqlString;
            try
            {
                using (objConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objConn.Open();
                    sqlString = "DELETE Rental WHERE member_number = @member_number AND movie_number = @movie_number";

                    //Create a command object with the SQL statement
                    using (objCommand = new SqlCommand(sqlString, objConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objCommand.Parameters.AddWithValue("@member_number", objRental.MemberNumber);
                        objCommand.Parameters.AddWithValue("@movie_number", objRental.MovieNumber);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objCommand.ExecuteNonQuery();
                        //Close the database connection
                        objConn.Close();

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
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objConn != null)
                {
                    objConn.Close();
                }
            }
        }
    }
}
