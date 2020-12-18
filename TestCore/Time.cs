using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCore
{
    public static class Time
    {
        private static readonly DateTime StartTime = DateTime.UtcNow;
        private static readonly Stopwatch Stopwatch = Stopwatch.StartNew();

        public static DateTime Now => StartTime + Stopwatch.Elapsed;
    }
}
