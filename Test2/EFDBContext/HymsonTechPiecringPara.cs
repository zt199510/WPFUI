using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HymsonContext
{

   public class HymsonTechPiecringPara
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuiqueCode { get; set; }
        public int typeName { get; set; }
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
       
    }
}
