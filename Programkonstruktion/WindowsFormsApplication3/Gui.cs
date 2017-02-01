using Controller;
using Model;
using System;
using ErrorHandler;
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
                    lblresponse.Text = "Id box is empty";
                    return;
                }

                Employee emp = new Employee();
                emp.EmployeeId = Int32.Parse(tempId);

                emp.Name = empNameTextBox.Text;
                emp.Name = emp.Name.Trim();
                if (emp.EmployeeId < 0)
                {
                    lblresponse.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(emp.Name))
                {
                    lblresponse.Text = "You need to write a name";
                    return;
                }
                if (cmbCompanyEmployee.SelectedItem == null)
                {
                    emp.CompanyId = 0;
                }
                else
                {
                    emp.CompanyId = Int32.Parse(cmbCompanyEmployee.Text);
                }
                bool success = EmployeeController.Create(emp);
                if (success)
                {

                    lblresponse.Text = "Employee Created";
                }
                else
                {
                    lblresponse.Text = "Failed to create Employee";
                }
            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
            DataTable test = CompanyController.ReadAll();
            dgvCompanies.DataSource = test;
                
        }

        private void showAllEmployees_Click(object sender, EventArgs e)
        {
            FillListWithAllEmployees();
            lblresponse.Text = "All Employees listed";
        }

        private void tabCust_Click(object sender, EventArgs e)
        {
    
            cmbEmployeesCustomer.Items.Clear();
            cmbCompanyBranch.Items.Clear();
            cmbCompanyEmployee.Items.Clear();
            updateCmbEmployee();
            updateCmbCompanyBranch();
            updateCmbEmployeeCompany();
            dgvDeleted.DataSource = CustomerController.ReadAllDeletedCustomers();
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (currentEmployee == null)
            {
                lblresponse.Text = "No employee chosen";
                return;
            }
            bool deleted = EmployeeController.Delete(currentEmployee.EmployeeId);
            if (deleted)
            {
                lblresponse.Text = "Employee deleted";
            }
            else
            {
                lblresponse.Text = "Employee not deleted";
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
                    lblresponse.Text = "No employee chosen";
                    return;
                }
                tempName = empNameTextBox.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    lblresponse.Text = "Name field is empty";
                    return;
                }
                currentEmployee.Name = empNameTextBox.Text;

                currentEmployee.CompanyId = Int32.Parse(cmbCompanyEmployee.Text);

                EmployeeController.Update(currentEmployee);
                FillListWithAllEmployees();
                lblresponse.Text = "Employee updated";
            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
            lblresponse.Text = "All Customers Listed";

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
                if (cmbEmployeesCustomer.Text != "")
                {
                    int empId = Int32.Parse(cmbEmployeesCustomer.Text);
                    currentEmployee = EmployeeController.FindById(empId);
                }

                if (currentEmployee == null)
                {
                    lblresponse.Text = "No Employee selected";
                    return;
                }

                String tempId = txtCustId.Text;
                tempId = tempId.Trim();
                if (String.IsNullOrEmpty(tempId))
                {
                    lblresponse.Text = "Id box is empty";
                    return;
                }

                Customer cust = new Customer();
                cust.CustomerId = Int32.Parse(tempId);
                cust.Name = txtCustName.Text;
                cust.Name = cust.Name.Trim();
                cust.Employee = currentEmployee;
                if (cust.CustomerId < 0)
                {
                    lblresponse.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(cust.Name))
                {
                    lblresponse.Text = "You need to write a name";
                    return;
                }
                bool success = CustomerController.Create(cust);

                if (success)
                {
                    lblresponse.Text = "Customer Created for " + currentEmployee.Name;
                }
                else
                {
                    lblresponse.Text = "Failed to create Customer";
                }

            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                lblresponse.Text = "No customer chosen";
                return;
            }
            bool deleted = CustomerController.Delete(currentCustomer.CustomerId);
            if (deleted)
            {
                lblresponse.Text = "Customer deleted";
            }
            else
            {
                lblresponse.Text = "Customer not deleted";
            }
            FillListWithAllCustomers();
            CustomerClear();
            dgvDeleted.DataSource = CustomerController.ReadAllDeletedCustomers();

        }

        private void updateCustButton_Click(object sender, EventArgs e)
        {
            string tempName;
            try
            {

                if (currentCustomer == null)
                {
                    lblresponse.Text = "No customer chosen";
                    return;
                }

                tempName = txtCustName.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    lblresponse.Text = "Name field is empty";
                    return;
                }
                currentCustomer.Name = txtCustName.Text;
                currentCustomer.EmployeeId = Int32.Parse(cmbEmployeesCustomer.Text);
                CustomerController.Update(currentCustomer);
                FillListWithAllCustomers();
                lblresponse.Text = "Customer updated";
            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                DataTable dt1 = CustomerController.ReadAllCustomersForEmployee(currentEmployee);
            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                    lblresponse.Text = "Id box is empty";
                    return;
                }

                Bransch bransch = new Bransch();
                bransch.BranschId = Int32.Parse(tempId);

                bransch.Name = txtBranchName.Text;
                bransch.Name = bransch.Name.Trim();
                if (bransch.BranschId < 0)
                {
                    lblresponse.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(bransch.Name))
                {
                    lblresponse.Text = "You need to write a name";
                    return;
                }

                bool success = BranschController.CreateBransch(bransch);
                FillListWithAllBranches();

                if (success)
                {

                    lblresponse.Text = "Bransch Created";
                }
                else
                {
                    lblresponse.Text = "Failed to create Bransch";
                }

            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                lblresponse.Text = "No branch chosen";
                return;
            }
            bool deleted = BranschController.DeleteBransch(currentBransch.BranschId);
            if (deleted)
            {
                lblresponse.Text = "branch deleted";
            }
            else
            {
                lblresponse.Text = "branch not deleted";
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
                    lblresponse.Text = "No branch chosen";
                    return;
                }

                tempName = txtBranchName.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    lblresponse.Text = "Name field is empty";
                    return;
                }
                currentBransch.Name = txtBranchName.Text;

                BranschController.UpdateBransch(currentBransch);
                FillListWithAllBranches();
                lblresponse.Text = "Branch updated";
            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                    lblresponse.Text = "Id box is empty";
                    return;
                }

                Registered_Company rc = new Registered_Company();
                rc.RegComp_Id = Int32.Parse(tempId);

                rc.Name = txtCompanyName.Text;
                rc.BranschId = Int32.Parse(cmbCompanyBranch.SelectedItem.ToString());
                if (rc.BranschId < 0)
                {
                    lblresponse.Text = "Id is less than 0";
                    return;
                }
                if (String.IsNullOrEmpty(rc.Name))
                {
                    lblresponse.Text = "You need to write a name";
                    return;
                }

                bool success = CompanyController.CreateRegistered_Company(rc);

                if (success)
                {

                    lblresponse.Text = "Company Created";
                }
                else
                {
                    lblresponse.Text = "Failed to create company";
                }

            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
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
                    lblresponse.Text = "No company chosen";
                    return;
                }

                tempName = txtCompanyName.Text;
                tempName = tempName.Trim();
                if (String.IsNullOrEmpty(tempName))
                {
                    lblresponse.Text = "Name field is empty";
                    return;
                }
                currentCompany.Name = txtCompanyName.Text;

                CompanyController.Update(currentCompany);
                FillListWithAllCompanies();
                lblresponse.Text = "Company updated";
            }
            catch (Exception ex)
            {
                lblresponse.Text = ErrorHandlern.HandleExceptions(ex);
            }

        }

        private void CompanyDelete_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                lblresponse.Text = "No company chosen";
                return;
            }
            bool deleted = CompanyController.DeleteRegistered_Company(currentCompany.RegComp_Id);
            if (deleted)
            {
                lblresponse.Text = "Company deleted";
            }
            else
            {
                lblresponse.Text = "Company not deleted";
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
    

