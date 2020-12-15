using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.TechModel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ST_CuttingParameter
    {
        public ST_CuttingParameter()
        {
            iCuttingGasType = 1;
        }
        public double fCuttingSpeed { get; set; } //(*切割速度*)
        public double fCuttingGasPress { get; set; }//(*切割气压*)
        public double fCuttingHeight { get; set; }//(*切割高度*)
        public double fCuttingFouce { get; set; }// *切割焦点*)
        public double fCuttingPrecision { get; set; }// 	(*切割精度*)
        public double fCuttingCompensation { get; set; }// (*割缝补偿*)
        public double fUpHeight { get; set; }// (*Z轴上抬高度*)
        public double fPeotectHeight { get; set; }// (*Z轴随动最低点*)
        public Int16 iCuttingPower { get; set; }// (*切割功率*)
        public Int16 iCuttingFrequency { get; set; }// (*切割频率*)
        public Int16 iCuttingDuty { get; set; }// (*切割占空比*)
        public Int16 iCuttingGasType { get; set; }//(*切割气体类型*)
        public Int16 iCuttingGasDelay { get; set; }//(*切割吹气延时*)
        public Int16 iCuttingBeamDelay { get; set; }//	(*烧穿延时*)
        public Int16 iPercingType { get; set; }//(*穿孔类型*)
        public Int16 iFollowingType { get; set; }//(*随动类型*)
        public Int16 iCuttingAcc { get; set; }//(*切割加速度*)
        public Int16 iCuttingRamptime { get; set; }//(*切割加速时间*)
        public Int16 iGeomRamptime { get; set; }//	(*切割圆弧加速时间*)
        public Int16 iCuttingPowerModel { get; set; }//	(   (*功率控制开关*)
        public double fGasAlarmPress { get; set; }//	报警


    }
}
