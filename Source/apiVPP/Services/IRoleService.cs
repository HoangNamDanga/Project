using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Models;

namespace apiVPP.Services
{
    public interface IRoleService
    {
        public List<Role> getAllRole();
        public Role getRoleById(int id);
        public bool DeleteRole(int id);
        public Role AddRoler(Role request);
        public Role UpdateRole(Role request);
    }
}
