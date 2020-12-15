using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.TechModel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ST_PiercingLaserControl
    {
        public ST_PiercingLaserControl()
        {
            PercingGasType = 0;
        }


        public double PercingGasPress { get; set; } //(*普通穿孔气体压力*)
        public double PercingHeight { get; set; } //(*普通穿孔高度*)
        public double PercingFocusPos { get; set; }            //(*普通穿孔焦点位置*)
        public Int16 PercingTime { get; set; }  //(*普通穿孔时间*)
        public Int16 PercingPower { get; set; }        //(*普通穿孔功率*)
        public Int16 PercingFrequency { get; set; }        //(*普通穿孔频率*)
        public Int16 PercingDuty { get; set; }   //(*普通穿孔占空比*)
        public Int16 MultiPiercingNum { get; set; }      //(*三级穿孔模式选择*)
        public Int16 PercingGasType { get; set; }                  //(*普通穿孔气体类型*)
        public Int16 Per { get; set; }             //(*补齐字节*)
        public Int16 Per2 { get; set; }  //(*补齐字节*)
    }
}
