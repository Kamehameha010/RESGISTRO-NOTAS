using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.UI.Config;
using School.UI.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Utility;

namespace School.UI.Controllers
{
    public class AccessController : Controller
    {
        private readonly IApiConfig _apiConfig;
        private readonly IHttpRequest<UserDTO,AccessDTO> _httpRequest;
        public AccessController(IApiConfig apiConfig, IHttpRequest<UserDTO,AccessDTO> httpRequest)
        {
            _httpRequest = httpRequest;
            _apiConfig = apiConfig;
            _apiConfig.Endpoint = "api/v1/Access";

        }
        public IActionResult Index()
        {

           // var response = _httpRequest.Post(new AccessDTO { Username = "perd125", Password = "123"}, _apiConfig.Url).Result;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccessDTO model)
        {
           
            var response = await _httpRequest.Post(model, _apiConfig.Url);
            if (response.Data != null)
            {
                var oUser = response.Data;
                HttpContext.Session.SetString("username", oUser.Username);
                HttpContext.Session.SetInt32("username", (int)oUser.RolId);
                ViewData["rolId"] = oUser.RolId;
                ViewBag.Tos = "Feeeeeel";

                return RedirectToAction(nameof(Index), "Home");
            }
            return BadRequest(response);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View(nameof(Index));
        }
    }


}
