using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Api.Response;
using SchoolSystem.Core.DTOs;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Core.QueryFilters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SchoolSystem.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public StudentsController(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<object>))]
        public IActionResult GetAll() => Ok(new ApiResponse<object> { Data = _unitWork.Students.GetStudents() });
        [HttpGet("courses")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<object>))]
        public IActionResult GetStudentCourse([FromQuery] GradebookFilter filter) => Ok(new ApiResponse<object> { Data = _unitWork.CourseGradebooks.GetGradebookByStudent(filter) });
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> Post(UserStudentDTO model)
        {
            var (userDTO, studentDTO) = model;
            var user = _mapper.Map<User>(userDTO);
            await _unitWork.Users.AddAsync(user);
            await _unitWork.SaveAsync();
            studentDTO.UserId = user.UserId;
            var student = _mapper.Map<Student>(studentDTO);

            await _unitWork.Students.AddAsync(student);
            await _unitWork.SaveAsync();
            userDTO = _mapper.Map<UserDTO>(user);
            studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(new { userDTO, studentDTO });
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> Put(UserStudentDTO model)
        {
            var (userDTO, studentDTO) = model;
            var user = _mapper.Map<User>(userDTO);

            _unitWork.Users.Update(user);
            studentDTO.UserId = user.UserId;

            var student = _mapper.Map<Student>(studentDTO);
            _unitWork.Students.Update(student);

            await _unitWork.SaveAsync();
            userDTO = _mapper.Map<UserDTO>(user);
            studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(new { userDTO, studentDTO });
        }

    }
}