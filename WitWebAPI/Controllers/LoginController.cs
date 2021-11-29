using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WitWebAPI.Models;
using WitWebAPI.Services;

namespace WitWebAPI.Controllers
{
    [Route("auth/")]
    public class LoginController : Controller
    {
        private readonly IDBStore Database;
        private readonly DatabaseContext WITDB;
        private IPassword Password { get; set; }

        public LoginController(IDBStore _dbStore, DatabaseContext _db, IPassword _password)
        {
            Database = _dbStore;
            WITDB = _db;
            Password = _password;
        }

        public string Index()
        {
            LoginResponseModel response;

            response = new LoginResponseModel { Status = "fail", Message = "You must choose an authentication method" };

            return JsonConvert.SerializeObject(response);
        }

        [Route("mobile/")]
        [HttpPost]
        public string MobileAuth([FromBody]LoginRequestModel UserLoginRequest)
        {
            LoginResponseModel response;
            SiteUserModel userModel = WITDB.SiteUser.Where(x => x.suEmail == UserLoginRequest.userName).FirstOrDefault();           

            if (string.IsNullOrEmpty(UserLoginRequest.userName) || string.IsNullOrEmpty(UserLoginRequest.password))
            {
                response = new LoginResponseModel { Status = "fail", Message = "Login Failed. Check Username and Password.", User = null };                
            }
            else
            {
                if (userModel != null && Password.Check(userModel.suPassword, UserLoginRequest.password))
                {
                    response = new LoginResponseModel { Status = "success", Message = "You have been successfully logged in.", User = userModel };
                }
                else
                {
                    response = new LoginResponseModel { Status = "fail", Message = "Login Failed. Check Username and Password.", User = null };
                }                                
            }

            return JsonConvert.SerializeObject(response);
        }

        [Route("mobileGet/")]
        [HttpGet]
        public string MobileAuthGet(string userName, string password)
        {
            LoginResponseModel response;
            SiteUserModel userModel = WITDB.SiteUser.Where(x => x.suEmail == userName).FirstOrDefault();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                response = new LoginResponseModel { Status = "fail", Message = "Login Failed. Check Username and Password.", User = null };
            }
            else
            {
                if (userModel != null && Password.Check(userModel.suPassword, password))
                {
                    response = new LoginResponseModel { Status = "success", Message = "You have been successfully logged in.", User = userModel };
                }
                else
                {
                    response = new LoginResponseModel { Status = "fail", Message = "Login Failed. Check Username and Password.", User = null };
                }
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}
