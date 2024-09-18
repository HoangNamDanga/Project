using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace apiVPP.Models
{
    public class Employee : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int RoleId { get; set; }
        public Role Role {  get; set; }

        public int? SuperiorID { get; set; }
        public Employee Superior { get; set; }

        public ICollection<Employee> Subordinates { get; set;}

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
