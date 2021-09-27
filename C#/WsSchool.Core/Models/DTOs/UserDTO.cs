namespace WsSchool.Core.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }
        public int? PersonId { get; set; }
    }
}
