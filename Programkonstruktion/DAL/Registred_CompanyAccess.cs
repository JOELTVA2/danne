using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Registred_CompanyAccess
    {
        public static IEnumerable<Employee> ReadAllEmployeesForACompany(Registered_Company rc)
        { 

            List<Employee> employees = new List<Employee>();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return employees;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_Company_Employees", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RegComp_Id", rc.RegComp_Id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                    emp.Name = reader["Name"].ToString();

                    employees.Add(emp);
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
            return employees;

        }

        public static IEnumerable<Registered_Company> ReadAll()
        {

            List<Registered_Company> rcs = new List<Registered_Company>();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return rcs;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_All_RegCompany", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Registered_Company rc = new Registered_Company();
                    rc.RegComp_Id = reader.GetInt32(reader.GetOrdinal("RegComp_Id"));
                    rc.Name = reader["Name"].ToString();

                    rcs.Add(rc);
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
            return rcs;

        }


        public static Customer FindById(int id)

        {
            Customer customer = null;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return null;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Find_A_Customer_By_ID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@Id", id);
                cmd.Parameters.Add(idParam);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    customer = new Customer();
                    customer.CustomerId = reader.GetInt32(reader.GetOrdinal("Id"));
                    customer.Name = reader["Name"].ToString();
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
            return customer;
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
                SqlParameter idParam = new SqlParameter("@RegComp_Id", regComp_Id);
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
                SqlParameter idParam = new SqlParameter("@RegComp_Id", rc.RegComp_Id);
                SqlParameter nameParam = new SqlParameter("@Name", rc.Name);
                SqlParameter branschParam = new SqlParameter("@BranschId", rc.BranschId);
                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(nameParam);
                cmd.Parameters.Add(branschParam);
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

