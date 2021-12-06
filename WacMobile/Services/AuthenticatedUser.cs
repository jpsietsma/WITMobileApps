using System;
using System.Collections.Generic;
using System.Text;
using WacMobile.Models;

namespace WacMobile.Services
{
    public class AuthenticatedUser : SiteUser
    {

        public AuthenticatedUser(SiteUser _loggedInUser)
        {

        }

        public string GetUserFullName()
        {
            return suFullName;
        }
     
    }
}
