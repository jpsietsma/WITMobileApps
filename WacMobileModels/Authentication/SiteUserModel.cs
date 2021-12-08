using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WacMobileModels.Authentication
{
    public class SiteUserModel
    {
        [Key]
        public int suID { get; set; }
        public string suFirstName { get; set; }
        public string suLastName { get; set; }
        public string suEmail { get; set; }
        public string suPassword { get; set; }
        public DateTime? suPasswordExpirationDate { get; set; }
        public DateTime? suCreateDate { get; set; }
        public string suPhoneNumber { get; set; }
        public DateTime? suLastLoginDate { get; set; }
        public bool suLocked { get; set; }
        public string suDomainUserName { get; set; }
        public int? suSiteUserTitleID { get; set; }
        public bool suActive { get; set; }
        public string suPasswordResetToken { get; set; }
        public string suPasswordResetSelector { get; set; }
        public DateTime? suLastUpdatedDate { get; set; }
        public int? suLastUpdatedByID { get; set; }
        public int? suAgencyID { get; set; }
    }
}
