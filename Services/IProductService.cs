using Employee3Dep.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee3Dep.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product? GetById(int id);
        public void Create(Product newProduct);
        public bool Update(int id, Product UpdatedProduct);
        public bool PartialUpdate(int id, [FromBody] Product PartialUpdatedProduct);
        public bool Delete(int id);
        
    }
}
