namespace SchoolSystem.Core.Entities
{
    public class ViewStudentUser
    {
        public int? UserId { get; set; }
        public int? Nid { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }
        public int? StudentId { get; set; }
        public string Classroom { get; set; }
    }
}