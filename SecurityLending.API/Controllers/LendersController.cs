using SecurityLending.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SecurityLending.services.abstraction;


namespace SecurityLending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendersController : ControllerBase ,ICustomerController<Lender>
    {
        private readonly ICustomersService<Lender> service;
        public LendersController(ICustomersService<Lender> lendersService) 
            => this.service = lendersService;

        [HttpGet("name/{name}/currency/{currency}")]
        public IEnumerable<Lender> Get(string name, string currency)
             => service.FindCustomers(name, currency);

        [HttpGet("name/{name}")]
        public IEnumerable<Lender> GetByName(string name)
            => service.FindCustomers(name, "");

        [HttpGet("currency/{currency}")]
        public IEnumerable<Lender> GetByCurrency(string currency)
            => service.FindCustomers("", currency);

        [HttpGet("{id}")]
        public Lender Get(int id) => service.FindCustomerById(id);

        [HttpPost]
        public bool Post([FromBody] Lender newLender) 
            => service.CreateNewCustomer(newLender);


    }
}
