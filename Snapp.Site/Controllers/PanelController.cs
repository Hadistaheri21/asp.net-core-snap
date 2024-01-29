using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapp.Core.Generators;
using Snapp.Core.Securities;
using Snapp.Core.Services;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels.Panel;
using Snapp.Core.ViewModels;
using Snapp.DataAccessLayer.Entities;
using System.Text;
using System.Security.Cryptography;
using System.Net.Http;
using Newtonsoft.Json;

using Snapp.Core.ViewModels.Payment;

namespace Snapp.Site.Controllers
{
    [RoleAttribute("user")]
    public class PanelController : Controller
    {
        private IPanel _panel;

        public PanelController(IPanel panel)
        {
            _panel = panel;
        }

        //public async Task<IActionResult> TestApi()
        //{

        //    var client = new HttpClient();

        //    client.BaseAddress = new Uri("https://api.openweathermap.org");

        //    var response = await client.GetAsync($"/data/2.5/weather?lat=38&lon=52&appid=42322586b8ce663c2f1db0a19ecc0d72");

        //    var result = await response.Content.ReadAsStringAsync();

        //    var obj = JsonConvert.DeserializeObject<dynamic>(result);

        //    WeatherViewModel viewModel = new WeatherViewModel()
        //    {
        //        فرمول درجه سانتی گراد....2=  رقم اعشار2
        //        Temp = Math.Round(((float)obj.main.temp * 9 / 5 - 459.67), 2),

        //        Hum = Math.Round(((float)obj.main.humidity), 2)
        //    };

        //    return Content(viewModel.Hum + " | " + viewModel.Temp);
        //}

        public IActionResult Dashbord()
        {
            User user = _panel.GetUser(User.Identity.Name);

            Guid? transactID = _panel.ExistsUserTransacts(user.Id);

            int status = -1;

            Guid? driverID = null;

            string carCode = "";

            string carName = "";

            string carColor = "";

            string driverName = "";

            long price = 0;

            string Avatar = "";

            string startLat = "";

            string startLng = "";

            string endLat = "";

            string endLng = "";

            if (transactID != null)
            {
                Transact transact = _panel.GetUserTransact((Guid)transactID);

                status = transact.Status;

                driverID = transact.DriverId;

                price = transact.Total;

                startLat = transact.StartLat;

                startLng = transact.StartLng;

                endLat = transact.EndLat;

                endLng = transact.EndLng;

                if (transact.DriverId !=null)
                {
                    Driver driver = _panel.GetDriverById((Guid)transact.DriverId);

                    User driverDetail = _panel.GetUserById((Guid)transact.DriverId);

                    driverName = driverDetail.UserDetail.FullName;

                    carCode = driver.CarCode;

                    carColor = driver.Color!=null ? driver.Color.Name :"" ;
                   
                    carName = driver.Car?.Name;
                }
            }

            DashbordViewModel dashbord = new DashbordViewModel()
            {
                DriverId = driverID,
                UserId = user.Id,
                TransactId= transactID,
                Status = status,
                Avatar=Avatar,
                DriverName=driverName,
                CarCode=carCode,
                CarName=carName,
                CarColor=carColor,
                Price=price,
                Wallet=user.wallet,
                EndLat=endLat,
                StartLat=startLat,
                EndLng=endLng,
                StartLng=startLng
            };

            return View(dashbord);
        }



        //id=kelometr
        public async Task<IActionResult> ConfirmRequest(double id, string lat1,string lat2,string lng1,string lng2)
        {
            long price = _panel.GetPriceType(id);

            var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.openweathermap.org");
            var response = await client.GetAsync($"/data/2.5/weather?lat=38&lon=52&units=metric&appid=42322586b8ce663c2f1db0a19ecc0d72");

            var result = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(result);

            WeatherViewModel viewModel = new WeatherViewModel()
            {
                Hum = Math.Round((float)obj.main.humidity),
                Temp = Math.Round((float)obj.main.temp)
            };

            double humC = Convert.ToDouble(((viewModel.Hum) - 32) * (0.555));

            float tempPercent = _panel.GetTempPercent(viewModel.Temp);
            float humPercent = _panel.GetHumidityPercent(humC);

            price = Convert.ToInt64(price + (price * tempPercent));
            price = Convert.ToInt64(price + (price * humPercent));

            TransactViewModel priceConfirm = new TransactViewModel()
            {
                Fee = price,
                UserId = _panel.GetUserId(User.Identity.Name),

                StartLat=lat1,
                StartLng=lng1,
                EndLng=lng2,
                EndLat=lat2
            };

            return View(priceConfirm);
        }


