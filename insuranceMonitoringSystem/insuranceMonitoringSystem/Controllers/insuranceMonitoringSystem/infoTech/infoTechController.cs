using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using insuranceMonitoringSystem.Models;



namespace insuranceMonitoringSystem.Controllers.insuranceMonitoringSystem.infoTech.infoTechController
{
    public class infoTechController : Controller
    {
        private readonly ILogger<infoTechController> _logger;

        
        public infoTechController(ILogger<infoTechController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TestModel test2 = new TestModel();
            ViewData.Model = test2.testdata();
            
            return View("~/Views/insuranceMonitoringSystem/infoTech/Index.cshtml");
        }

        public IActionResult newEmployee()
        {
            return View("~/Views/insuranceMonitoringSystem/infoTech/newEmpForm.cshtml");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}