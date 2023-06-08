using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
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
    public class OrderController : ControllerBase
    {
        public IOrderService OrderService { get; }
        public IMapper Mapper { get; }

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            OrderService = orderService;
            Mapper = mapper;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get(int customerId)
        {
            var result = await OrderService.GetAllOrderByCustomer(customerId);
            var carts = Mapper.Map<IEnumerable<OrderDto>>(result.Data);
            return Ok(carts);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(OrderDto product)
        {
            OrderDomain corderProduct = Mapper.Map<OrderDomain>(product);
            var result = await OrderService.AddOrder(corderProduct);
            if (result.IsSuccess)
                return Created(nameof(Post), product);
            return BadRequest();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
