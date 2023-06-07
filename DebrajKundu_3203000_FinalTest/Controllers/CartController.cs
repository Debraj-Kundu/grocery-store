using AutoMapper;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ICartService CartService { get; }
        public IMapper Mapper { get; }

        public CartController(ICartService cartService, IMapper mapper)
        {
            CartService = cartService;
            Mapper = mapper;
        }

        // GET: api/<CartController>
        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<IEnumerable<CustomerCartDto>>> Get(int customerId)
        {
            var result = await CartService.GetCartByCustomer(customerId);
            var carts = Mapper.Map<IEnumerable<CustomerCartDto>>(result.Data);
            return Ok(carts);
        }

        // GET api/<CartController>/5
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
