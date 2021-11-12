using System;
using System.Collections.Generic;
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
        public IActionResult GetAll()
        {
            var courses = _mapper.Map<IEnumerable<CourseDTO>>(_unitWork.Courses.GetCourses());
            return Ok(new ApiResponse<IEnumerable<CourseDTO>> { Data = courses });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = _mapper.Map<CourseDTO>(await _unitWork.Courses.FindAsync(id));

            return Ok(new ApiResponse<CourseDTO> { Data = course });
        }

        [HttpPost]
        public async Task<IActionResult> Post(CourseDTO model)
        {
            var course = _mapper.Map<Course>(model);
            await _unitWork.Courses.AddAsync(course);
            await _unitWork.SaveAsync();
            return Ok(_mapper.Map<CourseDTO>(course));
        }

        [HttpPut]
        public async Task<IActionResult> Put(CourseDTO model)
        {
            var course = _mapper.Map<Course>(model);
            _unitWork.Courses.Update(course);
            await _unitWork.SaveAsync();
            return Ok(_mapper.Map<CourseDTO>(course));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"{nameof(id)} is empty");
            }
            await _unitWork.Courses.DeleteAsync((int)id);
            await _unitWork.SaveAsync();
            return NoContent();
        }
    }
}