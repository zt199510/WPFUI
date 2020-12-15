using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.TechModel
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class ST_CommonParameter
    {
        public ST_CommonParameter()
        {
            fPeotectdistance = 0.1;
            fPreGapDist = 25;
        }

        public double fEnergyCtrlLowSpeed { get; set; } //(*能量控制拐角速度*)
        public double fEnergyCtrlHighSpeed { get; set; } //(*能量控制启动速度*)
        public double fCutCircularRadius { get; set; } //(*打孔后切圆半径*)
        public double fCutCircularSpeed { get; set; } //(*打孔后切圆速度*)
        public double fGasChangeTime { get; set; } //(*气体切换延时*)
        public double fConerPauseTime { get; set; } //(*转角吹气延时*)
        public double fGasDelayCloseTime { get; set; } //(*切割关气延时*)
        public double fPeotectdistance { get; set; } // (*Z轴随动上抬起跳距离 *)
        public double fPreGapDist { get; set; } // (*Z轴蛙跳提前距离 *)
        public double fSlowStartTime { get; set; } //(*慢起刀时间*)
        public double iSlowStartFeedHigh { get; set; } //(*慢起刀高度*)
        public Int16 iEnergyCtrlType { get; set; } //(*能量控制类型，1功率控制 2占空比控制*)
        public Int16 iEnergyCtrlLowPower { get; set; } //(*能量控制拐角功率*)
        public Int16 iEnergyCtrlLowDuty { get; set; } //(*能量控制拐角占空比*)
        public Int16 iAutoBorderEnable { get; set; } //(*自动寻边功能开关，1开启，2关闭*)
        public Int16 iAngleEnable { get; set; } //(*坐标旋转开关，1开启，2关闭*)
        public Int16 iCutCircularAfterPiercing { get; set; } //(*打孔后切圆开关，1开启，2关闭*)
        public Int16 iGasChangeEN { get; set; } //(*气体切换延时，1开启，2关闭*)
        public Int16 iConerStart { get; set; } //(*拐角工艺开关，1开启，2关闭*)
        public Int16 iSlowStart { get; set; } //(*慢起刀，1开启，2关闭*)
        public Int16 iSlowStartFeedFactor { get; set; } //(*慢起刀速度倍率*)
        public double fSlowStartDistance { get; set; } //(*慢速距离*)

        public float fCuttingMaterials { get; set; } //(*切割板材材料*)
        public float fCuttingThickness { get; set; } //(*切割板材厚度*)
        public float fCuttingGas { get; set; } //(*切割气体*)
        public float fCuttingNozzle { get; set; } //(*切割喷嘴直径*)

        public Int16 iCornerStart { get; set; } // 尖角功能开关
        public double iCornerAngleLimit { get; set; } // 尖角角度限制
        public double iCornerPreDist { get; set; } //   尖角前段距离
        public double iCornerPostDist { get; set; } // 尖角后段距离
        public Int16 iCornerFeedFactor { get; set; } // 速度倍率
        public Int16 iCornerPower { get; set; } // 尖角功率
        public Int16 iCornerFrequency { get; set; } // 尖角频率
        public Int16 iCornerDuty { get; set; } // 尖角占空比
        public double iCornerPress { get; set; } //   尖角气压
        public Int16 iCoolPiontStart { get; set; } // 冷却点功能
        public double iCoolPiontPress { get; set; } //   气压
        public double iCoolPiontDelay { get; set; } // 冷却时间

        public double fHSCFunction { get; set; } //加速度因子

        public double fBspline { get; set; } //样条拟合


    }
}
