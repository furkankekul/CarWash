using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO.IsolatedStorage;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IGenericService<Employee> employeeManager;
       
        public EmployeeController()
        {
            this.employeeManager = new EmployeeManager();
        }

        [HttpPost]
        public IActionResult EmployeeAdd([FromBody] Employee e)
        {
            Model model = new Model();
            model = employeeManager.InsertBL(e);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);

        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            Model model = new Model();
            model = employeeManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpGet("EmployeeGet")]
        public IActionResult EmployeeGet()
        {
            Model model = new Model();
            var values = employeeManager.GetAllListBL();
            return Ok(values);
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee e)
        {
            Model model = new Model();
            model = employeeManager.UpdateBL(e);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }


        [HttpPost("EmployeeAddRange")]
        public IActionResult EmployeeAddRange(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                employeeManager.InsertBL(item);
            }

            return Ok(employees);

        }



    }
}