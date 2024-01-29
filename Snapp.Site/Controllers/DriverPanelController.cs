using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Generators;
using Snapp.Core.Securities;
using Snapp.Core.Services;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Panel;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entites;
using System.Text;
using System.Security.Cryptography;
using System.Net.Http;
using Newtonsoft.Json;
using Snapp.Core.ViewModels.Payment;
using Newtonsoft.Json.Linq;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Site.Controllers
{
    [RoleAttribute("driver")]
    public class DriverPanelController : Controller
    {
        private IPanel _panel;

        public DriverPanelController(IPanel panel)
        {
            _panel = panel;
        }

        public IActionResult Index()
        {
            User user = _panel.GetUser(User.Identity.Name);

            Transact transact = _panel.GetDriverConfrimTransact(user.Id);

            if (transact == null)
            {
                DriverPanelViewModel viewModel = new DriverPanelViewModel()
                {
                    DriverId = user.Id,
                    Status = 0,
                    Desc = "",
                    EndLat = "",
                    EndLng = "",
                    Price = 0,
                    StartLat = "",
                    StartLng = "",
                    TransactId = null,
                    UserId = null,
                    UserName = ""
                };

                return View(viewModel);
            }
            else
            {
                string username = _panel.GetUserById(transact.UserId).UserDetail.FullName;

                DriverPanelViewModel viewModel = new DriverPanelViewModel()
                {
                    DriverId = user.Id,
                    Status = transact.Status,
                    Desc = "",
                    EndLat = transact.EndLat,
                    EndLng = transact.EndLng,
                    Price = transact.Total,
                    StartLat = transact.StartLat,
                    StartLng = transact.StartLng,
                    TransactId = transact.Id,
                    UserId = transact.UserId,
                    UserName = username
                };

                return View(viewModel);

            }
        }

        public JsonResult List()
        {
            var result = _panel.GetTransactsNotAccept();

            return new JsonResult(result);
        }

        public IActionResult UpdateStatus(Guid id)
        {
            User user = _panel.GetUser(User.Identity.Name);

            _panel.UpdateStatus(id, user.Id, 1);

            return RedirectToAction("Index");
        }

        public IActionResult EndRequest(Guid id)
        {
            _panel.EndRequest(id);

            return RedirectToAction("Index");
        }
    }
}
