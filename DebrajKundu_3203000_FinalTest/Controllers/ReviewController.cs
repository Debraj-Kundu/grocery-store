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
    public class ReviewController : ControllerBase
    {

        public IReviewService ReviewService { get; }
        public IMapper Mapper { get; }

        public ReviewController(IReviewService productService,IMapper mapper)
        {
            ReviewService = productService;
            Mapper = mapper;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReviewController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReviewDto>> Post(ReviewDto review)
        {
            if (ModelState.IsValid)
            {
                review.CustomerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                review.Username = User.FindFirstValue(ClaimTypes.Name);
                ReviewDomain reviewToCreate = Mapper.Map<ReviewDomain>(review);
                var result = await ReviewService.SaveReview(reviewToCreate);
                if (result.IsSuccess)
                    return Created(nameof(Post), review);
            }
            return BadRequest();
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
