using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Snapp.DataAccessLayer.Entities;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;

namespace Snapp.Site.Controllers
{
    public class HumidityController : Controller
    {
        private IAdmin _admin;

        public HumidityController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetHumiditys();

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
                _admin.AddHumidity(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Humidity humidity = await _admin.GetHumidityById(id);

            MonthTypeViewModel viewModel = new MonthTypeViewModel()
            {
                End = humidity.End,
                Name = humidity.Name,
                Percent = humidity.Precent,
                Start = humidity.Start
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, MonthTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateHumidity(viewModel, id);

                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteHumidity(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
