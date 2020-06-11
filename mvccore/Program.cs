using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace mvccore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

      public static string ConsoleToke()
        {
            // 定义用户信息
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, "文明"),
                new Claim(JwtRegisteredClaimNames.Email, "1638414903@qq.com"),
            };

            // 和 Startup 中的配置一致
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcd12345689ajksajsajkjksdlksdjsd"));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "server",
                audience: "client007",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(3),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
