using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.Services;
using Snapp.Core.ViewModels.Panel;
namespace Snapp.Core.Interfaces
{
   public interface IPanel : IDisposable
    {
        Task<UserDetail> GetUserDetail(string username);

        string GetRoleName(string username);

        Guid GetUserId(string username);

        User GetUser(string username);

        User GetUserById(Guid id);

        Driver GetDriverById(Guid id);


        //برای پروفایل
        //چون میخایم پیفامی براش بفرسیم از bool استفاده میکنیم
        bool UpdateUserDetailsProfile(Guid id,UserDetailProfileViewModel viewModel);

        long GetPriceType(double id);
        float GetTempPercent(double id);
        float GetHumidityPercent(double id);


        #region Addresses

        Task<List<UserAddresse>> GetUserAddresses(Guid id);
        void AddAddress(Guid id, UserAddresseViewModel viewModel);

        #endregion

        #region payment

        void AddFactor(Factor factor);
        bool UpdateFactor(Guid userid,string ordernNumber,long Price);

       Guid GetFactorById(string ordernumber);
       void UpdatePayment(Guid id,string date,string time,string desc,string bank,string trac,string refid);
       Task<Factor> GetFactor(Guid id);
        #endregion

        #region Transact

        void AddTransact(Transact model);
        void UpdatePayment(Guid id);
        void UpdateRate(Guid id, int rate);
        Task<Transact> GetTransactById(Guid id);
        Task<List<Transact>> GetUserTransacts(Guid id);
        Task<List<Transact>> GetDriverTransacts(Guid id);
        void UpdateDriver(Guid id, Guid driverId);
        void UpdateDriverRate(Guid id, bool rate);
        void UpdateStatus(Guid id, Guid? driverId, int status);

        List<Transact> GetTransactsNotAccept();

        Guid? ExistsUserTransacts(Guid id);

        Transact GetUserTransact(Guid id);

        #endregion

        #region Request

        Transact GetDriverConfrimTransact(Guid id);
        Transact GetUserConfrimTransact(Guid id);
        void EndRequest(Guid id);
        //نظرسنجی
        void AddRate(Guid id, int rate);

        #endregion
    }
}
