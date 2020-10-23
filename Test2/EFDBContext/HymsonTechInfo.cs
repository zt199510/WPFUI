using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HymsonContext
{
    [Table("HymsonTechInfoes")]
    public class HymsonTechInfo
    {
       
  


        public string TechnologyName { get; set; }

        public string Nozzle { get; set; }
        public string Annotation { get; set; }
        public string ThicknessInfo { get; set; }
        public int Isinitialize { get; set; }
        public int GasID { get; set; }
        public string MaterialsName { get; set; }
        public int MaterialsID { get; set; }
        [Key]
        public string QuiqueCode { get; set; }
        public string TenanltId { get; set; }
        public string DeviceSn { get; set; }

        public string CreateTime { get; set; }

        public string LaserPower { get; set; }
    }
}
