using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Mapper
{
    public class MapperConverterEmployee
    {
        public static EmployeeResponse ToEmployeeResponseDTO(Employee employee)
        {
            return new EmployeeResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                RoleId = employee.RoleId,
                SuperiorID = employee.SuperiorID,
                Subordinates = employee.Subordinates?.Select(s => s.FirstName + " " + s.LastName).ToList(),
                CreatedDate = employee.CreatedDate,
                UpdatedDate = employee.UpdatedDate
            };
        }

        public static Employee ToEmployee( EmployeeRequest request)
        {
            return new Employee
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                RoleId = request.RoleId,
                SuperiorID = request.SuperiorID
            };
        }
    }
}
