using Employee3Dep.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace Employee3Dep.Services
{
    public class Employee3Service:IEmployee3Service
    {
        private readonly List<Employee3> employees = new List<Employee3>()
        {
            new Employee3{Id=1,Name="Dhanush",Department="Software"},
            new Employee3{Id=2,Name="Shibu",Department="Gulf company"}
        };

        public IEnumerable<Employee3> GetAll()
        {
            return employees;
        }
        public  Employee3 GetById(int id)
        {

            return employees.FirstOrDefault(i => i.Id == id);
            
                
        }
        public void Create(Employee3 CreatingEmp)
        {
            CreatingEmp.Id = employees.Max(i => i.Id) + 1;
            employees.Add(CreatingEmp);

        }
        public bool Update(int id,Employee3 updatedItem)
        {
            var emp = employees.FirstOrDefault(i => i.Id == id);
            if (emp == null)
                return false;
            emp.Name = updatedItem.Name;
            emp.Department = updatedItem.Department;
            return true;

        }
        public bool PartialUpdate(int id, [FromBody] Employee3 PartialEmp)
        {
            var emp = employees.FirstOrDefault(i => i.Id == id);
            if (emp == null)
                return false;
            if (!string.IsNullOrEmpty(PartialEmp.Name))
                emp.Name = PartialEmp.Name;
            if (!string.IsNullOrEmpty(PartialEmp.Department))
                emp.Department = PartialEmp.Department;
            return true;
        }
        public void Delete(int id)
        {
            var emp = employees.FirstOrDefault(i => i.Id == id);
            if (emp != null)
                employees.Remove(emp);
        }
    }
}
