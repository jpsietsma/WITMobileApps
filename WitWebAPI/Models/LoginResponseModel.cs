using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WitWebAPI.Models
{
    public class LoginResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public SiteUserModel User { get; set; }
    }
}
