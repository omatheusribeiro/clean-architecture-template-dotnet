using clean_architecture_dotnet.Application.Services.Sales.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Sales;
using clean_architecture_dotnet.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Api.Controllers.V1.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("GetAllSales")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var response = await _saleService.GetAll();

            if (response.StatusCode == (int)HttpStatus.NotFound)
                return NotFound(response);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);

        }

        [HttpGet("GetSaleById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _saleService.GetById(id);

            if (response.StatusCode == (int)HttpStatus.NotFound)
                return NotFound(response);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);

        }

        [HttpPut("PutSale")]
        [Authorize]
        public async Task<ActionResult<SaleViewModel>> Put([FromBody] SaleViewModel sale)
        {
            var response = await _saleService.Put(sale);

            if (response.StatusCode == (int)HttpStatus.NotFound)
                return NotFound(response);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("PostSale")]
        [Authorize]
        public async Task<ActionResult<SaleViewModel>> Post([FromBody] SaleViewModel sale)
        {
            var response = await _saleService.Post(sale);

            if (response.StatusCode == (int)HttpStatus.NotFound)
                return NotFound(response);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("DeleteSale")]
        [Authorize]
        public async Task<ActionResult<SaleViewModel>> Delete([FromBody] SaleViewModel sale)
        {
            var response = await _saleService.Delete(sale);

            if (response.StatusCode == (int)HttpStatus.NotFound)
                return NotFound(response);

            if (response.StatusCode == (int)HttpStatus.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
