using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WitWebAPI.Controllers
{
    [Route("auth/")]
    public class LoginController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }

        [Route("mobile/")]
        [HttpPost]
        public string MobileAuth()
        {
            return string.Empty;
        }
    }
}
