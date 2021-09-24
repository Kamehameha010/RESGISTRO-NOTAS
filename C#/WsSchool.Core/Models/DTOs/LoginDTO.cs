namespace WsSchool.Core.Models.DTOs
{
    public class LoginDTO
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }

    }
}
