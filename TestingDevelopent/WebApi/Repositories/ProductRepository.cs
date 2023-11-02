using ManeroProject.Models;
using WebApi.Contexts;

namespace WebApi.Repositories;

public interface IProductRepository : IRepo<ProductEntity, ProductContext>
{
}
public class ProductRepository : Repo<ProductEntity, ProductContext>, IProductRepository
{
    public ProductRepository(ProductContext context) : base(context)
    {
    }
}
