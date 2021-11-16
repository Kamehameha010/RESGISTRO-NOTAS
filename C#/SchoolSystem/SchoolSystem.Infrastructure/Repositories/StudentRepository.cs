using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Core.QueryFilters;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDBContext _context;
        public StudentRepository(SchoolDBContext context) => _context = context;
        public async Task AddAsync(Student model) => await _context.Student.AddAsync(model);
        public async Task<Student> FindAsync(int id) => await _context.Student.FindAsync(id);

        public IEnumerable GetStudentCourse(CourseFilter filter)
        {

            var students = _context.ViewStudent.AsQueryable();

            if (filter.StudentId != null)
            {
                students = students.Where(x => x.StudentId == filter.StudentId);
            }

            if (!String.IsNullOrEmpty(filter.Name))
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
        public IEnumerable<ViewStudentUser> GetStudents() => _context.ViewStudent.AsEnumerable();

        public void Update(Student model) => _context.Student.Update(model);

    }
}