using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snapp.DataAccessLayer.Entities;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;

namespace Snapp.Core.Scopes
{
   public class PanelScope
    {
        private readonly IPanel _panel;

        public PanelScope(IPanel panel)
        {
            _panel = panel;
        }

        public User GetUser(Guid id)
        {
            return _panel.GetUserById(id);
        }

        public Driver GetDriver(Guid id)
        {
            return _panel.GetDriverById(id);
        }
    }
}
