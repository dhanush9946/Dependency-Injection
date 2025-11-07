using Employee3Dep.Models;

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Employee3Dep.Services
{
    public class ProductService:IProductService
    {
        private readonly List<Product> products = new List<Product>()
        {
            new Product{Id=1,Name="Samsung Galaxy S23",Description="It is the number one mobile phone in the samsung products"},
            new Product{Id=2,Name="Asus Tuf Gaming",Description="It is the  budget king Laptop for Gamers"}
        };

        public IEnumerable<Product> GetAll() => products;
        public Product? GetById(int id) => products.FirstOrDefault(i => i.Id == id);
        public void Create(Product NewProduct)
        {
            NewProduct.Id = products.Max(i => i.Id) + 1;
            products.Add(NewProduct);
        }
        public bool Update(int id,Product updatedProduct)
        {
            var product = products.FirstOrDefault(i => i.Id == id);
            if (product == null)
                return false;
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            return true;
             
        }
        public bool PartialUpdate(int id, [FromBody] Product partialUpdatedProduct)
        {
            var product = products.FirstOrDefault(i => i.Id == id);
            if (product == null) return false;
            if (!string.IsNullOrEmpty(partialUpdatedProduct.Name))
            {
                product.Name = partialUpdatedProduct.Name;

            }
            if (!string.IsNullOrEmpty(partialUpdatedProduct.Description))
            {
                product.Description = partialUpdatedProduct.Description;
            }
            return true;
        }
        public bool Delete(int id)
        {
            var product = products.FirstOrDefault(i => i.Id == id);
            if (product == null) return false;
            products.Remove(product);
            return true;
        }
    }
}
