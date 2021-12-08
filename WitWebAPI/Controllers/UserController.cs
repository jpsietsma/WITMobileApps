using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WacMobileModels.Authentication;
using WitWebAPI.Services;

namespace WitWebAPI.Controllers
{
    [Route("data/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext Database;

        public UserController(DatabaseContext _db)
        {
            Database = _db;
        }

        [Route("details/{Id}")]
        [HttpGet]
        public string GetUserDetails(int Id)
        {
            SiteUserModel user = Database.SiteUser.Where(x => x.suID == Id).FirstOrDefault();

            return JsonConvert.SerializeObject(user);
        }
    }
}
