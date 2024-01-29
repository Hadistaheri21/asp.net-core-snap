using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
namespace Snapp.Core.Scopes
{
    public class SiteLayoutScope
    {
        private IPanel _panel;

        public SiteLayoutScope(IPanel panel)
        {
            _panel = panel;
        }

        public string GetUserRole(string username)
        {
            return _panel.GetRoleName(username);
        }
    }
}
