using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Mapper;
using apiVPP.Models;
using Azure.Core;
using System.Data;

namespace apiVPP.Services.Imp
{
    public class EmployeeService : IEmployeeService
    {
        public readonly Context _context;
        public EmployeeService(Context context)
        {
            _context = context;
        }
        public Employee AddEmployee(EmployeeRequest request)
        {
            var employee = MapperConverterEmployee.ToEmployee(request);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<EmployeeResponse> getAllEmployee()
        {
            return _context.Employees.Select(e => MapperConverterEmployee.ToEmployeeResponseDTO(e)).ToList();
        }

        public Employee getEmployeeById(int id)
        {
            var emp = _context.Employees.FirstOrDefault(a => a.Id == id);
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        public Employee UpdateEmployee(EmployeeRequest request)
        {
            var employee = MapperConverterEmployee.ToEmployee(request);
            var updateEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (updateEmployee != null)
            {
                updateEmployee.FirstName = employee.FirstName;
                updateEmployee.LastName = employee.LastName;
                updateEmployee.RoleId = employee.RoleId;
                updateEmployee.SuperiorID = employee.SuperiorID;
                _context.SaveChanges();
            }
            return updateEmployee;
        }
    }
}
