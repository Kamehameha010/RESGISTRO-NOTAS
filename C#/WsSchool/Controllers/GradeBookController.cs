using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.Entities;
using WsSchool.Core.Models.Mysql;
using WsSchool.Core.Repository;

namespace WsSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeBookController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly UnitWork _unitWork;

        public GradeBookController(SchoolDbContext context)
        {
            _context = context;
            _unitWork = new UnitWork(_context);

        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            return new Response { Code = 1, Message = "", Data = await _unitWork.GreadeBook.GetAll() };
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Gradebook model)
        {
            _unitWork.GreadeBook.Insert(model);
            await _unitWork.SaveAsync();
            return new Response { Code = 1, Message = "", Data = null };
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Put(int id, Gradebook model)
        {
            if (id != model.GradebookId)
            {
                return new Response { Code = 0, Message = "", Data = null };
            }
            _unitWork.GreadeBook.Update(model);
            await _unitWork.SaveAsync();

            return new Response { Code = 1, Message = "", Data = null };
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            var oGradebook = await _unitWork.GreadeBook.GetById(id);
            if (oGradebook is null)
            {
                return new Response { Code = 0, Message = "Not Exists", Data = null };
            }
            return new Response { Code = 0, Message = "", Data = oGradebook };

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            try
            {
                await _unitWork.GreadeBook.Delete(id);
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
