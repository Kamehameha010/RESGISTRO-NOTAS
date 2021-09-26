using Microsoft.AspNetCore.Mvc;
using System.Net;
using WsSchool.Core.Interfaces;
using WsSchool.Core.Models;
using WsSchool.Core.Models.DTOs;

namespace WsSchool.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        //private readonly SchoolDbContext _context;
        private readonly IValidate _validate;

        public AccessController( IValidate validate)
        {
            _validate = validate;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Response))]
        public IActionResult VerifyCredendential(AccessDTO model)
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
