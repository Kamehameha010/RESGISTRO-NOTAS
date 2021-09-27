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
    public class GradeBooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public GradeBooksController(IMapper mapper, IUnitWork work)
        {
            _mapper = mapper;
            _unitWork = work;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<IEnumerable<GradeBookDTO>>(await _unitWork.GradeBook.GetAll()) });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> Post(GradeBookDTO model)
        {
            await _unitWork.GradeBook.Insert(_mapper.Map<Gradebook>(model));
            await _unitWork.SaveAsync();
            return Ok(new Response { Code = 1, Message = "", Data = null });
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        public async Task<IActionResult> Put(int id, GradeBookDTO model)
        {
            if (id != model.GradebookId)
            {
                return BadRequest(new Response { Code = 0, Message = "Bad request", Data = null });
            }
            _unitWork.GradeBook.Update(_mapper.Map<Gradebook>(model));
            await _unitWork.SaveAsync();

            return Ok(new Response { Code = 1, Message = "Successful", Data = null });
        }
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Response))]

        public async Task<IActionResult> GetById(int id)
        {
            var oGradeBook = await _unitWork.GradeBook.GetById(id);
            if (oGradeBook is null)
            {
                return NotFound(new Response { Code = 0, Message = "Not Found", Data = null });
            }
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<GradeBookDTO>(oGradeBook) });

        }
    }
}
