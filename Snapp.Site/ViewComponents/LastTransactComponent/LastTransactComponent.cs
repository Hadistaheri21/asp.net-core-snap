using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Site.ViewComponents.LastTransactComponent
{
    public class LastTransactComponent : ViewComponent 
    {
        private readonly IAdmin _admin;

        public LastTransactComponent(IAdmin admin)
        {
            _admin = admin;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ViewLastTransact", await _admin.LastTransact()));
        }
    }
}
