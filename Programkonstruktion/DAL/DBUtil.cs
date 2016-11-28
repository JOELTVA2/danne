using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    class DBUtil
        //nicedatabasmannen

    {
        public static SqlConnection CreateConnection()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(ConnectionString.connStringLaptop);

                myConnection.Open();
                return myConnection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

            public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;

            }


        }
    }
}
