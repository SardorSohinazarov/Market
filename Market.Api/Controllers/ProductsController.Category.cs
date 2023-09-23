using Market.Domain.Configurations;
using Market.Domain.Entities.Products;
using Microsoft.AspNetCore.Mvc;

namespace Market.Api.Controllers
{
    public partial class ProductsController
    {
        [HttpPost("Categories")]
        public async Task<ActionResult<ProductCategory>> AddCategoryAsync([FromBody] string name)
            => Ok(await _productService.AddCategoryAsync(name));

        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetAllCategoryAsync([FromQuery] PaginationParams @params)
            => Ok(await _productService.GetCategoryWithProductsAsync(@params));

        [HttpGet("Categories/{Id}")]
        public async Task<ActionResult<ProductCategory>> GetCategoryAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _productService.GetCategoryAsync(p => p.Id == id));

        [HttpPut("Categories/{Id}")]
        public async Task<ActionResult<ProductCategory>> UpdateCategoryAsync([FromRoute(Name = "Id")] long id, string name)
            => Ok(await _productService.UpdateCategoryAsync(id, name));

        [HttpDelete("Categories/{Id}")]
        public async Task<ActionResult<bool>> DeleteCategoryAsync([FromRoute(Name = "Id")] long id)
            => Ok(await _productService.DeleteCategoryAsync(p => p.Id == id));
    }
}
