using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.dashbord_admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Snapp.DataAccessLayer.Entities;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using Snapp.Core.ViewModels;

namespace Snapp.Site.Controllers
{
    public class UserController : Controller
    {
        //کتابخانه ها
        private IAdmin _admin;

        private PersianCalendar Pc = new PersianCalendar();

        public UserController(IAdmin admin) 
        {
            //key license report
            StiLicense.LoadFromString("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");
            
            _admin = admin;

           
        }
        public async Task<IActionResult> Index() 
        {
            var result = await _admin.GetUsers();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(),"Id","Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel viewModel)//sabr kon bash
        {
           if(ModelState.IsValid)
            {
                _admin.AddUser(viewModel);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title",viewModel.RoleId);
            return View(viewModel);
        }


        public async Task<IActionResult> Edit(Guid id)
        {

            User user = await _admin.GetUserById(id);

            UserDetail userDetail = await _admin.GetUserDetail(id);

            UserEditViewModel viewModel = new UserEditViewModel()
            {
                RoleId = user.RoleId,
                IsActive=user.IsActive,
                Username=user.Username,
                BirthDate=userDetail.BirthDate,
                FullName=userDetail.FullName 
            };

            if(userDetail.BirthDate == null)
            {
                ViewBag.MyDate = Pc.GetYear(DateTime.Now).ToString("0000") + "/" + Pc.GetMonth(DateTime.Now).ToString("00") + "/" +
                                 Pc.GetDayOfMonth(DateTime.Now).ToString("00");
            }
            else
            {
                ViewBag.MyDate = userDetail.BirthDate;
            }


            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title" , user.RoleId);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel viewModel,Guid id)
        {
            if (ModelState.IsValid)
            {
                _admin.UpdateUser(viewModel, id);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.MyDate = viewModel.BirthDate;
            ViewBag.RoleId = new SelectList(await _admin.GetRoles(), "Id", "Title", viewModel.RoleId);
            return View(viewModel);
        }

        public IActionResult Delete(Guid id)
        {
            _admin.DeleteUser(id);

            return RedirectToAction(nameof(Index));

        }
        //get
        public async Task<IActionResult> DriverProp(Guid id)
        {
            var result = await _admin.GetDriver(id);

            DriverPropViewModel viewModel = new DriverPropViewModel()
            {
                Address = result.Address,
                AvatarName=result.Avatar,
                NationalCode=result.NationalCode,
                Tel=result.Tel,
            };

            ViewBag.IsError = false;
            ViewBag.IsSuccess = false;

            return View(viewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> DriverProp(Guid id, DriverPropViewModel viewModel)
        {
            bool Status = false;

            if(ModelState.IsValid)
            {
                 Status = _admin.UpdateDriverProp(id, viewModel);
            }

            if(Status)
            {
                ViewBag.IsError = false;
                ViewBag.IsSuccess = true;
            }
            else
            {
                ViewBag.IsError = true;
                ViewBag.IsSuccess = false;
            }
            
            var result = await _admin.GetDriver(id);

            DriverPropViewModel model = new DriverPropViewModel()
            {
                Address = result.Address,
                AvatarName = result.Avatar,
                NationalCode = result.NationalCode,
                Tel = result.Tel,
            };

            return View(model);
        }

        public async Task<IActionResult> DriverCertificate(Guid id)
        {
            var driver = await _admin.GetDriver(id);

            DriverImgViewModel model = new DriverImgViewModel()
            {
                ImgName = driver.Img,
                IsConfirm=driver.IsConfirm
            };

            ViewBag.IsSuccess = false;
            ViewBag.IsError = false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DriverCertificate(Guid id, DriverImgViewModel viewModel)
        {
            var driver = await _admin.GetDriver(id);

            bool result = false;

            if(ModelState.IsValid)
            {
              result =  _admin.UpdateDriverCertificate(id, viewModel);
            }

            if(result)
            {
                ViewBag.IsSuccess = true;
                ViewBag.IsError = false;
            }
            else
            {
                ViewBag.IsSuccess = false;
                ViewBag.IsError = true;
            }

            DriverImgViewModel model = new DriverImgViewModel()
            {
                ImgName = driver.Img,
                IsConfirm = driver.IsConfirm
            };

            return View(model);
        }

        public async Task<IActionResult> DriverCar(Guid id)
        {
            var driver = await _admin.GetDriver(id);

            DriverCarViewModel viewModel = new DriverCarViewModel()
            {
                CarCode = driver.CarCode,
                CarId=driver.CarId,
                ColorId=driver.ColorId
            };

           if (driver.CarId == null)
            {
                ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name");
            }
           else
            {
                ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name", driver.CarId);
            }


            if(driver.ColorId == null)
            {
                ViewBag.ColorId = new SelectList(await _admin.GetColors(), "Id", "Name");

            }

            else 
            {
                ViewBag.ColorId = new SelectList(await _admin.GetColors(), "Id", "Name", driver.ColorId);
            }

            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DriverCar(Guid id,DriverCarViewModel viewModel)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                result = _admin.UpdateDriverCar(id, viewModel);
            }
            if(result)
            {
                ViewBag.IsSuccess = true;
            }

            else
            {
                ViewBag.IsSuccess = false;
            }
       
            ViewBag.CarId = new SelectList(await _admin.GetCars(), "Id", "Name" , viewModel.CarId);
            ViewBag.ColorId = new SelectList(await _admin.GetColors(), "Id", "Name", viewModel.ColorId);

            return View(viewModel);
        }


        public IActionResult ShowPrint()
        {
            return View("ShowPrint");
        }
        
        public IActionResult Print()
        {
            StiReport report = new StiReport();

            report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/reports/Report2.mrt"));

            var users = _admin.GetUsers().Result;

            List<Report2ViewModel> report2s = new List<Report2ViewModel>();

            foreach (var item in users)
            {
                Report2ViewModel report2 = new Report2ViewModel()
                {
                    NationalCode = "ندارد",
                    BirthDate = item.UserDetail.BirthDate,
                    FullName = item.UserDetail.FullName,
                    Username = item.Username
                };

                report2s.Add(report2);
            }

            report.RegData("dt2", report2s);
            return StiNetCoreViewer.GetReportResult(this, report);
        }

        public IActionResult ViewerEvent()
        {
            return StiNetCoreViewer.ViewerEventResult(this);
        }
    }
}
