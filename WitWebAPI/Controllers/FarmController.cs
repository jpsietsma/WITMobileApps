using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WacMobileModels.Farm;
using WitWebAPI.Services;

namespace WitWebAPI.Controllers
{
    [Route("data/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly DatabaseContext Database;

        public FarmController(DatabaseContext _db)
        {
            Database = _db;
        }

        [Route("details/{Id}")]
        [HttpGet]
        public string GetFarmDetails(int Id)
        {
            FarmDetailsViewModel farm;

            farm = Database.Farm.Where(x => x.farmID == Id)
                .Include(a => a.farmPrimaryAddress)
                .FirstOrDefault();

            return JsonConvert.SerializeObject(farm);
        }

        [Route("all")]
        [HttpGet]
        public string GetAllFarms()
        {
            List<FarmDetailsViewModel> farms = new List<FarmDetailsViewModel>();

            farms = Database.Farm
                .Include(a => a.farmPrimaryAddress)
                .Include(p => p.farmParticipantProducer)
                .OrderBy(f => f.farmIdentificationValue)
                .ToList();

            return JsonConvert.SerializeObject(farms);
        }

    }
}
