using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;
using System.Data.SqlClient;
using System.Data;

namespace StockManagementSystem.Repository
{
    public class PurchaseRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public Purchase GetLastPurchasesProductInfoById(int id)
        {
            Purchase purchase = new Purchase();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT * FROM Purchases WHERE ProductId=" + id+ " ORDER BY Id ";
                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConnection);

                //open connection
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();

                
                while (sqlDataReader.Read())
                {

                    purchase.Id =Convert.ToInt32(sqlDataReader["id"]);
                    purchase.Date = sqlDataReader["Date"].ToString();
                    purchase.InvoiceNo = sqlDataReader["InvoiceNo"].ToString();
                    purchase.SupplierId = Convert.ToInt32(sqlDataReader["SupplierId"]);
                    purchase.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
                    purchase.ManufacturedDate = sqlDataReader["ManufacturedDate"].ToString();
                    purchase.ExpireDate = sqlDataReader["ExpireDate"].ToString();
                    purchase.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    purchase.UnitPrice = Convert.ToDouble( sqlDataReader["UnitPrice"]);
                    purchase.TotalPrice = Convert.ToDouble( sqlDataReader["TotalPrice"]);
                    purchase.MRP = Convert.ToDouble(sqlDataReader["MRP"]);
                    purchase.Remarks = sqlDataReader["Remarks"].ToString();

                }

                //close connection
                sqlConnection.Close();
            }

            return purchase;
        }

        public bool UniquePurchaseCode(Purchase purchase)
        {
            bool exists = false;

            //Connection

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                //Command 
                string commandString = @"SELECT InvoiceNo FROM Purchases  WHERE InvoiceNo = '" + purchase.InvoiceNo + "'  ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                //showDataGridView.DataSource = dataTable;

                //Close
                sqlConnection.Close();
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                sqlConnection.Close();
            }
            return exists;
        }
        public bool AddPurchase(List<Purchase> purchases)
        {
            
            bool isAdded = false;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            { //open connection
                sqlConnection.Open();
                foreach (var purchase in purchases)
                {
                    string queryString = @"INSERT INTO Purchases VALUES('" + purchase.Date + "','" + purchase.InvoiceNo + "'," + purchase.SupplierId + "," + purchase.ProductId + ",'" + purchase.Code + "','" + purchase.ManufacturedDate + "','" + purchase.ExpireDate + "'," + purchase.Quantity + "," + purchase.UnitPrice + "," + purchase.TotalPrice + "," + purchase.MRP + ",'" + purchase.Remarks + "');";
                    SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);


                    int isExecuted = sqlCommand.ExecuteNonQuery();

                    
                    if (isExecuted > 0)
                    {
                        isAdded = true;
                    }
                }
                //close connection
                sqlConnection.Close();

            }

            return isAdded;
        }

        public string GetLastPurchaseCode()
        {
            string code = "";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT Code FROM Purchases ORDER BY Id DESC ";
                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConnection);

                //open connection
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    code = sqlDataReader["Code"].ToString();
                    break;
                }

                //close connection
                sqlConnection.Close();

            }

            return code;
        }

        public int GetTotalProductById(int id)
        {
            int totalQuantity = 0;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT p.MRP,SUM(p.Quantity) AS TotalQuantity FROM Purchases as p where p.ProductId="+id+" Group by p.ProductId,p.MRP ";
                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConnection);

                //open connection
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        totalQuantity = Convert.ToInt32(sqlDataReader["TotalQuantity"]);
                        break;
                    }
                }
               

                //close connection
                sqlConnection.Close();

            }

            return totalQuantity;

        }

    }
}
