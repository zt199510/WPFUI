using HymsonContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hymson.Data
{
    public class HymsonConetxt:DbContext
    {
        public static readonly string DbPath = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}HymsonTech.db";
        public DbSet<HymsonTechInfo> hymsonTechInfos { get; set; }
        public DbSet<HymsonTechCommonPara> hymsonTechCommonParas { get; set; }

        public DbSet<HymsonTechCuttingPara> hymsonTechCuttingParas { get; set; }

        public DbSet<HymsonTechPiecringPara> hymsonTechPiecringParas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(DbPath);
        }
    }
}
