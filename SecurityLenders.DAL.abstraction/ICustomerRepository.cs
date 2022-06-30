using SecurityLending.models;
using System.Collections.Generic;

namespace SecurityLenders.DAL.abstraction
{
    public interface ICustomerRepository<T> where T : Customer
    {
        public int Create(T newCustomer);
        public T SearchOne(int id);
        public IEnumerable<T> Search(string name, string currency);
    }
}
