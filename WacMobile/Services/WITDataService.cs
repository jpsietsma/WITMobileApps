using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WacMobile.Models;
using WacMobile.Views;

namespace WacMobile.Services
{
    public class WITDataService
    {
        private HttpClient HttpContext { get; set; }

        public WITDataService()
        {
            HttpContext = new HttpClient();
            HttpContext.BaseAddress = new Uri(AppSettingsManager.Settings["BaseUrl"]);
            HttpContext.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        /// <summary>
        /// Retrieve a list of participant FirstName, LastName, and ID's
        /// </summary>
        public async Task<List<ParticipantDetailsViewModel>> GetParticipants()
        {
            try
            {
                var url = AppSettingsManager.Settings["PartDataUrl"] + "/all";

                HttpResponseMessage response = await HttpContext.GetAsync(url);

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var responseString = await json.ReadAsStringAsync();

                    var responseModel = JsonConvert.DeserializeObject<List<ParticipantDetailsViewModel>>(responseString);

                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieve all details about a participant by ID
        /// </summary>
        public async Task<ParticipantDetailsViewModel> GetParticipantDetails(int partID)
        {
            try
            {
                var url = AppSettingsManager.Settings["PartDataUrl"] + $@"/details/{partID}";

                HttpResponseMessage response = await HttpContext.GetAsync(url);

                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var responseString = await json.ReadAsStringAsync();

                    var responseModel = JsonConvert.DeserializeObject<ParticipantDetailsViewModel>(responseString);

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
