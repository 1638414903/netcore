using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mvccore.Views.bootstrap
{
    public class boostrapIndexController : Controller
    {
        public IActionResult boostrapIndex()
        {

            ViewBag.aa = "a";
            return View();
        }

        public IActionResult Index()
        {      
            return View();
        }
    }
}
