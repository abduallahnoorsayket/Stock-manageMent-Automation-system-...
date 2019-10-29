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
    public partial class SalesUiController : UserControl
    {
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        SalesManager _salesManager=new SalesManager();
        CustomerManager _customerManager = new CustomerManager();
        PurchaseManager _purchaseManager=new PurchaseManager();
        public List<Sale> _sales = new List<Sale>();

        //private double loyaltyPoint = 0;
        public SalesUiController()
        {
            InitializeComponent();

            //ClearAllErrorLabel();
             GenerateSaleCodeBeforeSubmit();

            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.DataSource = _categoryManager.GetAllCategoryForComboBox();

            customerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            customerComboBox.DataSource = _customerManager.GetAllCustomerForComboBox();
        }
        
        private void SalesUiController_Load(object sender, EventArgs e)
        {
            ClearAllErrorLabel();
            //loyaltyPointTextBox.Text = loyaltyPoint.ToString();
        }
        private void addSaleButton_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();

            if (Convert.ToInt32(customerComboBox.SelectedValue) == 0)
            {
                customerComboBoxErrorLabel.Text = @"Select a customer";
                customerComboBox.Focus();
                return;
            }
            if (Convert.ToInt32(categoryComboBox.SelectedValue) == 0)
            {
                categoryComboBoxErrorLabel.Text = @"Select a category !";
                categoryComboBox.Focus();
                return;
            }


            if (Convert.ToInt32(productComboBox.SelectedValue) == 0)
            {
                productComboBoxErrorLabel.Text = @"Select a product";
                productComboBox.Focus();
                return;
            }
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                quatityErrorLabel.Text = @"Quantity is required !";
                quantityTextBox.Focus();
                return;
            }
            if (String.IsNullOrEmpty(mrpTextBox.Text))
            {
                mrpErrorLabel.Text = @"MRP is required !";
                mrpTextBox.Focus();
            }

            if (addSaleButton.Text == @"Add")
            {
                sale.Date = saleDateTimePicker.Text;
                //sale.InvoiceNo = billNoTextBox.Text;
                sale.Code = codeTextBox.Text;
                sale.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
                sale.ProductId = Convert.ToInt32(productComboBox.SelectedValue);
                sale.Product = productComboBox.Text;
                sale.Quantity = Convert.ToInt32(quantityTextBox.Text);
                sale.MRP = Convert.ToDouble(mrpTextBox.Text);
                sale.TotalMRP = Convert.ToInt32(totalMrpTextBox.Text);

                //grandtotalTextBox.Text = sale.TotalMRP.ToString();
                _sales.Add(sale);

                CheckReorderLevel(sale.ProductId,sale.Quantity);
                ShowAllSales();
            }
            else
            {
                int index = 0;
                foreach (var itemSale in _sales)
                {

                    if (itemSale.Code == codeTextBox.Text)
                    {
                        sale = _sales.ElementAt(index);
                        break;
                    }
                    index++;

                }

                sale.Date = saleDateTimePicker.Text;
                //sale.InvoiceNo = billNoTextBox.Text;
                sale.Code = codeTextBox.Text;
                sale.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
                sale.ProductId = Convert.ToInt32(productComboBox.SelectedValue);
                sale.Quantity = Convert.ToInt32(quantityTextBox.Text);
                sale.MRP = Convert.ToDouble(mrpTextBox.Text);
                sale.TotalMRP = Convert.ToDouble(totalMrpTextBox.Text);


                MessageBox.Show(@"Updated successfully");
                addSaleButton.Text = @"Add";

            }

            

            GrandTotal();
            ClearAllTextBox();
            ShowAllSales();
            GenerateSaleCodeBeforeSubmit();
        }

        public void CheckReorderLevel(int productId,int quantity)
        {
            int reorderLevel = _productManager.GetReorderLevelById(productId);
            int availableQuantity = AvailableQuantity(productId);

            if (availableQuantity-quantity < reorderLevel)
            {
                MessageBox.Show(@"Reorder level reached,Please purchase ! ", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ShowAllSales()
        {
            salesDataGridView.DataSource = null;
            salesDataGridView.DataSource = _sales;
        }

        private void salesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (salesDataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                MessageBox.Show("edit");

                try
                {
                    if (e.RowIndex >= 0)
                    {
                        if (salesDataGridView.CurrentRow != null) salesDataGridView.CurrentRow.Selected = true;

                        //public int Id { get; set; }1
                        //public string Date { get; set; }2
                        //public string Code { get; set; }3
                        //public int CustomerId { get; set; }4
                        //public int ProductId { get; set; }5
                        //public string Product { get; set; }6
                        //public int Quantity { get; set; }7
                        //public double MRP { get; set; }8
                        //public double TotalMRP { get; set; }9


                        //id
                        saleDateTimePicker.Text = salesDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                      
                        codeTextBox.Text = salesDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                        customerComboBox.SelectedValue = Convert.ToInt32(salesDataGridView.Rows[e.RowIndex].Cells[4].Value);

                        //product id
                        int id = Convert.ToInt32(salesDataGridView.Rows[e.RowIndex].Cells[5].Value);

                        //get category id by product id
                        int catId = _categoryManager.GetCategoryIdByProductId(id);

                        //set value to category combobox
                        categoryComboBox.SelectedValue = catId;

                        //set value to product combobox
                        productComboBox.SelectedValue = id;


                        
                        quantityTextBox.Text = salesDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                        mrpTextBox.Text = salesDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                        totalMrpTextBox.Text = salesDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();

                        //MessageBox.Show(Sl + "");


                        addSaleButton.Text = @"Update";

                        //Show();
                        ShowAllSales();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            if (salesDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show(@"Are you sure, you want to delete this record?", @"Message Box", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    codeTextBox.Text = salesDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int index = 0;
                    Sale sale1 = new Sale();

                    foreach (var itemSale in _sales)
                    {

                        if (itemSale.Code == codeTextBox.Text)
                        {
                            sale1 = _sales.ElementAt(index);
                            break;
                        }
                        index++;

                    }
                    _sales.Remove(sale1);
                    salesDataGridView.DataSource = null;
                    salesDataGridView.DataSource = _sales;

                    

                    // get next purchase code
                    GenerateSaleCodeBeforeSubmit();
                }


            }
        
    }

        public void GenerateSaleCodeBeforeSubmit()
        {
            if (_sales.Count > 0)
            {
                Sale ph = new Sale();
                ph = _sales.ElementAt(_sales.Count - 1);
                GenerateSaleCode(ph.Code);
            }
            else
            {
                 GenerateSaleCode(_salesManager.GetLastSaleCode());
            }
        }

        private void GenerateSaleCode(string lastSaleCode)
        {
            string code = "";

            string year = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            if (lastSaleCode == "")
            {
                code = year + "-0001";
            }
            else
            {
                string[] afterSplit = lastSaleCode.Split('-');

                string serialNo = afterSplit[afterSplit.Length - 1];
                int number = int.Parse(serialNo);
                code = year + "-" + (++number).ToString("D" + serialNo.Length);
            }

            codeTextBox.Text = code;

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryComboBoxErrorLabel.Text = "";
            int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.DataSource = _productManager.GetAllProductForComboBox(categoryId);
        }


        private void productComboBox_TextChanged(object sender, EventArgs e)
        {
            productComboBoxErrorLabel.Text = "";
            addSaleButton.Enabled=true;
            bool notExist = true;
            int productId = Convert.ToInt32(productComboBox.SelectedValue);

            int availableQuantity = AvailableQuantity(productId);

            if (productId > 0 && availableQuantity ==0)
            {
                MessageBox.Show(@"Product is not available ( 0 quantity )", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                notExist = false;
                availableQuantityTextBox.Text = "";
                mrpTextBox.Text = "";
                addSaleButton.Enabled = false;
            }

            foreach (var itemSale in _sales)
            {
                if (itemSale.ProductId == productId)
                {
                    MessageBox.Show(@"Selected product already added",@"Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    //productComboBoxErrorLabel.Text = @"Already exist";
                    notExist = false;
                    addSaleButton.Enabled = false;
                    break;
                }

            }
            if (productId > 0 && notExist)
            {
                //MessageBox.Show("purchase      " + totalPurchaseQuantity.ToString());
                //MessageBox.Show("Sale        " + totalSaleQuantity.ToString());
                availableQuantityTextBox.Text = availableQuantity.ToString();


                Purchase purchase=new Purchase();

                purchase = _purchaseManager.GetLastPurchasesProductInfoById(productId);

                mrpTextBox.Text = purchase.MRP.ToString();

            }

        }

        private int AvailableQuantity(int productId)
        {
            int totalPurchaseQuantity = _purchaseManager.GetTotalProductById(productId);
            int totalSaleQuantity = _salesManager.GetTotalProductById(productId);

            int availableQuantity = totalPurchaseQuantity - totalSaleQuantity;
            return availableQuantity;
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerComboBoxErrorLabel.Text = "";

            //loyaltyPoint =
            loyaltyPointTextBox.Text= _customerManager.GetCustomerLoyaltyPointById(Convert.ToInt32(customerComboBox.SelectedValue)).ToString();
                //loyaltyPointTextBox.Text = loyaltyPoint.ToString();
            if (Convert.ToInt32(customerComboBox.SelectedValue)>0)
            {
                customerComboBox.Enabled = false;
            }
           
        }
        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            quatityErrorLabel.Text = "";
            if (mrpTextBox.TextLength > 0 && quantityTextBox.Text.Length > 0)
            {
                totalMrpTextBox.Text =
                    (Convert.ToInt32(quantityTextBox.Text) * Convert.ToDouble(mrpTextBox.Text)).ToString();
            }
            else
            {
                totalMrpTextBox.Text = "0";
            }



        }

        private void mrpTextBox_TextChanged(object sender, EventArgs e)
        {
            quatityErrorLabel.Text = "";
            if (mrpTextBox.TextLength > 0 && quantityTextBox.Text.Length > 0)
            {
                totalMrpTextBox.Text =
                    (Convert.ToInt32(quantityTextBox.Text) * Convert.ToDouble(mrpTextBox.Text)).ToString();
            }
            else
            {
                totalMrpTextBox.Text = "0";
            }
        }

        public void GrandTotal()
        {
            double grandTotal = 0;
            foreach (var itemSale in _sales)
            {
                grandTotal += itemSale.TotalMRP;

            }

            grandtotalTextBox.Text = grandTotal.ToString();
            int loyaltyPoint =
               Convert.ToInt32( _customerManager.GetCustomerLoyaltyPointById(Convert.ToInt32(customerComboBox.SelectedValue)));
            
            int discountPercentage =loyaltyPoint / 10;
            discountTextbox.Text = discountPercentage.ToString();

            discountAmountTextBox.Text = (grandTotal * discountPercentage/100).ToString();

            payableAmountTextBox.Text = (grandTotal - Convert.ToInt32(discountAmountTextBox.Text)).ToString();



        }
        public void ClearAllErrorLabel()
        {

          
            customerComboBoxErrorLabel.Text = "";
            productComboBoxErrorLabel.Text = "";
            quatityErrorLabel.Text = "";
            categoryComboBoxErrorLabel.Text = "";
            mrpErrorLabel.Text = "";
        }

        public void ClearAllTextBox()
        {
            saleDateTimePicker.CustomFormat = "yyyy-MM-dd";
            //customerComboBox.SelectedValue = 0;
            categoryComboBox.SelectedValue = 0;
            productComboBox.SelectedValue = 0;
            codeTextBox.Clear();
            quantityTextBox.Clear();
            totalMrpTextBox.Clear();
            availableQuantityTextBox.Clear();
            mrpTextBox.Clear();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(@"Are you sure, you want to submit and save all this record?", @"Message Box", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (_salesManager.AddSale(_sales))
                    {

                        salesDataGridView.DataSource = null;
                        MessageBox.Show(@"Saved SuccessFully", @"Message Box", MessageBoxButtons.OK);
                        _sales.Clear();
                        //get next purchase code
                        GenerateSaleCodeBeforeSubmit();
                    }
                    else
                    {
                        MessageBox.Show(@"Not saved", @"Message Box", MessageBoxButtons.OK);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        private void salesDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.salesDataGridView.Rows[e.RowIndex].Cells["Sl"].Value = (e.RowIndex + 1).ToString();
        }

        private void quantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                quatityErrorLabel.Text = @"Only numeric value !";
                return;
            }
        }

        private void mrpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                mrpErrorLabel.Text = @"Only numeric value !";
;               return;
            }
        }

    }
}
