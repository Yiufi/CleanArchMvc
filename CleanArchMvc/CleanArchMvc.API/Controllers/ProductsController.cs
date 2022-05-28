using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();
            if (products == null)
            {
                return NotFound("Product not found");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProducts")]
        public async Task<ActionResult<ProductDTO>> GetById([FromRoute] int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]

        public async Task<ActionResult> Create([FromBody] ProductDTO productRequest)
        {
            if (productRequest == null) 
            {
                return BadRequest("Invalid Data");
            }

            await _productService.Add(productRequest);

            return new CreatedAtRouteResult("GetProducts", new { id = productRequest.Id }, productRequest);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Update([FromBody] ProductDTO productRequest, int id)
        {
            if (id != productRequest.Id) 
            {
                return BadRequest();
            }

            if (productRequest == null)
            {
                return BadRequest("Invalid Data");
            }

            await _productService.Update(productRequest);

            return Ok(productRequest);

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            await _productService.Remove(id);

            return Ok(product);
        }

    }
}
