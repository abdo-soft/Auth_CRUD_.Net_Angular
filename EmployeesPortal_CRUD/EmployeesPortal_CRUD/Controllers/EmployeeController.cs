using EmployeesPortal_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesPortal_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _EmpDBContext;

        public EmployeeController(EmployeeDbContext EmpDBContext)
        {
            _EmpDBContext = EmpDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_EmpDBContext.Employee.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_EmpDBContext.Employee.FirstOrDefault(c => c.EmpId == id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            _EmpDBContext.Employee.Add(employee);
            _EmpDBContext.SaveChanges();

            return Ok("Employee created");
        }


        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            var emp = _EmpDBContext.Employee.FirstOrDefault(c => c.EmpId == employee.EmpId);

            if (emp == null)
                return BadRequest();

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Email = employee.Email;
            emp.PhoneNumber = employee.PhoneNumber;

            _EmpDBContext.Employee.Update(emp);
            _EmpDBContext.SaveChanges();

            return Ok("Employee updated");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _EmpDBContext.Employee.FirstOrDefault(c => c.EmpId == id);

            if (emp == null)
                return BadRequest();

            _EmpDBContext.Employee.Remove(emp);
            _EmpDBContext.SaveChanges();

            return Ok("Employee deleted");
        }
    
}
}
