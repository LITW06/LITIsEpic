using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LITIsEpic.Data;

namespace LITIsEpic.Web.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<VisitCounts> FiveMostFrequentIPs { get; set; }
        public int TodayCount { get; set; }
        public string MostPopularIP { get; set; }
    }
}
