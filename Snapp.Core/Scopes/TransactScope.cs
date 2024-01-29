using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.Services;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Core.Scopes
{
   public class TransactScope
    {
        private readonly IAdmin _admin;

        public TransactScope(IAdmin admin)
        {
            _admin = admin;
        }

        public User GetUserById(Guid id)
        {
            return _admin.GetUserById(id).Result;
        }
    }
}
