using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Repository
{
    public class CustomerRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public bool AddCustomer(Customer customer)
        {
            bool isAdded = false;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"INSERT INTO Customers VALUES('" + customer.Code + "','" + customer.Name + "','" + customer.Address + "','" + customer.Email + "','" + customer.Contact + "'," + customer.LoyaltyPoint + ")";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);

                //open connection
                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();

                //close connection
                sqlConnection.Close();

                if (isExecuted > 0)
                {
                    isAdded = true;
                }
            }

            return isAdded;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool isUpdated = false;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"UPDATE Customers SET Code='" + customer.Code + "',Name='" + customer.Name + "',Address='" + customer.Address + "',Email='" + customer.Email + "',Contact='" + customer.Contact + "',LoyaltyPoint=" + customer.LoyaltyPoint + " WHERE Id=" + customer.Id + " ";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);

                //open connection
                sqlConnection.Open();

                int isExecuted = sqlCommand.ExecuteNonQuery();

                //close connection
                sqlConnection.Close();

                if (isExecuted > 0)
                {
                    isUpdated = true;
                }
            }

            return isUpdated;
        }
        //Unique Contact
        public bool UniqueContact(Customer customer)
        {
            bool exists = false;

            //Connection

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                //Command 
                string commandString = @"SELECT * FROM customers  WHERE Contact = '" + customer.Contact + "'  AND Id !=" + customer.Id + " ";
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
        //Unique Email
        public bool UniqueEmail(Customer customer)
        {
            bool exists = false;

            //Connection
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                //Command 
                string commandString = @"SELECT * FROM Customers  WHERE Email = '" + customer.Email + "'  AND Id !=" + customer.Id + " ";
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
        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT * FROM Customers";
                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConnection);

                //open connection
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Customer customer = new Customer();

                    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    customer.Code = sqlDataReader["Code"].ToString();
                    customer.Name = sqlDataReader["Name"].ToString();
                    customer.Address = sqlDataReader["Address"].ToString();
                    customer.Email = sqlDataReader["Email"].ToString();
                    customer.Contact = sqlDataReader["Contact"].ToString();
                    customer.LoyaltyPoint = Convert.ToInt32(sqlDataReader["LoyaltyPoint"]);
                    customers.Add(customer);

                }

                //close connection
                sqlConnection.Close();

                return customers;
            }
        }
        public List<Customer> SearchCustomer(string name, string email, string contact)
        {
            List<Customer> customers = new List<Customer>();
            string commandString = "";
            //Connection
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {

                //Command 
                if (!String.IsNullOrEmpty(name))
                {
                    commandString = @"SELECT * FROM Customers  WHERE Name = '" + name + "'";
                }
                if (!String.IsNullOrEmpty(email))
                {
                    commandString = @"SELECT * FROM Customers  WHERE Email = '" + email + "'";
                }
                if (!String.IsNullOrEmpty(contact))
                {
                    commandString = @"SELECT * FROM Customers  WHERE Contact = '" + contact + "'";
                }


                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    customer.Code = sqlDataReader["Code"].ToString();
                    customer.Name = sqlDataReader["Name"].ToString();
                    customer.Address = sqlDataReader["Address"].ToString();
                    customer.Email = sqlDataReader["Email"].ToString();
                    customer.Contact = sqlDataReader["Contact"].ToString();
                    customer.LoyaltyPoint = Convert.ToDouble(sqlDataReader["LoyaltyPoint"]);
                    customers.Add(customer);
                }
                //Close
                sqlConnection.Close();
            }
            return customers;
        }
        public List<Customer> GetAllCustomerForComboBox()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT Id,Name FROM Customers";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Customer customer1 = new Customer()
                {
                    Id = 0,
                    Name = "--Select--"
                };
                customers.Add(customer1);

                while (sqlDataReader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    customer.Name = sqlDataReader["Name"].ToString();
                    customers.Add(customer);
                }
            }

            return customers;

        }

        public double GetCustomerLoyaltyPointById(int id)
        {
            double point = 0;

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT LoyaltyPoint FROM Customers WHERE  Id = " + id + " ";
                SqlCommand sqlCmd = new SqlCommand(queryString, sqlConnection);

                //open connection
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    point = Convert.ToDouble(sqlDataReader["LoyaltyPoint"]);

                }

                //close connection
                sqlConnection.Close();
            }

            return point;
        }
        public string GetLastCustomerCode()
        {
            string code = "";
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                string queryString = @"SELECT Code FROM Customers ORDER BY Id DESC ";
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
    }
}