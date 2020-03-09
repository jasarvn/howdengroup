using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using insuranceMonitoringSystem.Models.InfoTech;
using insuranceMonitoringSystem.Models;


namespace insuranceMonitoringSystem.Controllers.insuranceMonitoringSystem.infoTech
{
    public class infoTechDepartmentController : Controller
    {
        public InfoTechDepartmentModel query = new InfoTechDepartmentModel();
        public IActionResult departmentDashboard()
        {
            ViewData.Model = query.getdeptList();
            return PartialView("~/Views/insuranceMonitoringSystem/infoTech/department/departmentDashboard.cshtml");
        }

        public IActionResult newDepartment()
        {
            return View("~/Views/insuranceMonitoringSystem/infoTech/department/deptForm.cshtml");
        }


        [HttpPost]
        public string insertDepartmentAsync(string deptDescription)
        {
            query.deptDescription = deptDescription;
            query.insertDepartment();
            return "Save";
        }

        [HttpPost]
        public string updateDepartmentAsync(int deptId)
        {
            query.deptId = deptId;
            query.updateDepartment();
            return "Updated";
        }


        public IActionResult editDepartment(int deptId)
        {
            ViewData["deptId"] = deptId;
            query.deptId = deptId;
            DataTable result = query.getDepartmentInfo();

            foreach (DataRow row in result.Rows)
            {
                ViewData["deptId"] = row["deptId"].ToString();
                ViewData["deptDescription"] = row["deptDescription"].ToString();
             }


            return View("~/Views/insuranceMonitoringSystem/infoTech/department/deptForm.cshtml");
        }

        public IActionResult deleteDepartment(int deptId)
        {
            ViewData["deptId"] = deptId;
            query.deptId = deptId;
            query.deleteDepartment();

            return View("~/Views/insuranceMonitoringSystem/infoTech/department/deptForm.cshtml");
        }
    }
}