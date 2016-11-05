using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
     public class CustomerController
    {
        public static Customer FindById(int id)
        {
            return CustomerAccess.FindById(id);     
        }
        public static IEnumerable<Customer> ReadAll()
        {
            return CustomerAccess.ReadAll();
        }
        public static bool Create(Customer cust)
        {
            return CustomerAccess.Create(cust);
        }
        public static bool Delete(int id)
        {
            return CustomerAccess.Delete(id);
        }
        public static bool Update(Customer cust)
        {
            return CustomerAccess.Update(cust);
        }
        public static IEnumerable<Customer> ReadAllCustomersForEmployee(Employee emp)
        {
            return CustomerAccess.ReadAllCustomersForEmployee(emp);
        }
    }
}
