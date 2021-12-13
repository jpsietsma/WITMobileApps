using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WacMobile.Models
{
    public class ParticipantDetailsViewModel
    {
        public int conID { get; set; }
        public string conFirstName { get; set; }
        public string conLastName { get; set; }
        public int? conTitleID { get; set; }
        public int? conSuffixID { get; set; }
        public string conEmail { get; set; }
        public int? conContactTypeID { get; set; }
        public bool? conIsOrganization { get; set; }
        public int? conContactOrganizationID { get; set; }
        public int? conPrimaryPhoneNumberID { get; set; }
        public int? conPrimaryAddress { get; set; }
        public bool? conIsActive { get; set; }
        public bool? conIsDeceased { get; set; }
        public int? conCreatedByID { get; set; }
        public DateTime? conCreatedDate { get; set; }
        public int? conModifiedByID { get; set; }
        public DateTime? conModifiedDate { get; set; }

        public string GetNameLF { get { return string.Concat(conLastName, ", ", conFirstName); } }
        public string GetNameFL { get { return string.Concat(conFirstName, " ", conLastName); } }

    }
}
