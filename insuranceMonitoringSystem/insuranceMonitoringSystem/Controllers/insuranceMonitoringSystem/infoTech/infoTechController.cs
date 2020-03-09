using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using insuranceMonitoringSystem.Models.InfoTechModel;
using insuranceMonitoringSystem.Models;

namespace insuranceMonitoringSystem.Controllers.insuranceMonitoringSystem.infoTech.infoTechController
{
    public class infoTechController : Controller
    {
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
            InfoTechModel query = new InfoTechModel();
            ViewData.Model = query.getempList();
            
            return View("~/Views/insuranceMonitoringSystem/infoTech/Index.cshtml");
        }

        public IActionResult newEmployee()
        {
            return View("~/Views/insuranceMonitoringSystem/infoTech/empForm.cshtml");
        }
      

        [HttpPost]
        public string insertEmployeeAsync(string empFname, string empMname, string empLname)
        {
            InfoTechModel query = new InfoTechModel();
            query.empFname = empFname;
            query.empMname = empMname;
            query.empLname = empLname;
            query.insertEmployee();
            return "Save";
        }

        [HttpPost]
        public string updateEmployeeAsync(string empFname, string empMname, string empLname,int empId)
        {
            InfoTechModel query = new InfoTechModel();
            query.empId = empId;
            query.empFname = empFname;
            query.empMname = empMname;
            query.empLname = empLname;
            query.updateEmployee();
            return "Updated";
        }

        /* public IActionResult displayTest()
         {
             return PartialView("~/Views/insuranceMonitoringSystem/infoTech/newEmpForm.cshtml");
         }*/

        public IActionResult editEmployee(int empId)
        {
            ViewData["empId"] = empId;
            InfoTechModel query = new InfoTechModel();
            query.empId = empId;
            DataTable result = query.getEmployeeInfo();

            foreach(DataRow row in result.Rows)
            {
                ViewData["empId"] = row["empId"].ToString();
                ViewData["empFname"] = row["empFname"].ToString();
                ViewData["empMname"] = row["empMname"].ToString();
                ViewData["empLname"] = row["empLname"].ToString();
            }


            return View("~/Views/insuranceMonitoringSystem/infoTech/empForm.cshtml");
        }

        public IActionResult deleteEmployee(int empId)
        {
            ViewData["empId"] = empId;
            InfoTechModel query = new InfoTechModel();
            query.empId = empId;
            query.deleteEmployee();

            return View("~/Views/insuranceMonitoringSystem/infoTech/empForm.cshtml");
        }


    }

    }