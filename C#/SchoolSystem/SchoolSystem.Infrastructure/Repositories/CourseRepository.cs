using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Enumerations;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;

namespace SchoolSystem.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolDBContext _context;
        public CourseRepository(SchoolDBContext context) => _context = context;
        public async Task AddAsync(Course model) => await _context.Course.AddAsync(model);

        public async Task DeleteAsync(int id)
        {
            var course = await FindAsync(id);
            if (course is null)
            {
                throw new NullReferenceException("Not Found course");
            }
            course.CourseStatusId = (int?)CourseState.CLOSE;
        }

        public async Task<Course> FindAsync(int id) => await _context.Course.FindAsync(id);

        public IEnumerable<Course> GetCourses() => _context.Course;

        public void Update(Course model) => _context.Course.Update(model);
    }
}