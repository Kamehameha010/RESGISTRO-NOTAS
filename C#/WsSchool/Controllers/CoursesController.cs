using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.Entities;
using WsSchool.Core.Models.Mysql;
using WsSchool.Core.Repository;

namespace WsSchool.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly UnitWork _unitWork;

        public CoursesController(SchoolDbContext context)
        {
            _context = context;
            _unitWork = new UnitWork(_context);

        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            return new Response { Code = 1, Message = "", Data = await _unitWork.Course.GetAll() };
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Course model)
        {
            _unitWork.Course.Insert(model);
            await _unitWork.SaveAsync();
            return new Response { Code = 1, Message = "", Data = null };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(int id, Course model)
        {
            if (id != model.CourseId)
            {
                return new Response { Code = 0, Message = "", Data = null };
            }
            _unitWork.Course.Update(model);
            await _unitWork.SaveAsync();

            return new Response { Code = 1, Message = "", Data = null };
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            var oCourse = await _unitWork.Course.GetById(id);
            if (oCourse is null)
            {
                return new Response { Code = 0, Message = "Not Exists", Data = null };
            }
            return new Response { Code = 0, Message = "", Data = oCourse };

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            try
            {
                await _unitWork.Course.Delete(id);
                await _unitWork.SaveAsync();
                return new Response { Code = 1, Message = "", Data = null };
            }
            catch (Exception)
            {
                return new Response { Code = 0, Message = "Not Exists", Data = null };
            }

        }
    }
}
