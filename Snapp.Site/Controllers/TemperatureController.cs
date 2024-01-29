using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;


namespace Snapp.Site.Controllers
{
    public class TemperatureController : Controller
    {
        private IAdmin _admin;

        public TemperatureController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetTemperatures();

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
                _admin.AddTemperature(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Temperature temperature = await _admin.GetTemperatureById(id);

            MonthTypeViewModel viewModel = new MonthTypeViewModel()
            {
                End = temperature.End,
                Name = temperature.Name,
                Percent = temperature.Precent,
                Start = temperature.Start
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateTemperature(viewModel, id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteTemperature(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
