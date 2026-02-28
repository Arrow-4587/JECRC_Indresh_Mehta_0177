using System;
using System.Collections.Generic;

namespace ProductDemo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsStock { get; set; }
    }
    public class ProductCatalog
    {
        private List<Product> products;
        public ProductCatalog()
        {
            products = new List<Product>
            {
                new Product { Id = 100, Name = "Laptop", Description = "Electronics Item", Price = 75000, IsStock = true },
                new Product { Id = 101, Name = "Smartphone", Description = "Electronics Item", Price = 55000, IsStock = true },
                new Product { Id = 102, Name = "Desk", Description = "Furniture", Price = 5000, IsStock = false },
                new Product { Id = 103, Name = "Notebook", Description = "Furniture", Price = 750, IsStock = false },
            };
        }
        public void DisplayProducts()
        {
            Console.WriteLine("Product Catalog:");
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Description: {product.Description}, Price: {product.Price}, In Stock: {product.IsStock}");
            }
        }
    }
    class TestProduct
    {
        static void Main(string[] args)
        {
            ProductCatalog catalog = new ProductCatalog();
            catalog.DisplayProducts();
        }
    }

}