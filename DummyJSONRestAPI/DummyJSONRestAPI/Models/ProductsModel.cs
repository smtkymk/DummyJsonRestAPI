﻿namespace DummyJSONRestAPI.Models
{
    public class ProductsModel
    {
        public List<Product> Products { get; set; }
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }

    public class Product : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Images { get; set; }
    }
}
