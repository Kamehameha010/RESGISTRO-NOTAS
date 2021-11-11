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
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IUnitWork _unitWork;
        private readonly SchoolDBContext _context;
        public UsersController(IUnitWork unitWork, IMapper mapper, SchoolDBContext context)
        {
            _unitWork = unitWork;
            _mapper = mapper;
            _context = context;
           
            _passwordService = new PasswordService();
        }
        [HttpGet]
        public IActionResult Get() => Ok();


        [HttpPost]
        public async Task<IActionResult> PostAsync(UserDTO model)
        {
            var user = _mapper.Map<User>(model);
            await _unitWork.Users.AddAsync(user);
            await _unitWork.SaveAsync();
            return Ok(new ApiResponse<UserDTO> { Data = _mapper.Map<UserDTO>(user) });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserDTO model)
        {
            var user = _mapper.Map<User>(model);
            user.Password ??= _passwordService.Encrypt(user.Password);
            _unitWork.Users.Update(user);
            _unitWork.Save();
            return Ok();
        }


    }
}