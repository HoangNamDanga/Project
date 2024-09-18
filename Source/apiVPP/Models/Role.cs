using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiVPP.Models
{
    public class Role : IdentityRole<int>
    {
        public string Name {  get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal SpendingLimit { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
