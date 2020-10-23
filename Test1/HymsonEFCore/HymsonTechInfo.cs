using System.ComponentModel.DataAnnotations;

namespace HymsonContext
{

    public class HymsonTechInfo
    {
        [Key]
        public int Id { get; set; }

        public string TechnologyName { get; set; }

        public string Nozzle { get; set; }
        public string Annotation { get; set; }
        public string ThicknessInfo { get; set; }
        public string Isinitialize { get; set; }
        public string QuiqueCode { get; set; }
        public string TenanltId { get; set; }
        public string DeviceSn { get; set; }

        public string CreateTime { get; set; }

        public string IsHttpPost { get; set; }

        public string LaserPower { get; set; }
    }
}
