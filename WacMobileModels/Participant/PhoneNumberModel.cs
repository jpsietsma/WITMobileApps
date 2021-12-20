using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WacMobileModels.Participant
{
    public class PhoneNumberModel
    {
        [Key]
        public int phoID { get; set; }
        public string phoNumber { get; set; }
        public int? phoContactID { get; set; }
        public int? phoPhoneNumberTypeID { get; set; }
        public bool phoIsActive { get; set; }

        public int? phoCreatedByID { get; set; }
        public DateTime phoCreatedDate { get; set; }
        public int? phoModifiedByID { get; set; }
        public DateTime phoModifiedDate { get; set; }
    }
}
