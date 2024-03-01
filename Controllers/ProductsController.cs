using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet_shop_api.Context;
using pet_shop_api.DTO;
using pet_shop_api.Entities;

namespace pet_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // CRUD operations

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateUpdateProductDto dto)
        {
            var newProduct = new ProductEntity()
            {
                Brand = dto.Brand,
                Title = dto.Title
            };

           await _context.Products.AddAsync(newProduct);
           await _context.SaveChangesAsync();

            return Ok("Product saved successfully");
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetAllProducts()
        {
               var products = await _context.Products.ToListAsync();

               return Ok(products);
        }

        [HttpGet]
        [Route("{id}")] 
        public async Task<ActionResult<ProductEntity>> GetProductByID([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] CreateUpdateProductDto dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product not found");
            }

            product.Title = dto.Title;
            product.Brand = dto.Brand;

           await _context.SaveChangesAsync();

           return Ok("Product updated successfully");
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.Id == id);

            if (product is null)
            {
                return NotFound("Product not found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("Product deleted successfully");
        }

    }
}
