using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthDebug
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TestController
    {
        [HttpGet]
        public string Test()
        {
            return "Hello World!";
        }
    }
}