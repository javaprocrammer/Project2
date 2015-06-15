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
    public static class MovieDB
    {
        public static List<Movie> GetMovie()
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Movie> movieList = new List<Movie>();

            string movieSQL = "SELECT movie_number, movie_title, description, movie_year_made, genre_id," +
                                " movie_rating, media_type, movie_retail_cost, tape_rental_cost," +
                                " copies_on_hand, image, trailer, vendor_id FROM Movie";

            SqlCommand objMovCommand = null;
            SqlConnection objMovConn = null;
            SqlDataReader movReader = null;

            try
            {
                using (objMovConn = new SqlConnection(connectionString))
                {
                    //Opens the connection to the database
                    objMovConn.Open();
                    //Command object created with the SQL statement
                    using (objMovCommand = new SqlCommand(movieSQL, objMovConn))
                    {
                        //SQL executes and returns a DataReader
                        using ((movReader = objMovCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (movReader.Read())
                            {
                                Movie objMovie = new Movie();
                                objMovie.MovieNumber = movReader["movie_number"].ToString();
                                objMovie.MovieTitle = movReader["movie_title"].ToString();
                                objMovie.Description = movReader["description"].ToString();
                                objMovie.YearReleased = movReader["movie_year_made"].ToString();
                                objMovie.GenreId = movReader["genre_id"].ToString();
                                objMovie.Rating = movReader["movie_rating"].ToString();
                                objMovie.Format = movReader["media_type"].ToString();
                                objMovie.RetailCost = movReader["movie_retail_cost"].ToString();
                                objMovie.RentalCost = movReader["tape_rental_cost"].ToString();
                                objMovie.OnHand = movReader["copies_on_hand"].ToString();
                                objMovie.Image = movReader["image"].ToString();
                                objMovie.Trailer = movReader["trailer"].ToString();
                                objMovie.VendorId = movReader["vendor_id"].ToString();

                                //Add Movie to collection
                                movieList.Add(objMovie);
                            }
                        }
                    }

                    return movieList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objMovConn != null)
                {
                    objMovConn.Close();
                }
            }
        }

        public static List<Movie> GetMemberMovie()
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Movie> memberMovieList = new List<Movie>();

            string movieSQL = "SELECT movie_number, movie_title, description, movie_year_made, genre_id," +
                                " movie_rating, tape_rental_cost FROM Movie";

            SqlCommand objMovCommand = null;
            SqlConnection objMovConn = null;
            SqlDataReader movReader = null;

            try
            {
                using (objMovConn = new SqlConnection(connectionString))
                {
                    //Opens the connection to the database
                    objMovConn.Open();
                    //Command object created with the SQL statement
                    using (objMovCommand = new SqlCommand(movieSQL, objMovConn))
                    {
                        //SQL executes and returns a DataReader
                        using ((movReader = objMovCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (movReader.Read())
                            {
                                Movie objMovie = new Movie();
                                objMovie.MovieNumber = movReader["movie_number"].ToString();
                                objMovie.MovieTitle = movReader["movie_title"].ToString();
                                objMovie.Description = movReader["description"].ToString();
                                objMovie.YearReleased = movReader["movie_year_made"].ToString();
                                objMovie.GenreId = movReader["genre_id"].ToString();
                                objMovie.Rating = movReader["movie_rating"].ToString();
                                objMovie.RentalCost = movReader["tape_rental_cost"].ToString();

                                //Add Movie to collection
                                memberMovieList.Add(objMovie);
                            }
                        }
                    }
                    return memberMovieList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objMovConn != null)
                {
                    objMovConn.Close();
                }
            }
        }

        public static Movie GetMovie(int movNumber)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            string movieSQL = "SELECT movie_number, movie_title, description, movie_year_made, genre_id," +
                                " movie_rating, media_type, movie_retail_cost, tape_rental_cost," +
                                " copies_on_hand, image, trailer, vendor_id FROM Movie" +
                                " WHERE movie_number = @movie_number";

            SqlCommand objMovCommand = null;
            SqlConnection objMovConn = null;
            SqlDataReader movReader = null;
            Movie objMovie = null;
            try
            {
                using (objMovConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objMovConn.Open();
                    //Create a command object with the SQL statement
                    using (objMovCommand = new SqlCommand(movieSQL, objMovConn))
                    {
                        //Set command parameter
                        objMovCommand.Parameters.AddWithValue("@movie_number", movNumber);
                        //Execute the SQL and return a DataReader
                        using ((movReader = objMovCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (movReader.Read())
                            {
                                objMovie = new Movie();
                                //Fill the customer object if found
                                objMovie.MovieNumber = movReader["movie_number"].ToString();
                                objMovie.MovieTitle = movReader["movie_title"].ToString();
                                objMovie.Description = movReader["description"].ToString();
                                objMovie.YearReleased = movReader["movie_year_made"].ToString();
                                objMovie.GenreId = movReader["genre_id"].ToString();
                                objMovie.Rating = movReader["movie_rating"].ToString();
                                objMovie.Format = movReader["media_type"].ToString();
                                objMovie.RetailCost = movReader["movie_retail_cost"].ToString();
                                objMovie.RentalCost = movReader["tape_rental_cost"].ToString();
                                objMovie.OnHand = movReader["copies_on_hand"].ToString();
                                objMovie.Image = movReader["image"].ToString();
                                objMovie.Trailer = movReader["trailer"].ToString();
                                objMovie.VendorId = movReader["vendor_id"].ToString();
                            }
                        }
                    }
                    return objMovie;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objMovConn != null)
                {
                    objMovConn.Close();
                }
            }
        }

        public static bool AddMovie(Movie objMovie)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string movieSQL;

            SqlCommand objMovCommand = null;
            SqlConnection objMovConn = null;

            try
            {
                using (objMovConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objMovConn.Open();
                    movieSQL = "INSERT into Movie VALUES (@movie_number, @movie_title, @description, @movie_year_made," +
                                " @genre_id, @movie_rating, @media_type, @movie_retail_cost, @tape_rental_cost," +
                                " @copies_on_hand, @image, @trailer, @vendor_id)";

                    //Create a command object with the SQL statement
                    using (objMovCommand = new SqlCommand(movieSQL, objMovConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objMovCommand.Parameters.AddWithValue("@movie_number", Convert.ToInt16(objMovie.MovieNumber));
                        objMovCommand.Parameters.AddWithValue("@movie_title", objMovie.MovieTitle);
                        objMovCommand.Parameters.AddWithValue("@description", objMovie.Description);
                        objMovCommand.Parameters.AddWithValue("@movie_year_made", Convert.ToInt16(objMovie.YearReleased));
                        objMovCommand.Parameters.AddWithValue("@genre_id", Convert.ToInt16(objMovie.GenreId));
                        objMovCommand.Parameters.AddWithValue("@movie_rating", objMovie.Rating);
                        objMovCommand.Parameters.AddWithValue("@media_type", objMovie.Format);
                        objMovCommand.Parameters.AddWithValue("@movie_retail_cost", Convert.ToDouble(objMovie.RetailCost));
                        objMovCommand.Parameters.AddWithValue("@tape_rental_cost", Convert.ToDouble(objMovie.RentalCost));
                        objMovCommand.Parameters.AddWithValue("@copies_on_hand", Convert.ToInt16(objMovie.OnHand));
                        objMovCommand.Parameters.AddWithValue("@image", objMovie.Image);
                        objMovCommand.Parameters.AddWithValue("@trailer", objMovie.Trailer);
                        objMovCommand.Parameters.AddWithValue("@vendor_id", objMovie.VendorId);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objMovCommand.ExecuteNonQuery();
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
                if (objMovConn != null)
                {
                    objMovConn.Close();
                }
            }
        }

        public static bool UpdateMovie(Movie objMovie)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;

            SqlCommand objMovCommand = null;
            SqlConnection objMovConn = null;

            string movieSQL;
            try
            {
                using (objMovConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objMovConn.Open();
                    movieSQL = "UPDATE Movie " + Environment.NewLine +
                                " SET movie_number = @movie_number, " + Environment.NewLine +
                                "    movie_title = @movie_title, " + Environment.NewLine +
                                "    description = @description, " + Environment.NewLine +
                                "    movie_year_made = @movie_year_made, " + Environment.NewLine +
                                "    genre_id = @genre_id, " + Environment.NewLine +
                                "    movie_rating = @movie_rating, " + Environment.NewLine +
                                "    media_type = @media_type, " + Environment.NewLine +
                                "    movie_retail_cost = @movie_retail_cost, " + Environment.NewLine +
                                "    tape_rental_cost = @tape_rental_cost, " + Environment.NewLine +
                                "    copies_on_hand = @copies_on_hand, " + Environment.NewLine +
                                "    image = @image, " + Environment.NewLine +
                                "    trailer = @trailer, " + Environment.NewLine +
                                "    vendor_id = @vendor_id " + Environment.NewLine +
                                " WHERE movie_number = @movie_number ";

                    //Create a command object with the SQL statement
                    using (objMovCommand = new SqlCommand(movieSQL, objMovConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objMovCommand.Parameters.AddWithValue("@movie_number", Convert.ToInt16(objMovie.MovieNumber));
                        objMovCommand.Parameters.AddWithValue("@movie_title", objMovie.MovieTitle);
                        objMovCommand.Parameters.AddWithValue("@description", objMovie.Description);
                        objMovCommand.Parameters.AddWithValue("@movie_year_made", Convert.ToInt16(objMovie.YearReleased));
                        objMovCommand.Parameters.AddWithValue("@genre_id", Convert.ToInt16(objMovie.GenreId));
                        objMovCommand.Parameters.AddWithValue("@movie_rating", objMovie.Rating);
                        objMovCommand.Parameters.AddWithValue("@media_type", objMovie.Format);
                        objMovCommand.Parameters.AddWithValue("@movie_retail_cost", Convert.ToDouble(objMovie.RetailCost));
                        objMovCommand.Parameters.AddWithValue("@tape_rental_cost", Convert.ToDouble(objMovie.RentalCost));
                        objMovCommand.Parameters.AddWithValue("@copies_on_hand", Convert.ToInt16(objMovie.OnHand));
                        objMovCommand.Parameters.AddWithValue("@image", objMovie.Image);
                        objMovCommand.Parameters.AddWithValue("@trailer", objMovie.Trailer);
                        objMovCommand.Parameters.AddWithValue("@vendor_id", objMovie.VendorId);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objMovCommand.ExecuteNonQuery();
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
                if (objMovConn != null)
                {
                    objMovConn.Close();
                }
            }
        }

        public static bool DeleteMovie(Movie objMovie)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;

            SqlConnection objMovConn = null;
            SqlCommand objMovCommand = null;

            string movieSQL;
            try
            {
                using (objMovConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objMovConn.Open();
                    movieSQL = "DELETE Movie WHERE movie_number = @movie_number";

                    //Create a command object with the SQL statement
                    using (objMovCommand = new SqlCommand(movieSQL, objMovConn))
                    {                        
                        objMovCommand.Parameters.AddWithValue("@movie_number", objMovie.MovieNumber);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objMovCommand.ExecuteNonQuery();
                        //Close the database connection
                        objMovConn.Close();

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
                if (objMovConn != null)
                {
                    objMovConn.Close();
                }

            }
        }
    }
}
