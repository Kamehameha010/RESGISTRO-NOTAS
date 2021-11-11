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

    public class AccessController : ControllerBase
    {
        private readonly ISecurityRepository _repo;
        public AccessController(ISecurityRepository repo) => _repo = repo;

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<Security>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login(userLogin model)
        {
            return Ok(new ApiResponse<Security> { Data = await _repo.CheckUserAsync(model) });
        }
    }
}