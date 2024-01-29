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
    public class ColorController : Controller
    {

        private IAdmin _admin;

        public ColorController(IAdmin admin)
        {
            //تزریق وابستگی ها

            _admin = admin;

        }
        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetColors();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminColorViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _admin.AddColor(viewModel);

                return RedirectToAction(nameof(Index)); 
            }

            return View(viewModel);
        }

        //قسمت get
        public async Task<IActionResult> Edit(Guid id)
        {
            Color color = await _admin.GetColorById(id);

            AdminColorViewModel viewModel = new AdminColorViewModel()
            {
                Code=color.Code,
                Name=color.Name
            };
             
            return View(viewModel);
        }

        //قسمت post
        [HttpPost]
        public IActionResult Edit(Guid id,AdminColorViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
               bool result= _admin.UpdateColor(viewModel, id);

                if(result)
                {
                    return RedirectToAction(nameof(Index));

                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {

            _admin.DeleteColor(id);

           return RedirectToAction(nameof(Index));
        }
    }
}
