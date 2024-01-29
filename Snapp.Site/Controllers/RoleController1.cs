using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Snapp.DataAccessLayer.Entities;

using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.dashbord_admin;
using Snapp.Core.Services;

namespace Snapp.Site.Controllers
{
    public class RoleController : Controller
    {
        private IAdmin _admin;

        public RoleController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetRoles();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddRole(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _admin.GetRoleById(id);

            RoleViewModel roleView = new RoleViewModel()
            {
                Name = result.Name,
                Title = result.Title
            };

            return View(roleView);
        }

        [HttpPost]
        public IActionResult Edit(RoleViewModel viewModel, Guid id)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateRole(viewModel, id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteRole(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
