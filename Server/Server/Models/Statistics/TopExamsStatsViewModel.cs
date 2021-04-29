using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.Statistics
{
    public class TopExamsStatsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AttemptsCount { get; set; }
    }
}
