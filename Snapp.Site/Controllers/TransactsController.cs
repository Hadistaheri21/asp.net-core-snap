using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;
using Snapp.Core.ViewModels;
using System.Globalization;
using Snapp.Core.Generators;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Site.Controllers
{
    public class TransactsController : Controller
    {
        private readonly IAdmin _admin;

        public TransactsController(IAdmin admin)
        {
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            List<Transact> result = await _admin.GetTransacts();

            return View(result);
        }
    }
}
