using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace mvccore.Controllers
{
    //[Authorize] 特性用于标识此 Controller 或 Action 需要使用合规的 Token 才能登录
    [Route("api/[Controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        [Authorize]
        [HttpGet("get")]
        public string Get()
        {
            return "访问成功";
        }

        [HttpGet("Token")]
        public string Token()
        {
           return Program.ConsoleToke();
        }

    }
}
