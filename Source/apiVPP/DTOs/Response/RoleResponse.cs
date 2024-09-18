using System.ComponentModel.DataAnnotations.Schema;

namespace apiVPP.DTOs.Response
{
    public class RoleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal SpendingLimit { get; set; }
        public List<string> Employees { get; set; }
    }
}
