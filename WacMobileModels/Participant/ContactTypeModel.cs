using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WacMobileModels.Participant
{
    public class ContactTypeModel
    {
        [Key]
        public int ctyID { get; set; }
        public string ctyName { get; set; }
        public string ctyDescription { get; set; }
        public string ctyType { get; set; }
        public bool ctyIsActive { get; set; }
        public int ctyCreatedByID { get; set; }
        public DateTime ctyCreatedDate { get; set; }
        public int ctyModifiedByID { get; set; }
        public DateTime ctyModifiedDate { get; set; }
    }
}
