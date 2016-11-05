using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class BranschAccess
    {


        public static IEnumerable<Bransch> ReadAll()
        {

            List<Bransch> bransches = new List<Bransch>();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return bransches;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_All_Bransch", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bransch bransch = new Bransch();
                    bransch.BranschId = reader.GetInt32(reader.GetOrdinal("Id"));
                    bransch.Name = reader["Name"].ToString();

                    bransches.Add(bransch);
                }

            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                DBUtil.CloseConnection(conn);


            }
            return bransches;

        }


        public static Bransch FindById(int branschId)

        {
            Bransch bransch = null;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return null;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Find_A_Bransch_By_BranschID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@BranschId", branschId);
                cmd.Parameters.Add(idParam);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bransch = new Bransch();
                    bransch.BranschId = reader.GetInt32(reader.GetOrdinal("BranschId"));
                    bransch.Name = reader["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DBUtil.CloseConnection(conn);
            }
            return bransch;
        }

        public static bool CreateBransch(Bransch bransch)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_New_Bransch", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BranschId", bransch.BranschId);
                cmd.Parameters.AddWithValue("@Name", bransch.Name);

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DBUtil.CloseConnection(conn);
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public static bool Delete(int id)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Delete_A_Customer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@Id", id);
                cmd.Parameters.Add(idParam);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DBUtil.CloseConnection(conn);
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public static bool UpdateBransch(Bransch bransch)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Update_A_Bransch", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@BranschId", bransch.BranschId);
                SqlParameter nameParam = new SqlParameter("@Name", bransch.Name);
                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(nameParam);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DBUtil.CloseConnection(conn);
            }
            if (result == 0)
            {
                return false;
            }
            return true;
        }
    }
}
 
