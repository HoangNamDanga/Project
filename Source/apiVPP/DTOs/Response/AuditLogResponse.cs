using System.ComponentModel.DataAnnotations;

namespace apiVPP.DTOs.Response
{
    public class AuditLogResponse
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public string FieldChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int ChangedBy { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
