using SecurityLending.models;
using System.Collections.Generic;



namespace SecurityLending.services.abstraction
{
    public interface ICustomersService<T> where T : Customer
    {
        //Create
        public bool CreateNewCustomer(T newCustomer);
        //public bool CreateNewCustomer(string name, string currency, int count, bool interested);
        //Read
        public T FindCustomerById(int id);

        public IEnumerable<T> FindCustomers(string name,string currency);
    }
}
