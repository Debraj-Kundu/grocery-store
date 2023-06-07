using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
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
    public class ProductController : ControllerBase
    {
        public IProductService ProductService { get; }
        public ICategoryService CategoryService { get; }
        public IMapper Mapper { get; }

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            ProductService = productService;
            CategoryService = categoryService;
            Mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var result = await ProductService.GetAllProducts();
            var products = Mapper.Map<IEnumerable<ProductDto>>(result.Data);
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var result = await ProductService.GetProductById(id);
            if (result.IsSuccess == false ||  result.Data == null)
                return NotFound();
            var product = Mapper.Map<ProductDto>(result.Data);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post(ProductDto product)
        {
            var res = await CategoryService.GetCategoryByName("Biscuit");
            ProductDomain productToCreate = Mapper.Map<ProductDomain>(product);
            //productToCreate.Category = res.Data;
            var result = await ProductService.CreateProduct(productToCreate);
            if(result.IsSuccess)
                return Created(nameof(Post), product);
            return BadRequest();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
