using ManeroProject.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApi.Enums;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Services;

public interface ICategoryService
{
    Task<ServiceResponse<Category>> CreateCategoryAsync(ServiceRequest<CategorySchema> request);
    Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(int categoryId);
}
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<ServiceResponse<Category>> CreateCategoryAsync(ServiceRequest<CategorySchema> request)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(int categoryId)
    {
        var response = new ServiceResponse<List<Product>>();

        try
        {
            var products = await _categoryRepository.GetProductsByCategoryIdAsync(categoryId);

            if (products != null && products.Any())
            {
                response.Content = products;
                response.StatusCode = StatusCode.Ok;
            }
            else
            {
                response.StatusCode = StatusCode.NotFound;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.StatusCode = StatusCode.InternalServerError;
        }

        return response;
    }


}
