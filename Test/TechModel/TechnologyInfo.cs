using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TechModel
{
    public class TechnologyInfo
    {

        public string QuiqueCode { get; set; }
        //材料ID
        public int MaterialsID { get; set; }
        //材料名称
        public string MaterialsName { get; set; }
        //气体id
        public int GasID { get; set; }

        public int Isinitialize { get; set; }
        //厚度
        public string ThicknessInfo { get; set; }
        //注释
        public string Annotation { get; set; }
        //喷嘴
        public string Nozzle { get; set; }
        //工艺名称
        public string TechnologyName { get; set; }

        public TechnologyNodeList TechnologyNodeList { get; set; }

    }
}
