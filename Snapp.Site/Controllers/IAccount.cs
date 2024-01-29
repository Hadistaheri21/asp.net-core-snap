using Snapp.Core.Services;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace Snapp.Site.Controllers
{
    internal interface IAccount
    {
        Task<User> RegisterUser(RegisterViewModel viewModel);
        Task<User> RegisterDriver(RegisterViewModel viewModel);
        Task<User> ActiveUser(ActiveViewModel viewModel);
    }
}