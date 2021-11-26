using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;

namespace WacMobile.Services
{
    public class AuthenticationService
    {
        private LoginRequestModel RequestModel {get; }
        private LoginResponseModel ResponseModel { get; }


        public AuthenticationService(string _userName, string _password)
        {
            RequestModel = new LoginRequestModel
            {
                Username = _userName,
                Password = _password
            };
        }

        public async Task<LoginResponseModel> AuthenticateUser()
        {            
            string requestJson = JsonConvert.SerializeObject(RequestModel);


            return null;

        }
    }
}
