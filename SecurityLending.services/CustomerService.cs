using SecurityLenders.DAL.abstraction;
using SecurityLending.models;
using SecurityLending.services.abstraction;
using System;
using System.Collections.Generic;

namespace SecurityLending.services
{
    public class CustomerService<T> : ICustomersService<T> where T : Customer
    {
        private readonly ICustomerRepository<T> repository;

        public CustomerService(ICustomerRepository<T> repository) => this.repository = repository;

        public bool CreateNewCustomer(T newCustomer)
        {
            if (newCustomer.Name.Trim().Length <= 0)
                throw new Exception($"InCorrect input, field: {nameof(newCustomer.Name)}");

            if (newCustomer.Currency.Trim().Length != 3)
                throw new Exception($"InCorrect input, field: {nameof(newCustomer.Currency)}");
            try
            {
                var res = repository.Create(newCustomer);
                return res > 0;
            }
            catch { return false; }
        }

        public T FindCustomerById(int id)
        {
            return repository.SearchOne(id);
        }

        public IEnumerable<T> FindCustomers(string name, string currency)
        {
            return repository.Search(name, currency);
        }
    }
}
