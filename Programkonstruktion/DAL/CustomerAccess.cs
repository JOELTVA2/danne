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
    public class CustomerAccess
    {
        public static DataTable ReadAllCustomersForEmployee(Employee emp)
        {

            DataTable customers = new DataTable();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return customers;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_Customers_With_A_Given_EmployeeID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", emp.EmployeeId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(customers);
            }
            catch (Exception e)
            {
                throw e; 

            }
            finally
            {
                DBUtil.CloseConnection(conn);


            }
            return customers;

        }

        public static DataTable ReadAll()
        {

            DataTable customers = new DataTable();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return customers;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_All_Customers", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(customers);

            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                DBUtil.CloseConnection(conn);


            }
            return customers;

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
                cmd.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = id;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    customer = new Customer();
                    customer.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                    customer.Name = reader["Name"].ToString();
                    customer.EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
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

        public static bool Create(Customer cust)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_New_Customer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cust.CustomerId;
                cmd.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = cust.Name;
                cmd.Parameters.AddWithValue("@EmpId", SqlDbType.Int).Value = cust.Employee.EmployeeId;
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
        public static bool Update(Customer cust)
        {
            int result = 0;
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return false;
            }
            try
            {
                
                SqlCommand cmd = new SqlCommand("usp_Update_A_Customer", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cust.CustomerId;
                cmd.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = cust.Name;
                cmd.Parameters.AddWithValue("@EmpId", SqlDbType.Int).Value = cust.EmployeeId;
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


