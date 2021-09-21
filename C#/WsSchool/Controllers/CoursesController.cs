using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WsSchool.Core.Models;
using WsSchool.Core.Models.Mysql;

namespace WsSchool.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        public CoursesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/Courses
        [HttpGet]
        public async Task<ActionResult<Response>> GetCourse()
        {
            return new Response { Code = 1, Message = "", Data = await _context.Course.ToListAsync() };
        }


        // GET: api/v1/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);

            if (course == null)
            {
                return new Response { Code = 0, Message = "Not Found Course", Data = null };
            }
            return new Response { Code = 0, Message = "", Data = null };
        }

        // PUT: api/v1/Courses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCourseAsync(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return new Response { Code = 0, Message = "", Data = null };
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return new Response { Code = 0, Message = "Not Found Id", Data = null };
                }
                else
                {
                    return new Response { Code = 0, Message = "Error try again later", Data = null };
                }
            }

            return new Response { Code = 1, Message = "", Data = null };
        }

        // POST: api/v1/Courses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Response>> PostCourseAsync(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return new Response { Code = 1, Message = "SuccessFul Insert", Data = null };
        }

        // DELETE: api/v1/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteCourseAsync(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return new Response { Code = 0, Message = "Not Found Id", Data = null };
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return new Response { Code = 0, Message = "Successful Delete", Data = null }; ;
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
