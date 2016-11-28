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
    public class Registred_CompanyAccess
    {
        public static DataTable ReadAllEmployeesForACompany(Registered_Company rc)
        {

            DataTable rcs = new DataTable();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return rcs;
            }

            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_Company_Employees", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", rc.RegComp_Id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(rcs);

            }

            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                DBUtil.CloseConnection(conn);


            }
            return rcs;

        }

        public static DataTable ReadAll()
        {

            DataTable rcs = new DataTable();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return rcs;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_All_RegCompanies", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(rcs);


            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                DBUtil.CloseConnection(conn);


            }
            return rcs;
        }

        public static Registered_Company FindById(int id)

        {
            Registered_Company rc = null;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return null;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Find_A_RegComp_By_ID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@RegComp_Id", id);
                cmd.Parameters.Add(idParam);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    rc = new Registered_Company();
                    rc.RegComp_Id = reader.GetInt32(reader.GetOrdinal("RegComp_Id"));
                    rc.Name = reader["Name"].ToString();
                    rc.BranschId = Int32.Parse(reader["BranschId"].ToString());
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
            return rc;
        }

        public static bool CreateRegistered_Company(Registered_Company rc)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_New_RegCompany", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegComp_Id", rc.RegComp_Id);
                cmd.Parameters.AddWithValue("@Name", rc.Name);
                cmd.Parameters.AddWithValue("@BranschId", rc.BranschId);
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

        public static bool DeleteRegistered_Company(int regComp_Id)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Delete_A_RegCompany", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@RegCom_Id", regComp_Id);
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
        public static bool Update(Registered_Company rc)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Update_A_RegisteredCompany", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@RegComp_Id", SqlDbType.Int).Value = rc.RegComp_Id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = rc.Name;
                cmd.Parameters.Add("@BranschId", SqlDbType.Int).Value = rc.BranschId;
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

