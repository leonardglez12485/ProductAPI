
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly DataContext _context;
    // Constructor to inject the DataContext
    public ProductController(DataContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Product cannot be null");
        }
        var newProduct = new Product
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Category = product.Category,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };
         _context.Products.Add(newProduct);
        var saved = await _context.SaveChangesAsync();
        return StatusCode(201, newProduct);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        if (id <= 0 || id > int.MaxValue)
        {
            return BadRequest("Invalid product ID");
        }
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }
        return Ok(product);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(string? name, string? category)
    {
        var products = await _context.Products
            .Where(p => (string.IsNullOrEmpty(name) || (p.Name != null && p.Name.Contains(name))) &&
                        (string.IsNullOrEmpty(category) || (p.Category != null && p.Category.Contains(category))))
            .ToListAsync();
        return Ok(products);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
    {
        if (id <= 0 || id > int.MaxValue)
        {
            return BadRequest("Invalid product ID");
        }
        if (product == null)
        {
            return BadRequest("Product cannot be null");
        }
        if (id != product.Id)
        {
            return BadRequest("Product ID mismatch");
        }
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return NotFound("Product not found");
        }
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Description = product.Description;
        existingProduct.Category = product.Category;
        existingProduct.IsActive = product.IsActive;

        _context.Products.Update(existingProduct);
        var saved = await _context.SaveChangesAsync();
        return Ok(saved);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        if (id <= 0 || id > int.MaxValue)
        {
            return BadRequest("Invalid product ID");
        }
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }
        _context.Products.Remove(product);
        var removed = await _context.SaveChangesAsync();
        return Ok(removed);
    }
}
