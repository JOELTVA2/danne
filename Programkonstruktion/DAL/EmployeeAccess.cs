using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class EmployeeAccess
    {

        public static DataTable ReadAll()
        {

            DataTable employees = new DataTable();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return employees;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_All_Employees", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(employees);
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



        public static Employee FindById(int id)

        {
            Employee employee = null;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return null;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Find_An_Employee_By_ID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@EmpId", id);
                cmd.Parameters.Add(idParam);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee();
                    employee.EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                    employee.Name = reader["Name"].ToString();
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
            return employee;
        }

        public static bool CreateEmployee(Employee emp)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_New_Employee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = emp.EmployeeId;
                cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = emp.Name;
                if (emp.CompanyId == 0)
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = emp.CompanyId;
                }

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
                SqlCommand cmd = new SqlCommand("usp_Delete_An_Employee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter("@EmployeeId", id);
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

        public static bool Update(Employee emp)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Update_An_Employee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = emp.EmployeeId;
                cmd.Parameters.Add("@Name", SqlDbType.Int).Value = emp.Name;
                if (emp.CompanyId == 0 || emp.CompanyId == null)
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = emp.CompanyId;
                }
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