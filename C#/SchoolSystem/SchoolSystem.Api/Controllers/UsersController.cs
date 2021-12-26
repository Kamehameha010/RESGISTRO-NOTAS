using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Api.Response;
using SchoolSystem.Core.DTOs;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;
using SchoolSystem.Infrastructure.Data;
using SchoolSystem.Infrastructure.Interfaces;
using SchoolSystem.Infrastructure.Services;

namespace SchoolSystem.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IUnitWork _unitWork;
        public UsersController(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
            _passwordService = new PasswordService();
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Get() => Ok();
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK) ]
        public async Task<IActionResult> Post(UserDTO model)
        {
            var user = _mapper.Map<User>(model);
            await _unitWork.Users.AddAsync(user);
            await _unitWork.SaveAsync();
            return Ok(new ApiResponse<UserDTO> { Data = _mapper.Map<UserDTO>(user) });
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Put(UserDTO model)
        {
            var user = _mapper.Map<User>(model);
            user.Password ??= _passwordService.Encrypt(user.Password);
            _unitWork.Users.Update(user);
            _unitWork.Save();
            return NoContent();
        }


    }
}