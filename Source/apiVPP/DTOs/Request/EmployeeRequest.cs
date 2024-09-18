namespace apiVPP.DTOs.Request
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int? SuperiorID { get; set; }
    }
}

