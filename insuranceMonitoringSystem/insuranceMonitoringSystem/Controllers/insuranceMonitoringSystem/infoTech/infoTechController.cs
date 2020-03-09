using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using insuranceMonitoringSystem.Models.InfoTech;
using insuranceMonitoringSystem.Models;

namespace insuranceMonitoringSystem.Controllers.insuranceMonitoringSystem.infoTech.infoTechController
{
    public class infoTechController : Controller
    {

        public InfoTechEmployeeModel query = new InfoTechEmployeeModel();

        private readonly ILogger<infoTechController> _logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public infoTechController(ILogger<infoTechController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("~/Views/insuranceMonitoringSystem/infoTech/Index.cshtml");
        }

       

    }

    }