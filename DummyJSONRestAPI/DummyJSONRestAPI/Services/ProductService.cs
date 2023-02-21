using DummyJSONRestAPI.Consts;
using DummyJSONRestAPI.Controllers;
using DummyJSONRestAPI.Helpers;
using DummyJSONRestAPI.Models;

namespace DummyJSONRestAPI.Services
{

    public class ProductService : IProductService
    {
        private readonly ILogger<ProductController> _logger;

        public ProductService(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public async Task<ProductsModel> GetAllProductAsync()
        {
            var response = await HttpHelper.GetDataFromApi<ProductsModel>(ResourceConstants.BaseApiUrl);
            if (response == null || response.Products == null || response.Products.Count == 0)
                throw new Exception("Sonuç Bulunamadı");

            return response;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var apiUrl = ResourceConstants.BaseApiUrl + $"/{id}";
            var response = await HttpHelper.GetDataFromApi<Product>(apiUrl);

            if(response == null)
                throw new Exception($"{id} Araması ile ürün bulunamadı.");

            return response;
        }

        public async Task<ProductsModel> GetProductSearchAsync(string queryString)
        {
            var apiUrl = ResourceConstants.BaseApiUrl + $"/search?q={queryString}";
            var response = await HttpHelper.GetDataFromApi<ProductsModel>(apiUrl);

            if (response == null || response.Products == null || response.Products.Count == 0)
                throw new Exception($"{queryString} için sonuç bulunamadı.");

            return response;
        } 

        public async Task<List<Product>> GetProductSearchQueryAsync(string queryString)
        {
            if (ValidationHelper.IsValidLetter(queryString))
                  _logger.LogInformation("kategori aramasına rakam girilemez");

            var result = await HttpHelper.GetDataFromApi<ProductsModel>(ResourceConstants.BaseApiUrl);
            var response = result?.Products?.Where(x => x.Category.ToLower() == queryString.ToLower()).ToList();

            if (response == null)
                throw new Exception($"{queryString} için sonuç bulunamadı.");

            return response;
        }

        public async Task<List<string>> GetProductsCategoriesAsync()
        {
            var apiUrl = ResourceConstants.BaseApiUrl + $"/categories";
            var response = await HttpHelper.GetDataFromApi<List<string>>(apiUrl);
            
            if (response == null)
                throw new Exception("Sonuç Bulunamadı");

            return response;
        }

        public async Task<Product> DeleteGetProductByIdAsync(int id)
        {
            var result = await HttpHelper.GetDataFromApi<ProductsModel>(ResourceConstants.BaseApiUrl);
            var response = result?.Products?.Where(x => x.Id == id).FirstOrDefault();

            if (response == null)
                throw new Exception("Sonuç Bulunamadı");

            return response;
        }

        public async Task<List<Product>> ShowGetProductByIdAsync(Product product)
        {
            var response = await HttpHelper.GetDataFromApi<ProductsModel>(ResourceConstants.BaseApiUrl);
            response.Products = response.Products.Where(x => x.Id != product.Id).ToList();

            if (response == null || response.Products == null || response.Products.Count == 0)
                throw new Exception("Sonuç Bulunamadı");

            return response.Products;
        }

        public async Task<Product> GetEditProductByIdAsync(int id)
        {
            var result = await HttpHelper.GetDataFromApi<ProductsModel>(ResourceConstants.BaseApiUrl);
            var response = result?.Products?.Where(x => x.Id == id).FirstOrDefault();

            if (response == null)
                throw new Exception("Sonuç Bulunamadı");

            return response;
        }

        public async Task<ProductsModel> PutEditProductByIdAsync(Product product)
        {    
            var response = await HttpHelper.GetDataFromApi<ProductsModel>(ResourceConstants.BaseApiUrl);
            response.Products[product.Id - 1] = product;

            if (response == null || response.Products == null || response.Products.Count == 0)
                throw new Exception("Sonuç Bulunamadı");

            return response;
        }

        public async Task<ProductsModel> AddProductByIdAsync(Product product)
        {  
            var response = await HttpHelper.GetDataFromApi<ProductsModel>(ResourceConstants.BaseApiUrl);
            response.Products.Add(product);

            if (response == null || response.Products == null || response.Products.Count == 0)
                throw new Exception("Sonuç Bulunamadı");

            return response;
        }
    }
}
