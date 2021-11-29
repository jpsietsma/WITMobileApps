using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;

namespace WacMobile.Services
{
    public class AuthenticationService
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginResponseModel ResponseModel { get; private set; }

        private LoginRequestModel RequestModel { get; set; }        
        private HttpClient HttpContext { get; set; }


        public AuthenticationService()
        {
            HttpContext = new HttpClient();
            HttpContext.BaseAddress = new Uri(AppSettingsManager.Settings["BaseUrl"]);
            HttpContext.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LoginResponseModel> AuthenticateUserAsync()
        {            
            if (UserName != null && Password != null)
            {
                RequestModel = new LoginRequestModel()
                {
                    userName = UserName,
                    password = Password
                };
            }

            try
            {
                var requestData = JsonConvert.SerializeObject(RequestModel);

                StringContent content = new StringContent(requestData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpContext.PostAsync(AppSettingsManager.Settings["AuthUrl"], content);

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var responseString = await json.ReadAsStringAsync();

                    var responseModel = JsonConvert.DeserializeObject<LoginResponseModel>(responseString);

                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
