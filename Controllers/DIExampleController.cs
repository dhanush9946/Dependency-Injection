using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee3Dep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DIExampleController : ControllerBase
    {
        [HttpGet]
        [Route("InsertEmployee")]
        public void InsertEmployee()
        {
            
            Employee emp = new Employee(new DALSql());
            emp.InsertData();
        }
    }


    //BLL(Bussiness Logic  Layer
    public class Employee
    {
        int dbType=1;
        IDALSql dalser;
        public Employee(IDALSql _dlaser)
        {
            dalser = _dlaser;
        }
        public void InsertData()
        {
           
            dalser.InsertData();
            
        }
    }

    //interface
    public interface IDALSql
    {
        public void InsertData();
    }

    //DAL(Data access layer
    public class DALSql:IDALSql
    {
        public void InsertData()
        {
            //Logic
        }
    }

    public class DALOracle:IDALSql
    {
        public void InsertData()
        {
            //Logic
        }
    }
}
