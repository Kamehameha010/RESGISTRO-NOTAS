using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Api.Response;
using SchoolSystem.Core.Entities;
using SchoolSystem.Core.Interfaces;

namespace SchoolSystem.Api.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccessController : ControllerBase
    {
        private readonly ISecurityRepository _repo;
        public AccessController(ISecurityRepository repo) => _repo = repo;

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Security>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> Login(UserLogin model)
        {
            var user = await _repo.CheckUserAsync(model);
            if (user != null)
            {
                return Ok(new ApiResponse<Security> { Data = user });
            }
            return NotFound(new ApiResponse<object> { Message = "Check credentials. Try again" });
        }
    }
}