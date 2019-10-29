using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class AddPurchaseUi : Form
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        SupplierManager _supplierManager = new SupplierManager();
        SalesManager _salesManager=new SalesManager();

        //List<Purchase> _purchases = new List<Purchase>();

        private PurchaseUiController purchaseUiController;
        public AddPurchaseUi(PurchaseUiController purchaseUiController2)
        {
            InitializeComponent();
            purchaseUiController = purchaseUiController2;

            ClearAllErrorLabel();
            codeTextBox.Text=purchaseUiController.GeneratePurchaseCodeBeforeSubmit();

            supplierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            supplierComboBox.DataSource = _supplierManager.GetAllSupplierForComboBox();

            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.DataSource = _categoryManager.GetAllCategoryForComboBox();

            //int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            //productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //productComboBox.DataSource = _productManager.GetAllProductForComboBox(categoryId);


            
        }
        private void AddPurchaseUi_Load(object sender, EventArgs e)
        {
            ClearAllErrorLabel();

        }

        private void closeCategoryUiButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(@"Are you sure, you want to exit?", @"Message Box", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase();
            purchase.InvoiceNo = billNoTextBox.Text;

            bool isFound = false;

            //check unique invoice in purchases list
            foreach (var itemPurchase in purchaseUiController._purchases)
            {
                if (itemPurchase.InvoiceNo == billNoTextBox.Text)
                {
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                invoiceNoErrorLabel.Text = @"Invoice no. already exist in current purchase list!";
                billNoTextBox.Focus();
                return;
            }
            if (_purchaseManager.UniquePurchaseCode(purchase))
            {
                invoiceNoErrorLabel.Text = @"Invoice no. already exist in database!";
                billNoTextBox.Focus();
                return;
            }

            if (String.IsNullOrEmpty(billNoTextBox.Text))
            {
                invoiceNoErrorLabel.Text = @"Invoice no. required !";
                billNoTextBox.Focus();
                return;
            }

            if (Convert.ToInt32(supplierComboBox.SelectedValue)==0)
            {
                supplierComboBoxErrorLabel.Text = @"Select a supplier !";
                supplierComboBox.Focus();
                return;
            }

            if (Convert.ToInt32(categoryComboBox.SelectedValue) == 0)
            {
                categoryComboboxerrorLabel.Text = @"Select a category !";
                categoryComboBox.Focus();
                return;
            }

            if (Convert.ToInt32(productComboBox.SelectedValue)==0)
            {
                productComboBoxErrorLabel.Text = @"Select a product";
                productComboBox.Focus();
                return;
            }

            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                quantityErrorLabel.Text = @"Quantity is required !";
                quantityTextBox.Focus();
                return;
            }

            if (String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                UnitPriceErrorLabel.Text = @"Unit price is required !";
                unitPriceTextBox.Focus();
                return;
            }

            if (String.IsNullOrEmpty(mrpTextBox.Text))
            {
                mrpErrorLabel.Text = @"MRP is required !";
                mrpTextBox.Focus();
            }

            if (String.IsNullOrEmpty(remarksTextBox.Text))
            {
                remarkErrorLabel.Text = @"Remark is required !";
                remarksTextBox.Focus();
                return;
            }
            

            if (addButton.Text == "Add")
            {

                purchase.Date = purchaseDateTimePicker.Text;
                purchase.InvoiceNo = billNoTextBox.Text;
                purchase.SupplierId = Convert.ToInt32(supplierComboBox.SelectedValue);
                purchase.ProductId = Convert.ToInt32(productComboBox.SelectedValue);
                purchase.Code = codeTextBox.Text;
                purchase.ManufacturedDate = manufacturedDateTimePicker.Text;
                purchase.ExpireDate = expireDateTimePicker.Text;
                purchase.Quantity = Convert.ToInt32(quantityTextBox.Text);
                purchase.UnitPrice = Convert.ToDouble(unitPriceTextBox.Text);

                purchase.TotalPrice = Convert.ToDouble(totalPriceTextBox.Text);
                purchase.MRP = Convert.ToDouble(mrpTextBox.Text);
                purchase.Remarks = remarksTextBox.Text;


                purchaseUiController._purchases.Add(purchase);


            }
            else
            {
                int index = 0;
                foreach (var itemPurchase in purchaseUiController._purchases)
                {

                    if (itemPurchase.Code == codeTextBox.Text)
                    {
                        purchase = purchaseUiController._purchases.ElementAt(index);
                        break;
                    }
                    index++;

                }

                purchase.Date = purchaseDateTimePicker.Text;
                purchase.InvoiceNo = billNoTextBox.Text;
                purchase.SupplierId = Convert.ToInt32(supplierComboBox.SelectedValue);
                purchase.ProductId = Convert.ToInt32(productComboBox.SelectedValue);
                purchase.Code = codeTextBox.Text;
                purchase.ManufacturedDate = manufacturedDateTimePicker.Text;
                purchase.ExpireDate = expireDateTimePicker.Text;
                purchase.Quantity = Convert.ToInt32(quantityTextBox.Text);
                purchase.UnitPrice = Convert.ToDouble(unitPriceTextBox.Text);

                purchase.TotalPrice = Convert.ToDouble(totalPriceTextBox.Text);
                purchase.MRP = Convert.ToDouble(mrpTextBox.Text);
                purchase.Remarks = remarksTextBox.Text;

                MessageBox.Show(@"Updated successfully");
                addButton.Text = @"Add";

                //after update close the form
                Close();
            }

            ClearAllTextBox();

            //purchaseUiController.purchaseDataGridView.DataSource = null;
            //purchaseUiController.purchaseDataGridView.DataSource = _purchases;
            purchaseUiController.ShowAllPurchase();


            //get next purchase code
            codeTextBox.Text=purchaseUiController.GeneratePurchaseCodeBeforeSubmit();
        }

       
        public void ClearAllErrorLabel()
        {
           
            invoiceNoErrorLabel.Text = "";
            supplierComboBoxErrorLabel.Text = "";
            categoryComboboxerrorLabel.Text = "";
            productComboBoxErrorLabel.Text = "";
            quantityErrorLabel.Text = "";
            UnitPriceErrorLabel.Text = "";
            mrpErrorLabel.Text = "";
            remarkErrorLabel.Text = "";
        }
        public void ClearAllTextBox()
        {
            purchaseDateTimePicker.CustomFormat = "yyyy-MM-dd";
            billNoTextBox.Clear();
            supplierComboBox.SelectedValue = 0;
            categoryComboBox.SelectedValue = 0;
            productComboBox.SelectedValue = 0;
            codeTextBox.Clear();
            availableQuantityTextBox.Clear();
            manufacturedDateTimePicker.CustomFormat = "yyyy-MM-dd";
            expireDateTimePicker.CustomFormat = "yyyy-MM-dd";
            quantityTextBox.Clear();
            unitPriceTextBox.Clear();
            totalPriceTextBox.Clear();
            previousUnitPriceTextbox.Clear();
            previousMRPTextBox.Clear();
            mrpTextBox.Clear();
            remarksTextBox.Clear();
        }


        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryComboboxerrorLabel.Text = "";
            int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.DataSource = _productManager.GetAllProductForComboBox(categoryId);
        }

        private void productComboBox_TextChanged(object sender, EventArgs e)
        {


            int productId = Convert.ToInt32(productComboBox.SelectedValue);

            Purchase purchase = new Purchase();
            purchase = _purchaseManager.GetLastPurchasesProductInfoById(productId);

            availableQuantityTextBox.Enabled = false;
            previousUnitPriceTextbox.Enabled = false;
            previousMRPTextBox.Enabled = false;

            previousUnitPriceTextbox.Text = purchase.UnitPrice.ToString();
            previousMRPTextBox.Text = purchase.MRP.ToString();



            int totalPurchaseQuantity = _purchaseManager.GetTotalProductById(productId);
            int totalSaleQuantity = _salesManager.GetTotalProductById(productId);

            int availableQuantity = totalPurchaseQuantity - totalSaleQuantity;
            availableQuantityTextBox.Text = availableQuantity.ToString();


        }

        private void unitPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show(@"Only numeric value !");
                return;
            }

            if (chr == 8)
            {
                totalPriceTextBox.Text = "";
            }

        }

        private void unitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            UnitPriceErrorLabel.Text = "";
            if (unitPriceTextBox.TextLength > 0 && quantityTextBox.Text.Length > 0)
            {
                totalPriceTextBox.Text =
                    (Convert.ToInt32(quantityTextBox.Text) * Convert.ToDouble(unitPriceTextBox.Text)).ToString();
            }
            else
            {
                totalPriceTextBox.Text = "0";
            }

            if (unitPriceTextBox.TextLength > 0)
            {
                double price = Convert.ToDouble(unitPriceTextBox.Text);
                mrpTextBox.Text = (price + price * 25 / 100).ToString();
            }



        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            quantityErrorLabel.Text = "";
            if (unitPriceTextBox.TextLength > 0 && quantityTextBox.Text.Length > 0)
            {
                totalPriceTextBox.Text =
                    (Convert.ToInt32(quantityTextBox.Text) * Convert.ToDouble(unitPriceTextBox.Text)).ToString();
            }
            else
            {
                totalPriceTextBox.Text = "0";
            }

            if (unitPriceTextBox.TextLength > 0)
            {
                double price = Convert.ToDouble(unitPriceTextBox.Text);
                mrpTextBox.Text = (price + price * 25 / 100).ToString();
            }
        }

        private void billNoTextBox_TextChanged(object sender, EventArgs e)
        {
            invoiceNoErrorLabel.Text = "";
        }

        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierComboBoxErrorLabel.Text = "";
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productComboBoxErrorLabel.Text = "";

            //codeTextBox.Text = _productManager.GetCodeById(Convert.ToInt32(productComboBox.SelectedValue));
        }

        private void mrpTextBox_TextChanged(object sender, EventArgs e)
        {
            mrpErrorLabel.Text = "";
        }

        private void remarksTextBox_TextChanged(object sender, EventArgs e)
        {
            remarkErrorLabel.Text = "";
        }

        private void availableQuantityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
