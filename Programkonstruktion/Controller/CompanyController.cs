using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data;

namespace Controller
{
    public class CompanyController
    {

        public static DataTable ReadAllEmployeesForACompany(Registered_Company rc)
        {
            return Registred_CompanyAccess.ReadAllEmployeesForACompany(rc);
        }

        public static DataTable ReadAll()
        {
            return Registred_CompanyAccess.ReadAll();
        }

        public static Registered_Company FindById(int id)

        {
            return Registred_CompanyAccess.FindById(id);
        }

        public static bool CreateRegistered_Company(Registered_Company rc)
        {
            return Registred_CompanyAccess.CreateRegistered_Company(rc);
        }

        public static bool DeleteRegistered_Company(int regComp_Id)
        {
            return Registred_CompanyAccess.DeleteRegistered_Company(regComp_Id);
        }
        public static bool Update(Registered_Company rc)
        {
            return Registred_CompanyAccess.Update(rc);
        }

    }
}




