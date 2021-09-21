namespace WsSchool.Core.Models.DTOs
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CourseStatusId { get; set; }
    }
}
