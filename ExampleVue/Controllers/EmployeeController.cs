using ServiceLayer.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleVue.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        //EmployeeServicesImpl : IEmployeeServices
        public EmployeeController()
        {
            _employeeServices = new EmployeeServicesImpl();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public JsonResult GetEmployess()
        {
            var result = _employeeServices.GetAllEmployees();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}