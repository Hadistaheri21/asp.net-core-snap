using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Snapp.Core.Security;
using Snapp.DataAccessLayer.Entities; 
namespace Snapp.Core.Securities
{
    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IAccountService _account;
        private string _roleName;

        public RoleAttribute(string roleName)
        {
            _roleName = roleName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string username = context.HttpContext.User.Identity.Name;
                _account = (IAccountService)context.HttpContext.RequestServices.GetService(typeof(IAccountService));

                if (!_account.CheckUserRole(_roleName, username))
                {
                    context.Result = new RedirectResult("/Account/Register");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Register");
            }
        }
    }
}
