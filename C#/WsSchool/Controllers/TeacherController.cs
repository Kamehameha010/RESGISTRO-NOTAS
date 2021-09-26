using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Entities;

namespace WsSchool.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public TeacherController(IMapper mapper, IUnitWork work)
        {
            _mapper = mapper;
            _unitWork = work;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<IEnumerable<TeacherDTO>>(await _unitWork.Teacher.GetAll()) });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> Post(TeacherDTO model)
        {
            await _unitWork.Teacher.Insert(_mapper.Map<Teacher>(model));
            await _unitWork.SaveAsync();
            return Ok(new Response { Code = 1, Message = "", Data = null });
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        public async Task<IActionResult> Put(int id, TeacherDTO model)
        {
            if (id != model.TeacherId)
            {
                return BadRequest(new Response { Code = 0, Message = "Bad request", Data = null });
            }
            _unitWork.Teacher.Update(_mapper.Map<Teacher>(model));
            await _unitWork.SaveAsync();

            return Ok(new Response { Code = 1, Message = "Successful", Data = null });
        }
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Response))]

        public async Task<IActionResult> GetById(int id)
        {
            var oTeacher= await _unitWork.Teacher.GetById(id);
            if (oTeacher is null)
            {
                return NotFound(new Response { Code = 0, Message = "Not Found", Data = null });
            }
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<TeacherDTO>(oTeacher) });

        }
    }
}
