﻿using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static DataTable ReadAll()
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
        public static DataTable ReadAllCustomersForEmployee(Employee emp)
        {
            return CustomerAccess.ReadAllCustomersForEmployee(emp);
        }
        public static DataTable ReadAllDeletedCustomers()
        {
            return CustomerAccess.ReadAllDeletedCustomers();
        }
    }
}
