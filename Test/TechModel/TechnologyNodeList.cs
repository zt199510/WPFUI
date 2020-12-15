using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.TechModel
{
    public class TechnologyNodeList
    {
        public ST_CommonParameter commonPara = new ST_CommonParameter();
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public ST_CuttingParameter[] cuttinPara = new ST_CuttingParameter[9];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public ST_PiercingLaserControl[] piercingPara = new ST_PiercingLaserControl[6];

        public TechnologyNodeList()
        {
            for (int i = 0; i < 9; i++) // 切割需要9个对象 
            {
                cuttinPara[i] = new ST_CuttingParameter();
                if (i < 6) //穿孔只有6层
                    piercingPara[i] = new ST_PiercingLaserControl();
            }
        }
    }
}
