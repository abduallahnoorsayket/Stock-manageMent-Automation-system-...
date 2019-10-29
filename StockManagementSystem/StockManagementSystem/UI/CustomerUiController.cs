using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class CustomerUiController : UserControl
    {
        CustomerManager _customerManager = new CustomerManager();
        Customer _customer = new Customer();
        public CustomerUiController()
        {
            InitializeComponent();
        }

        private void CustomerUiController_Load(object sender, EventArgs e)
        {
            ShowAllCustomer();
            searchTextBoxErrorLabel.Text = "";
        }
        public void ShowAllCustomer()
        {
            customerDataGridView.DataSource = _customerManager.GetAllCustomer();

        }
        private void customerDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.customerDataGridView.Rows[e.RowIndex].Cells["Sl"].Value = (e.RowIndex + 1).ToString();
        }
        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddCustomerUi addCustomerUi = new AddCustomerUi(this);
            if (customerDataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {

                        if (customerDataGridView.CurrentRow != null) customerDataGridView.CurrentRow.Selected = true;

                        addCustomerUi.customerId = Convert.ToInt32(customerDataGridView.Rows[e.RowIndex].Cells[1].Value);
                        addCustomerUi.codeTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        addCustomerUi.nameTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                        addCustomerUi.addressTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                        addCustomerUi.emailTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                        addCustomerUi.contactTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                        addCustomerUi.loyaltyPointTextBox.Text = customerDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                        addCustomerUi.saveOrUpdateButton.Text = @"Update";
                        addCustomerUi.Show();


                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            AddCustomerUi addCustomerUi = new AddCustomerUi(this);

            addCustomerUi.Show();

        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                searchTextBoxErrorLabel.ForeColor = Color.Red;
                searchTextBoxErrorLabel.Text = @"Search value required !";
                searchTextBoxErrorLabel.Focus();
                return;
            }

            List<Customer> customers = new List<Customer>();
            if (nameRadioButton.Checked == true)
            {
                customers = _customerManager.SearchCustomer(searchTextBox.Text, "", "");
                if (customers.Count != 0)
                {
                    customerDataGridView.DataSource = customers;
                }
                else
                {
                    customerDataGridView.DataSource = null;
                    MessageBox.Show(@"No Result Found", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (emailRadioButton.Checked == true)
            {
                customers = _customerManager.SearchCustomer("", searchTextBox.Text, "");
                if (customers.Count != 0)
                {
                    customerDataGridView.DataSource = customers;
                }
                else
                {
                    customerDataGridView.DataSource = null;
                    MessageBox.Show(@"No Result Found", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (contactRadioButton.Checked == true)
            {
                customers = _customerManager.SearchCustomer("", "", searchTextBox.Text);
                if (customers.Count != 0)
                {
                    customerDataGridView.DataSource = customers;
                }
                else
                {
                    customerDataGridView.DataSource = null;
                    MessageBox.Show(@"No Result Found", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void showAllCustomerButton_Click(object sender, EventArgs e)
        {
            ShowAllCustomer();
        }
    }
}
