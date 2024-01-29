using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;


using Snapp.DataAccessLayer.Entites;
using Snapp.Core.Generators;

namespace Snapp.Site.Controllers
{
    public class DiscountController : Controller
    {
        private IAdmin _admin;

        public DiscountController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetDiscounts();

            return View(result);
        }

        public IActionResult Create()
        {
            ViewBag.MyDate = DatetimeGenarator.GetShamsiDate();

            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminDiscountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddDiscount(viewModel);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.MyDate = DatetimeGenarator.GetShamsiDate();
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _admin.GetDiscountById(id);

            AdminDiscountViewModel viewModel = new AdminDiscountViewModel()
            {
                Name = result.Name,
                Code = result.Code,
                Desc = result.Desc,
                Expire = result.Expire,
                Percent = result.Percent,
                Price = result.Price,
                Start = result.Start
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, AdminDiscountViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateDiscount(viewModel, id);

                if (result == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteDiscount(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
