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
