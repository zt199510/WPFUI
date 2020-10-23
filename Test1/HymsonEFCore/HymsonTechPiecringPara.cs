using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace HymsonContext
{

   public class HymsonTechPiecringPara
    {
        [Key]
        public int Id { get; set; }

        public string MultiPiercingNum { get; set; }
        public string Per { get; set; }
        public string Per2 { get; set; }
        public string PercingDuty { get; set; }
        public string PercingFocusPos { get; set; }
        public string PercingFrequency { get; set; }
        public string PercingGasPress { get; set; }
        public string PercingGasType { get; set; }
        public string PercingHeight { get; set; }
        public string PercingPower { get; set; }
        public string PercingTime { get; set; }
        public string QuiqueCode { get; set; }
    }
}
