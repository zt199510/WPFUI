﻿// <auto-generated />
using Hymson.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hymson.Data.Migrations
{
    [DbContext(typeof(HymsonConetxt))]
    partial class HymsonConetxtModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("HymsonContext.HymsonTechCommonPara", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuiqueCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("fBspline")
                        .HasColumnType("TEXT");

                    b.Property<string>("fConerPauseTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCutCircularRadius")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCutCircularSpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingGas")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingMaterials")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingNozzle")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingThickness")
                        .HasColumnType("TEXT");

                    b.Property<string>("fEnergyCtrlHighSpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("fEnergyCtrlLowSpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("fGasChangeTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("fGasDelayCloseTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("fHSCFunction")
                        .HasColumnType("TEXT");

                    b.Property<string>("fPeotectdistance")
                        .HasColumnType("TEXT");

                    b.Property<string>("fPreGapDist")
                        .HasColumnType("TEXT");

                    b.Property<string>("fSlowStartDistance")
                        .HasColumnType("TEXT");

                    b.Property<string>("fSlowStartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("iAngleEnable")
                        .HasColumnType("TEXT");

                    b.Property<string>("iAutoBorderEnable")
                        .HasColumnType("TEXT");

                    b.Property<string>("iConerStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCoolPiontDelay")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCoolPiontPress")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCoolPiontStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerAngleLimit")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerDuty")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerFeedFactor")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerFrequency")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerPostDist")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerPower")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerPreDist")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerPress")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCornerStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCutCircularAfterPiercing")
                        .HasColumnType("TEXT");

                    b.Property<string>("iEnergyCtrlLowDuty")
                        .HasColumnType("TEXT");

                    b.Property<string>("iEnergyCtrlLowPower")
                        .HasColumnType("TEXT");

                    b.Property<string>("iEnergyCtrlType")
                        .HasColumnType("TEXT");

                    b.Property<string>("iGasChangeEN")
                        .HasColumnType("TEXT");

                    b.Property<string>("iSlowStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("iSlowStartFeedFactor")
                        .HasColumnType("TEXT");

                    b.Property<string>("iSlowStartFeedHigh")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("hymsonTechCommonParas");
                });

            modelBuilder.Entity("HymsonContext.HymsonTechCuttingPara", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MyProperty")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuiqueCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingCompensation")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingFouce")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingGasPress")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingHeight")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingPrecision")
                        .HasColumnType("TEXT");

                    b.Property<string>("fCuttingSpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("fGasAlarmPress")
                        .HasColumnType("TEXT");

                    b.Property<string>("fPeotectHeight")
                        .HasColumnType("TEXT");

                    b.Property<string>("fUpHeight")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingAcc")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingBeamDelay")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingDuty")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingFrequency")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingGasDelay")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingGasType")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingPower")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingPowerModel")
                        .HasColumnType("TEXT");

                    b.Property<string>("iCuttingRamptime")
                        .HasColumnType("TEXT");

                    b.Property<string>("iPercingType")
                        .HasColumnType("TEXT");

                    b.Property<int>("typeName")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("hymsonTechCuttingParas");
                });

            modelBuilder.Entity("HymsonContext.HymsonTechInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Annotation")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeviceSn")
                        .HasColumnType("TEXT");

                    b.Property<string>("IsHttpPost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Isinitialize")
                        .HasColumnType("TEXT");

                    b.Property<string>("LaserPower")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nozzle")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuiqueCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("TechnologyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenanltId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThicknessInfo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("hymsonTechInfos");
                });

            modelBuilder.Entity("HymsonContext.HymsonTechPiecringPara", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MultiPiercingNum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Per")
                        .HasColumnType("TEXT");

                    b.Property<string>("Per2")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingDuty")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingFocusPos")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingFrequency")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingGasPress")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingGasType")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingHeight")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingPower")
                        .HasColumnType("TEXT");

                    b.Property<string>("PercingTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuiqueCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("hymsonTechPiecringParas");
                });
#pragma warning restore 612, 618
        }
    }
}
