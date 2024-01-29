using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using System.Globalization;
using Snapp.Core.ViewModels;
using Snapp.Core.Generators;
using Snapp.Core.ViewModels.dashbord_admin;
using Snapp.DataAccessLayer.Entities;


namespace Snapp.Site.Controllers
{
    public class AdminController : Controller
    {
        private IAdmin _admin;
        private PersianCalendar pc = new PersianCalendar();

        public AdminController(IAdmin admin)
        {
            //تزریق وابستگی ها
            _admin = admin;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SiteSetting()
        {
            Setting setting = await _admin.GetSetting();

            SiteSettingViewModel viewModel = new SiteSettingViewModel()
            {
                Desc = setting.Desc,
                Tel = setting.Tel,
                Fax = setting.Fax,
                Name = setting.Name
            };


            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SiteSetting(SiteSettingViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                bool result = _admin.UpdateSiteSetting(viewModel);

               ViewBag.IsSuccess = result;
            }

            return View(viewModel);
        }


        public async Task<IActionResult> PriceSetting()
        {
            Setting setting = await _admin.GetSetting();

            PriceSettingViewModel viewModel = new PriceSettingViewModel()
            {
                IsDistance = setting.IsDistance,
                IsWeatherPirce=setting.IsWeatherPirce
            };


            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PriceSetting(PriceSettingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdatePriceSetting(viewModel);

                ViewBag.IsSuccess = result;
            }

            return View(viewModel);
        }


        public async Task<IActionResult> AboutSetting()
        { 
        Setting setting = await _admin.GetSetting();

            AboutSettingViewModel viewModel = new AboutSettingViewModel()
        {
            About = setting.About
        
        };


        ViewBag.IsSuccess = false;

            return View(viewModel);
    }

    [HttpPost]
    public IActionResult AboutSetting(AboutSettingViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            bool result = _admin.UpdateAboutSetting(viewModel);

            ViewBag.IsSuccess = result;
        }

        return View(viewModel);
    }


        public async Task<IActionResult> TermsSetting()
        {
            Setting setting = await _admin.GetSetting();

            TermsSettingViewModel viewModel = new TermsSettingViewModel()
            {
                Terms = setting.Terms

            };


            ViewBag.IsSuccess = false;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult TermsSetting(TermsSettingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = _admin.UpdatTermsSetting(viewModel);

                ViewBag.IsSuccess = result;
            }

            return View(viewModel);
        }


        public IActionResult weeklyFactor()
        {
            //گرفتن تاریخ روز
            string strToday = DatetimeGenarator.GetShamsiDate();

            // 0000/00/00 ....>0000=4 سال هست
            int Ayear = Convert.ToInt32(strToday.Substring(0, 4));

            int AMinth = Convert.ToInt32(strToday.Substring(5, 2));

            int Aday = Convert.ToInt32(strToday.Substring(8,2));


            string strEndDate = "";

            var Charts = new List<ChartViewModel>();

            int intM = 0;

            //  روز داریم 7

            for (int i = 0 ; i <=6 ; i++)
            {
                DateTime dtA = pc.ToDateTime(Ayear, AMinth, Aday, 0, 0, 0, 0);

                if (i==0)
                {
                    dtA = dtA.AddDays(i);
                }

                else
                {
                    //مثال  i=6 بود 6 روز کم میکند
                    intM = -i;

                    dtA = dtA.AddDays(intM);
                }

                strEndDate = pc.GetYear(dtA).ToString("0000") + "/" + pc.GetMonth(dtA).ToString("00") + "/"
                    + pc.GetDayOfMonth(dtA).ToString("00");

                ChartViewModel chart = new ChartViewModel()
                {
                    Label = strEndDate,
                    Value = _admin.weeklyFactor(strEndDate),
                    Color = ColorGenerators.SelectColorCode()
                };

                Charts.Add(chart);
            }

            return View(Charts);
        }


        public IActionResult weeklyRegister()
        {
            //گرفتن تاریخ روز
            string strToday = DatetimeGenarator.GetShamsiDate();

            // 0000/00/00 ....>0000=4 سال هست
            int Ayear = Convert.ToInt32(strToday.Substring(0, 4));

            int AMinth = Convert.ToInt32(strToday.Substring(5, 2));

            int Aday = Convert.ToInt32(strToday.Substring(8, 2));


            string strEndDate = "";

            var Charts = new List<ChartViewModel>();

            int intM = 0;

            //  روز داریم 7

            for (int i = 0; i <= 6; i++)
            {
                DateTime dtA = pc.ToDateTime(Ayear, AMinth, Aday, 0, 0, 0, 0);

                if (i == 0)
                {
                    dtA = dtA.AddDays(i);
                }

                else
                {
                    //مثال  i=6 بود 6 روز کم میکند
                    intM = -i;

                    dtA = dtA.AddDays(intM);
                }

                strEndDate = pc.GetYear(dtA).ToString("0000") + "/" + pc.GetMonth(dtA).ToString("00") + "/"
                    + pc.GetDayOfMonth(dtA).ToString("00");

                ChartViewModel chart = new ChartViewModel()
                {
                    Label = strEndDate,
                    Value = _admin.weeklyRegister(strEndDate),
                    Color = ColorGenerators.SelectColorCode()
                };

                Charts.Add(chart);
            }

            return View(Charts);
        }


        public IActionResult MonthlyFactor()
        {
            var Charts = new List<ChartViewModel>();

            for (int i = 1; i < 12; i++)
            {
                
                string strMonth = i.ToString("00");

                ChartViewModel chart = new ChartViewModel()
                {
                    Color = ColorGenerators.SelectColorCode(),
                    Label = MonthConvertor.FarsiMonth(i),
                    Value=_admin.MonthlyFactor(strMonth)
                };

                Charts.Add(chart);
            }

            return View(Charts);
        }

        public IActionResult MonthlyRegister()
        {
            var Charts = new List<ChartViewModel>();

            for (int i = 1; i < 12; i++)
            {

                string strMonth = i.ToString("00");

                ChartViewModel chart = new ChartViewModel()
                {
                    Color = ColorGenerators.SelectColorCode(),
                    Label = MonthConvertor.FarsiMonth(i),
                    Value = _admin.MonthlyRegister(strMonth)
                };

                Charts.Add(chart);
            }

            return View(Charts);
        }
    }
}
