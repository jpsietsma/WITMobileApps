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
        private JsonSerializer _jsonSerializer { get; set; }


        public AuthenticationService()
        {
            HttpContext = new HttpClient();
            HttpContext.BaseAddress = new Uri(AppSettingsManager.Settings["BaseUrl"]);
            HttpContext.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _jsonSerializer = new JsonSerializer();
        }

        public async Task<LoginResponseModel> AuthenticateUserAsync()
        {            
            if (UserName != null && Password != null)
            {
                RequestModel = new LoginRequestModel()
                {
                    Username = UserName,
                    Password = Password
                };
            }

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(RequestModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpContext.PostAsync(AppSettingsManager.Settings["AuthUrl"], content);

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var x = json;

                    var responseModel = _jsonSerializer.Deserialize<LoginResponseModel>(json);

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
