using System;
using System.Collections.Generic;
using System.Text;

namespace WacMobile.Models
{
    public class LoginResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public SiteUser User { get; set; }
        public string AuthenticationToken { get; set; }
    }
}
