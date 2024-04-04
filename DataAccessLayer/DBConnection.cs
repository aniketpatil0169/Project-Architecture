using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBConnection
    {
        static DBConnection _obj;

        string _connectionString = string.Empty;
        private DBConnection() 
        { 
            _connectionString = ConfigurationManager.ConnectionStrings["ASPDB"].ConnectionString;
        }

        public static DBConnection Instanve
        {
            get 
            {
                if (_obj == null) 
                {
                    _obj = new DBConnection();
                }
                return _obj;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
        public void OpenConnection()
        { 
            Connection.Open();
        }
        public void CloseConnection() 
        {
            Connection.Close();
        }
    }
}
