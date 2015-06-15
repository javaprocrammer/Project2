using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class AdminScreen : Form
    {
        public AdminScreen()
        {
            InitializeComponent();
        }

        private void AdminScreen_Load(object sender, EventArgs e)
        {

           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MovieListLoad()
        {
            try
            {
                List<Movie> movieList = new List<Movie>();
                movieList = MovieDB.GetMovie();               
                gridViewAdminMovie.DataSource = movieList;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearMovieFields()
        {
            txtMovNum.Clear();
            txtMovTitle.Clear();
            txtMovDesc.Clear();
            txtMovReleased.Clear();
            txtMovGenre.Clear();
            txtMovRating.Clear();
            txtMovFormat.Clear();
            txtMovRetail.Clear();
            txtMovRental.Clear();
            txtMovCopies.Clear();
            txtMovImage.Clear();
            txtMovTrailer.Clear();
            txtMovVendor.Clear();
            gridViewAdminMovie.DataSource = null;
        }                        

        private void btnMovShow_Click(object sender, EventArgs e)
        {
            MovieListLoad();
        }

        private void btnMovClear_Click(object sender, EventArgs e)
        {
            ClearMovieFields();
        }

        private void btnMovAdd_Click(object sender, EventArgs e)
        {
            if (txtMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovNum.Focus();
                return;
            }
            else
            {
                Movie objMovieNum = MovieDB.GetMovie(Convert.ToInt16(txtMovNum.Text.Trim()));
                if (objMovieNum != null)
                {
                    MessageBox.Show("Movie Number " + txtMovNum.Text.Trim() + " already exists in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMovNum.Clear();
                    txtMovNum.Focus();
                    return;
                }
            }
            if (txtMovTitle.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Title.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovTitle.Focus();
                return;
            }
            if (txtMovDesc.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Description.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovDesc.Focus();
                return;
            }
            if (txtMovReleased.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter Year Released.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovReleased.Focus();
                return;
            }
            if (txtMovGenre.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovGenre.Focus();
                return;
            }
            else
            {
                Genre objGenre = GenreDB.GetGenre(Convert.ToInt16(txtMovGenre.Text.Trim()));
                if (objGenre == null)
                {
                    MessageBox.Show("Genre ID # " + txtMovGenre.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMovGenre.Clear();
                    txtMovGenre.Focus();
                    return;
                }
            }
            if (txtMovRating.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Rating.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovRating.Focus();
                return;
            }
            if (txtMovFormat.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Format.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovFormat.Focus();
                return;
            }
            if (txtMovRetail.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Retail Cost.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovRetail.Focus();
                return;
            }
            if (txtMovRental.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Rental Cost.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovRental.Focus();
                return;
            }
            if (txtMovCopies.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter the # Copies On_Hand.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovCopies.Focus();
                return;
            }
            if (txtMovImage.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter an Image.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovImage.Focus();
                return;
            }
            if (txtMovTrailer.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Trailer.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovTrailer.Focus();
                return;
            }
            if (txtMovVendor.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor ID.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovVendor.Focus();
                return;
            }
            else
            {
                Vendor objVendor = VendorDB.GetVendor(Convert.ToInt16(txtMovVendor.Text.Trim()));
                if (objVendor == null)
                {
                    MessageBox.Show("Vendor ID # " + txtMovVendor.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMovVendor.Clear();
                    txtMovVendor.Focus();
                    return;
                }
            }

            Movie objMovie = new Movie();
            objMovie.MovieNumber = txtMovNum.Text.Trim();
            objMovie.MovieTitle = txtMovTitle.Text.Trim();
            objMovie.Description = txtMovDesc.Text.Trim();
            objMovie.YearReleased = txtMovReleased.Text.Trim();
            objMovie.GenreId = txtMovGenre.Text.Trim();
            objMovie.Rating = txtMovRating.Text.Trim();
            objMovie.Format = txtMovFormat.Text.Trim();
            objMovie.RetailCost = txtMovRetail.Text.Trim();
            objMovie.RentalCost = txtMovRental.Text.Trim();
            objMovie.OnHand = txtMovCopies.Text.Trim();
            objMovie.Image = txtMovImage.Text.Trim();
            objMovie.Trailer = txtMovTrailer.Text.Trim();
            objMovie.VendorId = txtMovVendor.Text.Trim();
            try
            {
                bool status = MovieDB.AddMovie(objMovie);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Movie added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearMovieFields();
                    MovieListLoad();
                }
                else
                {
                    MessageBox.Show("Movie was not added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void btnMovFind_Click(object sender, EventArgs e)
        {
            if (txtMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovNum.Focus();
                return;
            }

            try
            {
                Movie objMovie = MovieDB.GetMovie(Convert.ToInt16(txtMovNum.Text.Trim()));
                if (objMovie != null)
                {
                    txtMovTitle.Text = objMovie.MovieTitle;
                    txtMovDesc.Text = objMovie.Description;
                    txtMovReleased.Text = objMovie.YearReleased;
                    txtMovGenre.Text = objMovie.GenreId;
                    txtMovRating.Text = objMovie.Rating;
                    txtMovFormat.Text = objMovie.Format;
                    txtMovRetail.Text = objMovie.RetailCost;
                    txtMovRental.Text = objMovie.RentalCost;
                    txtMovCopies.Text = objMovie.OnHand;
                    txtMovImage.Text = objMovie.Image;
                    txtMovTrailer.Text = objMovie.Trailer;
                    txtMovVendor.Text = objMovie.VendorId;
                }
                else
                {
                    MessageBox.Show("Movie Number " + txtMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMovUpdate_Click(object sender, EventArgs e)
        {
            if (txtMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovNum.Focus();
                return;
            }
            else
            {
                Movie objMovieNum = MovieDB.GetMovie(Convert.ToInt16(txtMovNum.Text.Trim()));
                if (objMovieNum == null)
                {
                    MessageBox.Show("Movie Number " + txtMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMovNum.Clear();
                    txtMovNum.Focus();
                    return;
                }
            }
            if (txtMovTitle.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Title.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovTitle.Focus();
                return;
            }
            if (txtMovDesc.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Description.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovDesc.Focus();
                return;
            }
            if (txtMovReleased.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter Year Released.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovReleased.Focus();
                return;
            }
            if (txtMovGenre.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovGenre.Focus();
                return;
            }
            else
            {
                Genre objGenre = GenreDB.GetGenre(Convert.ToInt16(txtMovGenre.Text.Trim()));
                if (objGenre == null)
                {
                    MessageBox.Show("Genre ID # " + txtMovGenre.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMovGenre.Clear();
                    txtMovGenre.Focus();
                    return;
                }
            }
            if (txtMovRating.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Rating.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovRating.Focus();
                return;
            }
            if (txtMovFormat.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Format.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovFormat.Focus();
                return;
            }
            if (txtMovRetail.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Retail Cost.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovRetail.Focus();
                return;
            }
            if (txtMovRental.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Rental Cost.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovRental.Focus();
                return;
            }
            if (txtMovCopies.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter the # Copies On_Hand.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovCopies.Focus();
                return;
            }
            if (txtMovImage.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter an Image.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovImage.Focus();
                return;
            }
            if (txtMovTrailer.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Trailer.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovTrailer.Focus();
                return;
            }
            if (txtMovVendor.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor ID.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovVendor.Focus();
                return;
            }
            else
            {
                Vendor objVendor = VendorDB.GetVendor(Convert.ToInt16(txtMovVendor.Text.Trim()));
                if (objVendor == null)
                {
                    MessageBox.Show("Vendor ID # " + txtMovVendor.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMovVendor.Clear();
                    txtMovVendor.Focus();
                    return;
                }
            }

            Movie objMovie = new Movie();
            objMovie.MovieNumber = txtMovNum.Text.Trim();
            objMovie.MovieTitle = txtMovTitle.Text.Trim();
            objMovie.Description = txtMovDesc.Text.Trim();
            objMovie.YearReleased = txtMovReleased.Text.Trim();
            objMovie.GenreId = txtMovGenre.Text.Trim();
            objMovie.Rating = txtMovRating.Text.Trim();
            objMovie.Format = txtMovFormat.Text.Trim();
            objMovie.RetailCost = txtMovRetail.Text.Trim();
            objMovie.RentalCost = txtMovRental.Text.Trim();
            objMovie.OnHand = txtMovCopies.Text.Trim();
            objMovie.Image = txtMovImage.Text.Trim();
            objMovie.Trailer = txtMovTrailer.Text.Trim();
            objMovie.VendorId = txtMovVendor.Text.Trim();
            try
            {
                bool status = MovieDB.UpdateMovie(objMovie);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Movie updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearMovieFields();
                    MovieListLoad();
                }
                else
                {
                    MessageBox.Show("Movie was not updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMovDelete_Click(object sender, EventArgs e)
        {
            if (txtMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMovNum.Focus();
                return;
            }
            else
            {
                Movie objMovieNum = MovieDB.GetMovie(Convert.ToInt16(txtMovNum.Text.Trim()));
                if (objMovieNum == null)
                {
                    MessageBox.Show("Movie Number " + txtMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMovNum.Clear();
                    txtMovNum.Focus();
                    return;
                }
            }

            Movie objMovie = new Movie();
            objMovie.MovieNumber = txtMovNum.Text.Trim();
            try
            {
                bool status = MovieDB.DeleteMovie(objMovie);
                if (status) 
                {
                    MessageBox.Show("Movie deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearMovieFields();
                    MovieListLoad();
                }
                else
                {
                    MessageBox.Show("Movie was not deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MemberListLoad()
        {
            try
            {
                List<Member> memberList = new List<Member>();
                memberList = MemberDB.GetMember();

                gridViewMembers.DataSource = memberList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearMemberFields()
        {
            gridViewMembers.DataSource = null;
            txtMemNum.Clear();
            txtMemJoin.Clear();
            txtMemFName.Clear();
            txtMemLName.Clear();
            txtMemAddress.Clear();
            txtMemCity.Clear();
            txtMemState.Clear();
            txtMemZip.Clear();
            txtMemPhone.Clear();
            txtMemStatus.Clear();
            txtMemPassword.Clear();
            txtMemEmploy.Clear();
        }
                
        private void btnMemShow_Click(object sender, EventArgs e)
        {
            MemberListLoad();
        }

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            ClearMemberFields();
        }
        
        private void btnMemAdd_Click(object sender, EventArgs e)
        {
            if (txtMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemNum.Focus();
                return;
            }
            else
            {
                Member objMemberNum = MemberDB.GetMember(Convert.ToInt16(txtMemNum.Text.Trim()));
                if (objMemberNum != null)
                {
                    MessageBox.Show("Member Number " + txtMemNum.Text.Trim() + " already exists in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMemNum.Clear();
                    txtMemNum.Focus();
                    return;
                }
            }
            if (txtMemJoin.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Join Date.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemJoin.Focus();
                return;
            }
            if (txtMemFName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a First Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemFName.Focus();
                return;
            }
            if (txtMemLName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Last Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemLName.Focus();
                return;
            }
            if (txtMemAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter an Address.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemAddress.Focus();
                return;
            }
            if (txtMemCity.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a City.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemCity.Focus();
                return;
            }
            if (txtMemState.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a State.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemState.Focus();
                return;
            }
            if (txtMemZip.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Zipcode.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemZip.Focus();
                return;
            }
            if (txtMemPhone.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Phone Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemPhone.Focus();
                return;
            }
            if (txtMemStatus.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter Member's Status.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemStatus.Focus();
                return;
            }
            if (txtMemPassword.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Password.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemPassword.Focus();
                return;
            }
            if (txtMemEmploy.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please indicate if an Employee(1) or a Member(0).", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemEmploy.Focus();
                return;
            }

            Member objMember = new Member();
            objMember.MemberNumber = txtMemNum.Text.Trim();
            objMember.JoinDate = txtMemJoin.Text.Trim();
            objMember.FirstName = txtMemFName.Text.Trim();
            objMember.LastName = txtMemLName.Text.Trim();
            objMember.Address = txtMemAddress.Text.Trim();
            objMember.City = txtMemCity.Text.Trim();
            objMember.State = txtMemState.Text.Trim();
            objMember.Zipcode = txtMemZip.Text.Trim();
            objMember.Phone = txtMemPhone.Text.Trim();
            objMember.Status = txtMemStatus.Text.Trim();
            objMember.Password = txtMemPassword.Text.Trim();
            objMember.Employee = txtMemEmploy.Text.Trim();
            try
            {
                bool status = MemberDB.AddMember(objMember);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Member added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearMemberFields();
                    MemberListLoad();
                }
                else
                {
                    MessageBox.Show("Member was not added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMemUpdate_Click(object sender, EventArgs e)
        {
            if (txtMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemNum.Focus();
                return;
            }
            else
            {
                Member objMemberNum = MemberDB.GetMember(Convert.ToInt16(txtMemNum.Text.Trim()));
                if (objMemberNum == null)
                {
                    MessageBox.Show("Member Number " + txtMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMemNum.Clear();
                    txtMemNum.Focus();
                    return;
                }
            }
            if (txtMemJoin.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Join Date.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemJoin.Focus();
                return;
            }
            if (txtMemFName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a First Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemFName.Focus();
                return;
            }
            if (txtMemLName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Last Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemLName.Focus();
                return;
            }
            if (txtMemAddress.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter an Address.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemAddress.Focus();
                return;
            }
            if (txtMemCity.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a City.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemCity.Focus();
                return;
            }
            if (txtMemState.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a State.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemState.Focus();
                return;
            }
            if (txtMemZip.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Zipcode.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemZip.Focus();
                return;
            }
            if (txtMemPhone.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Phone Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemPhone.Focus();
                return;
            }
            if (txtMemStatus.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter Member's Status.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemStatus.Focus();
                return;
            }
            if (txtMemPassword.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Password.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemPassword.Focus();
                return;
            }
            if (txtMemEmploy.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please indicate if an Employee(1) or a Member(0).", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemEmploy.Focus();
                return;
            }

            Member objMember = new Member();
            objMember.MemberNumber = txtMemNum.Text.Trim();
            objMember.JoinDate = txtMemJoin.Text.Trim();
            objMember.FirstName = txtMemFName.Text.Trim();
            objMember.LastName = txtMemLName.Text.Trim();
            objMember.Address = txtMemAddress.Text.Trim();
            objMember.City = txtMemCity.Text.Trim();
            objMember.State = txtMemState.Text.Trim();
            objMember.Zipcode = txtMemZip.Text.Trim();
            objMember.Phone = txtMemPhone.Text.Trim();
            objMember.Status = txtMemStatus.Text.Trim();
            objMember.Password = txtMemPassword.Text.Trim();
            objMember.Employee = txtMemEmploy.Text.Trim();
            try
            {
                bool status = MemberDB.UpdateAdminMember(objMember);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Member updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearMemberFields();
                    MemberListLoad();
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

        private void btnMemDelete_Click(object sender, EventArgs e)
        {
            if (txtMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemNum.Focus();
                return;
            }
            else
            {
                Member objMemberNum = MemberDB.GetMember(Convert.ToInt16(txtMemNum.Text.Trim()));
                if (objMemberNum == null)
                {
                    MessageBox.Show("Member Number " + txtMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMemNum.Clear();
                    txtMemNum.Focus();
                    return;
                }
            }

            Member objMember = new Member();
            objMember.MemberNumber = txtMemNum.Text.Trim();
            try
            {
                bool status = MemberDB.DeleteMember(objMember);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Member deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearMemberFields();
                    MemberListLoad();
                }
                else
                {
                    MessageBox.Show("Member was not deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMemFind_Click(object sender, EventArgs e)
        {
            if (txtMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMemNum.Focus();
                return;
            }

            try
            {
                Member objMember = MemberDB.GetMember(Convert.ToInt16(txtMemNum.Text.Trim()));
                if (objMember != null)
                {
                    txtMemJoin.Text = objMember.JoinDate;
                    txtMemFName.Text = objMember.FirstName;
                    txtMemLName.Text = objMember.LastName;
                    txtMemAddress.Text = objMember.Address;
                    txtMemCity.Text = objMember.City;
                    txtMemState.Text = objMember.State;
                    txtMemZip.Text = objMember.Zipcode;
                    txtMemPhone.Text = objMember.Phone;
                    txtMemStatus.Text = objMember.Status;
                    txtMemPassword.Text = objMember.Password;
                    txtMemEmploy.Text = objMember.Employee;
                }
                else
                {
                    MessageBox.Show("Member Number " + txtMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void RentalListLoad()
        {
            try
            {
                List<Rental> rentalList = new List<Rental>();
                rentalList = RentalDB.GetRental();

                gridViewRentals.DataSource = rentalList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearRentalFields()
        {
            gridViewRentals.DataSource = null;
            txtRentMovNum.Clear();
            txtRentMemNum.Clear();
            txtCheckout.Clear();
            txtReturn.Clear();
            txtExpReturn.Clear();
            txtRentCost.Clear();
        }

        private void btnRentShow_Click(object sender, EventArgs e)
        {
            RentalListLoad();
        }

        private void btnRentClear_Click(object sender, EventArgs e)
        {
            ClearRentalFields();
        }

        private void btnRentAdd_Click(object sender, EventArgs e)
        {
            if (txtRentMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMovNum.Focus();
                return;
            }
            else
            {
                Movie objMovie = MovieDB.GetMovie(Convert.ToInt16(txtRentMovNum.Text.Trim()));
                if (objMovie != null)
                {
                    txtRentCost.Text = objMovie.RentalCost;
                }
                else
                {
                    MessageBox.Show("Movie Number " + txtRentMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMovNum.Clear();
                    txtRentMovNum.Focus();
                    return;
                }
            }
            if (txtRentMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMemNum.Focus();
                return;
            }
            else
            {
                Member objMember = MemberDB.GetMember(Convert.ToInt16(txtRentMemNum.Text.Trim()));
                if (objMember == null)
                {
                    MessageBox.Show("Member Number " + txtRentMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMemNum.Clear();
                    txtRentMemNum.Focus();
                    return;
                }
            }
            if (txtCheckout.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Date Checked Out.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCheckout.Focus();
                return;
            }
            if (txtExpReturn.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter an Exp. Return Date.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpReturn.Focus();
                return;
            }
            if (txtReturn.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Date Returned.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReturn.Focus();
                return;
            }

            Rental objRental = new Rental();
            objRental.MovieNumber = txtRentMovNum.Text.Trim();
            objRental.MemberNumber = txtRentMemNum.Text.Trim();
            objRental.Checkedout = txtCheckout.Text.Trim();
            objRental.Returned = txtReturn.Text.Trim();
            objRental.ExpectedReturn = txtExpReturn.Text.Trim();
            objRental.RentalCost = txtRentCost.Text.Trim();
            try
            {
                bool status = RentalDB.AddRental(objRental);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Rental added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearRentalFields();
                    RentalListLoad();
                }
                else
                {
                    MessageBox.Show("Rental was not added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRentUp_Click(object sender, EventArgs e)
        {
            if (txtRentMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMovNum.Focus();
                return;
            }
            else
            {
                Movie objMovie = MovieDB.GetMovie(Convert.ToInt16(txtRentMovNum.Text.Trim()));
                if (objMovie != null)
                {
                    txtRentCost.Text = objMovie.RentalCost;
                }
                else
                {
                    MessageBox.Show("Movie Number " + txtRentMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMovNum.Clear();
                    txtRentMovNum.Focus();
                    return;
                }
            }
            if (txtRentMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMemNum.Focus();
                return;
            }
            else
            {
                Member objMember = MemberDB.GetMember(Convert.ToInt16(txtRentMemNum.Text.Trim()));
                if (objMember == null)
                {
                    MessageBox.Show("Member Number " + txtRentMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMemNum.Clear();
                    txtRentMemNum.Focus();
                    return;
                }
            }
            if (txtCheckout.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Date Checked Out.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCheckout.Focus();
                return;
            }
            if (txtExpReturn.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter an Exp. Return Date.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpReturn.Focus();
                return;
            }
            if (txtReturn.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Date Returned.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReturn.Focus();
                return;
            }

            Rental objRental = new Rental();
            objRental.MovieNumber = txtRentMovNum.Text.Trim();
            objRental.MemberNumber = txtRentMemNum.Text.Trim();
            objRental.Checkedout = txtCheckout.Text.Trim();
            objRental.Returned = txtReturn.Text.Trim();
            objRental.ExpectedReturn = txtExpReturn.Text.Trim();
            objRental.RentalCost = txtRentCost.Text.Trim();
            try
            {
                bool status = RentalDB.UpdateRental(objRental);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Rental updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearRentalFields();
                    RentalListLoad();
                }
                else
                {
                    MessageBox.Show("Rental was not updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRentDelete_Click(object sender, EventArgs e)
        {
            if (txtRentMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMovNum.Focus();
                return;
            }
            else
            {
                Movie objMovie = MovieDB.GetMovie(Convert.ToInt16(txtRentMovNum.Text.Trim()));
                if (objMovie == null)
                {                  
                    MessageBox.Show("Movie Number " + txtRentMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMovNum.Clear();
                    txtRentMovNum.Focus();
                    return;
                }
            }
            if (txtRentMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMemNum.Focus();
                return;
            }
            else
            {
                Member objMember = MemberDB.GetMember(Convert.ToInt16(txtRentMemNum.Text.Trim()));
                if (objMember == null)
                {
                    MessageBox.Show("Member Number " + txtRentMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMemNum.Clear();
                    txtRentMemNum.Focus();
                    return;
                }
            }

            Rental objRental = new Rental();
            objRental.MovieNumber = txtRentMovNum.Text.Trim();
            objRental.MemberNumber = txtRentMemNum.Text.Trim();
            try
            {
                bool status = RentalDB.DeleteRental(objRental);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Rental deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearRentalFields();
                    RentalListLoad();
                }
                else
                {
                    MessageBox.Show("Rental was not deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRentFind_Click(object sender, EventArgs e)
        {
            if (txtRentMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMovNum.Focus();
                return;
            }
            else
            {
                Movie objMovie = MovieDB.GetMovie(Convert.ToInt16(txtRentMovNum.Text.Trim()));
                if (objMovie == null)
                {
                    MessageBox.Show("Movie Number " + txtRentMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMovNum.Clear();
                    txtRentMovNum.Focus();
                    return;
                }
            }
            if (txtRentMemNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Member Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMemNum.Focus();
                return;
            }
            else
            {
                Member objMember = MemberDB.GetMember(Convert.ToInt16(txtRentMemNum.Text.Trim()));
                if (objMember == null)
                {
                    MessageBox.Show("Member Number " + txtRentMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRentMemNum.Clear();
                    txtRentMemNum.Focus();
                    return;
                }
            }

            try
            {
                Rental objRental = RentalDB.GetRental(Convert.ToInt16(txtRentMemNum.Text.Trim()), Convert.ToInt16(txtRentMovNum.Text.Trim()));
                if (objRental != null)
                {
                    txtCheckout.Text = objRental.Checkedout;
                    txtReturn.Text = objRental.Returned;
                    txtExpReturn.Text = objRental.ExpectedReturn;
                    txtRentCost.Text = objRental.RentalCost;
                }
                else
                {
                    MessageBox.Show("Rental of movie number " + txtRentMovNum.Text.Trim() +
                        " to member number " + txtRentMemNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnRentCost_Click(object sender, EventArgs e)
        {
            if (txtRentMovNum.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Movie Number.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRentMovNum.Focus();
                return;
            }

            Movie objMovie = MovieDB.GetMovie(Convert.ToInt16(txtRentMovNum.Text.Trim()));
            if (objMovie != null)
            {
                txtRentCost.Text = objMovie.RentalCost;
            }
            else
            {
                MessageBox.Show("Movie Number " + txtMovNum.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }        

        private void GenreListLoad()
        {
            try
            {
                List<Genre> genreList = new List<Genre>();
                genreList = GenreDB.GetGenre();

                gridViewGenre.DataSource = genreList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearGenreFields()
        {
            gridViewGenre.DataSource = null;
            txtGenreID.Clear();
            txtGenreName.Clear();
        }

        private void btnGenreShow_Click(object sender, EventArgs e)
        {
            GenreListLoad();
        }

        private void btnGenreClear_Click(object sender, EventArgs e)
        {
            ClearGenreFields();
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            if (txtGenreID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenreID.Focus();
                return;
            }            
            if (txtGenreName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenreName.Focus();
                return;
            }

            Genre objGenre = new Genre();
            objGenre.GenreId = txtGenreID.Text.Trim();
            objGenre.GenreName = txtGenreName.Text.Trim();
            try
            {
                bool status = GenreDB.AddGenre(objGenre);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Genre added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearGenreFields();
                    GenreListLoad();
                }
                else
                {
                    MessageBox.Show("Genre was not added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpGenre_Click(object sender, EventArgs e)
        {
            if (txtGenreID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenreID.Focus();
                return;
            }
            if (txtGenreName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenreName.Focus();
                return;
            }

            Genre objGenre = new Genre();
            objGenre.GenreId = txtGenreID.Text.Trim();
            objGenre.GenreName = txtGenreName.Text.Trim();
            try
            {
                bool status = GenreDB.UpdateGenre(objGenre);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Genre updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearGenreFields();
                    GenreListLoad();
                }
                else
                {
                    MessageBox.Show("Genre was not updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelGenre_Click(object sender, EventArgs e)
        {
            if (txtGenreID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenreID.Focus();
                return;
            }
            
            Genre objGenre = new Genre();
            objGenre.GenreId = txtGenreID.Text.Trim();
            try
            {
                bool status = GenreDB.DeleteGenre(objGenre);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Genre deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearGenreFields();
                    GenreListLoad();
                }
                else
                {
                    MessageBox.Show("Genre was not deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindGenre_Click(object sender, EventArgs e)
        {
            if (txtGenreID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Genre ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenreID.Focus();
                return;
            }

            try
            {
                Genre objGenre = GenreDB.GetGenre(Convert.ToInt16(txtGenreID.Text.Trim()));
                if (objGenre != null)
                {
                    txtGenreName.Text = objGenre.GenreName;
                }
                else
                {
                    MessageBox.Show("Genre ID # " + txtGenreID.Text.Trim() +
                        " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void VendorListLoad()
        {
            try
            {
                List<Vendor> vendorList = new List<Vendor>();
                vendorList = VendorDB.GetVendor();

                gridViewVendor.DataSource = vendorList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearVendorFields()
        {
            gridViewVendor.DataSource = null;
            txtVendorID.Clear();
            txtVendName.Clear();
            txtVendPhone.Clear();
        }

        private void btnVendorShow_Click(object sender, EventArgs e)
        {
            VendorListLoad();
        }

        private void btnClearVendor_Click(object sender, EventArgs e)
        {
            ClearVendorFields();
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            if (txtVendorID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendorID.Focus();
                return;
            }
            if (txtVendName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendName.Focus();
                return;
            }
            if (txtVendPhone.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor Phone #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendPhone.Focus();
                return;
            }

            Vendor objVendor = new Vendor();
            objVendor.VendorId = txtVendorID.Text.Trim();
            objVendor.VendorName = txtVendName.Text.Trim();
            objVendor.VendorPhone = txtVendPhone.Text.Trim();
            try
            {
                bool status = VendorDB.AddVendor(objVendor);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Vendor added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearVendorFields();
                    VendorListLoad();
                }
                else
                {
                    MessageBox.Show("Vendor was not added to the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpVendor_Click(object sender, EventArgs e)
        {
            if (txtVendorID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendorID.Focus();
                return;
            }
            if (txtVendName.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor Name.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendName.Focus();
                return;
            }
            if (txtVendPhone.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor Phone #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendPhone.Focus();
                return;
            }

            Vendor objVendor = new Vendor();
            objVendor.VendorId = txtVendorID.Text.Trim();
            objVendor.VendorName = txtVendName.Text.Trim();
            objVendor.VendorPhone = txtVendPhone.Text.Trim();
            try
            {
                bool status = VendorDB.UpdateVendor(objVendor);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Vendor updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearVendorFields();
                    VendorListLoad();
                }
                else
                {
                    MessageBox.Show("Vendor was not updated in the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelVendor_Click(object sender, EventArgs e)
        {
            if (txtVendorID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendorID.Focus();
                return;
            }
            
            Vendor objVendor = new Vendor();
            objVendor.VendorId = txtVendorID.Text.Trim();;
            try
            {
                bool status = VendorDB.DeleteVendor(objVendor);
                if (status) //You can use this syntax as well..if (status ==true)
                {
                    MessageBox.Show("Vendor deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearVendorFields();
                    VendorListLoad();
                }
                else
                {
                    MessageBox.Show("Vendor was not deleted from the database.", "",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFindVendor_Click(object sender, EventArgs e)
        {
            if (txtVendorID.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please enter a Vendor ID #.", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendorID.Focus();
                return;
            }
            
            try
            {
                Vendor objVendor = VendorDB.GetVendor(Convert.ToInt16(txtVendorID.Text.Trim()));
                if (objVendor != null)
                {
                    txtVendName.Text = objVendor.VendorName;
                    txtVendPhone.Text = objVendor.VendorPhone;
                }
                else
                {
                    MessageBox.Show("Vendor ID # " + txtVendorID.Text.Trim() +
                        " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("As of right now I got no idea how to put images into the database, " +
                                "but this would be a good way to show them.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabelTrailer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("As of right now I got no idea to how put trailers into the database, " +
                                "but this would be a good way to show them.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsScreen objReportForm = new ReportsScreen();
            objReportForm.ShowDialog();
            objReportForm = null;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void voidMethod()
        {

        }

        private void voidMethod2()
        {

        }
    }
}
