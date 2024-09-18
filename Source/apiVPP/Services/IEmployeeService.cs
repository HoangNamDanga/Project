using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Services
{
    public interface IEmployeeService
    {
        public List<EmployeeResponse> getAllEmployee();
        public Employee getEmployeeById(int id);
        public bool DeleteEmployee(int id);
        public Employee AddEmployee(EmployeeRequest request);
        public Employee UpdateEmployee(EmployeeRequest request);
    }
}
