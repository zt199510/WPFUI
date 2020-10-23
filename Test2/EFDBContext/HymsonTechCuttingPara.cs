using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HymsonContext
{
   public class HymsonTechCuttingPara
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string QuiqueCode { get; set; }

        public int typeName { get; set; }
        public string fCuttingCompensation { get; set; }
      

        public string fCuttingFouce { get; set; }
        public string fCuttingGasPress { get; set; }
        public string fCuttingHeight { get; set; }
        public string fCuttingPrecision { get; set; }
        public string fCuttingSpeed { get; set; }
        public string fGasAlarmPress { get; set; }

        public string fPeotectHeight { get; set; }
        public string fUpHeight { get; set; }

        public string iCuttingAcc { get; set; }
        public string iCuttingBeamDelay { get; set; }
        public string iCuttingDuty { get; set; }
        public string iCuttingFrequency { get; set; }
        public string iCuttingGasDelay { get; set; }
        public string iCuttingGasType { get; set; }
        public string iCuttingPower { get; set; }

        public string iCuttingPowerModel { get; set; }

        public string iCuttingRamptime { get; set; }
        public string iFollowingType { get; set; }

        public string iGeomRamptime { get; set; }
        public string iPercingType { get; set; }

      
    }
}
