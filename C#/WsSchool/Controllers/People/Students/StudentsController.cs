using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Entities;

namespace WsSchool.Controllers.People
{
    public class StudentsController
    {
    }

    public partial class PeopleController
    {
        [HttpGet("Students")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<IEnumerable<StudentDTO>>(await _unitWork.Student.GetAll()) });
        }

        [HttpPost("{id}/Students")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> PostStudent(int id ,StudentDTO model)
        {
            model.PersonId = id;
            await _unitWork.Student.Insert(_mapper.Map<Student>(model));
            await _unitWork.SaveAsync();
            return Ok(new Response { Code = 1, Message = "", Data = null });
        }

        [HttpPut("Students/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        public async Task<IActionResult> PutStudent(int id, StudentDTO model)
        {
            if (id != model.StudentId)
            {
                return BadRequest(new Response { Code = 0, Message = "Bad request", Data = null });
            }
            _unitWork.Student.Update(_mapper.Map<Student>(model));
            await _unitWork.SaveAsync();

            return Ok(new Response { Code = 1, Message = "Successful", Data = null });
        }
        [HttpGet("Students/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Response))]

        public async Task<IActionResult> GetStudentById(int id)
        {
            var oStudent = await _unitWork.Student.GetById(id);
            if (oStudent is null)
            {
                return NotFound(new Response { Code = 0, Message = "Not Found", Data = null });
            }
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<StudentDTO>(oStudent) });

        }
    }
}