        [HttpPost]
        public async Task<IActionResult> ConfirmRequest(TransactViewModel viewModel)
        {
            User user = _panel.GetUser(User.Identity.Name);

            bool isCash = true;

            if (user.wallet >= viewModel.Fee)
            {
                isCash = false;
            }


            Transact transact = new Transact()
            {
                Id=CodeGenerator.Getid(),
                Date=DatetimeGenarator.GetShamsiDate(),
                Discount=0,
                DriverId=null,
                DriverRate=false,
                EndAddress=viewModel.EndAddress,
                EndLat=viewModel.EndLat,
                EndLng=viewModel.EndLng,
                EndTime=null,
                Fee=viewModel.Fee,
                IsCash=isCash,
                Rate=0,
                StartAddress=viewModel.StartAddress,
                StartLat=viewModel.StartLat,
                StartLng=viewModel.StartLng,
                StartTime=null,
                Status=0,
                Total=viewModel.Fee,
                UserId=viewModel.UserId
            };

            //ثبت اطلاعات
            _panel.AddTransact(transact);

            //در انتظار رااننده
            return RedirectToAction("Dashbord");
        }

        public IActionResult UpdateStatus(Guid id)
        {
            _panel.UpdateStatus(id,null,3);

            return RedirectToAction("Dashbord");
        }

            public async Task<IActionResult> UserProfile()
        {
            var result = await _panel.GetUserDetail(User.Identity.Name);

            UserDetailProfileViewModel viewModel = new UserDetailProfileViewModel()
            {
                BirthDate = result.BirthDate,
                FullName = result.FullName
            };

            ViewBag.IsSuccess = false;
            ViewBag.MyDate = DatetimeGenarator.GetShamsiDate();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserProfile(UserDetailProfileViewModel viewModel)
        {
            var result = await _panel.GetUserDetail(User.Identity.Name);

            bool myUpdate = _panel.UpdateUserDetailsProfile(result.UserId, viewModel);

            ViewBag.MyDate = viewModel.BirthDate;
            ViewBag.IsSuccess = myUpdate;
            return View(viewModel);
        }

        public async Task<IActionResult> ResultPayment(Guid id)
        {
            var result = await _panel.GetFactor(id);

            return View(result);
        }

        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(FactorViewModel viewModel)
        {
            UserDetail user = await _panel.GetUserDetail(User.Identity.Name);
            string orderNumber = CodeGenerator.getordercode();

            var checkFactor = _panel.UpdateFactor(user.UserId, orderNumber, viewModel.Wallet);

            if (checkFactor == false)
            {
                Factor factor = new Factor()
                {
                    BankName = null,
                    Date = null,
                    Desc = null,
                    Id = CodeGenerator.Getid(),
                    OrderNumber = orderNumber,
                    Price = Convert.ToInt32(viewModel.Wallet),
                    RefNumber = null,
                    Time = null,
                    TraceNumber = null,
                    UserId = user.UserId
                };

                _panel.AddFactor(factor);
            }

            Guid factorID = _panel.GetFactorById(orderNumber);

            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(viewModel.Wallet));
            var result = payment.PaymentRequest("تراکنش جدید", "https://localhost:44375/Panel/PaymentCallBack/" + factorID);

            if (result.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Result.Authority);
            }

            return Redirect("/Panel/ResultPayment/" + factorID);
        }

        public async Task<IActionResult> PaymentCallBack(Guid id)
        {
            Factor factor = await _panel.GetFactor(id);
            string authority = HttpContext.Request.Query["Authority"];

            var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(factor.Price));
            var result = payment.Verification(authority).Result;

            if (result.Status == 100)
            {
                _panel.UpdatePayment(id, DatetimeGenarator.GetShamsiDate(), DatetimeGenarator.GetShamsiTime(), "افزایش اعتبار زرین پال", "زرین پال", result.RefId.ToString(), result.RefId.ToString());
            }

