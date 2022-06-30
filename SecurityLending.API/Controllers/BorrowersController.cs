using SecurityLending.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SecurityLending.services.abstraction;


namespace SecurityLending.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowersController : ControllerBase, ICustomerController<Borrower>
    {
        private readonly ICustomersService<Borrower> service;

        public BorrowersController(ICustomersService<Borrower> borrowerssService) => this.service = borrowerssService;

        [HttpGet("name/{name}/currency/{currency}")]
        public IEnumerable<Borrower> Get(string name, string currency) 
            => service.FindCustomers(name, currency);

        [HttpGet("name/{name}")]
        public IEnumerable<Borrower> GetByName(string name) 
            => service.FindCustomers(name, "");

        [HttpGet("currency/{currency}")]
        public IEnumerable<Borrower> GetByCurrency(string currency) 
            => service.FindCustomers("", currency);

        [HttpGet("{id}")]
        public Borrower Get(int id) 
            => service.FindCustomerById(id);

        [HttpPost]
        public bool Post([FromBody] Borrower value)
            => service.CreateNewCustomer(value);
    }
}
