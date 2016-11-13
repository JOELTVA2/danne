using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Gui : Form
    {
        private Employee currentEmployee { get; set; }
        private Customer currentCustomer { get; set; }
        public Gui()
        {

            InitializeComponent();
            updateCmbEmployee();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Debug.WriteLine(employeeListbox.SelectedItem);
            //currentEmployee = employeeListbox.SelectedItem as Employee;
            empIdTextBox.Text = currentEmployee.EmployeeId.ToString();
            empNameTextBox.Text = currentEmployee.Name;

        }

        private void empIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void createEmpButton_Click(object sender, EventArgs e)
        {
            try
            {
                String tempId = empIdTextBox.Text;
                tempId = tempId.Trim();
                if (String.IsNullOrEmpty(tempId))
                {
                    labelUserMsg.Text = "Id box is empty";
                    return;
                }

                Employee emp = new Employee();
                emp.EmployeeId = Int32.Parse(tempId);

                emp.Name = empNameTextBox.Text;
                emp.Name = emp.Name.Trim();
                if (emp.EmployeeId < 0)
                {
                    labelUserMsg.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(emp.Name))
                {
                    labelUserMsg.Text = "You need to write a name";
                    return;
                }
                if (cmbCompanyEmployee.SelectedItem == null)
                {
                    emp.CompanyId = 0;
                }
                else
                {
                    emp.CompanyId = Int32.Parse(cmbCompanyEmployee.SelectedItem.ToString());
                }

                bool success = EmployeeController.Create(emp);

                if (success)
                {

                    labelUserMsg.Text = "Employee Created";
                }
                else
                {
                    labelUserMsg.Text = "Failed to create Employee";
                }

            }
            catch (FormatException)
            {

                labelUserMsg.Text = "Only numbers in ID";
            }
            catch (OverflowException)
            {
                labelUserMsg.Text = "Too many digits in ID";
            }
            FillListWithAllEmployees();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Gui_Load(object sender, EventArgs e)
        {

        }
        private void FillListWithAllEmployees()
        {
            dgvEmployees.DataSource = EmployeeController.ReadAll();
        }

        private void showAllEmployees_Click(object sender, EventArgs e)
        {
            FillListWithAllEmployees();
            labelUserMsg.Text = "All Employees listed";
        }

        private void tabCust_Click(object sender, EventArgs e)
        {
           // IEnumerable<Employee> employees = EmployeeController.ReadAll();
            cmbEmployeesCustomer.Items.Clear();
            updateCmbEmployee();


        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (currentEmployee == null)
            {
                labelUserMsg.Text = "No employee chosen";
                return;
            }
            bool deleted = EmployeeController.Delete(currentEmployee.EmployeeId);
            if (deleted)
            {
                labelUserMsg.Text = "Employee deleted";
            }
            else
            {
                labelUserMsg.Text = "Employee not deleted";
            }
            FillListWithAllEmployees();


        }

        private void updateEmp_Click(object sender, EventArgs e)
        {
            string tempName;
            try
            {

                if (currentEmployee == null)
                {
                    labelUserMsg.Text = "No employee chosen";
                    return;
                }

                tempName = empNameTextBox.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    labelUserMsg.Text = "Name field is empty";
                    return;
                }
                currentEmployee.Name = empNameTextBox.Text;

                EmployeeController.Update(currentEmployee);
                FillListWithAllEmployees();
                labelUserMsg.Text = "Employee updated";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void nameEmpLabel_Click(object sender, EventArgs e)
        {

        }
        private void FillListWithCustomerFromE()
        {
            IEnumerable<Customer> customers = CustomerController.ReadAllCustomersForEmployee(currentEmployee);
            empCustListBox.Items.Clear();
            foreach (Customer cust in customers)
            {
                Debug.WriteLine(cust.CustomerId + " " + cust.Name);
                empCustListBox.Items.Add(cust);
            }

        }
        private void FillListWithAllCustomers()
        {
            dgvCustomers.DataSource = CustomerController.ReadAll();
        }

        private void showAllCust_Click(object sender, EventArgs e)
        {
            FillListWithAllCustomers();
            cLabelMsg.Text = "All Customers Listed";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentEmployee = cmbEmployeesCustomer.SelectedItem as Employee;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateCustomerButton_Click(object sender, EventArgs e)

        {
            try
            {
                currentEmployee = cmbEmployeesCustomer.SelectedItem as Employee;

                int empId = Int32.Parse(cmbEmployeesCustomer.SelectedItem.ToString());
                currentEmployee = EmployeeController.FindById(empId);

                if (currentEmployee == null)
                {
                    cLabelMsg.Text = "No employee selected";
                    return;
                }

                String tempId = txtCustId.Text;
                tempId = tempId.Trim();
                if (String.IsNullOrEmpty(tempId))
                {
                    labelUserMsg.Text = "Id box is empty";
                    return;
                }

                Customer cust = new Customer();
                cust.CustomerId = Int32.Parse(tempId);
                cust.Name = txtCustName.Text;
                cust.Name = cust.Name.Trim();
                cust.Employee = currentEmployee;
                if (cust.CustomerId < 0)
                {
                    cLabelMsg.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(cust.Name))
                {
                    cLabelMsg.Text = "You need to write a name";
                    return;
                }
                bool success = CustomerController.Create(cust);

                if (success)
                {
                    cLabelMsg.Text = "Customer Created for " + currentEmployee.Name;
                }
                else
                {
                    cLabelMsg.Text = "Failed to create Customer";
                }

            }
            catch (FormatException)
            {

                cLabelMsg.Text = "Only numbers in ID";
            }
            catch (OverflowException)
            {
                cLabelMsg.Text = "Too many digits in ID";
            }
            FillListWithAllCustomers();
        }

        private void cListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCustomer = cmbCompanyEmployee.SelectedItem as Customer;
            txtCustId.Text = currentCustomer.CustomerId.ToString();
            txtCustName.Text = currentCustomer.Name;
         
        }

        private void empCustListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showCustForE_Click(object sender, EventArgs e)
        {
            if (currentEmployee == null)
            {
                labelUserMsg.Text = "No employee chosen";
                return;
            }
            FillListWithCustomerFromE();
            labelUserMsg.Text = "All customers listed for " + currentEmployee;

        }

        private void deleteCustFromE_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null)
            {
                cLabelMsg.Text = "No customer chosen";
                return;
            }
            bool deleted = CustomerController.Delete(currentCustomer.CustomerId);
            if (deleted)
            {
                cLabelMsg.Text = "Customer deleted";
            }
            else
            {
                cLabelMsg.Text = "Customer not deleted";
            }
            FillListWithAllCustomers();

        }

        private void updateCustButton_Click(object sender, EventArgs e)
        {
            string tempName;
            try
            {

                if (currentCustomer == null)
                {
                    cLabelMsg.Text = "No customer chosen";
                    return;
                }

                tempName = txtCustName.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    cLabelMsg.Text = "Name field is empty";
                    return;
                }
                currentCustomer.Name = txtCustName.Text;

                CustomerController.Update(currentCustomer);
                FillListWithAllCustomers();
                cLabelMsg.Text = "Customer updated";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int empId = Int32.Parse(dgvEmployees.CurrentRow.Cells[0].Value.ToString());
                currentEmployee = EmployeeController.FindById(empId);
                empIdTextBox.Text = currentEmployee.EmployeeId.ToString();
                empNameTextBox.Text = currentEmployee.Name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
       
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CustomerClear();
                int custId = Int32.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                currentCustomer = CustomerController.FindById(custId);
                txtCustId.Text = currentCustomer.CustomerId.ToString();
                txtCustName.Text = currentCustomer.Name;
                cmbEmployeesCustomer.SelectedText = currentCustomer.EmployeeId.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int empId = Int32.Parse(dgvEmployees.CurrentRow.Cells[0].Value.ToString());
                currentEmployee = EmployeeController.FindById(empId);
                empIdTextBox.Text = currentEmployee.EmployeeId.ToString();
                empNameTextBox.Text = currentEmployee.Name;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void updateCmbEmployee()
        {
            DataTable employees = EmployeeController.ReadAll();

            for (int i = 0; i < employees.Rows.Count; i++)
            {
                cmbEmployeesCustomer.Items.Add(employees.Rows[i]["EmployeeId"]);
            }

        }

        private void CustomerClear()
        {
            txtCustId.Clear();
            txtCustName.Clear();
            cmbEmployeesCustomer.Text = "";
        }

    }
}
