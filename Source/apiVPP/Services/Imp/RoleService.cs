using apiVPP.Data;
using apiVPP.DTOs.Request;
using apiVPP.DTOs.Response;
using apiVPP.Mapper;
using apiVPP.Models;

namespace apiVPP.Services.Imp
{
    public class RoleService : IRoleService
    {
        public readonly Context _context;
        public RoleService(Context context)
        {
            _context = context;
        }

        public Role AddRoler(Role request)
        {
            var role = MapperConverterRole.requestRole(request);
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }

        public bool DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(a => a.Id == id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Role> getAllRole()
        {
            return _context.Roles.ToList();
        }

        public Role getRoleById(int id)
        {
            var role = _context.Roles.FirstOrDefault(a => a.Id == id);
            if (role != null)
            {
                return role;
            }
            else
            {
                return null;
            }
        }

        public Role UpdateRole(Role request)
        {
            var updateRole = _context.Roles.FirstOrDefault(a => a.Id == request.Id);
            if (updateRole != null)
            {
                updateRole.Id = request.Id;
                updateRole.Name = request.Name;
                updateRole.SpendingLimit = request.SpendingLimit;
                _context.SaveChanges();
            }
            return updateRole;
        }
    }
}
