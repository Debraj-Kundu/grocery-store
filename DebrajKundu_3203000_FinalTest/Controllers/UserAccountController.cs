using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.WebAPI.DTO;
using FinalTest.WebAPI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        public ICustomerService CustomerService { get; }
        public IMapper Mapper { get; }
        public JWTSetting JwtSetting { get; }

        public UserAccountController(ICustomerService customerService, IMapper mapper, IOptions<JWTSetting> options)
        {
            CustomerService = customerService;
            Mapper = mapper;
            JwtSetting = options.Value;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(CustomerLogin customer)
        {
            var result = await CustomerService.GetCustomerWithDetails(customer.Email, CommonMethods.Encrypt(customer.Password));
            if (result.Data == null)
                return Unauthorized();

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(JwtSetting.securitykey);
            var userClaims = new Claim[]{
                                new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                                new Claim(ClaimTypes.Name, result.Data.Name),
                                new Claim(ClaimTypes.Email, result.Data.Email),
                                new Claim(ClaimTypes.Role, result.Data.Role)
                            };
            var userIdentity = new ClaimsIdentity(userClaims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = userIdentity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            return Ok(new { token = finaltoken });
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            var result = await CustomerService.GetAllCustomers();
            var products = Mapper.Map<IEnumerable<CustomerDto>>(result.Data);
            return Ok(products);
        }

        [HttpPost("register")]
        public async Task<ActionResult<CustomerDto>> Post(CustomerDto customer)
        {
            customer.Password = CommonMethods.Encrypt(customer.Password);
            CustomerDomain customerToCreate = Mapper.Map<CustomerDomain>(customer);
            var result = await CustomerService.CreateCustomer(customerToCreate);
            if (result.IsSuccess)
                return Created(nameof(Post), customer);
            return BadRequest();
        }
    }
}
