using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;


using System.Windows.Forms;

namespace StockManagementSystem.UI
{
    public partial class AddCustomerUi : Form
    {

        CustomerManager _customerManager = new CustomerManager();
        Customer _customer = new Customer();
        string pattern;

        public int customerId;
        private CustomerUiController customerUiController;
        public AddCustomerUi(CustomerUiController customerUiController2)
        {
            InitializeComponent();
            customerUiController = customerUiController2;
            GetLastCustomerCode();
        }

        private void AddCustomerUi_Load(object sender, EventArgs e)
        {
            ClearAllErrorLabel();
            
        }
        private void ClearAllErrorLabel()
        {
            nameErrorLabel.Text = "";
            addressErrorLabel.Text = "";
            emailErrorLabel.Text = "";
            contactErrorLabel.Text = "";
            loyaltyPointErrorLabel.Text = "";
            
        }

        private void saveOrUpdateButton_Click(object sender, EventArgs e)
        {
            _customer.Id = customerId;
            _customer.Code = codeTextBox.Text;
            _customer.Name = nameTextBox.Text;
            _customer.Address = addressTextBox.Text;
            _customer.Email = emailTextBox.Text;
            _customer.Contact = contactTextBox.Text;
            //loyaltyPointTextBox.Text = "0";
            //_customer.LoyaltyPoint = Convert.ToInt32(loyaltyPointTextBox.Text);


            if (String.IsNullOrEmpty(_customer.Name))
            {
                nameErrorLabel.ForeColor = Color.Red;
                nameErrorLabel.Text = @"Name is required";
                nameTextBox.Focus();
                return;
            }
            if (_customerManager.UniqueEmail(_customer))
            {
                emailErrorLabel.ForeColor = Color.Red;
                emailErrorLabel.Text = @"Email is already exist !";
                emailTextBox.Focus();
                return;
            }

            if (String.IsNullOrEmpty(_customer.Email))
            {
                emailErrorLabel.ForeColor = Color.Red;
                emailErrorLabel.Text = @"Email is required !";
                emailTextBox.Focus();
                return;
            }
            if (_customerManager.UniqueContact(_customer))
            {
                contactErrorLabel.ForeColor = Color.Red;
                contactErrorLabel.Text = @"Contact is already exist !";
                contactTextBox.Focus();
                return;
            }
            if (!String.IsNullOrEmpty(_customer.Contact) && _customer.Contact.Length != 11)
            {
                contactErrorLabel.ForeColor = Color.Red;
                contactErrorLabel.Text = @"Contact is 11 character length required !";
                contactTextBox.Focus();
                return;
            }
            if (String.IsNullOrEmpty(_customer.Contact))
            {
                contactErrorLabel.ForeColor = Color.Red;
                contactErrorLabel.Text = @"Contact is required !";
                contactTextBox.Focus();
                return;
            }

            if (String.IsNullOrEmpty(loyaltyPointTextBox.Text))
            {
                loyaltyPointErrorLabel.ForeColor = Color.Red;
                loyaltyPointErrorLabel.Text = @"Loyalty point is required !";
                loyaltyPointTextBox.Focus();
                return;
            }
            _customer.LoyaltyPoint = Convert.ToDouble(loyaltyPointTextBox.Text);

            if (String.IsNullOrEmpty(_customer.Address))
            {
                addressErrorLabel.ForeColor = Color.Red;
                addressErrorLabel.Text = @"Address is required !";
                addressTextBox.Focus();
                return;
            }

           

            if (saveOrUpdateButton.Text == @"Save")
            {
                if (_customerManager.AddCustomer(_customer))
                {
                    customerUiController.ShowAllCustomer();
                    MessageBox.Show(@"Saved Successfully");
                    // customerDataGridView.DataSource = _customerManager.GetAllCustomer();
                 
                   
                    GetLastCustomerCode();
                }
                else
                {
                    MessageBox.Show(@"Save Failed");
                }
            }
            else
            {
                if (_customerManager.UpdateCustomer(_customer))
                {
                    customerUiController.ShowAllCustomer();
                    MessageBox.Show(@"Updated Successfully");
                    //customerDataGridView.DataSource = _customerManager.GetAllCustomer();
               
                    saveOrUpdateButton.Text = "Save";
                  
                    Close();
                }
                else
                {
                    MessageBox.Show(@"Update Failed");
                }

            }
            ClearAllTextBox();
            ClearAllErrorLabel();
            GetLastCustomerCode();

        }

        private void ClearAllTextBox()
        {
            codeTextBox.Clear();
            nameTextBox.Clear();
            addressTextBox.Clear();
            emailTextBox.Clear();
            contactTextBox.Clear();
            loyaltyPointTextBox.Clear();

        }
        private void GetLastCustomerCode()
        {
            string lastCustomerCode = _customerManager.GetLastCustomerCode();

            if (lastCustomerCode == "")
            {
                lastCustomerCode = "0001";
            }
            else
            {
                int number = int.Parse(lastCustomerCode);
                lastCustomerCode = (++number).ToString("D" + lastCustomerCode.Length);

            }

            codeTextBox.Text = lastCustomerCode;
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(@"Are you sure, you want to exit?", @"Message Box", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameErrorLabel.Text = "";
        }

        private void contactTextBox_TextChanged(object sender, EventArgs e)
        {
            contactErrorLabel.Text = "";
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (Regex.IsMatch(emailTextBox.Text, pattern))
            {
                emailErrorLabel.Text = "";
            }
            else
            {
                emailErrorLabel.Text = @"Enter Valid Email!!";
                emailErrorLabel.ForeColor = Color.Red;
                return;
            }
        }

        private void loyaltyPointTextBox_TextChanged(object sender, EventArgs e)
        {
            loyaltyPointErrorLabel.Text = "";
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {
            addressErrorLabel.Text = "";
        }
    }
   
    
}
