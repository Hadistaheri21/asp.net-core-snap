using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Snapp.Core.interfaces;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.Securities;

namespace Snapp.Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
      
        //[Authorize]
        //public IActionResult StartUser()
        //{
        //    return Content("Login Success");
        //}
       
        //[RoleAttribute("user")]
        //public IActionResult UserPanel()
        //{
        //    return Content("Hi User");
        //}

        //[RoleAttribute("driver")]
        //public IActionResult DriverPanel()
        //{
        //    return Content("Hi Driver");
        //}


        public IActionResult Demo()
        {
            return View();
        }
    }
}
        
