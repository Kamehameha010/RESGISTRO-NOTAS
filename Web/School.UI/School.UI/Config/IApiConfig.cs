using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.UI.Config
{
    public interface IApiConfig
    {
        public string BaseUrl { get; }
        public string Endpoint { get; set; }
        public string Url { get; }
    }
}
