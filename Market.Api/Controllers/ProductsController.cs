using Market.Domain.Configurations;
using Market.Service.DTOs;
using Market.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams @params)
            => Ok(await _productService.GetAllAsync(@params));

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _productService.GetAsync(p => p.Id == id));

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm]ProductForCreationDto dto)
            => Ok(await _productService.AddAsync(dto));

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromForm]ProductForCreationDto dto, [FromRoute(Name = "Id")] long Id)
            => Ok(await _productService.UpdateAsync(Id, dto));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _productService.DeleteAsync(p => p.Id == id));

    }
}
