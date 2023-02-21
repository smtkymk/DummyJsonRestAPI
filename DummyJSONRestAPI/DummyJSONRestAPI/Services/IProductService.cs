using DummyJSONRestAPI.Models;

namespace DummyJSONRestAPI.Services
{
    public interface IProductService
    {
        Task<ProductsModel> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<ProductsModel> GetProductSearchAsync(string queryString);
        Task<List<Product>> GetProductSearchQueryAsync(string queryString);
        Task<Product> DeleteGetProductByIdAsync(int id);
        Task<List<Product>> ShowGetProductByIdAsync(Product product);
        Task<Product> GetEditProductByIdAsync(int id);
        Task<ProductsModel> PutEditProductByIdAsync(Product product);
        Task<ProductsModel> AddProductByIdAsync(Product product);
        Task<List<string>> GetProductsCategoriesAsync();
    }
}
