using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SchoolSystem.Core.Entities.Results
{
    public class CourseResult
    {
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentResult> Students { get; set; }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            CourseResult result = obj as CourseResult;
            return CourseId == result.CourseId &&
                    Name.Equals(result.Name) &&
                    Code.Equals(result.Code);
        }

        // override object.GetHashCode
        public override int GetHashCode() => Tuple.Create(CourseId, Code, Name).GetHashCode();
    }
}