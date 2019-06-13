using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LITIsEpic.Data;
using Microsoft.AspNetCore.Mvc;
using LITIsEpic.Web.Models;
using Microsoft.Extensions.Configuration;

namespace LITIsEpic.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            var repo = new VisitsRepository(_connectionString);
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ip == "::1")
            {
                ip = "127.0.0.1";
            }
            repo.AddVisit(ip);
            var vm = new HomePageViewModel
            {
                FiveMostFrequentIPs = repo.GetFiveMostFrequentIPs(),
                TodayCount = repo.GetVisitCountForToday(),
                MostPopularIP = repo.GetMostPopularIpAddress()
            };
            return View(vm);
        }
    }
}
