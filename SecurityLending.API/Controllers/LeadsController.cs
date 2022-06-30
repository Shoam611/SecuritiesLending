using Microsoft.AspNetCore.Mvc;
using SecurityLending.models;
using SecurityLending.services.abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecurityLending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase, ICustomerController<Lead>
    {
        private readonly ICustomersService<Lead> service;

        public LeadsController(ICustomersService<Lead> leadsService) 
            => this.service = leadsService;
       
        [HttpGet("name/{name}/currency/{currency}")]
        public IEnumerable<Lead> Get(string name, string currency) 
            => service.FindCustomers(name, currency);

        [HttpGet("name/{name}")]
        public IEnumerable<Lead> GetByName(string name) 
            => service.FindCustomers(name, "");

        [HttpGet("currency/{currency}")]
        public IEnumerable<Lead> GetByCurrency(string currency) 
            => service.FindCustomers("", currency);
        
        [HttpGet("{id}")]
        public Lead Get(int id) => service.FindCustomerById(id);
       
        [HttpPost]
        public bool Post([FromBody] Lead value) 
            => service.CreateNewCustomer(value);

    }
}
