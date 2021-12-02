using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Entities.Results;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class GradebookRepository : IGradebookRepository
    {
        private readonly SchoolDBContext _context;

        public GradebookRepository(SchoolDBContext context) => _context = context;
        public async Task AddAsync(CourseGradebook model) => await _context.CourseGradebook.AddAsync(model);



        public IEnumerable<TeacherResult> GetGradebookTeacher(int teacherId)
        {
            return _context.ViewTeacher.Where(x => x.TeacherId == teacherId).ToList()
                   .Select(a =>
                   new TeacherResult
                   {
                       TeacherId = (int)a.TeacherId,
                       Fullname = $"{a.Name} {a.Lastname ?? ""}".Trim(),
                       Courses = _context.Course.ToList().Join(_context.CourseGradebook.Where(x => x.TeacherId == a.TeacherId), c => c.CourseId, d => d.CourseId, (c, d) =>
                       new CourseResult
                       {
                           CourseId = c.CourseId,
                           Code = c.Code,
                           Name = c.Name,
                           Students = _context.ViewStudent.ToList().Join(_context.CourseGradebook.Where(x => x.TeacherId == a.TeacherId && x.CourseId == c.CourseId), m => m.StudentId, n => n.StudentId,
                               (m, n) => new StudentResult
                               {
                                   StudentId = (int)m.StudentId,
                                   Fullname = $"{m.Name} {m.Lastname ?? string.Empty}".Trim(),
                                   Q1 = n.Q1,
                                   Q2 = n.Q2,
                                   Q3 = n.Q3,
                                   Average = n.Average,
                                   Status = n.Status ? "Approved" : "Disapproved"
                               })
                       }).Distinct()
                   });

        }

       

        public void Update(CourseGradebook model) => _context.CourseGradebook.Update(model);
    }
}