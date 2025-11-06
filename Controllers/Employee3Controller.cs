using System;
using Employee3Dep.Models;
using Employee3Dep.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee3Dep.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Employee3Controller:ControllerBase
    {
        private readonly IEmployee3Service service;

        public Employee3Controller(IEmployee3Service _service)
        {
            service = _service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee3>> GetAll()
        {
           var emps= service.GetAll();
            return Ok(emps);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var emp = service.GetById(id);
            if (emp == null) NotFound();
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult Create(Employee3 newEmp)
        {
            service.Create(newEmp);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult update(int id,Employee3 upd)
        {
            service.Update(id, upd);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult partialupd(int id,Employee3 parupd)
        {
            if (service.PartialUpdate(id, parupd)==false)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return NoContent();
        }
    }
}
