using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.Models;
using apiVPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiVPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _context;
        public EmployeeController(IEmployeeService context)
        {

            _context = context;
        }


        [HttpGet("getAll")]
        public ActionResult<List<Employee>> getAll()
        {
            var listEmployee =  _context.getAllEmployee();
            if(listEmployee == null)
            {
                return NotFound();
            }
            return Ok(listEmployee);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> getEmployeeId(int id)
        {
            var emp = _context.getEmployeeById(id);
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] EmployeeRequest employee)
        {
            var employeeNew = _context.AddEmployee(employee);
            return Ok(employeeNew);
        }

        [HttpDelete("{id}")]
        public ActionResult deleteEmployee(int id)
        {
            var employeeDelete = _context.DeleteEmployee(id);
            if (employeeDelete != false)
            {
                return Ok(employeeDelete);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> updateRole([FromBody] EmployeeRequest employee)
        {
            var employeeUpdate = _context.UpdateEmployee(employee);
            if (employeeUpdate != null)
            {
                return Ok(employeeUpdate);
            }
            else
            {
                return Conflict();
            }
        }

    }
}
