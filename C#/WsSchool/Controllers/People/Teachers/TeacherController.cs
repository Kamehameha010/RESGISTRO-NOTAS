using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Entities;

namespace WsSchool.Controllers.People
{
    public class TeacherController
    {
    }

    public partial class PeopleController
    {
        [HttpGet("Teachers")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> GetTeachers()
        {
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<IEnumerable<TeacherDTO>>(await _unitWork.Teacher.GetAll()) });
        }

        [HttpPost("{id}/Teachers")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> PostTeacher(int id, TeacherDTO model)
        {
            model.PersonId = id;
            await _unitWork.Teacher.Insert(_mapper.Map<Teacher>(model));
            await _unitWork.SaveAsync();
            return Ok(new Response { Code = 1, Message = "", Data = null });
        }

        [HttpPut("Teachers/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        public async Task<IActionResult> PutTeacher(int id, TeacherDTO model)
        {
            if (id != model.TeacherId)
            {
                return BadRequest(new Response { Code = 0, Message = "Bad request", Data = null });
            }
            _unitWork.Teacher.Update(_mapper.Map<Teacher>(model));
            await _unitWork.SaveAsync();

            return Ok(new Response { Code = 1, Message = "Successful", Data = null });
        }
        [HttpGet("Teachers/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Response))]

        public async Task<IActionResult> GetTeacherById(int id)
        {
            var oTeacher = await _unitWork.Teacher.GetById(id);
            if (oTeacher is null)
            {
                return NotFound(new Response { Code = 0, Message = "Not Found", Data = null });
            }
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<TeacherDTO>(oTeacher) });

        }
    }
}
