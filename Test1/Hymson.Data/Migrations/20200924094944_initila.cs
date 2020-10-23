using Microsoft.EntityFrameworkCore.Migrations;

namespace Hymson.Data.Migrations
{
    public partial class initila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hymsonTechCommonParas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fBspline = table.Column<string>(nullable: true),
                    fConerPauseTime = table.Column<string>(nullable: true),
                    fCutCircularRadius = table.Column<string>(nullable: true),
                    fCutCircularSpeed = table.Column<string>(nullable: true),
                    fCuttingGas = table.Column<string>(nullable: true),
                    fCuttingMaterials = table.Column<string>(nullable: true),
                    fCuttingNozzle = table.Column<string>(nullable: true),
                    fCuttingThickness = table.Column<string>(nullable: true),
                    fEnergyCtrlHighSpeed = table.Column<string>(nullable: true),
                    fEnergyCtrlLowSpeed = table.Column<string>(nullable: true),
                    fGasChangeTime = table.Column<string>(nullable: true),
                    fGasDelayCloseTime = table.Column<string>(nullable: true),
                    fHSCFunction = table.Column<string>(nullable: true),
                    fPeotectdistance = table.Column<string>(nullable: true),
                    fPreGapDist = table.Column<string>(nullable: true),
                    fSlowStartDistance = table.Column<string>(nullable: true),
                    fSlowStartTime = table.Column<string>(nullable: true),
                    iAngleEnable = table.Column<string>(nullable: true),
                    iAutoBorderEnable = table.Column<string>(nullable: true),
                    iConerStart = table.Column<string>(nullable: true),
                    iCoolPiontDelay = table.Column<string>(nullable: true),
                    iCoolPiontPress = table.Column<string>(nullable: true),
                    iCoolPiontStart = table.Column<string>(nullable: true),
                    iCornerAngleLimit = table.Column<string>(nullable: true),
                    iCornerDuty = table.Column<string>(nullable: true),
                    iCornerFeedFactor = table.Column<string>(nullable: true),
                    iCornerFrequency = table.Column<string>(nullable: true),
                    iCornerPostDist = table.Column<string>(nullable: true),
                    iCornerPower = table.Column<string>(nullable: true),
                    iCornerPreDist = table.Column<string>(nullable: true),
                    iCornerPress = table.Column<string>(nullable: true),
                    iCornerStart = table.Column<string>(nullable: true),
                    iCutCircularAfterPiercing = table.Column<string>(nullable: true),
                    iEnergyCtrlLowDuty = table.Column<string>(nullable: true),
                    iEnergyCtrlLowPower = table.Column<string>(nullable: true),
                    iEnergyCtrlType = table.Column<string>(nullable: true),
                    iGasChangeEN = table.Column<string>(nullable: true),
                    iSlowStart = table.Column<string>(nullable: true),
                    iSlowStartFeedFactor = table.Column<string>(nullable: true),
                    iSlowStartFeedHigh = table.Column<string>(nullable: true),
                    QuiqueCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hymsonTechCommonParas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hymsonTechCuttingParas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fCuttingCompensation = table.Column<string>(nullable: true),
                    MyProperty = table.Column<string>(nullable: true),
                    fCuttingFouce = table.Column<string>(nullable: true),
                    fCuttingGasPress = table.Column<string>(nullable: true),
                    fCuttingHeight = table.Column<string>(nullable: true),
                    fCuttingPrecision = table.Column<string>(nullable: true),
                    fCuttingSpeed = table.Column<string>(nullable: true),
                    fGasAlarmPress = table.Column<string>(nullable: true),
                    fPeotectHeight = table.Column<string>(nullable: true),
                    fUpHeight = table.Column<string>(nullable: true),
                    iCuttingAcc = table.Column<string>(nullable: true),
                    iCuttingBeamDelay = table.Column<string>(nullable: true),
                    iCuttingDuty = table.Column<string>(nullable: true),
                    iCuttingFrequency = table.Column<string>(nullable: true),
                    iCuttingGasDelay = table.Column<string>(nullable: true),
                    iCuttingGasType = table.Column<string>(nullable: true),
                    iCuttingPower = table.Column<string>(nullable: true),
                    iCuttingPowerModel = table.Column<string>(nullable: true),
                    iCuttingRamptime = table.Column<string>(nullable: true),
                    iPercingType = table.Column<string>(nullable: true),
                    QuiqueCode = table.Column<string>(nullable: true),
                    typeName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hymsonTechCuttingParas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hymsonTechInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TechnologyName = table.Column<string>(nullable: true),
                    Nozzle = table.Column<string>(nullable: true),
                    Annotation = table.Column<string>(nullable: true),
                    ThicknessInfo = table.Column<string>(nullable: true),
                    Isinitialize = table.Column<string>(nullable: true),
                    QuiqueCode = table.Column<string>(nullable: true),
                    TenanltId = table.Column<string>(nullable: true),
                    DeviceSn = table.Column<string>(nullable: true),
                    CreateTime = table.Column<string>(nullable: true),
                    IsHttpPost = table.Column<string>(nullable: true),
                    LaserPower = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hymsonTechInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hymsonTechPiecringParas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MultiPiercingNum = table.Column<string>(nullable: true),
                    Per = table.Column<string>(nullable: true),
                    Per2 = table.Column<string>(nullable: true),
                    PercingDuty = table.Column<string>(nullable: true),
                    PercingFocusPos = table.Column<string>(nullable: true),
                    PercingFrequency = table.Column<string>(nullable: true),
                    PercingGasPress = table.Column<string>(nullable: true),
                    PercingGasType = table.Column<string>(nullable: true),
                    PercingHeight = table.Column<string>(nullable: true),
                    PercingPower = table.Column<string>(nullable: true),
                    PercingTime = table.Column<string>(nullable: true),
                    QuiqueCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hymsonTechPiecringParas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hymsonTechCommonParas");

            migrationBuilder.DropTable(
                name: "hymsonTechCuttingParas");

            migrationBuilder.DropTable(
                name: "hymsonTechInfos");

            migrationBuilder.DropTable(
                name: "hymsonTechPiecringParas");
        }
    }
}
