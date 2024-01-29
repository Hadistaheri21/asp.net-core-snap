using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.dashbord_admin;
using Snapp.DataAccessLayer.Context;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.Generators;
using Microsoft.EntityFrameworkCore;
using Snapp.Core.securities;
using System.IO;
using Snapp.DataAccessLayer.Entites;

namespace Snapp.Core.Services
{
    public class AdminServices : IAdmin
    {
        private SnappDbContext _Context;

        public AdminServices(SnappDbContext context)
        {
            _Context = context;
        }

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
            }
        }

        public void AddCar(CarViewModel viewModel)
        {
            Car car = new Car()
            {
                Id = CodeGenerator.Getid(),
                Name = viewModel.Name,
            };

            _Context.Cars.Add(car);
            _Context.SaveChanges();
        }

        public void DeleteCar(Guid id)
        {
            Car car = _Context.Cars.Find(id);

            if (car != null)
            {
                _Context.Cars.Remove(car);

                _Context.SaveChanges();

            }
        }
        public async Task<Car> GetCarById(Guid id)
        {
            return await _Context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCars()
        {
            return await _Context.Cars.OrderBy(c => c.Name).ToListAsync();
        }

        public bool UpdateCar(Guid id, CarViewModel viewModel)
        {
            Car car = _Context.Cars.Find(id);

            if (car != null)
            {
                //از ماشین فقط یک نام قابل ویرایشه
                car.Name = viewModel.Name;

                _Context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Color>> GetColors()
        {
            return await _Context.Colors.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Color> GetColorById(Guid id)
        {
            //شرط فایند روی کلید انجام میشه ینی آیدی
            return await _Context.Colors.FindAsync(id);
        }

        public void AddColor(AdminColorViewModel viewModel)
        {
            Color color = new Color()
            {
                Id = CodeGenerator.Getid(),
                Code = viewModel.Code,
                Name = viewModel.Name,
            };

            _Context.Colors.Add(color);
            _Context.SaveChanges();
        }

        public bool UpdateColor(AdminColorViewModel viewModel, Guid id)
        {
            Color color = _Context.Colors.Find(id);

            if (color != null)
            {
                color.Name = viewModel.Name;
                color.Code = viewModel.Code;

                _Context.SaveChanges();

                return true;
            }
            else
            {
                return false;

            }
        }

        public void DeleteColor(Guid id)
        {
            Color color = _Context.Colors.Find(id);

            if (color != null)
            {
                _Context.Colors.Remove(color);
                _Context.SaveChanges();
            }
        }

        public async Task<List<RateType>> GetRateTypes()
        {
            return await _Context.RateTypes.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<RateType> GetRateTypeById(Guid id)
        {
            return await _Context.RateTypes.FindAsync(id);
        }

        public void AddRateType(RateTypeViewModel viewModel)
        {
            RateType rateType = new RateType()
            {
                Id = CodeGenerator.Getid(),
                Name = viewModel.Name,
                Ok = viewModel.Ok,
                ViewOrder = viewModel.ViewOrder
            };

            _Context.RateTypes.Add(rateType);
            _Context.SaveChanges();
        }

        public bool UpdateRateType(RateTypeViewModel viewModel, Guid id)
        {
            RateType rateType = _Context.RateTypes.Find(id);

            if (rateType != null)
            {
                rateType.Name = viewModel.Name;
                rateType.Ok = viewModel.Ok;
                rateType.ViewOrder = viewModel.ViewOrder;

                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteRateType(Guid id)
        {

            RateType rateType = _Context.RateTypes.Find(id);

            if (rateType != null)
            {
                _Context.RateTypes.Remove(rateType);
                _Context.SaveChanges();

            }
        }

        public async Task<Setting> GetSetting()
        {
            return await _Context.Settings.FirstOrDefaultAsync();
        }

        public bool UpdateSiteSetting(SiteSettingViewModel viewModel)
        {
            Setting setting = _Context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.Desc = viewModel.Desc;
                setting.Tel = viewModel.Tel;
                setting.Name = viewModel.Name;
                setting.Fax = viewModel.Fax;


                _Context.SaveChanges();

                return true;
            }

            else
            {
                return false;
            }
        }

        public bool UpdatePriceSetting(PriceSettingViewModel viewModel)
        {
            Setting setting = _Context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.IsDistance = viewModel.IsDistance;
                setting.IsWeatherPirce = viewModel.IsWeatherPirce;

                _Context.SaveChanges();

                return true;
            }

            else
            {
                return false;
            }
        }

        public bool UpdateAboutSetting(AboutSettingViewModel viewModel)
        {
            Setting setting = _Context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.About = viewModel.About;

                _Context.SaveChanges();

                return true;
            }

            else
            {
                return false;
            }
        }

        public bool UpdatTermsSetting(TermsSettingViewModel viewModel)
        {
            Setting setting = _Context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.Terms = viewModel.Terms;

                _Context.SaveChanges();

                return true;
            }

            else
            {
                return false;
            }
        }

        public async Task<List<PriceType>> GetPriceTypes()
        {
            return await _Context.PriceTypes.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<PriceType> GetPriceTypeById(Guid id)
        {
            return await _Context.PriceTypes.FindAsync(id);
        }

        public void AddPriceType(PriceTypeViewModel viewModel)
        {
            PriceType priceType = new PriceType()
            {
                End = viewModel.End,
                Start = viewModel.Start,
                Name = viewModel.Name,
                Id = CodeGenerator.Getid(),
                Price = viewModel.Price
            };

            _Context.PriceTypes.Add(priceType);
            _Context.SaveChanges();
        }

        public bool UpdatePriceType(PriceTypeViewModel viewModel, Guid id)
        {
            PriceType priceType = _Context.PriceTypes.Find(id);

            if (priceType != null)
            {
                priceType.End = viewModel.End;
                priceType.Start = viewModel.Start;
                priceType.Name = viewModel.Name;
                priceType.Price = viewModel.Price;

                _Context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeletePriceType(Guid id)
        {
            PriceType priceType = _Context.PriceTypes.Find(id);

            _Context.PriceTypes.Remove(priceType);
            _Context.SaveChanges();
        }

        public async Task<List<MonthType>> GetMonthTypes()
        {
            return await _Context.MonthTypes.OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<MonthType> GetMonthTypeById(Guid id)
        {
            return await _Context.MonthTypes.FindAsync(id);
        }

        public void AddMonthType(MonthTypeViewModel viewModel)
        {
            MonthType monthType = new MonthType()
            {
                Id = CodeGenerator.Getid(),
                End = viewModel.End,
                Name = viewModel.Name,
                Precent = viewModel.Percent,
                Start = viewModel.Start
            };

            _Context.MonthTypes.Add(monthType);
            _Context.SaveChanges();
        }

        public bool UpdateMonthType(MonthTypeViewModel viewModel, Guid id)
        {
            MonthType monthType = _Context.MonthTypes.Find(id);

            if (monthType != null)
            {
                monthType.End = viewModel.End;
                monthType.Start = viewModel.Start;
                monthType.Name = viewModel.Name;
                monthType.Precent = viewModel.Percent;

                _Context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteMonthType(Guid id)
        {
            MonthType monthType = _Context.MonthTypes.Find(id);

            _Context.MonthTypes.Remove(monthType);
            _Context.SaveChanges();
        }

        public async Task<List<Humidity>> GetHumiditys()
        {
            return await _Context.Humidities.OrderBy(h => h.Name).ToListAsync();
        }

        public async Task<Humidity> GetHumidityById(Guid id)
        {
            return await _Context.Humidities.FindAsync(id);
        }

        public void AddHumidity(MonthTypeViewModel viewModel)
        {
            Humidity humidity = new Humidity()
            {
                End = viewModel.End,
                Id = CodeGenerator.Getid(),
                Name = viewModel.Name,
                Precent = viewModel.Percent,
                Start = viewModel.Start
            };

            _Context.Humidities.Add(humidity);
            _Context.SaveChanges();
        }

        public bool UpdateHumidity(MonthTypeViewModel viewModel, Guid id)
        {
            Humidity humidity = _Context.Humidities.Find(id);

            if (humidity != null)
            {
                humidity.End = viewModel.End;
                humidity.Name = viewModel.Name;
                humidity.Precent = viewModel.Percent;
                humidity.Start = viewModel.Start;

                _Context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteHumidity(Guid id)
        {
            Humidity humidity = _Context.Humidities.Find(id);

            if (humidity != null)
            {
                _Context.Humidities.Remove(humidity);
                _Context.SaveChanges();
            }
        }

        public async Task<List<Temperature>> GetTemperatures()
        {
            return await _Context.Temperatures.OrderBy(h => h.Name).ToListAsync();
        }

        public async Task<Temperature> GetTemperatureById(Guid id)
        {
            return await _Context.Temperatures.FindAsync(id);
        }

        public void AddTemperature(MonthTypeViewModel viewModel)
        {
            Temperature temperature = new Temperature()
            {
                End = viewModel.End,
                Id = CodeGenerator.Getid(),
                Name = viewModel.Name,
                Precent = viewModel.Percent,
                Start = viewModel.Start
            };

            _Context.Temperatures.Add(temperature);
            _Context.SaveChanges();
        }

        public bool UpdateTemperature(MonthTypeViewModel viewModel, Guid id)
        {
            Temperature temperature = _Context.Temperatures.Find(id);

            if (temperature != null)
            {
                temperature.End = viewModel.End;
                temperature.Name = viewModel.Name;
                temperature.Precent = viewModel.Percent;
                temperature.Start = viewModel.Start;

                _Context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteTemperature(Guid id)
        {
            Temperature temperature = _Context.Temperatures.Find(id);

            if (temperature != null)
            {
                _Context.Temperatures.Remove(temperature);
                _Context.SaveChanges();
            }

        }

        public async Task<List<Role>> GetRoles()
        {
            return await _Context.Roles.OrderBy(r => r.Title).ToListAsync();
        }

        public async Task<Role> GetRoleById(Guid id)
        {
            // برمیگردونه async یک دانه  
            return await _Context.Roles.FindAsync(id);
        }

        public void AddRole(RoleViewModel viewModel)
        {
            Role role = new Role()
            {
                Id = CodeGenerator.Getid(),
                Name = viewModel.Name,
                Title = viewModel.Title
            };

            _Context.Roles.Add(role);
            _Context.SaveChanges();
        }

        public bool UpdateRole(RoleViewModel viewModel, Guid id)
        {
            Role role = _Context.Roles.Find(id);

            if (role != null)
            {
                role.Name = viewModel.Name;
                role.Title = viewModel.Title;


                _Context.SaveChanges();

                return true;
            }

            return false;
        }


        public void DeleteRole(Guid id)
        {
            Role role = _Context.Roles.Find(id);

            if (role != null)
            {
                _Context.Roles.Remove(role);
                _Context.SaveChanges();
            }
        }

        public bool CheckUserName(string username)
        {
            //خروجی true and false
            return _Context.Users.Any(u => u.Username == username);
        }

        public void AddUser(UserViewModel viewModel)
        {
            User user = new()
            {
                Id = CodeGenerator.Getid(),
                IsActive = viewModel.IsActive,
                Password = HashEncode.gethashcode(HashEncode.gethashcode(CodeGenerator.GetActivecode())),
                RoleId = viewModel.RoleId,
                Token = null,
                Username = viewModel.Username,
                wallet = 0
            };

            _Context.Users.Add(user);

            UserDetail userDetail = new UserDetail()
            {
                UserId = user.Id,
                BirthDate = null,
                Date = DatetimeGenarator.GetShamsiDate(),
                Time = DatetimeGenarator.GetShamsiTime(),
                FullName = null
            };

            _Context.UserDetails.Add(userDetail);


            if (GetRoleId(viewModel.RoleId) == "driver")
            {
                Driver driver = new Driver()
                {
                    IsConfirm = false,
                    Address = null,
                    Avatar = null,
                    CarCode = null,
                    CarId = null,
                    ColorId = null,
                    Img = null,
                    Tel = null,
                    NationalCode = null,
                    UserId = user.Id
                };

                _Context.Drivers.Add(driver);

            }

            _Context.SaveChanges();
        }

        public string GetRoleId(Guid id)
        {
            return _Context.Roles.Find(id).Name;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _Context.Users.Include(u => u.Role).Include(u => u.UserDetail).OrderBy(u => u.Username).ToListAsync();
        }

        public void DeleteUser(Guid id)
        {
            User user = _Context.Users.Find(id);

            _Context.Users.Remove(user);
            _Context.SaveChanges();
        }

        public void AddDriver(Guid id)
        {
            Driver driver = new Driver()
            {


                IsConfirm = false,
                Address = null,
                Avatar = null,
                CarCode = null,
                CarId = null,
                ColorId = null,
                Img = null,
                Tel = null,
                NationalCode = null,
                UserId = id

            };

            _Context.Drivers.Add(driver);
            _Context.SaveChanges();
        }


        public void DeleteDriver(Guid id)
        {
            Driver driver = _Context.Drivers.Find(id);
            _Context.Drivers.Remove(driver);
            _Context.SaveChanges();
        }

        public bool UpdateUser(UserEditViewModel viewModel, Guid id)
        {
            User user = _Context.Users.Find(id);

            UserDetail userDetail = _Context.UserDetails.Find(id);

            if (user != null)
            {
                userDetail.FullName = viewModel.FullName;
                userDetail.BirthDate = viewModel.BirthDate;
                user.RoleId = viewModel.RoleId;
                user.IsActive = viewModel.IsActive;
                user.Username = viewModel.Username;

                if (GetRoleId(viewModel.RoleId) == "driver")
                {
                    if (!_Context.Drivers.Any(d => d.UserId == id))
                    {
                        AddDriver(id);
                    }
                }
                else
                {
                    if (_Context.Drivers.Any(d => d.UserId == id))
                    {
                        DeleteDriver(id);
                    }
                }

                _Context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool CheckUserNameForUpdate(string username, Guid id)
        {
            return _Context.Users.Any(u => u.Username == username && u.Id != id);
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _Context.Users.FindAsync(id);
        }

        public bool UpdateDriverProp(Guid id, DriverPropViewModel viewModel)
        {
            Driver driver = _Context.Drivers.Find(id);

            if (viewModel.Avatar != null)
            {
                string StrExt = Path.GetExtension(viewModel.Avatar.FileName);

                if (StrExt != ".jpg")
                {
                    return false;
                }

                string filePath = "";

                viewModel.AvatarName = CodeGenerator.GetfileName() + StrExt;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/driver/", viewModel.AvatarName);

                //ایجاد فایل
                using (var strem = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Avatar.CopyTo(strem);
                }

                if (driver.Avatar != null)
                {
                    File.Delete("wwwroot/img/driver/" + driver.Avatar);
                }

                driver.Avatar = viewModel.AvatarName;
                driver.NationalCode = viewModel.NationalCode;
                driver.Address = viewModel.Address;
                driver.Tel = viewModel.Tel;

                _Context.SaveChanges();

                return true;
            }
            else
            {
                if (driver.Avatar != null)
                {
                    driver.NationalCode = viewModel.NationalCode;
                    driver.Address = viewModel.Address;
                    driver.Tel = viewModel.Tel;

                    _Context.SaveChanges();

                    return true;
                }

                return false;
            }
        }

        public async Task<Driver> GetDriver(Guid id)
        {
            return await _Context.Drivers.FindAsync(id);
        }

        public bool UpdateDriverCertificate(Guid id, DriverImgViewModel viewModel)
        {
            Driver driver = _Context.Drivers.Find(id);

            if (viewModel.Img != null)
            {
                string StrExt = Path.GetExtension(viewModel.Img.FileName);

                if (StrExt != ".jpg")
                {
                    return false;
                }

                string filePath = "";

                viewModel.ImgName = CodeGenerator.GetfileName() + StrExt;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/driver/", viewModel.ImgName);

                //ایجاد فایل
                using (var strem = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Img.CopyTo(strem);
                }

                driver.Img = viewModel.ImgName;
                driver.IsConfirm = viewModel.IsConfirm;

                _Context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool UpdateDriverCar(Guid id, DriverCarViewModel viewModel)
        {
            Driver driver = _Context.Drivers.Find(id);

            driver.CarCode = viewModel.CarCode;
            driver.CarId = viewModel.CarId;
            driver.ColorId = viewModel.ColorId;

            _Context.SaveChanges();
            return true;
        }

        public async Task<UserDetail> GetUserDetail(Guid id)
        {
            return await _Context.UserDetails.FindAsync(id);
        }

        public async Task<List<Discount>> GetDiscounts()
        {
            return await _Context.Discounts.OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(Guid id)
        {
            return await _Context.Discounts.FindAsync(id);
        }

        public void AddDiscount(AdminDiscountViewModel viewModel)
        {
            Discount discount = new Discount()
            {
                Code = viewModel.Code,
                Desc = viewModel.Desc,
                Expire = viewModel.Expire,
                Id = CodeGenerator.Getid(),
                Name = viewModel.Name,
                Percent = viewModel.Percent,
                Price = viewModel.Price,
                Start = viewModel.Start
            };

            _Context.Discounts.Add(discount);
            _Context.SaveChanges();
        }

        public bool UpdateDiscount(AdminDiscountViewModel viewModel, Guid id)
        {
            Discount discount = _Context.Discounts.Find(id);

            if (discount != null)
            {
                discount.Code = viewModel.Code;
                discount.Start = viewModel.Start;
                //تاریخ پایان
                discount.Expire = viewModel.Expire;
                discount.Desc = viewModel.Desc;
                discount.Name = viewModel.Name;
                discount.Percent = viewModel.Percent;
                discount.Price = viewModel.Price;

                _Context.SaveChanges();
                return true;
            }

            return false;
        }

        public void DeleteDiscount(Guid id)
        {
            Discount discount = _Context.Discounts.Find(id);

            _Context.Discounts.Remove(discount);
            _Context.SaveChanges();
        }

        public int weeklyFactor(string date)
        {
            //یک تاریخ بگیریم و جمع ینی price را بهش یدیم

            if (!_Context.Factors.Any(f => f.RefNumber != null && f.Date == date))
            {
                return 0;
            }

            return _Context.Factors.Where(f => f.RefNumber != null && f.Date == date).ToList().Sum(f => f.Price);
        }

        public int MonthlyFactor(string month)
        {
            //گرفتن سال جاری
            string strYear = DatetimeGenarator.GetShamsiDate().Substring(0, 4);

            if (!_Context.Factors.Any(f => f.RefNumber != null && f.Date.Substring(5, 2) == month && f.Date.Substring(0, 4) == strYear))
            {
                return 0;
            }

            return _Context.Factors.Where(f => f.RefNumber != null && f.Date.Substring(5, 2) == month && f.Date.Substring(0, 4) == strYear).Sum(f => f.Price);
        }

        public int weeklyRegister(string date)
        {
            if (!_Context.Users.Include(f => f.UserDetail).Any(f => f.IsActive == true && f.UserDetail.Date == date))
            {
                return 0;
            }

            return _Context.Users.Include(f => f.UserDetail).Where(f => f.IsActive == true && f.UserDetail.Date == date).ToList().Count();
        }

        public int MonthlyRegister(string month)
        {
            //گرفتن سال جاری
            string strYear = DatetimeGenarator.GetShamsiDate().Substring(0, 4);

            if (!_Context.Users.Include(f => f.UserDetail).Any(f => f.IsActive == true && f.UserDetail.Date.Substring(5, 2) == month && f.UserDetail.Date.Substring(0, 4) == strYear))
            {
                return 0;
            }

            return _Context.Users.Include(f => f.UserDetail).Where(f => f.IsActive == true && f.UserDetail.Date.Substring(5, 2) == month && f.UserDetail.Date.Substring(0, 4) == strYear).Count();
        }

        public async Task<List<Transact>> GetTransacts()
        {
            return await _Context.Transacts.Include(x => x.User).OrderByDescending(x => x.Date).ThenByDescending(x => x.StartTime).ToListAsync();
        }

        public void DeleteTransact(Guid id)
        {
            var transact = _Context.Transacts.Find(id);

            _Context.Transacts.Remove(transact);

            _Context.SaveChanges();
        }

        public async Task<List<TransactRate>> GetTransactRates(Guid id)
        {
            return await _Context.TransactRates.Where(x => x.TransactId == id).ToListAsync();
        }

       
        public async Task<List<Transact>> LastTransact()
        {
            return await _Context.Transacts.Include(x => x.User).Where(x => x.Status == 2).OrderByDescending(x => x.Date).ThenByDescending(x => x.EndTime).Take(5).ToListAsync();
        }

        public int? WeeklyTransact(string date)
        {
            if (!_Context.Transacts.Any(x => x.Status == 2 && x.Date == date))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(_Context.Transacts.Where(x => x.Status == 2 && x.Date == date).Sum(x => x.Total));
            }
        }

        public async Task<List<Transact>> FillTransactInProcess(string date)
        {
            return await _Context.Transacts.Include(x => x.User).Where(x => x.Status == 1 && x.Date == date)
                .OrderByDescending(x => x.StartTime).ToListAsync();
        }

        public async Task<List<Transact>> FillCancelTransact(string date)
        {
            return await _Context.Transacts.Include(x => x.User).Where(x => x.Status == 3 && x.Date == date)
                .OrderByDescending(x => x.StartTime).ToListAsync();
        }
    }
} 


