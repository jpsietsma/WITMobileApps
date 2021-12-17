using System;
using System.Collections.Generic;
using System.Text;

namespace WacMobile.Models
{
    public class AddressModel
    {
        public int addID { get; set; }
        public string addAddress { get; set; }
        public string addAddress2 { get; set; }
        public string addCity { get; set; }
        public string addTownship { get; set; }
        public string addStateOrProvidence { get; set; }
        public string addZipOrPostalCode { get; set; }
        public int? addCountryID { get; set; }
        public int? addBasinID { get; set; }
        public int? addSubBasinID { get; set; }
        public int? addCreatedByID { get; set; }
        public DateTime? addCreatedDate { get; set; }
        public int? addModifiedByID { get; set; }
        public DateTime? addModifiedDate { get; set; }
    }
}
