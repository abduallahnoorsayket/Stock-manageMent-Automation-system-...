using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem.UI
{
    public partial class HomeUi : Form
    {
        public HomeUi()
        {
            InitializeComponent();
            activePanel.Height = homeButton.Height;
            activePanel.Top = homeButton.Top;

            HomeInfoUiController homeInfoUiController = new HomeInfoUiController();
            mainPanel.Controls.Clear();
            homeInfoUiController.Dock = DockStyle.Fill;
            homeInfoUiController.BringToFront();
            homeInfoUiController.Focus();
            mainPanel.Controls.Add(homeInfoUiController);

            timeLabel.Text = "";
            // timeLabel.Text= DateTime.Now.ToString("hh:mm:ss tt");
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show(@"Are you sure, you want to exit?", @"Message Box", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        #region Drag

        public const int WmNclbuttondown = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HT_CAPTION, 0);
            }
        }

        #endregion


        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = homeButton.Height;
            activePanel.Top = homeButton.Top;

            HomeInfoUiController homeInfoUiController = new HomeInfoUiController();
            mainPanel.Controls.Clear();
            homeInfoUiController.Dock = DockStyle.Fill;
            homeInfoUiController.BringToFront();
            homeInfoUiController.Focus();
            mainPanel.Controls.Add(homeInfoUiController);
        }

        private void categoryButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = categoryButton.Height;
            activePanel.Top = categoryButton.Top;

            CategoryUiController categoryUiController = new CategoryUiController();
            mainPanel.Controls.Clear();
            categoryUiController.Dock = DockStyle.Fill;
            categoryUiController.BringToFront();
            categoryUiController.Focus();
            mainPanel.Controls.Add(categoryUiController);

        }

        private void productButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = productButton.Height;
            activePanel.Top = productButton.Top;

            ProductUiController productUiController = new ProductUiController();
            mainPanel.Controls.Clear();
            productUiController.Dock = DockStyle.Fill;
            productUiController.BringToFront();
            productUiController.Focus();
            mainPanel.Controls.Add(productUiController);

        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = customerButton.Height;
            activePanel.Top = customerButton.Top;

            CustomerUiController customerUiController = new CustomerUiController();
            mainPanel.Controls.Clear();
            customerUiController.Dock = DockStyle.Fill;
            customerUiController.BringToFront();
            customerUiController.Focus();
            mainPanel.Controls.Add(customerUiController);
        }

        private void supplierButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = supplierButton.Height;
            activePanel.Top = supplierButton.Top;

            SupplierUiController supplierUiController = new SupplierUiController();
            mainPanel.Controls.Clear();
            supplierUiController.Dock = DockStyle.Fill;
            supplierUiController.BringToFront();
            supplierUiController.Focus();
            mainPanel.Controls.Add(supplierUiController);

        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = purchaseButton.Height;
            activePanel.Top = purchaseButton.Top;

           
            PurchaseUiController purchaseUiController = new PurchaseUiController();
            mainPanel.Controls.Clear();
            purchaseUiController.Dock = DockStyle.Fill;
            purchaseUiController.BringToFront();
            purchaseUiController.Focus();
            mainPanel.Controls.Add(purchaseUiController);

        }

        private void stockButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = stockButton.Height;
            activePanel.Top = stockButton.Top;


            StockUiController stockUiController = new StockUiController();
            mainPanel.Controls.Clear();
            stockUiController.Dock = DockStyle.Fill;
            stockUiController.BringToFront();
            stockUiController.Focus();
            mainPanel.Controls.Add(stockUiController);
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = reportButton.Height;
            activePanel.Top = reportButton.Top;


            ReportUiController reportUiController = new ReportUiController();
            mainPanel.Controls.Clear();
            reportUiController.Dock = DockStyle.Fill;
            reportUiController.BringToFront();
            reportUiController.Focus();
            mainPanel.Controls.Add(reportUiController);

            //ReportUi reportUi = new ReportUi();
            //reportUi.TopLevel = false;
            //mainPanel.Controls.Clear();
            //reportUi.Dock = DockStyle.Fill;
            //reportUi.BringToFront();
            //reportUi.Focus();
            //mainPanel.Controls.Add(reportUi);
        }

        private void saleButton_Click(object sender, EventArgs e)
        {
            activePanel.Height = saleButton.Height;
            activePanel.Top = saleButton.Top;


            SalesUiController salesUiController = new SalesUiController();
            mainPanel.Controls.Clear();
            salesUiController.Dock = DockStyle.Fill;
            salesUiController.BringToFront();
            salesUiController.Focus();
            mainPanel.Controls.Add(salesUiController);
        }
    }
}
