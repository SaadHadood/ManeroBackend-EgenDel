using ManeroProject.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Contexts;

public class ProductContext : DbContext
{
    public ProductContext()
    {
        
    }
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
