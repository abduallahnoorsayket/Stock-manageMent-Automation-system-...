using System.Collections.Generic;
using StockManagementSystem.Model;
using StockManagementSystem.Repository;

namespace StockManagementSystem.Manager
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository=new CustomerRepository();

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public bool UniqueContact(Customer customer)
        {
            return _customerRepository.UniqueContact(customer);
        }

        public bool UniqueEmail(Customer customer)
        {
            return _customerRepository.UniqueEmail(customer);
        }
        public List<Customer> GetAllCustomer()
        {
            return _customerRepository.GetAllCustomer();
        }

        public List<Customer> GetAllCustomerForComboBox()
        {
            return _customerRepository.GetAllCustomerForComboBox();
        }

        public double GetCustomerLoyaltyPointById(int id)
        {
            return _customerRepository.GetCustomerLoyaltyPointById(id);
        }
        public string GetLastCustomerCode()
        {
            return _customerRepository.GetLastCustomerCode();
        }

        public List<Customer> SearchCustomer(string name, string email, string contact)
        {
            return _customerRepository.SearchCustomer(name, email, contact);
        }

    }
}
