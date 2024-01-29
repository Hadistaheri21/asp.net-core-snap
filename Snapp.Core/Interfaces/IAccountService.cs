using System;
using System.Threading.Tasks;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entities;

namespace Snapp.Core.Interfaces
{
    public interface IAccountService :IDisposable
    {
        bool CheckMobileNumber(string Username);

        Task<User> RegisterUser(RegisterViewModel viewModel);

        Task<User> RegisterDriver(RegisterViewModel viewModel);

        Guid GetRoleByName(string name);

        Task<User> GetUser(string username);

        void UpdateUserPasssword(Guid Id, string code);

        Task<User> ActiveUser(ActiveViewModle viewModle);

        bool CheckUserRole(string role, string username);
    }
}
