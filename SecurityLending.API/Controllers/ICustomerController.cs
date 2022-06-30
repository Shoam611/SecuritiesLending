using Microsoft.AspNetCore.Mvc;
using SecurityLending.models;
using System.Collections.Generic;

namespace SecurityLending.API.Controllers
{
    public interface ICustomerController<T> where T :Customer
    {
        T Get(int id);
        IEnumerable<T> Get(string name, string currency);
        IEnumerable<T> GetByCurrency(string currency);
        IEnumerable<T> GetByName(string name);
        bool Post([FromBody] T value);
    }
}