﻿using Controller;
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
        private Bransch currentBransch { get; set; }
        private Registered_Company currentCompany { get; set; }

        public Gui()
        {

            InitializeComponent();
            updateCmbEmployee();
            updateCmbCompanyBranch();
            updateCmbEmployeeCompany();
            FillListWithAllCompanies();
            FillListWithAllCustomers();
            FillListWithAllEmployees();
            FillListWithAllBranches();
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

        private void FillListWithAllCompanies()
        {
            dgvCompanies.DataSource = CompanyController.ReadAll();
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
            cmbCompanyBranch.Items.Clear();
            cmbCompanyEmployee.Items.Clear();
            updateCmbEmployee();
            updateCmbCompanyBranch();
            updateCmbEmployeeCompany();
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
                    cLabelMsg.Text = "No customer selected";
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
            CustomerClear();

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
                currentCustomer.EmployeeId = Int32.Parse(cmbEmployeesCustomer.SelectedItem.ToString());
                CustomerController.Update(currentCustomer);
                FillListWithAllCustomers();
                cLabelMsg.Text = "Customer updated";
            }
            catch (Exception ex)
            {

                throw ex;
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
                dgvEmployeesCustomers.DataSource = CustomerController.ReadAllCustomersForEmployee(currentEmployee);
                

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

        private void dgvBranches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int branchId = Int32.Parse(dgvBranches.CurrentRow.Cells[0].Value.ToString());
                currentBransch = BranschController.FindById(branchId);
                txtBranchId.Text = currentBransch.BranschId.ToString();
                txtBranchName.Text = currentBransch.Name;
                dgvBranchCompanies.DataSource = BranschController.ReadAllCompaniesForABransch(currentBransch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CompanyClear();
                int companyId = Int32.Parse(dgvCompanies.CurrentRow.Cells[0].Value.ToString());
                currentCompany = CompanyController.FindById(companyId);
                txtCompanyId.Text = currentCompany.RegComp_Id.ToString();
                txtCompanyName.Text = currentCompany.Name;
                cmbCompanyBranch.SelectedText = currentCompany.BranschId.ToString();
                dgvCompaniesEmployees.DataSource = CompanyController.ReadAllEmployeesForACompany(currentCompany);

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

        private void updateCmbCompanyBranch()
        {
            DataTable branches = BranschController.ReadAll();

            for (int i = 0; i < branches.Rows.Count; i++)
            {
                cmbCompanyBranch.Items.Add(branches.Rows[i]["BranschId"]);
            }

        }

        private void updateCmbEmployeeCompany()
        {
            DataTable companies = CompanyController.ReadAll();

            for (int i = 0; i < companies.Rows.Count; i++)
            {
                cmbCompanyEmployee.Items.Add(companies.Rows[i]["RegComp_Id"]);
            }
        }

        private void CustomerClear()
        {
            txtCustId.Clear();
            txtCustName.Clear();
            cmbEmployeesCustomer.Text = "";
        }

        private void CompanyClear()
        {
            txtCompanyId.Clear();
            txtCompanyName.Clear();
            cmbCompanyBranch.Text = "";
        }


        private void CreateBranchButton_Click(object sender, EventArgs e)
        {
            try
            {
                String tempId = txtBranchId.Text;
                tempId = tempId.Trim();
                if (String.IsNullOrEmpty(tempId))
                {
                    labelUserMsg.Text = "Id box is empty";
                    return;
                }

                Bransch bransch = new Bransch();
                bransch.BranschId = Int32.Parse(tempId);

                bransch.Name = txtBranchName.Text;
                bransch.Name = bransch.Name.Trim();
                if (bransch.BranschId < 0)
                {
                    labelUserMsg.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(bransch.Name))
                {
                    labelUserMsg.Text = "You need to write a name";
                    return;
                }

                bool success = BranschController.CreateBransch(bransch);
                FillListWithAllBranches();

                if (success)
                {

                    labelUserMsg.Text = "Bransch Created";
                }
                else
                {
                    labelUserMsg.Text = "Failed to create Bransch";
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

        private void FillListWithAllBranches()
        {
            dgvBranches.DataSource = BranschController.ReadAll();
        }

        private void ShowAllBranchButton_Click(object sender, EventArgs e)
        {
            FillListWithAllBranches();
        }

        private void DeleteBranchButton_Click(object sender, EventArgs e)
        {
            if (currentBransch == null)
            {
                labelUserMsg.Text = "No branch chosen";
                return;
            }
            bool deleted = BranschController.DeleteBransch(currentBransch.BranschId);
            if (deleted)
            {
                labelUserMsg.Text = "branch deleted";
            }
            else
            {
                labelUserMsg.Text = "branch not deleted";
            }
            FillListWithAllBranches();


        }

        private void UpdateBranchButton_Click(object sender, EventArgs e)
        {
            string tempName;
            try
            {

                if (currentBransch == null)
                {
                    labelUserMsg.Text = "No branch chosen";
                    return;
                }

                tempName = txtBranchName.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    labelUserMsg.Text = "Name field is empty";
                    return;
                }
                currentBransch.Name = txtBranchName.Text;

                BranschController.UpdateBransch(currentBransch);
                FillListWithAllBranches();
                labelUserMsg.Text = "Branch updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void btnCompanyCreate_Click(object sender, EventArgs e)
        {

            try
            {
                String tempId = txtCompanyId.Text;
                tempId = tempId.Trim();
                if (String.IsNullOrEmpty(tempId))
                {
                    labelUserMsg.Text = "Id box is empty";
                    return;
                }

                Registered_Company rc = new Registered_Company();
                rc.RegComp_Id = Int32.Parse(tempId);

                rc.Name = txtCompanyName.Text;
                rc.BranschId = Int32.Parse(cmbCompanyBranch.SelectedItem.ToString());
                if (rc.BranschId < 0)
                {
                    labelUserMsg.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(rc.Name))
                {
                    labelUserMsg.Text = "You need to write a name";
                    return;
                }

                bool success = CompanyController.CreateRegistered_Company(rc);

                if (success)
                {

                    labelUserMsg.Text = "Company Created";
                }
                else
                {
                    labelUserMsg.Text = "Failed to create company";
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
            FillListWithAllCompanies();
        }

        private void btnCompanyUpdate_Click(object sender, EventArgs e)
        {
            string tempName;
            try
            {

                if (currentCompany == null)
                {
                    labelUserMsg.Text = "No company chosen";
                    return;
                }

                tempName = txtCompanyName.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    labelUserMsg.Text = "Name field is empty";
                    return;
                }
                currentCompany.Name = txtCompanyName.Text;

                CompanyController.Update(currentCompany);
                FillListWithAllCompanies();
                labelUserMsg.Text = "Company updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CompanyDelete_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                labelUserMsg.Text = "No company chosen";
                return;
            }
            bool deleted = CompanyController.DeleteRegistered_Company(currentCompany.RegComp_Id);
            if (deleted)
            {
                labelUserMsg.Text = "Company deleted";
            }
            else
            {
                labelUserMsg.Text = "Company not deleted";
            }
            FillListWithAllCompanies();
            CompanyClear();

        }

        private void btnCompanyShowAll_Click(object sender, EventArgs e)
        {
            FillListWithAllCompanies();
        }
    }
 }
    

