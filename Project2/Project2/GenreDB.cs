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
    public static class GenreDB
    {
        public static List<Genre> GetGenre()
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Genre> genreList = new List<Genre>();

            string genreSQL = "SELECT genre_id, genre_name FROM Genre";

            SqlCommand objGCommand = null;
            SqlConnection objGConn = null;
            SqlDataReader genreReader = null;

            try
            {
                using (objGConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objGConn.Open();
                    //Command object created with the SQL statement
                    using (objGCommand = new SqlCommand(genreSQL, objGConn))
                    {
                        //Execute the SQL and return a DataReader
                        using ((genreReader = objGCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (genreReader.Read())
                            {
                                Genre objGenre = new Genre();
                                objGenre.GenreId = genreReader["genre_id"].ToString();
                                objGenre.GenreName = genreReader["genre_name"].ToString();

                                //Add Genre to collection
                                genreList.Add(objGenre);
                            }
                        }
                    }

                    return genreList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objGConn != null)
                {
                    objGConn.Close();
                }
            }
        }

        public static Genre GetGenre(int genNumber)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            string genreSQL = "SELECT genre_id, genre_name FROM Genre" +
                              " WHERE genre_id = @genre_id";

            SqlCommand objGCommand = null;
            SqlConnection objGConn = null;
            SqlDataReader genReader = null;
            Genre objGenre = null;
            try
            {
                using (objGConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objGConn.Open();
                    //Create a command object with the SQL statement
                    using (objGCommand = new SqlCommand(genreSQL, objGConn))
                    {
                        //Set command parameter
                        objGCommand.Parameters.AddWithValue("@genre_id", genNumber);
                        //Execute the SQL and return a DataReader
                        using ((genReader = objGCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (genReader.Read())
                            {
                                objGenre = new Genre();
                                //Fill the customer object if found
                                objGenre.GenreId = genReader["genre_id"].ToString();
                                objGenre.GenreName = genReader["genre_name"].ToString();
                            }
                        }
                    }
                    return objGenre;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objGConn != null)
                {
                    objGConn.Close();
                }
            }
        }

        public static bool AddGenre(Genre objGenre)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string genreSQL;

            SqlCommand objGCommand = null;
            SqlConnection objGConn = null;

            try
            {
                using (objGConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objGConn.Open();
                    genreSQL = "INSERT into Genre VALUES (@genre_id, @genre_name)";

                    //Create a command object with the SQL statement
                    using (objGCommand = new SqlCommand(genreSQL, objGConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objGCommand.Parameters.AddWithValue("@genre_id", Convert.ToInt16(objGenre.GenreId));
                        objGCommand.Parameters.AddWithValue("@genre_name", objGenre.GenreName);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objGCommand.ExecuteNonQuery();
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
                if (objGConn != null)
                {
                    objGConn.Close();
                }
            }
        }

        public static bool UpdateGenre(Genre objGenre)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string genreSQL;

            SqlCommand objGCommand = null;
            SqlConnection objGConn = null;

            try
            {
                using (objGConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objGConn.Open();
                    genreSQL = "UPDATE Genre " + Environment.NewLine +
                                " SET genre_id = @genre_id, " + Environment.NewLine +
                                "     genre_name = @genre_name " + Environment.NewLine +
                                " WHERE genre_id = @genre_id ";

                    //Create a command object with the SQL statement
                    using (objGCommand = new SqlCommand(genreSQL, objGConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objGCommand.Parameters.AddWithValue("@genre_id", Convert.ToInt16(objGenre.GenreId));
                        objGCommand.Parameters.AddWithValue("@genre_name", objGenre.GenreName);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objGCommand.ExecuteNonQuery();
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
                if (objGConn != null)
                {
                    objGConn.Close();
                }
            }
        }

        public static bool DeleteGenre(Genre objGenre)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string genreSQL;

            SqlCommand objGCommand = null;
            SqlConnection objGConn = null;

            try
            {
                using (objGConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objGConn.Open();
                    genreSQL = "DELETE Genre WHERE genre_id = @genre_id";

                    //Create a command object with the SQL statement
                    using (objGCommand = new SqlCommand(genreSQL, objGConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objGCommand.Parameters.AddWithValue("@genre_id", objGenre.GenreId);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objGCommand.ExecuteNonQuery();
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
                if (objGConn != null)
                {
                    objGConn.Close();
                }
            }
        }
    }
}
