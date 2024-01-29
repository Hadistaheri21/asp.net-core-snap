using System;
using System.Linq;
using Snapp.Core.senders;
using Snapp.Core.Generators;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entities;
using Snapp.DataAccessLayer.Context;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels;
using Snapp.Core.securities;

namespace Snapp.Core.Services
{
    public class AccountServices:IAccountService
    {
        private SnappDbContext _context;


        public AccountServices(SnappDbContext context)
        {
            _context = context;
        }

        public string Username { get; private set; }

        public  async Task<User> ActiveUser(ActiveViewModle viewModle)
        {
            //string password = HashEncode.gethashcode(HashEncode.gethashcode(viewModle.Code));
            string password = viewModle.Code;
            User user = _context.Users.SingleOrDefault(u=>u.Password==password);

            if(user != null)
            {
                user.IsActive = true;
                user.Password =CodeGenerator.GetActivecode();

                _context.SaveChanges();
            }

            return await Task.FromResult(user);
        }

        public bool CheckMobileNumber(string Username)
        {
            return _context.Users.Any(u=>u.Username==Username);
        }

        public bool CheckUserRole(string role, string username)
        {
            Role myRole = _context.Roles.SingleOrDefault(r => r.Name == role);

            return _context.Users.Any(u => u.Username == username && u.RoleId == myRole.Id);
        }

       
        public void Dispose()    
        {
            if(_context!=null)
            {
                _context.Dispose();
            }
        }
        

        public Guid? GetRoleByName(string name)
        {
            //return _context.Roles.SingleOrDefault(r => r.Name == name).Id;
            var role = _context.Roles.FirstOrDefault(r => r.Name == name);
            if (role is not null)
            {
                return role.Id;
            }

            return null;


        }

        public  async Task<User> GetUser(string username)
        {
            return await Task.FromResult(_context.Users.SingleOrDefault(u => u.Username == username));
        }

        public async Task<User> RegisterDriver(RegisterViewModel viewModel)
        {
            if (!CheckMobileNumber(viewModel.Username))
            {
                string code = CodeGenerator.GetActivecode();

                User user = new User()
                {
                    IsActive = false,
                    Id = CodeGenerator.Getid(),
                    //Password = HashEncode.gethashcode(HashEncode.gethashcode(code)),
                    Password=code,
                    RoleId = (Guid)GetRoleByName("driver"),
                    Token = null,
                    Username = viewModel.Username
                };

                _context.Users.Add(user);

                UserDetail userDetail = new UserDetail()
                {
                    UserId = user.Id,
                    BirthDate = null,
                    Date = DatetimeGenarator.GetShamsiDate(),
                    Time = DatetimeGenarator.GetShamsiTime(),
                    FullName = null
                };

                _context.UserDetails.Add(userDetail);

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

                _context.Drivers.Add(driver);
                _context.SaveChanges();

                try
                {
                    smssender.verifysend(user.Username, "", code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
            else
            {
                User user = await GetUser(viewModel.Username);

                string code = CodeGenerator.GetActivecode();
                //UpdateUserPasssword(user.Id, HashEncode.gethashcode(HashEncode.gethashcode(code)));
                UpdateUserPasssword(user.Id,code);

                try
                {
                    smssender.verifysend(user.Username, "", code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
    }

    public async Task<User> RegisterUser(RegisterViewModel viewModle)
        {
            if (!CheckMobileNumber(viewModle.Username))    
            {
                string code = CodeGenerator.GetActivecode();

                User user = new()
                {
                    IsActive = false,
                    Id = CodeGenerator.Getid(),
                    Password =code,
                    RoleId = (Guid)GetRoleByName("user"),
                    Token = null,
                    Username = viewModle.Username
                };
 
                _context.Users.Add(user);
                UserDetail userDetail = new UserDetail()
                {
                    UserId = user.Id,
                    BirthDate = null,
                    Date = DatetimeGenarator.GetShamsiDate(),
                    Time = DatetimeGenarator.GetShamsiTime(),
                    FullName = null
                };

                _context.UserDetails.Add(userDetail);
                _context.SaveChanges();

                try
                {
                    smssender.verifysend(user.Username, "", code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
            else
            {
                 User user = await GetUser(viewModle.Username);

                string code = CodeGenerator.GetActivecode();
                //UpdateUserPasssword(user.Id, HashEncode.gethashcode(HashEncode.gethashcode(code)));
                UpdateUserPasssword(user.Id,code);

                try
                {
                    smssender.verifysend(user.Username, "",code);
                }
                catch
                {
                }

                return await Task.FromResult(user);
            }
        }

        public void UpdateUserPasssword(Guid Id, string code)
        {
            User user = _context.Users.Find(Id);
            //user.Password = HashEncode.gethashcode(HashEncode.gethashcode(code));
            user.Password = code;
            _context.SaveChanges();
        }

        Guid IAccountService.GetRoleByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}