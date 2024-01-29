using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;
using Snapp.DataAccessLayer.Entities;
namespace Snapp.Site.Controllers
{
    public class PriceTypeController : Controller
    {
        private IAdmin _admin;

        public PriceTypeController(IAdmin admin)
        {
            //تزریق وابستگی ها
            _admin = admin;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetPriceTypes();

            return View(result);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        public IActionResult Create(PriceTypeViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _admin.AddPriceType(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        //get
        public async Task<IActionResult> Edit( Guid id)
        {
            var result = await _admin.GetPriceTypeById(id);

            PriceTypeViewModel viewModel = new PriceTypeViewModel()
            {
                End=result.End,
                Start=result.Start,
                Name=result.Name,
                Price=result.Price
            };

            return View(viewModel);
        }

        //post
        [HttpPost]
        public IActionResult Edit(PriceTypeViewModel viewModel ,Guid id)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdatePriceType(viewModel,id);

              if(result)
                {
                return RedirectToAction(nameof(Index));

                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeletePriceType(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
