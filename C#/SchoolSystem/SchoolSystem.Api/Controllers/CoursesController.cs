using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Api.Response;
using SchoolSystem.Core.DTOs;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;

namespace SchoolSystem.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CoursesController(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CourseDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll()
        {
            var courses = _mapper.Map<IEnumerable<CourseDTO>>(_unitWork.Courses.GetCourses());
            return Ok(new ApiResponse<IEnumerable<CourseDTO>> { Data = courses });
        }
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CourseDTO>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var course = _mapper.Map<CourseDTO>(await _unitWork.Courses.FindAsync(id));
            if (course != null)
            {
                return NotFound();
            }
            return Ok(new ApiResponse<CourseDTO> { Data = course });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CourseDTO>))]
        public async Task<IActionResult> Post(CourseDTO model)
        {
            var course = _mapper.Map<Course>(model);
            await _unitWork.Courses.AddAsync(course);
            await _unitWork.SaveAsync();
            return Ok(_mapper.Map<CourseDTO>(course));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<CourseDTO>))]
        public async Task<IActionResult> Put(CourseDTO model)
        {
            var course = _mapper.Map<Course>(model);
            _unitWork.Courses.Update(course);
            await _unitWork.SaveAsync();
            return Ok(_mapper.Map<CourseDTO>(course));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitWork.Courses.DeleteAsync(id);
                await _unitWork.SaveAsync();
                return NoContent();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}