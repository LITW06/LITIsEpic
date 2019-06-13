using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LITIsEpic.Data
{
    public class VisitsRepository
    {
        private string _connectionString;

        public VisitsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddVisit(string ipAddress)
        {
            Visit visit = new Visit
            {
                IpAddress = ipAddress,
                Date = DateTime.Now
            };
            using (var context = new LitIsEpicContext(_connectionString))
            {
                context.Visits.Add(visit);
                context.SaveChanges();
            }
        }

        public IEnumerable<VisitCounts> GetFiveMostFrequentIPs()
        {
            using (var context = new LitIsEpicContext(_connectionString))
            {
                return context.Visits.GroupBy(v => v.IpAddress)
                    .OrderByDescending(v => v.Count()).Take(5).Select(g => new VisitCounts
                    {
                        IpAddress = g.Key,
                        Count = g.Count()
                    }).ToList();
            }
        }

        public int GetVisitCountForToday()
        {
            using (var context = new LitIsEpicContext(_connectionString))
            {
                return context.Visits.Count(v => v.Date.Date == DateTime.Today);
            }
        }

        public string GetMostPopularIpAddress()
        {
            return GetFiveMostFrequentIPs().First().IpAddress;
        }
    }
}
