using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [HttpGet("/api/[controller]/[action]/{id}")]
        public async Task<ActionResult<CustomerCartDto>> GetById(int id)
        {
            var result = await CartService.GetCartItemById(id);
            if (result.IsSuccess == false || result.Data == null)
                return NotFound();
            var product = Mapper.Map<CustomerCartDto>(result.Data);
            return Ok(product);
        }

        // POST api/<CartController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductDto>> Post(CustomerCartDto product)
        {
            product.CustomerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            CustomerCartDomain cartProduct = Mapper.Map<CustomerCartDomain>(product);
            var result = await CartService.AddCartProduct(cartProduct);
            if (result.IsSuccess)
                return Created(nameof(Post), product);
            return BadRequest();
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
