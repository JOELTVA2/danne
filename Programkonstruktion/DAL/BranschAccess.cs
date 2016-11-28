using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BranschAccess
    {


        public static DataTable ReadAll()
        {

            DataTable bransches = new DataTable();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return bransches;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Info_About_All_Bransches", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(bransches);

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

        public static DataTable ReadAllCompaniesForABransch(Bransch b)
        {

            DataTable bransches = new DataTable();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return bransches;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Info_About_Companies_With_A_Given_Bransch", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@BranschId", b.BranschId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.Add(idParam);
                adapter.Fill(bransches);

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

                cmd.Parameters.AddWithValue("@Bransch_Id", SqlDbType.Int).Value = bransch.BranschId;
                cmd.Parameters.AddWithValue("@Bransch_Name", SqlDbType.VarChar).Value = bransch.Name;
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
        public static bool DeleteBransch(int id)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Delete_A_Bransch", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@BranschId", id);
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
                cmd.Parameters.AddWithValue("@Bransch_Id", SqlDbType.Int).Value = bransch.BranschId;
                cmd.Parameters.AddWithValue("@Bransch_Name", SqlDbType.VarChar).Value = bransch.Name;        
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
 
