using System.Collections.Generic;

namespace SchoolSystem.Core.Entities.Results
{
    public class TeacherResult
    {
        public int TeacherId { get; set; }
        public string Fullname { get; set; }

        public IEnumerable<CourseResult> Courses { get; set; }
        
    }
}