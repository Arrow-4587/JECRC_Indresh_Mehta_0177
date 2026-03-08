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
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
     

        // // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product =  _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    

        // // POST: api/Product
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
                return Ok(product);
    
        }
        // // PUT: api/Product/5
        [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
      var product = _context.Products.Find(id);

      if(product == null)
        return NotFound();

      product.Name = updatedProduct.Name;
      product.Price = updatedProduct.Price;
      product.Quantity = updatedProduct.Quantity;
      _context.SaveChanges();

      return Ok(product);
    }
 
        // // GET: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product =  _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }    
           [HttpGet("search/{name}")]
public IActionResult SearchProduct(string name)
{
    var products = _context.Products
        .Where(p => p.Name.Contains(name))
        .ToList();

    return Ok(products);
}
    }
}