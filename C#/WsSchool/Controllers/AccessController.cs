using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Mysql;
using WsSchool.Core.Services;

namespace WsSchool.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        //private readonly SchoolDbContext _context;
        private readonly IValidate<LoginDTO> _validate;

        public AccessController()
        {
            _validate = new ValidateUser();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        public IActionResult VerifyCredendential(LoginDTO model)
        {
            var oUser = _validate.Validate(model);

            if (oUser is null)
            {
                return BadRequest(new Response { Code = 0, Message = "Check Credentials. Try again", Data = null });
            }
            return Ok(new Response { Code = 1, Message = "", Data = oUser });
        }
    }
}
