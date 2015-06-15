using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project2
{
    public partial class MembersScreen : Form
    {
        int mNumber = 0;
        string rentDate = "";
        string returnDate = "";

        public MembersScreen(int memNum)
        {
            InitializeComponent();
            mNumber = memNum;
        }

        private void MembersScreen_Load(object sender, EventArgs e)
        {
            txtMemId.Text = mNumber.ToString();
        }

        private void GetDate()
        {
            DateTime rentDateNow = DateTime.Now;
            DateTime returnDateThen = DateTime.Now.AddDays(3);

            rentDate = rentDateNow.ToString();
            returnDate = returnDateThen.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMemUpdate_Click(object sender, EventArgs e)
        {
            if (txtMFname.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your First Name.", "First Name Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMFname.Focus();
                return;
            }
            if (txtMLname.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your Last Name.", "Last Name Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMLname.Focus();
                return;
            }
            if (txtMAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your Street Adress.", "Address Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMAddress.Focus();
                return;
            }
            if (txtMCity.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter the name of your city/town.", "City Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMCity.Focus();
                return;
            }
            if (txtMState.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your State with its 2 letter designation.", "State Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMState.Focus();
                return;
            }
            if (txtMZip.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your Zipcode.", "Zipcode Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMZip.Focus();
                return;
            }
            if (txtMPhone.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your Phone Number.", "Phone Number Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMPhone.Focus();
                return;
            }
            if (txtMPass.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your new Password.", "Password Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMPass.Focus();
                return;
            }
            if (txtMemId.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter your Member ID Number.", "Member ID Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemId.Focus();
                return;
            }

            Member objMember = new Member();
            objMember.MemberNumber = txtMemId.Text.Trim();
            objMember.FirstName = txtMFname.Text.Trim();
            objMember.LastName = txtMLname.Text.Trim();
            objMember.Address = txtMAddress.Text.Trim();
            objMember.City = txtMCity.Text.Trim();
            objMember.State = txtMState.Text.Trim();
            objMember.Zipcode = txtMZip.Text.Trim();
            objMember.Phone = txtMPhone.Text.Trim();
            objMember.Password = txtMPass.Text.Trim();

            try
            {  
                bool status = MemberDB.UpdateMemMember(objMember);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Member information updated in the database.", "", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MemClear();
                }
                else
                {
                    MessageBox.Show("Member was not updated in the database.", "", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMAvailMovies_Click(object sender, EventArgs e)
        {
            
            try
            {
                List<Movie> movieList = new List<Movie>();
                movieList = MovieDB.GetMemberMovie();
                //MessageBox.Show("You have " + customerList.Count.ToString() + " customers");
                gridviewMemMovies.DataSource = movieList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMClear_Click(object sender, EventArgs e)
        {
            gridviewMemMovies.DataSource = null;
            txtGenreSearch.Clear();
            txtRatedSearch.Clear();
            cboViewList.DataSource = null;
        }

        private void btnMGenreMovies_Click(object sender, EventArgs e)
        {
            txtRatedSearch.Clear();

            string gsearch = "";
            if (txtGenreSearch.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a movie genre to find.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenreSearch.Focus();
                return;
            }
            else
            {
                gsearch = txtGenreSearch.Text.Trim();
            }
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Movie> genreSearchList = new List<Movie>();

            string movieSQL = "SELECT movie_number, movie_title, description, movie_year_made," +
                                " movie.genre_id, movie_rating, tape_rental_cost" +
                                " FROM movie INNER JOIN genre on movie.genre_id = genre.genre_id" +
                                " WHERE genre.genre_name = '" + gsearch + "'";

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
                                genreSearchList.Add(objMovie);
                            }                            
                        }
                    }
                    gridviewMemMovies.DataSource = genreSearchList;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (objMovConn != null)
                {
                    objMovConn.Close();
                }
            }
        }        

        private void btnMRatedMovies_Click(object sender, EventArgs e)
        {
            txtGenreSearch.Clear();

            string rsearch = "";
            if (txtRatedSearch.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a movie rating to find.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRatedSearch.Focus();
                return;
            }
            else
            {
                rsearch = txtRatedSearch.Text.Trim();
            }
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Movie> ratedSearchList = new List<Movie>();

            string movieSQL = "SELECT movie_number, movie_title, description, movie_year_made," +
                                " genre_id, movie_rating, tape_rental_cost" +
                                " FROM movie WHERE movie_rating = '" + rsearch + "'";

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
                                ratedSearchList.Add(objMovie);
                            }
                        }
                    }
                    gridviewMemMovies.DataSource = ratedSearchList;
                    //return memberMovieList;
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

        private void btnMSave_Click(object sender, EventArgs e)
        {
            GetDate();
            string rCost = "";

            if (txtRentalSave.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number to save.", "Rental Save Error", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentalSave.Focus();
                return;
            }

            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";
            string rentalSQL = "SELECT tape_rental_cost FROM Movie WHERE movie_number = '" +
                                    txtRentalSave.Text.Trim() + "'";
            SqlCommand objRentCommand = null;
            SqlConnection objRentConn = null;
            SqlDataReader rentReader = null;

            try
            {
                using (objRentConn = new SqlConnection(connectionString))
                {
                    //Opens the connection to the database
                    objRentConn.Open();
                    //Command object created with the SQL statement
                    using (objRentCommand = new SqlCommand(rentalSQL, objRentConn))
                    {
                        //SQL executes and returns a DataReader
                        using ((rentReader = objRentCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (rentReader.Read())
                            {                                
                                rCost = rentReader["tape_rental_cost"].ToString();
                            }
                        }
                    }
                }
                if (objRentConn != null)
                {
                    objRentConn.Close();
                }
                Rental objRental = new Rental();
                objRental.MovieNumber = txtRentalSave.Text.Trim();
                objRental.MemberNumber = mNumber.ToString();
                objRental.Checkedout = rentDate.ToString();
                objRental.Returned = returnDate.ToString();
                objRental.ExpectedReturn = returnDate.ToString();
                objRental.RentalCost = rCost.ToString();

                bool status = RentalDB.AddRental(objRental);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Movie added to rental list.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Movie was not added to rental list.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtRentalSave.Clear();
        }

        private void btnMView_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";
            string viewSQL = "SELECT movie_title FROM movie INNER JOIN rental ON movie.movie_number = rental.movie_number" +
                " WHERE rental.member_number = '" + txtMemId.Text.Trim() + "'";

            SqlCommand objViewCommand = null;
            SqlConnection objRentConn = null;
            SqlDataReader viewReader = null;
            

            //Creating a generic list of string objects example
            List<string> viewList = new List<string>();

            try
            {
                using (objRentConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objRentConn.Open();
                    //Create a command object with the SQL statement
                    using (objViewCommand = new SqlCommand(viewSQL, objRentConn))
                    {
                        //Execute the SQL and return a DataReader
                        using ((viewReader = objViewCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            //Loop through the ADO reader until no more records
                            while (viewReader.Read())
                            {
                                //Accessing data by a specific database column name
                                //Use this method for accessing each peice of column data using this syntax
                                string titleList = viewReader["movie_title"].ToString();
                                //Adding the lastname string variable as an object to the generic list
                                viewList.Add(titleList);
                            }
                        }
                    }
                    //Close the connection
                    objRentConn.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Fill the combo box by binding the lst array to the datasource property
            cboViewList.DataSource = viewList;
            //Setting the combo box default selection to nothing
            cboViewList.SelectedIndex = 0;  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRentDelete.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number to delete.", "Rental Delete Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentalSave.Focus();
                return;
            }

            Rental objRental = new Rental();
            objRental.MovieNumber = txtRentDelete.Text.Trim();
            objRental.MemberNumber = mNumber.ToString();

            try
            {
                bool status = RentalDB.DeleteRental(objRental);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Movie deleted from database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Movie was not found on list to delete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtRentDelete.Clear();
        }       

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            MemClear();
        }

        private void MemClear()
        {            
            txtMFname.Clear();
            txtMLname.Clear();
            txtMAddress.Clear();
            txtMCity.Clear();
            txtMState.Clear();
            txtMZip.Clear();
            txtMPhone.Clear();
            txtMPass.Clear();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If I knew how to include trailers in the database, I would have them play here.",
                                "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtPlay.Clear();
        }

        private void txtMemId_TextChanged(object sender, EventArgs e)
        {

        }       
    }
}
