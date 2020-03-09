using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using insuranceMonitoringSystem.Models;


namespace insuranceMonitoringSystem.Controllers.insuranceMonitoringSystem.insuranceCompany.insuranceCompanyController
{
    public class insuranceCompanyController : Controller
    {
        private readonly ILogger<insuranceCompanyController> _logger;

        public insuranceCompanyController(ILogger<insuranceCompanyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/insuranceMonitoringSystem/insuranceCompany/Index.cshtml");
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