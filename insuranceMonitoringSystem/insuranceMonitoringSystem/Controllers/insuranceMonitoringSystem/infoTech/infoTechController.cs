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

        public InfoTechEmployessModel query = new InfoTechEmployessModel();

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

        public IActionResult employeeDashboard()
        {
            ViewData.Model = query.getempList();
            return PartialView("~/Views/insuranceMonitoringSystem/infoTech/employee/employeeDashboard.cshtml");
        }

        public IActionResult newEmployee()
        {
            return View("~/Views/insuranceMonitoringSystem/infoTech/employee/empForm.cshtml");
        }
      

        [HttpPost]
        public string insertEmployeeAsync(string empFname, string empMname, string empLname)
        {
            query.empFname = empFname;
            query.empMname = empMname;
            query.empLname = empLname;
            query.insertEmployee();
            return "Save";
        }

        [HttpPost]
        public string updateEmployeeAsync(string empFname, string empMname, string empLname,int empId)
        {
            query.empId = empId;
            query.empFname = empFname;
            query.empMname = empMname;
            query.empLname = empLname;
            query.updateEmployee();
            return "Updated";
        }

    
        public IActionResult editEmployee(int empId)
        {
            ViewData["empId"] = empId;
            query.empId = empId;
            DataTable result = query.getEmployeeInfo();

            foreach(DataRow row in result.Rows)
            {
                ViewData["empId"] = row["empId"].ToString();
                ViewData["empFname"] = row["empFname"].ToString();
                ViewData["empMname"] = row["empMname"].ToString();
                ViewData["empLname"] = row["empLname"].ToString();
            }


            return View("~/Views/insuranceMonitoringSystem/infoTech/employee/empForm.cshtml");
        }

        public IActionResult deleteEmployee(int empId)
        {
            ViewData["empId"] = empId;
            query.empId = empId;
            query.deleteEmployee();

            return View("~/Views/insuranceMonitoringSystem/infoTech/employee/employeeDashBoard.cshtml");
        }


    }

    }