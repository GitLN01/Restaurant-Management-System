using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerBusiness
    {
        private readonly CustomerRepository customerRepository;

        public CustomerBusiness()
        {
            this.customerRepository = new CustomerRepository();
        }

        public List<Customers> GetAllCustomers()
        {
            return this.customerRepository.GetAllCustomers();
        }

        public bool ExistsCustomerWithEmail(string email)
        {
            return this.customerRepository.GetAllCustomers().Where(customer => customer.email == email).Any();
        }

        public Customers GetCustomerByEmail(string email)
        {
            return this.customerRepository.GetAllCustomers().Where(customer => customer.email == email).First();
        }

        public bool InsertCustomers(Customers c)
        {
            if (this.customerRepository.InsertCustomers(c) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
