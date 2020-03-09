using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using insuranceMonitoringSystem.Models;


namespace insuranceMonitoringSystem.Controllers.insuranceMonitoringSystem.broker.brokerAgent
{
    public class brokerAgentController : Controller
    {
        private readonly ILogger<brokerAgentController> _logger;

        public brokerAgentController(ILogger<brokerAgentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/insuranceMonitoringSystem/broker/brokerAgent/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}