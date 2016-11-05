using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class EmployeeAccess
    {

        public static IEnumerable<Employee> ReadAll()
        {

            List<Employee> employees = new List<Employee>();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return employees;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_All_Employees", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = reader.GetInt32(reader.GetOrdinal("Id"));
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
                    employee.Id = reader.GetInt32(reader.GetOrdinal("Id"));
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

        public static bool Create(Employee emp)
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
                SqlParameter idParam = new SqlParameter("@EmpId", emp.Id);
                SqlParameter nameParam = new SqlParameter("@EmpName", emp.Name);
                SqlParameter companyParam = new SqlParameter("@CompanyId", emp.Name);
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
                SqlParameter idParam = new SqlParameter("@EmployeeId", emp.Id);
                SqlParameter nameParam = new SqlParameter("@Name", emp.Name);
                SqlParameter companyParam = new SqlParameter("@CompanyId", emp.Name);
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