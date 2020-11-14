
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class HttpContextAccessor : IHttpContextAccessor
    {
        public HttpContextAccessor() { }

        public HttpContext HttpContext { get; set; }
    }
}
