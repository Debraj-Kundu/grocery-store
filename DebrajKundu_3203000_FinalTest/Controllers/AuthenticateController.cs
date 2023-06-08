using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.WebAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public ICustomerService CustomerService { get; }
        public IMapper Mapper { get; }

        public AuthenticateController(ICustomerService customerService, IMapper mapper)
        {
            CustomerService = customerService;
            Mapper = mapper;
        }


        [HttpGet("auth")]
        public IActionResult Authenticate()
        {
            return Ok();
        }

        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            var result = await CustomerService.GetAllCustomers();
            var products = Mapper.Map<IEnumerable<CustomerDto>>(result.Data);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Post(CustomerDto customer)
        {
            CustomerDomain customerToCreate = Mapper.Map<CustomerDomain>(customer);
            var result = await CustomerService.CreateCustomer(customerToCreate);
            if (result.IsSuccess)
                return Created(nameof(Post), customer);
            return BadRequest();
        }
    }
}
