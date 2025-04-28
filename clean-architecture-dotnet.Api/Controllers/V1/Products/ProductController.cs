using clean_architecture_dotnet.Application.Services.Products.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Api.Controllers.V1.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAll();

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);

        }

        [HttpGet("GetProductById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetById(id);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);

        }

        [HttpPut("PutProduct")]
        [Authorize]
        public async Task<ActionResult<ProductViewModel>> Put([FromBody] ProductViewModel product)
        {
            var response = await _productService.Put(product);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("PostProduct")]
        [Authorize]
        public async Task<ActionResult<ProductViewModel>> Post([FromBody] ProductViewModel product)
        {
            var response = await _productService.Post(product);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("DeleteProduct/{productId:int}")]
        [Authorize]
        public async Task<ActionResult<ProductViewModel>> Delete([FromRoute] int productId)
        {
            var response = await _productService.Delete(productId);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
