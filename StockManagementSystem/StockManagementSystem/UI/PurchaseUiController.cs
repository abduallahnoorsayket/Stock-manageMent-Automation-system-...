using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class PurchaseUiController : UserControl
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        SupplierManager _supplierManager = new SupplierManager();
        public List<Purchase> _purchases = new List<Purchase>();
        //private AddPurchaseUi addPurchaseUi=new AddPurchaseUi(this);
        public PurchaseUiController()
        {
            InitializeComponent();
            string lastPurchaseCode = _purchaseManager.GetLastPurchaseCode();
            GeneratePurchaseCode(lastPurchaseCode);
        }
        private void PurchaseUiController_Load(object sender, EventArgs e)
        {
            //AddPurchaseUi addPurchaseUi2=new AddPurchaseUi(this);
            //addPurchaseUi = addPurchaseUi2;
        }

        private void addPurchaseButton_Click(object sender, EventArgs e)
        {
            AddPurchaseUi addPurchaseUi=new AddPurchaseUi(this);
            addPurchaseUi.Show();
        }

        private void purchaseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddPurchaseUi addPurchaseUi = new AddPurchaseUi(this);
            if (purchaseDataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                MessageBox.Show("edit");

                try
                {
                    if (e.RowIndex >= 0)
                    {
                        if (purchaseDataGridView.CurrentRow != null) purchaseDataGridView.CurrentRow.Selected = true;

                        //id
                        addPurchaseUi.purchaseDateTimePicker.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        addPurchaseUi.billNoTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();

                        addPurchaseUi.supplierComboBox.SelectedValue = Convert.ToInt32(purchaseDataGridView.Rows[e.RowIndex].Cells[4].Value);

                        //product id
                        int id = Convert.ToInt32(purchaseDataGridView.Rows[e.RowIndex].Cells[5].Value);

                        //get category id by product id
                        int catId = _categoryManager.GetCategoryIdByProductId(id);

                        //set value to category combobox
                        addPurchaseUi.categoryComboBox.SelectedValue = catId;

                        //set value to product combobox
                        addPurchaseUi.productComboBox.SelectedValue = id;


                        addPurchaseUi.codeTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                        addPurchaseUi.manufacturedDateTimePicker.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                        addPurchaseUi.expireDateTimePicker.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                        addPurchaseUi.quantityTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                        addPurchaseUi.unitPriceTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                        addPurchaseUi.totalPriceTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
                        addPurchaseUi.mrpTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
                        addPurchaseUi.remarksTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[13].Value.ToString();
                        //MessageBox.Show(Sl + "");


                        addPurchaseUi.addButton.Text = @"Update";

                        addPurchaseUi.Show();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            if (purchaseDataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show(@"Are you sure, you want to delete this record?", @"Message Box", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    addPurchaseUi.codeTextBox.Text = purchaseDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                    int index = 0;
                    Purchase purchase1 = new Purchase();

                    foreach (var itemPurchase in _purchases)
                    {

                        if (itemPurchase.Code == addPurchaseUi.codeTextBox.Text)
                        {
                            purchase1 = _purchases.ElementAt(index);
                            break;
                        }
                        index++;

                    }
                    _purchases.Remove(purchase1);
                    purchaseDataGridView.DataSource = null;
                    purchaseDataGridView.DataSource = _purchases;

                    addPurchaseUi.ClearAllTextBox();

                    // get next purchase code
                    GeneratePurchaseCodeBeforeSubmit();
                }
                

            }
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
                    if (_purchaseManager.AddPurchase(_purchases))
                    {
                       
                        purchaseDataGridView.DataSource = null;
                        MessageBox.Show(@"Saved SuccessFully",@"Message Box",MessageBoxButtons.OK);
                        _purchases.Clear();
                        //get next purchase code
                        GeneratePurchaseCodeBeforeSubmit();
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
        public string GeneratePurchaseCodeBeforeSubmit()
        {
            if (_purchases.Count > 0)
            {
                Purchase ph = new Purchase();
                ph = _purchases.ElementAt(_purchases.Count - 1);
               return GeneratePurchaseCode(ph.Code);
            }
            else
            {
              return  GeneratePurchaseCode(_purchaseManager.GetLastPurchaseCode());
            }
        }
        private string GeneratePurchaseCode(string lastPurchaseCode)
        {
            string code = "";

            string year = DateTime.Parse(DateTime.Now.ToString()).Year.ToString();
            if (lastPurchaseCode == "")
            {
                code = year + "-0001";
            }
            else
            {
                string[] afterSplit = lastPurchaseCode.Split('-');

                string serialNo = afterSplit[afterSplit.Length - 1];
                int number = int.Parse(serialNo);
                code = year + "-" + (++number).ToString("D" + serialNo.Length);
            }
            //AddPurchaseUi addPurchaseUi2 = new AddPurchaseUi(this);
            //addPurchaseUi2.codeTextBox.Text = code;
            return code;

        }
        public void ShowAllPurchase()
        {
            purchaseDataGridView.DataSource = null;
            purchaseDataGridView.DataSource = _purchases;
        }

        private void purchaseDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.purchaseDataGridView.Rows[e.RowIndex].Cells["Sl"].Value = (e.RowIndex + 1).ToString();
        }

       
    }
}
