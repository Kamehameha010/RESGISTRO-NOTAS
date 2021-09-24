namespace WsSchool.Core.Models.DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public int? Nid { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? LoginId { get; set; }
    }
}
