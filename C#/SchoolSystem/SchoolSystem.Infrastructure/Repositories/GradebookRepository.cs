using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Entities.Results;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Core.QueryFilters;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class GradebookRepository : IGradebookRepository
    {
        private readonly SchoolDBContext _context;

        public GradebookRepository(SchoolDBContext context) => _context = context;
        public async Task AddAsync(CourseGradebook model) => await _context.CourseGradebook.AddAsync(model);
        public IEnumerable GetGradebookByStudent(GradebookFilter filter)
        {

            var students = _context.ViewStudent.AsQueryable();

            if (filter.StudentId != null)
            {
                students = students.Where(x => x.StudentId == filter.StudentId);
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                students = students.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()) || x.Lastname.ToLower().Contains(filter.Name.ToLower()));
            }

            var result = from vs in students.ToList()
                         join cg in _context.CourseGradebook on vs.StudentId equals cg.StudentId into grs
                         select new
                         {
                             StudentId = vs.StudentId,
                             FullName = $"{vs.Name} {vs.Lastname ?? string.Empty}".Trim(),
                             Courses = from gd in grs
                                       join c in _context.Course on gd.CourseId equals c.CourseId
                                       select new
                                       {
                                           CourseId = c.CourseId,
                                           Name = c.Name,
                                           N1 = gd.Q1,
                                           N2 = gd.Q2,
                                           N3 = gd.Q3,
                                           Average = gd.Average
                                       }
                         };

            return result;
        }

        public IEnumerable<TeacherResult> GetGradebookByTeacher(GradebookFilter filter)
        {
            return _context.ViewTeacher.Where(x => x.TeacherId == filter.TeacherId).ToList()
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