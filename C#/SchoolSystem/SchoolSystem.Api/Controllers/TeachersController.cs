using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Api.Response;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Core.DTOs;
using SchoolSystem.Core.Entities;
using System.Threading.Tasks;
using SchoolSystem.Core.QueryFilters;

namespace SchoolSystem.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]

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
        public IActionResult GetAll() => Ok(new ApiResponse<object> { Data = _unitWork.Teachers.GetTeaches() });
        [HttpGet("courses")]
        public IActionResult GetStudentCourse([FromQuery] CourseFilter filter) => Ok(new ApiResponse<object> { Data = _unitWork.Teachers.GetCoursesbyTeacher(filter) });
        [HttpPost]
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
            return Ok(new { userDTO, teacherDTO });
        }
    }
}