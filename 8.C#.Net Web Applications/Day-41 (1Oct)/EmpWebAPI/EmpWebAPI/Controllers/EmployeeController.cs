using EmpWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeecontext)
        {
            _employeeContext = employeecontext;
        }

        // GET: api/<EmployeeController>

        // a) Get list of employee data
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _employeeContext.Employees.ToListAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeContext.Employees.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Employee employee)
        {
            _employeeContext.Employees.Update(employee);
            _employeeContext.SaveChanges();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _employeeContext.Employees.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                {
                    _employeeContext.Employees.Remove(item);
                    _employeeContext.SaveChanges();
                }
            }
        }
    }
}
