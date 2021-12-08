using System;
using System.Collections.Generic;
using System.Text;

namespace WacMobileModels.Authentication
{
    public class LoginResponseModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public SiteUserModel User { get; set; }
    }
}
