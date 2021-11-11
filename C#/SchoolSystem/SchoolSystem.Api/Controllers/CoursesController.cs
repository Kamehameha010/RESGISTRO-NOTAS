using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Core.DTOs;

namespace SchoolSystem.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CoursesController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Insert(CourseDTO model){

            return Ok(model);
        }
    }
}