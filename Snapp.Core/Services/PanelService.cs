using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.ViewModels.Panel;
using Snapp.Core.Generators;
namespace Snapp.Core.Services
{
    public class PanelService : IPanel
    {
        private SnappDbContext _context;

        public PanelService(SnappDbContext context)
        {
            _context = context;
        }

        public void AddAddress(Guid id, UserAddresseViewModel viewModel)
        {
            UserAddresse addresse = new UserAddresse()
            {
                Desc=viewModel.Desc,
                Id=CodeGenerator.Getid(),
                Lat=viewModel.Lat,
                Lng=viewModel.Lng,
                Title=viewModel.Title,
                UserId=id,

            };

            _context.UserAddresses.Add(addresse);
            _context.SaveChanges();
        }

        public void AddFactor(Factor factor)
        {
            _context.Factors.Add(factor);
            _context.SaveChanges();
        }

        public void AddTransact(Transact model)
        {
            _context.Transacts.Add(model);
            _context.SaveChanges();
        }

        public void Dispose()
        {
           if(_context != null)
            {
                _context.Dispose();
            }
        }

        public Guid? ExistsUserTransacts(Guid id)
        {

            //0==create
            //1=driver tayed shodeh
            //2=success
            //3=cancel
            Transact transact = _context.Transacts.FirstOrDefault(x => x.UserId ==id && (x.Status ==0 || x.Status ==1 || x.Status==0));

            if (transact !=null)
            {
                return transact.Id;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Transact>> GetDriverTransacts(Guid id)
        {
            return await _context.Transacts.Where(x => x.DriverId == id && x.Status == 2)
                .OrderByDescending(x => x.Date).ToListAsync();
        }

        public async Task<Factor> GetFactor(Guid id)
        {
            return await _context.Factors.FindAsync(id);
        }

        public Guid GetFactorById(string ordernumber)
        {
            return _context.Factors.SingleOrDefault(f => f.OrderNumber == ordernumber).Id;
        }

        public float GetHumidityPercent(double id)
        {
            var hum = _context.Humidities.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (hum == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(hum.Precent / 100);
            }
        }

        public long GetPriceType(double id)
        {
            var PriceType = _context.PriceTypes.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (PriceType == null)
            {
                return 0;
            }
            else
            {
                return PriceType.Price;
            }
        }

        public string GetRoleName(string username)
        {
            return _context.Users.Include(u => u.Role).SingleOrDefault(u => u.Username == username).Role.Name;
        }

        public float GetTempPercent(double id)
        {
            var temp = _context.Temperatures.FirstOrDefault(x => x.End >= id && x.Start <= id);

            if (temp == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToSingle(temp.Precent / 100);
            }
        }

        public async Task<Transact> GetTransactById(Guid id)
        {
            return await _context.Transacts.FindAsync(id);
        }

        public User GetUser(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public async Task<List<UserAddresse>> GetUserAddresses(Guid id)
        {
            return await _context.UserAddresses.Where(a => a.UserId == id).ToListAsync();
        }

        public async Task<UserDetail> GetUserDetail(string username)
        {
            return await _context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.Username == username);
        }

        public Guid GetUserId(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username).Id;
        }

        public  async Task<List<Transact>> GetUserTransacts(Guid id)
        {
            return await _context.Transacts.Where(x => x.UserId == id && x.Status == 2)
                .OrderByDescending(x => x.Date).ToListAsync();
        }

        public Transact GetUserTransact(Guid id)
        {
            return _context.Transacts.Find(id);
        }

        public void UpdateDriver(Guid id, Guid driverId)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.DriverId = driverId;

            _context.SaveChanges();
        }

        public void UpdateDriverRate(Guid id, bool rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.DriverRate = rate;

            _context.SaveChanges();
        }

        public bool UpdateFactor(Guid userid, string ordernNumber, long Price)
        {
            Factor factor = _context.Factors.SingleOrDefault(f => f.UserId == userid && f.BankName == null);

            if (factor !=null)
            {
                factor.OrderNumber = ordernNumber;
                factor.Price = Convert.ToInt32(Price);

                _context.SaveChanges();

                return true;
            }

            return false;
        }
        
        public void UpdatePayment(Guid id, string date, string time, string desc, string bank, string trac, string refid)
        {
            Factor factor = _context.Factors.Find(id);
            User user = _context.Users.Find(factor.UserId);

            factor.Date = DatetimeGenarator.GetShamsiDate();
            factor.Time = DatetimeGenarator.GetShamsiTime();
            factor.Desc = desc;
            factor.TraceNumber = trac;
            factor.BankName = bank;
            factor.RefNumber = refid;

            user.wallet += factor.Price;

            _context.SaveChanges();
        }

        public void UpdatePayment(Guid id)
        {
           
        }

        public void UpdateRate(Guid id, int rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Rate = rate;

            _context.SaveChanges();
        }
      
        public bool UpdateUserDetailsProfile(Guid id, UserDetailProfileViewModel viewModel)
        {
            UserDetail user = _context.UserDetails.Find(id);

            if(user !=null)
            {
                //اگه پیدا شد ویرایش کن

                user.FullName = viewModel.FullName;
                user.BirthDate = viewModel.BirthDate;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.Include(x => x.UserDetail).FirstOrDefault(x => x.Id == id);
        }
        
        public Driver GetDriverById(Guid id)
        {
            return _context.Drivers.Include(x => x.Car).Include(x => x.Color).FirstOrDefault(x => x.UserId == id);
        }

        public List<Transact> GetTransactsNotAccept()
        {
            return _context.Transacts.Where(x => x.Status == 0).OrderByDescending(x => x.Date).ToList();
        }

        public Transact GetDriverConfrimTransact(Guid id)
        {
            // این جدول برای چی هست ؟  
            return _context.Transacts.FirstOrDefault(x => x.DriverId == id && x.Status == 1);
        }

        public Transact GetUserConfrimTransact(Guid id)
        {
            return _context.Transacts.FirstOrDefault(x => x.UserId == id && x.Status == 1);
        }

        public void EndRequest(Guid id)
        {
            Transact transact = _context.Transacts.Find(id);

            if (transact.IsCash == false)
            {
                User user = _context.Users.Find(transact.UserId);

                user.wallet -= transact.Total;

            }

            transact.Status = 2;
            _context.SaveChanges();
        }

        public void AddRate(Guid id, int rate)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Rate = rate;
            _context.SaveChanges();
        }

        public void UpdateStatus(Guid id, Guid? driverId, int status)
        {
            Transact transact = _context.Transacts.Find(id);

            transact.Status = status;

            if (driverId != null)
            {
                transact.DriverId = driverId;
            }

            _context.SaveChanges();
        }
    }
}

