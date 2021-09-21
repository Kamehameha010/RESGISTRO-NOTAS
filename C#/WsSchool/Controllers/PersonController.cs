using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models;
using WsSchool.Core.Models.Mysql;
using WsSchool.Core.Repository;

namespace WsSchool.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly UnitWork _unitWork;

        public PersonController(SchoolDbContext context)
        {
            _context = context;
            _unitWork = new UnitWork(_context);

        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            return new Response { Code = 1, Message = "", Data = await _unitWork.Person.GetAll() };
        }

        [HttpPost]
        public ActionResult<Response> Post(Person model)
        {
            _unitWork.Person.Insert(model);
            return new Response { Code = 1, Message = "", Data = null };
        }

        [HttpPut("{id}")]
        public ActionResult<Response> Put(int id, Person model)
        {
            if (id != model.PersonId)
            {
                return new Response { Code = 0, Message = "", Data = null };
            }
            _unitWork.Person.Update(id, model);
            return new Response { Code = 1, Message = "", Data = null };
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            var oPerson = await _unitWork.Person.GetById(id);
            if (oPerson is null)
            {
                return new Response { Code = 0, Message = "Not Exists", Data = null };
            }
            return new Response { Code = 0, Message = "", Data = oPerson };

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            try
            {
                await _unitWork.Person.Delete(id);
                return new Response { Code = 1, Message = "", Data = null };
            }
            catch (Exception)
            {
                return new Response { Code = 0, Message = "Not Exists", Data = null };
            }

        }
    }
}
