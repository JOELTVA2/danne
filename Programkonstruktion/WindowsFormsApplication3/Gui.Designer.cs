using Controller;
using Model;
using System.Collections.Generic;

namespace WindowsFormsApplication3
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button createEmpButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            System.Windows.Forms.Button CreateCustomerButton;
            System.Windows.Forms.Button btnCompanyCreate;
            System.Windows.Forms.Button CreateBranchButton;
            this.tabCust = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.cmbCompanyEmployee = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.showCustForE = new System.Windows.Forms.Button();
            this.empCustListBox = new System.Windows.Forms.ListBox();
            this.labelUserMsg = new System.Windows.Forms.Label();
            this.updateEmp = new System.Windows.Forms.Button();
            this.empNameTextBox = new System.Windows.Forms.TextBox();
            this.empDeleteButton = new System.Windows.Forms.Button();
            this.showAllButton = new System.Windows.Forms.Button();
            this.empIdTextBox = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbEmployeesCustomer = new System.Windows.Forms.ComboBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cLabelMsg = new System.Windows.Forms.Label();
            this.updateCustButton = new System.Windows.Forms.Button();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.deleteCustFromE = new System.Windows.Forms.Button();
            this.showAllCust = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvCompanies = new System.Windows.Forms.DataGridView();
            this.cmbCompanyBranch = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCompanyUpdate = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyId = new System.Windows.Forms.TextBox();
            this.CompanyDelete = new System.Windows.Forms.Button();
            this.btnCompanyShowAll = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvBranches = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.UpdateBranchButton = new System.Windows.Forms.Button();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.txtBranchId = new System.Windows.Forms.TextBox();
            this.DeleteBranchButton = new System.Windows.Forms.Button();
            this.ShowAllBranchButton = new System.Windows.Forms.Button();
            createEmpButton = new System.Windows.Forms.Button();
            CreateCustomerButton = new System.Windows.Forms.Button();
            btnCompanyCreate = new System.Windows.Forms.Button();
            CreateBranchButton = new System.Windows.Forms.Button();
            this.tabCust.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).BeginInit();
            this.SuspendLayout();
            // 
            // createEmpButton
            // 
            resources.ApplyResources(createEmpButton, "createEmpButton");
            createEmpButton.Name = "createEmpButton";
            createEmpButton.UseVisualStyleBackColor = true;
            createEmpButton.Click += new System.EventHandler(this.createEmpButton_Click);
            // 
            // CreateCustomerButton
            // 
            resources.ApplyResources(CreateCustomerButton, "CreateCustomerButton");
            CreateCustomerButton.Name = "CreateCustomerButton";
            CreateCustomerButton.UseVisualStyleBackColor = true;
            CreateCustomerButton.Click += new System.EventHandler(this.CreateCustomerButton_Click);
            // 
            // btnCompanyCreate
            // 
            resources.ApplyResources(btnCompanyCreate, "btnCompanyCreate");
            btnCompanyCreate.Name = "btnCompanyCreate";
            btnCompanyCreate.UseVisualStyleBackColor = true;
            // 
            // CreateBranchButton
            // 
            resources.ApplyResources(CreateBranchButton, "CreateBranchButton");
            CreateBranchButton.Name = "CreateBranchButton";
            CreateBranchButton.UseVisualStyleBackColor = true;
            CreateBranchButton.Click += new System.EventHandler(this.CreateBranchButton_Click);
            // 
            // tabCust
            // 
            this.tabCust.Controls.Add(this.tabPage7);
            this.tabCust.Controls.Add(this.tabPage1);
            this.tabCust.Controls.Add(this.tabPage2);
            this.tabCust.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabCust, "tabCust");
            this.tabCust.Name = "tabCust";
            this.tabCust.SelectedIndex = 0;
            this.tabCust.Tag = "";
            this.tabCust.Click += new System.EventHandler(this.tabCust_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dgvEmployees);
            this.tabPage7.Controls.Add(this.cmbCompanyEmployee);
            this.tabPage7.Controls.Add(this.label6);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Controls.Add(this.showCustForE);
            this.tabPage7.Controls.Add(this.empCustListBox);
            this.tabPage7.Controls.Add(this.labelUserMsg);
            this.tabPage7.Controls.Add(this.updateEmp);
            this.tabPage7.Controls.Add(this.empNameTextBox);
            this.tabPage7.Controls.Add(this.empDeleteButton);
            this.tabPage7.Controls.Add(this.showAllButton);
            this.tabPage7.Controls.Add(this.empIdTextBox);
            this.tabPage7.Controls.Add(createEmpButton);
            resources.ApplyResources(this.tabPage7, "tabPage7");
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToResizeColumns = false;
            this.dgvEmployees.AllowUserToResizeRows = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvEmployees, "dgvEmployees");
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellClick);
            // 
            // cmbCompanyEmployee
            // 
            this.cmbCompanyEmployee.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCompanyEmployee, "cmbCompanyEmployee");
            this.cmbCompanyEmployee.Name = "cmbCompanyEmployee";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // showCustForE
            // 
            resources.ApplyResources(this.showCustForE, "showCustForE");
            this.showCustForE.Name = "showCustForE";
            this.showCustForE.UseVisualStyleBackColor = true;
            this.showCustForE.Click += new System.EventHandler(this.showCustForE_Click);
            // 
            // empCustListBox
            // 
            this.empCustListBox.FormattingEnabled = true;
            resources.ApplyResources(this.empCustListBox, "empCustListBox");
            this.empCustListBox.Name = "empCustListBox";
            this.empCustListBox.SelectedIndexChanged += new System.EventHandler(this.empCustListBox_SelectedIndexChanged);
            // 
            // labelUserMsg
            // 
            resources.ApplyResources(this.labelUserMsg, "labelUserMsg");
            this.labelUserMsg.Name = "labelUserMsg";
            // 
            // updateEmp
            // 
            resources.ApplyResources(this.updateEmp, "updateEmp");
            this.updateEmp.Name = "updateEmp";
            this.updateEmp.UseVisualStyleBackColor = true;
            this.updateEmp.Click += new System.EventHandler(this.updateEmp_Click);
            // 
            // empNameTextBox
            // 
            resources.ApplyResources(this.empNameTextBox, "empNameTextBox");
            this.empNameTextBox.Name = "empNameTextBox";
            // 
            // empDeleteButton
            // 
            resources.ApplyResources(this.empDeleteButton, "empDeleteButton");
            this.empDeleteButton.Name = "empDeleteButton";
            this.empDeleteButton.UseVisualStyleBackColor = true;
            this.empDeleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // showAllButton
            // 
            resources.ApplyResources(this.showAllButton, "showAllButton");
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllEmployees_Click);
            // 
            // empIdTextBox
            // 
            resources.ApplyResources(this.empIdTextBox, "empIdTextBox");
            this.empIdTextBox.Name = "empIdTextBox";
            this.empIdTextBox.TextChanged += new System.EventHandler(this.empIdTextBox_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbEmployeesCustomer);
            this.tabPage1.Controls.Add(this.dgvCustomers);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cLabelMsg);
            this.tabPage1.Controls.Add(this.updateCustButton);
            this.tabPage1.Controls.Add(this.txtCustName);
            this.tabPage1.Controls.Add(this.txtCustId);
            this.tabPage1.Controls.Add(CreateCustomerButton);
            this.tabPage1.Controls.Add(this.deleteCustFromE);
            this.tabPage1.Controls.Add(this.showAllCust);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbEmployeesCustomer
            // 
            this.cmbEmployeesCustomer.FormattingEnabled = true;
            resources.ApplyResources(this.cmbEmployeesCustomer, "cmbEmployeesCustomer");
            this.cmbEmployeesCustomer.Name = "cmbEmployeesCustomer";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeColumns = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvCustomers, "dgvCustomers");
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cLabelMsg
            // 
            resources.ApplyResources(this.cLabelMsg, "cLabelMsg");
            this.cLabelMsg.Name = "cLabelMsg";
            // 
            // updateCustButton
            // 
            resources.ApplyResources(this.updateCustButton, "updateCustButton");
            this.updateCustButton.Name = "updateCustButton";
            this.updateCustButton.UseVisualStyleBackColor = true;
            this.updateCustButton.Click += new System.EventHandler(this.updateCustButton_Click);
            // 
            // txtCustName
            // 
            resources.ApplyResources(this.txtCustName, "txtCustName");
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtCustId
            // 
            resources.ApplyResources(this.txtCustId, "txtCustId");
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // deleteCustFromE
            // 
            resources.ApplyResources(this.deleteCustFromE, "deleteCustFromE");
            this.deleteCustFromE.Name = "deleteCustFromE";
            this.deleteCustFromE.UseVisualStyleBackColor = true;
            this.deleteCustFromE.Click += new System.EventHandler(this.deleteCustFromE_Click);
            // 
            // showAllCust
            // 
            resources.ApplyResources(this.showAllCust, "showAllCust");
            this.showAllCust.Name = "showAllCust";
            this.showAllCust.UseVisualStyleBackColor = true;
            this.showAllCust.Click += new System.EventHandler(this.showAllCust_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvCompanies);
            this.tabPage2.Controls.Add(this.cmbCompanyBranch);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btnCompanyUpdate);
            this.tabPage2.Controls.Add(this.txtCompanyName);
            this.tabPage2.Controls.Add(this.txtCompanyId);
            this.tabPage2.Controls.Add(btnCompanyCreate);
            this.tabPage2.Controls.Add(this.CompanyDelete);
            this.tabPage2.Controls.Add(this.btnCompanyShowAll);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCompanies
            // 
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvCompanies, "dgvCompanies");
            this.dgvCompanies.Name = "dgvCompanies";
            // 
            // cmbCompanyBranch
            // 
            this.cmbCompanyBranch.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCompanyBranch, "cmbCompanyBranch");
            this.cmbCompanyBranch.Name = "cmbCompanyBranch";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // btnCompanyUpdate
            // 
            resources.ApplyResources(this.btnCompanyUpdate, "btnCompanyUpdate");
            this.btnCompanyUpdate.Name = "btnCompanyUpdate";
            this.btnCompanyUpdate.UseVisualStyleBackColor = true;
            // 
            // txtCompanyName
            // 
            resources.ApplyResources(this.txtCompanyName, "txtCompanyName");
            this.txtCompanyName.Name = "txtCompanyName";
            // 
            // txtCompanyId
            // 
            resources.ApplyResources(this.txtCompanyId, "txtCompanyId");
            this.txtCompanyId.Name = "txtCompanyId";
            // 
            // CompanyDelete
            // 
            resources.ApplyResources(this.CompanyDelete, "CompanyDelete");
            this.CompanyDelete.Name = "CompanyDelete";
            this.CompanyDelete.UseVisualStyleBackColor = true;
            // 
            // btnCompanyShowAll
            // 
            resources.ApplyResources(this.btnCompanyShowAll, "btnCompanyShowAll");
            this.btnCompanyShowAll.Name = "btnCompanyShowAll";
            this.btnCompanyShowAll.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvBranches);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.UpdateBranchButton);
            this.tabPage3.Controls.Add(this.txtBranchName);
            this.tabPage3.Controls.Add(this.txtBranchId);
            this.tabPage3.Controls.Add(CreateBranchButton);
            this.tabPage3.Controls.Add(this.DeleteBranchButton);
            this.tabPage3.Controls.Add(this.ShowAllBranchButton);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvBranches
            // 
            this.dgvBranches.AllowUserToAddRows = false;
            this.dgvBranches.AllowUserToDeleteRows = false;
            this.dgvBranches.AllowUserToResizeColumns = false;
            this.dgvBranches.AllowUserToResizeRows = false;
            this.dgvBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvBranches, "dgvBranches");
            this.dgvBranches.Name = "dgvBranches";
            this.dgvBranches.ReadOnly = true;
            this.dgvBranches.RowHeadersVisible = false;
            this.dgvBranches.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBranches_CellClick);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // UpdateBranchButton
            // 
            resources.ApplyResources(this.UpdateBranchButton, "UpdateBranchButton");
            this.UpdateBranchButton.Name = "UpdateBranchButton";
            this.UpdateBranchButton.UseVisualStyleBackColor = true;
            this.UpdateBranchButton.Click += new System.EventHandler(this.UpdateBranchButton_Click);
            // 
            // txtBranchName
            // 
            resources.ApplyResources(this.txtBranchName, "txtBranchName");
            this.txtBranchName.Name = "txtBranchName";
            // 
            // txtBranchId
            // 
            resources.ApplyResources(this.txtBranchId, "txtBranchId");
            this.txtBranchId.Name = "txtBranchId";
            // 
            // DeleteBranchButton
            // 
            resources.ApplyResources(this.DeleteBranchButton, "DeleteBranchButton");
            this.DeleteBranchButton.Name = "DeleteBranchButton";
            this.DeleteBranchButton.UseVisualStyleBackColor = true;
            this.DeleteBranchButton.Click += new System.EventHandler(this.DeleteBranchButton_Click);
            // 
            // ShowAllBranchButton
            // 
            resources.ApplyResources(this.ShowAllBranchButton, "ShowAllBranchButton");
            this.ShowAllBranchButton.Name = "ShowAllBranchButton";
            this.ShowAllBranchButton.UseVisualStyleBackColor = true;
            this.ShowAllBranchButton.Click += new System.EventHandler(this.ShowAllBranchButton_Click);
            // 
            // Gui
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCust);
            this.Name = "Gui";
            this.Load += new System.EventHandler(this.Gui_Load);
            this.tabCust.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCust;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox empIdTextBox;
        private System.Windows.Forms.TextBox empNameTextBox;
        private System.Windows.Forms.Label labelUserMsg;
        private System.Windows.Forms.Button showAllButton;
        private System.Windows.Forms.Button empDeleteButton;
        private System.Windows.Forms.Button updateEmp;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button updateCustButton;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.Button deleteCustFromE;
        private System.Windows.Forms.Button showAllCust;
        private System.Windows.Forms.Label cLabelMsg;
        private System.Windows.Forms.ListBox empCustListBox;
        private System.Windows.Forms.Button showCustForE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompanyEmployee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.ComboBox cmbEmployeesCustomer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox cmbCompanyBranch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCompanyUpdate;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCompanyId;
        private System.Windows.Forms.Button CompanyDelete;
        private System.Windows.Forms.Button btnCompanyShowAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button UpdateBranchButton;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.TextBox txtBranchId;
        private System.Windows.Forms.Button DeleteBranchButton;
        private System.Windows.Forms.Button ShowAllBranchButton;
        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.DataGridView dgvBranches;
    }
}