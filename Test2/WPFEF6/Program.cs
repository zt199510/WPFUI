using EFDBContext;
using HymsonContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEF6
{
    class Program
    {
        static void Main(string[] args)
        {

            HymsonTechInfo info = new HymsonTechInfo();
            info.DeviceSn = "233";
            HymsonDBContext.Instance.hymsonTechInfos.Add(info);
            HymsonDBContext.Instance.SaveChanges();
            int a = HymsonDBContext.Instance.hymsonTechInfos.Count();

            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
