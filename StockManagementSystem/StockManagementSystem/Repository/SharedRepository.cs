using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.Repository
{
    public class SharedRepository
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        PurchaseManager _purchaseManager=new PurchaseManager();
        SalesManager _salesManager=new SalesManager();

        public List<PurchaseReportViewModel> GetPurchaseReport()
        {
            List<PurchaseReportViewModel> purchaseReportViewModels = new List<PurchaseReportViewModel>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT p.Id, p.Code AS Code,p.Name AS Name ,c.Name AS Category,SUM(pur.Quantity) AS AvailableQty,SUM(pur.TotalPrice) AS CP ,SUM(MRP*pur.Quantity) AS MRP,SUM(MRP*pur.Quantity-pur.TotalPrice) AS Profit 
 FROM Purchases AS pur LEFT JOIN Products AS p ON p.Id=pur.ProductId 
 LEFT JOIN Categories AS c ON p.CategoryId=c.Id GROUP BY p.Id, p.Code,p.Name,c.Name ORDER BY p.Code";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


                while (sqlDataReader.Read())
                {
                    int productId = Convert.ToInt32(sqlDataReader["Id"]);
                    int purchaseQuantity = _purchaseManager.GetTotalProductById(productId);
                    int salesQuantity = _salesManager.GetTotalProductById(productId);

                    

                    PurchaseReportViewModel model = new PurchaseReportViewModel();
                    model.Code = sqlDataReader["Code"].ToString();
                    model.Name = sqlDataReader["Name"].ToString();
                    model.Category= sqlDataReader["Category"].ToString();
                    //model.AvailableQty = Convert.ToInt32(sqlDataReader["AvailableQty"]);
                    model.AvailableQty = purchaseQuantity - salesQuantity;
                    model.CP = Convert.ToDouble(sqlDataReader["CP"]);
                    model.MRP = Convert.ToDouble(sqlDataReader["MRP"]);
                    model.Profit = Convert.ToDouble(sqlDataReader["Profit"]);
                    purchaseReportViewModels.Add(model);
                }
            }

            return purchaseReportViewModels;

        }
        public List<PurchaseReportViewModel> SearchPurchaseReportByDate(string startDate, string endDate)
        {
            List<PurchaseReportViewModel> purchaseReportViewModels = new List<PurchaseReportViewModel>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT p.Id, p.Code AS Code,p.Name AS Name ,c.Name AS Category,SUM(pur.Quantity) AS AvailableQty,SUM(pur.TotalPrice) AS CP ,SUM(MRP*pur.Quantity) AS MRP,SUM(MRP*pur.Quantity-pur.TotalPrice) AS Profit 
 FROM Purchases AS pur LEFT JOIN Products AS p ON p.Id=pur.ProductId 
 LEFT JOIN Categories AS c ON p.CategoryId=c.Id WHERE pur.Date BETWEEN '" + startDate+"' AND '"+endDate+"'  GROUP BY p.Id, p.Code,p.Name,c.Name ORDER BY p.Code";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


                while (sqlDataReader.Read())
                {
                    int productId = Convert.ToInt32(sqlDataReader["Id"]);
                    int purchaseQuantity = _purchaseManager.GetTotalProductById(productId);
                    int salesQuantity = _salesManager.GetTotalProductById(productId);

                    PurchaseReportViewModel model = new PurchaseReportViewModel();
                    model.Code = sqlDataReader["Code"].ToString();
                    model.Name = sqlDataReader["Name"].ToString();
                    model.Category = sqlDataReader["Category"].ToString();
                    //model.AvailableQty = Convert.ToInt32(sqlDataReader["AvailableQty"]);
                    model.AvailableQty = purchaseQuantity - salesQuantity;
                    model.CP = Convert.ToDouble(sqlDataReader["CP"]);
                    model.MRP = Convert.ToDouble(sqlDataReader["MRP"]);
                    model.Profit = Convert.ToDouble(sqlDataReader["Profit"]);
                    purchaseReportViewModels.Add(model);
                }
            }

            return purchaseReportViewModels;

        }


        public List<SalesReportViewModel> GetSalesReport()
        {
            List<SalesReportViewModel> salesReportViewModels = new List<SalesReportViewModel>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT p.Id, p.Code AS Code,p.Name AS Name ,c.Name AS Category,SUM(s.Quantity) AS SoldQty ,SUM(MRP*s.Quantity) AS SalesPrice
                 FROM Sales AS s LEFT JOIN Products AS p ON p.Id=s.ProductId 
                 LEFT JOIN Categories AS c ON p.CategoryId=c.Id  GROUP BY p.Id, p.Code,p.Name,c.Name ORDER BY p.Code";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


                while (sqlDataReader.Read())
                {
                    int productId = Convert.ToInt32(sqlDataReader["Id"]);
                    Purchase purchase=new Purchase();
                    purchase = _purchaseManager.GetLastPurchasesProductInfoById(productId);
                    


                    SalesReportViewModel model = new SalesReportViewModel();
                    model.Code = sqlDataReader["Code"].ToString();
                    model.Name = sqlDataReader["Name"].ToString();
                    model.Category = sqlDataReader["Category"].ToString();
                    model.SoldQty = Convert.ToInt32(sqlDataReader["SoldQty"]);
                    // model.CP = Convert.ToDouble(sqlDataReader["CP"]);
                    model.CP = model.SoldQty * purchase.UnitPrice;
                    model.SalesPrice = Convert.ToDouble(sqlDataReader["SalesPrice"]);
                    // model.Profit = Convert.ToDouble(sqlDataReader["Profit"]);
                    model.Profit = model.SalesPrice - model.CP;
                    salesReportViewModels.Add(model);
                }
            }

            return salesReportViewModels;
        }

        public List<SalesReportViewModel> SearchSalesReportByDate(string startDate, string endDate)
        {

            List<SalesReportViewModel> salesReportViewModels = new List<SalesReportViewModel>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT p.Id, p.Code AS Code,p.Name AS Name ,c.Name AS Category,SUM(s.Quantity) AS SoldQty ,SUM(MRP*s.Quantity) AS SalesPrice
                 FROM Sales AS s LEFT JOIN Products AS p ON p.Id=s.ProductId 
                 LEFT JOIN Categories AS c ON p.CategoryId=c.Id WHERE s.Date BETWEEN '" + startDate + "' AND '" + endDate + "'  GROUP BY p.Id, p.Code,p.Name,c.Name ORDER BY p.Code";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


                while (sqlDataReader.Read())
                {
                    int productId = Convert.ToInt32(sqlDataReader["Id"]);
                    Purchase purchase = new Purchase();
                    purchase = _purchaseManager.GetLastPurchasesProductInfoById(productId);



                    SalesReportViewModel model = new SalesReportViewModel();
                    model.Code = sqlDataReader["Code"].ToString();
                    model.Name = sqlDataReader["Name"].ToString();
                    model.Category = sqlDataReader["Category"].ToString();
                    model.SoldQty = Convert.ToInt32(sqlDataReader["SoldQty"]);
                    // model.CP = Convert.ToDouble(sqlDataReader["CP"]);
                    model.CP = model.SoldQty * purchase.UnitPrice;
                    model.SalesPrice = Convert.ToDouble(sqlDataReader["SalesPrice"]);
                    // model.Profit = Convert.ToDouble(sqlDataReader["Profit"]);
                    model.Profit = model.SalesPrice - model.CP;
                    salesReportViewModels.Add(model);
                }
            }

            return salesReportViewModels;
        }


    }
}
