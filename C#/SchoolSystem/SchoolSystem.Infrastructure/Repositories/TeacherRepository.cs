using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Core.QueryFilters;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDBContext _context;
        public TeacherRepository(SchoolDBContext context) => _context = context;
        public async Task AddAsync(Teacher model) => await _context.Teacher.AddAsync(model);

        public async Task<Teacher> FindAsync(int id) => await _context.Teacher.FindAsync(id);

        public IEnumerable GetCoursesbyTeacher(CourseFilter filter)
        {

            var teachers = _context.ViewTeacher.AsQueryable();

            if (filter.TeacherId != null)
            {
                teachers = teachers.Where(x => x.TeacherId == filter.TeacherId);
            }

            if (!String.IsNullOrEmpty(filter.Name))
            {
                teachers = teachers.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()) || x.Lastname.ToLower().Contains(filter.Name.ToLower()));
            }

            var result = from vt in teachers.ToList()
                         join cg in _context.CourseGradebook on vt.TeacherId equals cg.TeacherId into grs
                         select new
                         {
                             TeacherId = vt.TeacherId,
                             FullName = $"{vt.Name} {vt.Lastname ?? string.Empty}".Trim(),
                             Students = from gd in grs
                                        join vs in _context.ViewStudent on gd.StudentId equals vs.StudentId
                                        join c in _context.Course on gd.CourseId equals c.CourseId
                                        select new
                                        {
                                            CourseId = c.CourseId,
                                            Course = c.Name,
                                            StudentId = vs.StudentId,
                                            Name = vs.Name
                                        }
                         };
            return result;
        }

        public IEnumerable GetTeaches() => _context.ViewTeacher;

        public void Update(Teacher model) => _context.Teacher.Update(model);
    }
}