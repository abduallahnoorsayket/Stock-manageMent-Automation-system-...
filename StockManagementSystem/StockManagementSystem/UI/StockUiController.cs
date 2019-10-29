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

namespace StockManagementSystem.UI
{
    public partial class StockUiController : UserControl
    {
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        SharedManager  _sharedManager=new SharedManager();
        public StockUiController()
        {
            InitializeComponent();
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.DataSource = _categoryManager.GetAllCategoryForComboBox();

            //int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            //productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //productComboBox.DataSource = _productManager.GetAllProductForComboBox(categoryId);

        }

        private void StockUiController_Load(object sender, EventArgs e)
        {
            categoryComboboxerrorLabel.Text = "";
            productComboBoxErrorLabel.Text = "";


        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryComboboxerrorLabel.Text = "";
            int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue);

            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.DataSource = _productManager.GetAllProductForComboBox(categoryId);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(categoryComboBox.SelectedValue) == 0)
            {
                categoryComboboxerrorLabel.Text = @"Select a category !";
                categoryComboBox.Focus();
                return;
            }

            if (Convert.ToInt32(productComboBox.SelectedValue) == 0)
            {
                productComboBoxErrorLabel.Text = @"Select a product";
                productComboBox.Focus();
                return;
            }
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productComboBoxErrorLabel.Text = "";
        }
    }
}
