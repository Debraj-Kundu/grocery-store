using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.WebAPI.DTO;
using FinalTest.WebAPI.Service;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductController : ControllerBase
    {
        public IProductService ProductService { get; }
        public ICategoryService CategoryService { get; }
        public IMapper Mapper { get; }
        public IFileService FileService { get; }

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper, IFileService fileService)
        {
            ProductService = productService;
            CategoryService = categoryService;
            Mapper = mapper;
            FileService = fileService;
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var result = await ProductService.GetProductById(id);
            if (result.IsSuccess == false ||  result.Data == null)
                return NotFound();
            var product = Mapper.Map<ProductDto>(result.Data);
            return Ok(product);
        }

        // GET api/<ProductController>/abc
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get(string name)
        {
            var result = await ProductService.GetProductByParam(name);
            if (result.IsSuccess == false || result.Data == null)
                return NotFound();
            var product = Mapper.Map<IEnumerable<ProductDto>>(result.Data);
            return Ok(product);
        }

        // GET api/<ProductController>/<ActionMethod>/5
        [HttpGet("/api/[controller]/[action]/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategory(int categoryId)
        {
            var result = await ProductService.GetProductByCategory(categoryId);
            if (result.IsSuccess == false || result.Data == null)
                return NotFound();
            var product = Mapper.Map<IEnumerable<ProductDto>>(result.Data);
            return Ok(product);
        }


        // POST api/<ProductController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ProductDto>> Post([FromForm]ProductDto product)
        {
            if(ModelState.IsValid)
            { 
                if(product.ImageFile != null)
                {
                    var fileResult = FileService.SaveImage(product.ImageFile);
                    if(fileResult.Item1 == 1)
                    {
                        product.ProductImage = fileResult.Item2;
                    }
                }
                ProductDomain productToCreate = Mapper.Map<ProductDomain>(product);
                var result = await ProductService.CreateProduct(productToCreate);
                if(result.IsSuccess)
                    return Created(nameof(Post), product);
            }
            return BadRequest();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(int id, [FromForm]ProductDto product)
        {
            if(ModelState.IsValid)
            {
                if (product.ImageFile != null)
                {
                    var fileResult = FileService.SaveImage(product.ImageFile);
                    if (fileResult.Item1 == 1)
                    {
                        product.ProductImage = fileResult.Item2;
                    }
                }
                var productDomain = Mapper.Map<ProductDomain>(product);
                await ProductService.UpdateProduct(id, productDomain);
                return Created(nameof(Post), product);
            }
            return BadRequest();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await ProductService.RemoveProduct(id);
            if (result.IsSuccess)
                return Ok();
            return NotFound();
        }
    }
}
