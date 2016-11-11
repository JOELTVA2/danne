using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class EmployeeController
    {
        public static Employee FindById(int id)
        {
            return EmployeeAccess.FindById(id);
        }
        public static DataTable ReadAll()
        {
            return EmployeeAccess.ReadAll();
        }
        public static bool Create(Employee emp)
        {
            return EmployeeAccess.CreateEmployee(emp);
        }
        public static bool Delete(int id)
        {
            return EmployeeAccess.Delete(id);
        }
        public static bool Update(Employee emp)
        {
            return EmployeeAccess.Update(emp);
        }
    }
}
