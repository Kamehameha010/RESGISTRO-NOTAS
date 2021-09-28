using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace School.UI.Config
{
    public class ApiConfig : IApiConfig
    {

        private readonly IConfiguration _configuration;
        public ApiConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BaseUrl { get => _configuration.GetSection("ApiConfig")["BaseUrl"]; }

        public string Endpoint { get; set; }
        public string Url => new UriBuilder(BaseUrl) { Path = Endpoint }.ToString();
    }

}
