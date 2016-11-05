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
    public class CustomerAccess
    {
        public static IEnumerable<Customer> ReadAllCustomersForEmployee(Employee emp)
        {

            List<Customer> customers = new List<Customer>();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return customers;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_Customers_With_A_Given_EmployeeID", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", emp.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer cust = new Customer();
                    cust.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    cust.Name = reader["Name"].ToString();

                    customers.Add(cust);
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
            return customers;

        }

        public static IEnumerable<Customer> ReadAll()
        {

            List<Customer> customers = new List<Customer>();
            SqlConnection conn = DBUtil.CreateConnection();
            if (conn == null)
            {
                return customers;
            }
            try
            {

                SqlCommand cmd = new SqlCommand("usp_Info_About_All_Customers", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer cust = new Customer();
                    cust.CustomerId = reader.GetInt32(reader.GetOrdinal("Id"));
                    cust.Name = reader["Name"].ToString();

                    customers.Add(cust);
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
                SqlParameter idParam = new SqlParameter("@Id", id);
                cmd.Parameters.Add(idParam);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    customer = new Customer();
                    customer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    customer.Name = reader["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
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
                cmd.Parameters.AddWithValue("@CustomerId", cust.Id);
                cmd.Parameters.AddWithValue("@Name", cust.Name);
                cmd.Parameters.AddWithValue("@EmployeeId", cust.Employee.Id);
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
                SqlParameter idParam = new SqlParameter("@Id", cust.Id);
                SqlParameter nameParam = new SqlParameter("@Name", cust.Name);
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


