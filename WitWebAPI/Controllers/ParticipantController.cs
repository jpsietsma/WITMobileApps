﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WITMobileClasses.Participant;
using WitWebAPI.Services;

namespace WitWebAPI.Controllers
{
    [Route("data/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly DatabaseContext Database;

        public ParticipantController(DatabaseContext _db)
        {
            Database = _db;
        }

        [Route("details/{Id}")]
        [HttpGet]
        public string GetDetails(int Id)
        {
            ParticipantDetailsViewModel participantModel;

            participantModel = Database.Contact.Where(x => x.conID == Id).FirstOrDefault();

            return JsonConvert.SerializeObject(participantModel);
        }

        [Route("all")]
        [HttpGet]
        public string GetAll()
        {
            List<ParticipantDetailsViewModel> participants = new List<ParticipantDetailsViewModel>();

            participants = Database.Contact.ToList();

            return JsonConvert.SerializeObject(participants);
        }
    }
}
