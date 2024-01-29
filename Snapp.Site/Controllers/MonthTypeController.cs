using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;

namespace Snapp.Site.Controllers
{
    public class MonthTypeController : Controller
    {
        private IAdmin _admin;

        public MonthTypeController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetMonthTypes();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddMonthType(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var month = await _admin.GetMonthTypeById(id);

            MonthTypeViewModel viewModel = new MonthTypeViewModel()
            {
                End = month.End,
                Name = month.Name,
                Percent = month.Precent,
                Start = month.Start
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MonthTypeViewModel viewModel, Guid id)
        {
            if (ModelState.IsValid)
            {
                var result = _admin.UpdateMonthType(viewModel, id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteMonthType(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
