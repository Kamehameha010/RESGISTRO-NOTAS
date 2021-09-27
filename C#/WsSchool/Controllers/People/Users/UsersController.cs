using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Entities;

namespace WsSchool.Controllers.People
{

    public class UsersController
    {

    }


    public partial class PeopleController
    {
        [HttpGet("Users")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<IEnumerable<UserDTO>>(await _unitWork.User.GetAll()) });
        }

        [HttpPost("{id}/Users")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        public async Task<IActionResult> PostUser(int id, UserDTO model)
        {
            model.PersonId = id;
            var oUser = _mapper.Map<User>(model);
            await _unitWork.User.Insert(oUser);
            await _unitWork.SaveAsync();
            return Ok(new Response { Code = 1, Message = "", Data = oUser });
        }

        [HttpPut("Users/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        public async Task<IActionResult> PutUser(int id, UserDTO model)
        {
            if (id != model.UserId)
            {
                return BadRequest(new Response { Code = 0, Message = "Bad request", Data = null });
            }
            _unitWork.User.Update(_mapper.Map<User>(model));
            await _unitWork.SaveAsync();

            return Ok(new Response { Code = 1, Message = "Successful", Data = null });
        }
        [HttpGet("Users/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(Response))]

        public async Task<IActionResult> GetUserById(int id)
        {
            var oLogin = await _unitWork.User.GetById(id);
            if (oLogin is null)
            {
                return NotFound(new Response { Code = 0, Message = "Not Found", Data = null });
            }
            return Ok(new Response { Code = 1, Message = "", Data = _mapper.Map<UserDTO>(oLogin) });

        }

    }

}
