using BlogApiDemo.DataAcessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetEmployee()
        {
            using var c = new Context();
            var employees = c.Employees.ToList();
            return Ok(employees);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            using var c = new Context();
            c.Employees.Add(employee);
            c.SaveChanges();
            return Ok();
        }

        [HttpGet("id")]
        public IActionResult GetEmployee(int id)
        {
            var c = new Context();
            var employee = c.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();

            }
            return Ok(employee);
        }
        [HttpDelete("id")]
        public IActionResult DeleteEmployee(int id)
        {
            var c = new Context();
            var employee = c.Employees.Find(id);

            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(employee);
                c.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var c = new Context();
            var emp = c.Employees.Find(employee.Id);
            if(employee==null)
            {
                return NotFound();
            }
            emp.Name = employee.Name;
            c.Update(emp);
            c.SaveChanges();
            return Ok();
        }
    }
}
