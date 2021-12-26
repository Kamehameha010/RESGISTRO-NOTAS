using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Api.Response;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Core.DTOs;
using SchoolSystem.Core.Entities;
using System.Threading.Tasks;
using SchoolSystem.Core.QueryFilters;
using System;
using System.Collections;
using System.Net;

namespace SchoolSystem.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public TeachersController(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<object>))]
        public IActionResult GetAll() => Ok(new ApiResponse<object> { Data = _unitWork.Teachers.GetTeachers() });
        [HttpGet("courses")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<object>))]
        public IActionResult GetStudentCourse([FromQuery] GradebookFilter filter) => Ok(new ApiResponse<object> { Data = _unitWork.Teachers.GetCoursesbyTeacher(filter) });
        [HttpGet("gradebook")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable>))]
        public IActionResult GetGradebook([FromQuery] GradebookFilter filter)
        {
            return Ok(new ApiResponse<IEnumerable> { Data = _unitWork.CourseGradebooks.GetGradebookByTeacher(filter) });
        }
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> Post(UserTeacherDTO model)
        {
            var (userDTO, teacherDTO) = model;
            var user = _mapper.Map<User>(userDTO);

            await _unitWork.Users.AddAsync(user);
            await _unitWork.SaveAsync();
            teacherDTO.UserId = user.UserId;

            var teacher = _mapper.Map<Teacher>(teacherDTO);

            await _unitWork.Teachers.AddAsync(teacher);
            await _unitWork.SaveAsync();
            userDTO = _mapper.Map<UserDTO>(user);
            teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            return Ok(new { userDTO, teacherDTO });
        }
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> Put(UserTeacherDTO model)
        {
            var (userDTO, teacherDTO) = model;
            var user = _mapper.Map<User>(userDTO);

            _unitWork.Users.Update(user);
            teacherDTO.UserId = user.UserId;

            var teacher = _mapper.Map<Teacher>(teacherDTO);
            _unitWork.Teachers.Update(teacher);
            await _unitWork.SaveAsync();

            userDTO = _mapper.Map<UserDTO>(user);
            teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            return NoContent();
        }


    }
}