            return Redirect("/Panel/ResultPayment/" + id);
        }

        // درگاه پرداخت بانک ملی
        //[HttpPost]
        //public async Task<IActionResult> Payment(FactorViewModel viewModel)
        //{
        //    UserDetail user = await _panel.GetUserDetails(User.Identity.Name);
        //    string orderNumber = CodeGenerators.GetOrderCode();

        //    var checkFactor = _panel.UpdateFactor(user.UserId, orderNumber, viewModel.Wallet);

        //    if (checkFactor == false)
        //    {
        //        Factor factor = new Factor()
        //        {
        //            BankName = null,
        //            Date = null,
        //            Desc = null,
        //            Id = CodeGenerators.GetId(),
        //            OrderNumber = orderNumber,
        //            Price = Convert.ToInt32(viewModel.Wallet),
        //            RefNumber = null,
        //            Time = null,
        //            TraceNumber = null,
        //            UserId = user.UserId
        //        };

        //        _panel.AddFactor(factor);
        //    }

        //    string merchantId = "";
        //    string terminalId = "";
        //    string merchantKey = "";

        //    string signEncodeTemplate = $"{terminalId};{orderNumber};{viewModel.Wallet}";

        //    var byteData = Encoding.UTF8.GetBytes(signEncodeTemplate);
        //    var myAlgo = SymmetricAlgorithm.Create("TripleDes");
        //    myAlgo.Mode = CipherMode.ECB;
        //    myAlgo.Padding = PaddingMode.PKCS7;

        //    var myEnc = myAlgo.CreateEncryptor(Convert.FromBase64String(merchantKey), new byte[8]);

        //    string signData = Convert.ToBase64String(myEnc.TransformFinalBlock(byteData, 0, byteData.Length));

        //    var myData = new
        //    {
        //        MerchanId = merchantId,
        //        TerminalId = terminalId,
        //        Amount = viewModel.Wallet,
        //        OrderId = orderNumber,
        //        LocalDateTime = DateTime.Now,
        //        ReturnUrl = "https://localhost:44369/Panel/CallBack",
        //        SignData = signData
        //    };

        //    var res = CallApi<RequestPaymentResult>("https://sadad.shaparak.ir/api/v0/Request/PaymentRequest", myData).Result;

        //    if (res.ResCode == 0)
        //    {
        //        return Redirect($"https://sadad.shaparak.ir/Purchase/Index?token={res.Token}");
        //    }
        //    else
        //    {
        //        return RedirectToAction("ResultPayment");
        //    }
        //}

        [HttpPost]
        public IActionResult CallBack(CallbackRequestPayment result)
        {
            string merchantId = "";
            string terminalId = "";
            string merchantKey = "";

            Guid factorID = _panel.GetFactorById(Convert.ToString(result.OrderId));

            var byteData = Encoding.UTF8.GetBytes(result.Token);

            var myAlgo = SymmetricAlgorithm.Create("TripleDes");
            myAlgo.Mode = CipherMode.ECB;
            myAlgo.Padding = PaddingMode.PKCS7;

            var myEnc = myAlgo.CreateEncryptor(Convert.FromBase64String(merchantKey), new byte[8]);

            string signData = Convert.ToBase64String(myEnc.TransformFinalBlock(byteData, 0, byteData.Length));

            var myData = new
            {
                Token = result.Token,
                SignData = signData
            };

            var verifyRes = CallApi<VerifyResultDate>("https://sadad.shaparak.ir/api/v0/Advice/Verify", myData).Result;

            if (verifyRes.ResCode == 0)
            {
                _panel.UpdatePayment(factorID, DatetimeGenarator.GetShamsiDate(), DatetimeGenarator.GetShamsiTime(), verifyRes.Decription, "سداد ملی", verifyRes.SystemTraceNo, verifyRes.RetrivalRefNo);

                return Redirect("/Panel/ResultPayment/" + factorID);
            }
            else
            {
                return Redirect("/Panel/ResultPayment/" + factorID);
            }
        }

        //T=type
        public async Task<T> CallApi<T>(string api, object value) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(api);
                client.DefaultRequestHeaders.Accept.Clear();

                var json = JsonConvert.SerializeObject(value);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var w = client.PostAsync(api, content);
                w.Wait();

                HttpResponseMessage response = w.Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    result.Wait();
                    return JsonConvert.DeserializeObject<T>(result.Result);
                }

                return new T();
            }
        }

        public IActionResult Chat()
        {
            return View();
        }

        public IActionResult UpdateRate(Guid id, int rate)
        {
            _panel.UpdateRate(id, rate);

            return RedirectToAction("Dashbord");
        }
    }
}
