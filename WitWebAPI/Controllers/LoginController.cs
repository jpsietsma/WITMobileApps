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

        public LoginController(IDBStore _dbStore, DatabaseContext _db)
        {
            Database = _dbStore;
            WITDB = _db;
        }

        public string Index()
        {
            LoginResponseModel response;

            response = new LoginResponseModel { Status = "fail", Message = "You must choose an authentication method" };

            return JsonConvert.SerializeObject(response);
        }

        [Route("mobile/")]
        //[HttpPost]
        public string MobileAuth(string userName, string password)
        {
            LoginResponseModel response;
            SiteUserModel userModel = WITDB.SiteUser.Where(x => x.suEmail == userName).FirstOrDefault();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                response = new LoginResponseModel { Status = "fail", Message = "Login Failed. Check Username and Password." };                
            }
            else
            {               
                if (userModel != null)
                {
                    response = new LoginResponseModel { Status = "success", Message = "You have been successfully logged in.", User = userModel };
                }
                else
                {
                    response = new LoginResponseModel { Status = "fail", Message = "Login Failed. Check Username and Password." };
                }                                
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}
