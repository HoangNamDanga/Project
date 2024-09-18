using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiVPP.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeID { get; set; }

        public int ChangedBy { get; set; }

        public string FieldChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public DateTime ChangeDate { get; set; }

        [ForeignKey("EmployeeID")] // Chỉ ra khóa ngoại tới EmployeeID
        public virtual Employee Employee { get; set; }

        [ForeignKey("ChangedBy")] // Chỉ ra khóa ngoại tới ChangedBy
        public virtual Employee ChangedByEmployee { get; set; }
    }
}
