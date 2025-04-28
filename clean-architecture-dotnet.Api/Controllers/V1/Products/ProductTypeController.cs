using clean_architecture_dotnet.Application.Services.Products;
using clean_architecture_dotnet.Application.Services.Products.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Api.Controllers.V1.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet("GetAllProductTypes")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productTypeService.GetAll();

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);

        }

        [HttpGet("GetProductTypeById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productTypeService.GetById(id);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);

        }

        [HttpPut("PutProductType")]
        [Authorize]
        public async Task<ActionResult<ProductTypeViewModel>> Put([FromBody] ProductTypeViewModel type)
        {
            var response = await _productTypeService.Put(type);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("PostProductType")]
        [Authorize]
        public async Task<ActionResult<ProductTypeViewModel>> Post([FromBody] ProductTypeViewModel type)
        {
            var response = await _productTypeService.Post(type);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
