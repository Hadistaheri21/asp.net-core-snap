using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;
using Snapp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;

namespace Snapp.Site.Controllers
{
    public class CarController : Controller
    {
        private IAdmin _admin;

        public CarController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _admin.GetCars();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _admin.AddCar(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _admin.GetCarById(id);

            CarViewModel viewModel = new CarViewModel()
            {
                Name = result.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, CarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdateCar(id, viewModel);

                if (result == true)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteCar(id);

            //if (result == true)
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ImportFile()
        {
            return View();
        }

        public async Task<IActionResult> Import(IFormFile file)
        {
            //خودم اضافه کردم که ثبت ماشین از اکسل انجام بشه آموزش این کد را نداشت
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (file != null)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);

                    using var package = new ExcelPackage(stream);
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int i = 2; i <= rowCount; i++)
                    {
                        CarViewModel viewModel = new()
                        {
                            Name = worksheet.Cells[i, 1].Value.ToString().Trim()
                        };

                        _admin.AddCar(viewModel);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(ImportFile));
            }
        }
    }
}
