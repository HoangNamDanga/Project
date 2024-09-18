using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Mapper
{
    public class MapperConverterRole
    {
        public static RoleResponse responseRole(Role role)
        {
            var response = new RoleResponse();
            response.Id = role.Id;
            response.Name = role.Name;
            response.SpendingLimit = role.SpendingLimit;
            response.Employees = role.Employees?.Select(e => e.FirstName + " " + e.LastName).ToList();
            return response;
        }

        public static Role requestRole(Role request)
        {
            var role = new Role();
            role.Name = request.Name;
            role.SpendingLimit = request.SpendingLimit;
            return role;
        }
    }
}
