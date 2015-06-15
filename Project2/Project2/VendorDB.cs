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
    public static class VendorDB
    {
        public static List<Vendor> GetVendor()
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            List<Vendor> vendorList = new List<Vendor>();

            string vendorSQL = "SELECT vendor_id, vendor_name, vendor_phone FROM Vendor";

            SqlCommand objVCommand = null;
            SqlConnection objVConn = null;
            SqlDataReader vendReader = null;

            try
            {
                using (objVConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objVConn.Open();
                    //Command object created with the SQL statement
                    using (objVCommand = new SqlCommand(vendorSQL, objVConn))
                    {
                        //Execute the SQL and return a DataReader
                        using ((vendReader = objVCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (vendReader.Read())
                            {
                                Vendor objVendor = new Vendor();
                                objVendor.VendorId = vendReader["vendor_id"].ToString();
                                objVendor.VendorName = vendReader["vendor_name"].ToString();
                                objVendor.VendorPhone = vendReader["vendor_phone"].ToString();

                                //Add Vendor to collection
                                vendorList.Add(objVendor);
                            }
                        }
                    }
                    return vendorList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {                
                if (objVConn != null)
                {
                    objVConn.Close();
                }
            }
        }

        public static Vendor GetVendor(int vendorNumber)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            string vendorSQL = "SELECT vendor_id, vendor_name, vendor_phone FROM Vendor" +
                               " WHERE vendor_id = @vendor_id"; ;

            SqlCommand objVendCommand = null;
            SqlConnection objVendConn = null;
            SqlDataReader vendReader = null;
            Vendor objVendor = null;
            try
            {
                using (objVendConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objVendConn.Open();
                    //Create a command object with the SQL statement
                    using (objVendCommand = new SqlCommand(vendorSQL, objVendConn))
                    {
                        //Set command parameter
                        objVendCommand.Parameters.AddWithValue("@vendor_id", vendorNumber);
                        //Execute the SQL and return a DataReader
                        using ((vendReader = objVendCommand.ExecuteReader(CommandBehavior.CloseConnection)))
                        {
                            while (vendReader.Read())
                            {
                                objVendor = new Vendor();
                                //Fill the customer object if found
                                objVendor.VendorId = vendReader["vendor_id"].ToString();
                                objVendor.VendorName = vendReader["vendor_name"].ToString();
                                objVendor.VendorPhone = vendReader["vendor_phone"].ToString();
                            }
                        }
                    }
                    return objVendor;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (objVendConn != null)
                {
                    objVendConn.Close();
                }
            }
        }

        public static bool AddVendor(Vendor objVendor)
        {
            //string dateReturned = "";
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;

            SqlCommand objVendCommand = null;
            SqlConnection objVendConn = null;

            string vendorSQL;
            try
            {
                using (objVendConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objVendConn.Open();
                    vendorSQL = "INSERT into Vendor VALUES (@vendor_id, @vendor_name, @vendor_phone)";

                    //Create a command object with the SQL statement
                    using (objVendCommand = new SqlCommand(vendorSQL, objVendConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objVendCommand.Parameters.AddWithValue("@vendor_id", Convert.ToInt16(objVendor.VendorId));
                        objVendCommand.Parameters.AddWithValue("@vendor_name", objVendor.VendorName);
                        objVendCommand.Parameters.AddWithValue("@vendor_phone", objVendor.VendorPhone);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objVendCommand.ExecuteNonQuery();
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
                if (objVendConn != null)
                {
                    objVendConn.Close();
                }
            }
        }

        public static bool UpdateVendor(Vendor objVendor)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;
            string vendorSQL;

            SqlCommand objVendCommand = null;
            SqlConnection objVendConn = null;

            try
            {
                using (objVendConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objVendConn.Open();
                    vendorSQL = "UPDATE Vendor " + Environment.NewLine +
                                " SET vendor_id = @vendor_id, " + Environment.NewLine +
                                "     vendor_name = @vendor_name, " + Environment.NewLine +
                                "     vendor_phone = @vendor_phone " + Environment.NewLine +
                                " WHERE vendor_id = @vendor_id ";

                    //Create a command object with the SQL statement
                    using (objVendCommand = new SqlCommand(vendorSQL, objVendConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objVendCommand.Parameters.AddWithValue("@vendor_id", Convert.ToInt16(objVendor.VendorId));
                        objVendCommand.Parameters.AddWithValue("@vendor_name", objVendor.VendorName);
                        objVendCommand.Parameters.AddWithValue("@vendor_phone", objVendor.VendorPhone);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objVendCommand.ExecuteNonQuery();
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
                if (objVendConn != null)
                {
                    objVendConn.Close();
                }
            }
        }

        public static bool DeleteVendor(Vendor objVendor)
        {
            string connectionString = "Server=198.209.220.125;Database=cram;User Id=louis;Password=lou15;";

            int rowsAffected = 0;

            SqlConnection objVendConn = null;
            SqlCommand objVendCommand = null;

            string VendorSQL;
            try
            {
                using (objVendConn = new SqlConnection(connectionString))
                {
                    //Open the connection to the datbase
                    objVendConn.Open();
                    VendorSQL = "DELETE Vendor WHERE vendor_id = @vendor_id";

                    //Create a command object with the SQL statement
                    using (objVendCommand = new SqlCommand(VendorSQL, objVendConn))
                    {
                        //Use the command parameters method to set the paramater values of the SQL Insert statement
                        objVendCommand.Parameters.AddWithValue("@vendor_id", objVendor.VendorId);
                        //Execute the SQL and return the number of rows affected
                        rowsAffected = objVendCommand.ExecuteNonQuery();
                        //Close the database connection
                        objVendConn.Close();

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
                if (objVendConn != null)
                {
                    objVendConn.Close();
                }
            }
        }
    }
}
