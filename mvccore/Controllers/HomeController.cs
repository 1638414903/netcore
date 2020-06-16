using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;
using mvccore.Models;

namespace mvccore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new ErrorViewModel();
            model.RequestId = "999";
            ViewBag.aa = "张三";
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ceshi()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(Users model)
        {
            if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.PassWord))
            {

                return Content("<script>alert('账号或密码不能为空！');history.go(-1);</script>");

            }
            if (model.UserName == "1" && model.PassWord == "1")
            {

                //return new RedirectResult("privacy");
                return Ok("/boostrapIndex/boostrapIndex");
                //return RedirectToAction("boostrapIndex", "boostrapIndex");
                //return RedirectToPage("home/privacy");
                //return RedirectToAction("privacy");
                //HttpContext.Response.Redirect("./home/privacy");
                //return "成功";
            }
            else
            {
                return Content("<script>alert('账号或密码错误！！！');history.go(-1);</script>");
            }
        }

        public class Users
        {
            public string UserName { get; set; }
            public string PassWord { get; set; }
        }    
    }
}
