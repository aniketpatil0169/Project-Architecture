using Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ProductDB : IProductDB
    {
        public bool CreateProduct(Product product)
        {
            bool result = false;

            //string cs = ConfigurationManager.ConnectionStrings["ASPDB"].ConnectionString;
            //SqlConnection con = new SqlConnection(cs);

            DBConnection connection = DBConnection.Instanve;

            try
            {
                SqlCommand cmd = new SqlCommand("uspCreateProduct", connection.Connection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);

                SqlParameter status = new SqlParameter()
                {
                    ParameterName = "@Status",
                    Direction = ParameterDirection.Output,
                    SqlDbType = SqlDbType.Bit
                };
                cmd.Parameters.Add(status);

                connection.OpenConnection();

                cmd.ExecuteNonQuery();

                result = (bool)status.Value;
            }
            catch (Exception ex) { }
            finally
            {
                if (connection.Connection != null)
                {
                    connection.CloseConnection();
                }
            }
            return result;
        }
    }
}
