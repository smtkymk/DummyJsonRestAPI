using DummyJSONRestAPI.Models;
using DummyJSONRestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace DummyJSONRestAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllProduct()
        {
            var response = await _productService.GetAllProductAsync();
            return View(response);
        }


        public IActionResult GetProductById()
        {
            return View();
        }

        public async Task<IActionResult> GetProductId(int productid)
        {
            var response = await _productService.GetProductByIdAsync(productid);
            return View(response);
        }

        public IActionResult GetProductBySearch()
        {
            return View();
        }

        public async Task<IActionResult> GetProductSearch(string search)
        {
            var response = await _productService.GetProductSearchAsync(search);
            return View(response);
        }

        public async Task<IActionResult> GetProductSearchQuery(int  id)
        {
            var responsecategory = await _productService.GetProductsCategoriesAsync();
            string queryString = responsecategory[id-1]; 
            ViewBag.Query = queryString;
            var response = await _productService.GetProductSearchQueryAsync(queryString);
            
            return View(response);
        }

        public async Task<IActionResult> GetProductsCategories()
        {
            var response = await _productService.GetProductsCategoriesAsync();
            
            ViewBag.count=response.Count+1;
            ViewBag.values = response;

            return View(response);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteGetProductByIdAsync(id);
            return RedirectToAction("ShowDeleteUpdatedProducts",response);
        }

        public async Task<IActionResult> ShowDeleteUpdatedProducts(Product product)
        {
            var response = await _productService.ShowGetProductByIdAsync(product);
            return View(response);
        }


        public async Task<IActionResult> EditPutProduct(int id)
        {
            var response = await  _productService.GetEditProductByIdAsync(id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditPutProduct(Product product)
        {
            return RedirectToAction("ShowEditUpdatedProducts", product);
        }

        public async Task<IActionResult> ShowEditUpdatedProducts(Product product)
        {
            var response = await _productService.PutEditProductByIdAsync(product); 
            return View(response);
        }

        public async Task<IActionResult> AddProduct()
        {
            var response = await _productService.GetAllProductAsync();
            ViewBag.Count = response.Products.Count+1;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            return RedirectToAction("ShowAddUpdatedProducts", product);
        }

        public async Task<IActionResult> ShowAddUpdatedProducts(Product product)
        {
            var response = await _productService.AddProductByIdAsync(product);
            return View(response);
        }
    }
}
