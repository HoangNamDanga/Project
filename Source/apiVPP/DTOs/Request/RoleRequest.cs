using System.ComponentModel.DataAnnotations.Schema;

namespace apiVPP.DTOs.Request
{
    public class RoleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal SpendingLimit { get; set; }
    }
}
