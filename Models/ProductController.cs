using Microsoft.AspNetCore.Mvc;
using Employee3Dep.Models;
using Employee3Dep.Services;
namespace Employee3Dep.Models
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController:ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService _service)
        {
            service = _service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Getall()
        {
            return Ok(service.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            return Ok(service.GetById(id));
        }
        [HttpPost]
        public IActionResult posting(Product newProduct)
        {
            service.Create(newProduct);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult update(int id,Product updatedProduct)
        {
            var bol = service.Update(id, updatedProduct);
            if (bol == false)
                NotFound();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult partialUpdate(int id, Product partialUpdateProduct)
        {
            var product = service.PartialUpdate(id, partialUpdateProduct);
            if (product == false)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public  IActionResult Delete(int id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
