using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HymsonContext
{
    public class HymsonTechCommonPara
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string QuiqueCode { get; set; }
        public string fBspline { get; set; }
        public string fConerPauseTime { get; set; }
        public string fCutCircularRadius { get; set; }
        public string fCutCircularSpeed { get; set; }
        public string fCuttingGas { get; set; }
        public string fCuttingMaterials { get; set; }
        public string fCuttingNozzle { get; set; }
        public string fCuttingThickness { get; set; }
        public string fEnergyCtrlHighSpeed { get; set; }
        public string fEnergyCtrlLowSpeed { get; set; }
        public string fGasChangeTime { get; set; }
        public string fGasDelayCloseTime { get; set; }
        public string fHSCFunction { get; set; }
        public string fPeotectdistance { get; set; }
        public string fPreGapDist { get; set; }
        public string fSlowStartDistance { get; set; }
        public string fSlowStartTime { get; set; }
        public string iAngleEnable { get; set; }
        public string iAutoBorderEnable { get; set; }
        public string iConerStart { get; set; }
        public string iCoolPiontDelay { get; set; }
        public string iCoolPiontPress { get; set; }
        public string iCoolPiontStart { get; set; }
        public string iCornerAngleLimit { get; set; }
        public string iCornerDuty { get; set; }
        public string iCornerFeedFactor { get; set; }
        public string iCornerFrequency { get; set; }
        public string iCornerPostDist { get; set; }
        public string iCornerPower { get; set; }

        public string iCornerPreDist { get; set; }

        public string iCornerPress { get; set; }
        public string iCornerStart { get; set; }
        public string iCutCircularAfterPiercing { get; set; }
        public string iEnergyCtrlLowDuty { get; set; }
        public string iEnergyCtrlLowPower { get; set; }
        public string iEnergyCtrlType { get; set; }
        public string iGasChangeEN { get; set; }
        public string iSlowStart { get; set; }
        public string iSlowStartFeedFactor { get; set; }
        public string iSlowStartFeedHigh { get; set; }
       
    
    }
}
