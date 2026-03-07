using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // // GET: api/Product/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Product>> GetProduct(int id)
        // {
        //     var product = await _context.Products.FindAsync(id);

        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     return product;
        // }

        // // POST: api/Product
        // [HttpPost]
        // public async Task<ActionResult<Product>> PostProduct(Product product)
        // {
        //     _context.Products.Add(product);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        // }
    }
}