using SecurityLenders.DAL.abstraction;
using SecurityLending.models;
using System;
using System.Collections.Generic;

namespace SecurityLending.DAL
{
    public class CustomerRepository<T> : ICustomerRepository<T> where T : Customer
    {
        private readonly ISecurityLendingDbContext<T> context;

        public CustomerRepository(ISecurityLendingDbContext<T> context) 
            => this.context = context;

        public int Create(T newCustomer)
        {
            context.List.Add(newCustomer);
            return context.SaveChanges();
        }

        public IEnumerable<T> Search(string name, string currency) 
            => context.List.Filter(name, currency);

        public T SearchOne(int id) => context.List.Find(id);
    }
}
