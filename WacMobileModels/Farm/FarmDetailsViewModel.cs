using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WacMobileModels.Address;
using WacMobileModels.Participant;

namespace WacMobileModels.Farm
{
    public class FarmDetailsViewModel
    {
        [Key]
        public int farmID { get; set; }
        public int? farmContactID { get; set; }
        public string farmName { get; set; }
        public string farmFADStatus { get; set; }
        public string farmRankScore { get; set; }
        public string farmAEMScore { get; set; }
        public int? farmT1AssignedToID { get; set; }
        public int? farmT2AssignedToID { get; set; }
        public string farmTier2Notes { get; set; }
        public string farmIdentificationAlpha { get; set; }
        public string farmIdentificationNumber { get; set; }
        public string farmIdentificationValue { get; set; }
        public string farmPrimaryTaxParcelID { get; set; }
        public int? farmPrimaryBasinID { get; set; }

        [Column(TypeName = "nchar(10)")]
        public string farmPrimarySubBasinID { get; set; }

        [ForeignKey("farmPrimaryAddress")]
        public int? farmPrimaryAddressID { get; set; }
        public AddressModel farmPrimaryAddress { get; set; }

        [ForeignKey("farmParticipantProducer")]
        public int? farmParticipantProducerID { get; set; }
        public ParticipantDetailsViewModel farmParticipantProducer {get;set;}

        public int? farmCreatedByID { get; set; }
        public DateTime? farmCreatedDate { get; set; }
        public int? farmModifiedByID { get; set; }
        public DateTime? farmModifiedDate { get; set; }
        public string farmSizeConstant { get; set; }
        public decimal? farmAvgFieldDistanceFromWatercourse { get; set; }
        public decimal? farmFarmsteadDistanceFromWatercourse { get; set; }
        public decimal? farmProfessionalJudgementPoints { get; set; }
        public string farmEohPLevel { get; set; }
        public DateTime? farmRankingDetailsUpdatedDate { get; set; }
        public int? farmRankingDetailsUpdatedByID { get; set; }

    }
}
