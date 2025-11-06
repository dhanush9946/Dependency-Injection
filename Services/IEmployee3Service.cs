using Employee3Dep.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee3Dep.Services
{
    public interface IEmployee3Service
    {
        public IEnumerable<Employee3> GetAll();
        public Employee3 GetById(int id);
        public void Create(Employee3 newEmployee);
        public bool Update(int id, Employee3 UpdatedEmployee);
        public bool PartialUpdate(int id, [FromBody] Employee3 partialUpdated);

        public void Delete(int id);
    }
}
