using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DBUtil
        //nicedatabasmannen

    {
        public static SqlConnection CreateConnection()
        {
            try
            {
                SqlConnection myConnection = new SqlConnection("user id=sa;" +
                                               "password=hejhej10;server=MACK;" +
                                               "Trusted_Connection=yes;" +
                                               "database=LabSQL2;" +
                                               "connection timeout=5");

                myConnection.Open();
                return myConnection;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);

                return null;
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
                Debug.WriteLine(e.StackTrace);

            }


        }
    }
}
