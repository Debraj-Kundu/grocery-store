using AutoMapper;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.WebAPI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopOrderController : ControllerBase
    {

        public ITopOrderService TopOrderService { get; }
        public IMapper Mapper { get; }

        public TopOrderController(ITopOrderService topOrderService, IMapper mapper)
        {
            TopOrderService = topOrderService;
            Mapper = mapper;
        }

        

        // GET api/<TopOrderController>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopOrderDto>>> Get(int top, int month, int year)
        {
            if (top == default(int))
                top = 5;
            if (month == default(int))
                month = DateTimeOffset.UtcNow.Month;
            if (year == default(int))
                year = DateTimeOffset.UtcNow.Year;
            var result = await TopOrderService.GetTopProducts(top, month, year);
            var topOrders = Mapper.Map<IEnumerable<TopOrderDto>>(result.Data);
            return Ok(topOrders);
        }

        // POST api/<TopOrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TopOrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TopOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
