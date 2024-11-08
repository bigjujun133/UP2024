using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UP2024
{
    internal class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=ADCLG1;Initial Catalog=ROMAN;Integrated Security=True");//HOME-PC\SQLEXPRESS
        public void openconnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeconnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getconnection()
        {
            return sqlConnection;
        }
    }
}
