using HymsonContext;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBContext
{
    public class HymsonDBContext:DbContext
    {
        public static readonly string DbPath = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}Db\\HymsonTech.db";
        public DbSet<HymsonTechInfo> hymsonTechInfos { get; set; }
        public DbSet<HymsonTechCommonPara> hymsonTechCommonParas { get; set; }

        public DbSet<HymsonTechCuttingPara> hymsonTechCuttingParas { get; set; }

        public DbSet<HymsonTechPiecringPara> hymsonTechPiecringParas { get; set; }

        private static readonly Lazy<HymsonDBContext> _instance =
       new Lazy<HymsonDBContext>(() => {

           DbConnection sqliteCon = SQLiteProviderFactory.Instance.CreateConnection();
           sqliteCon.ConnectionString = DbPath;
           return new HymsonDBContext(sqliteCon);
       });

        public static HymsonDBContext Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private HymsonDBContext(DbConnection con) : base(con, true) { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<HymsonDBContext>(modelBuilder));
        }
    }
}
