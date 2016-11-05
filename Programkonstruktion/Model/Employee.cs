using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Customer> Customers { get; set; } 

        public Employee()
        {
            Customers = new List<Customer>();
        }

        public override string ToString()
        {
            return Id +"-"+ Name;
        }
    

    }
}