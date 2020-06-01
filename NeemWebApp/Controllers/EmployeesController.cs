using NeemDataAccess.Interfaces;
using NeemDataModel.Models;
using System.Net;
using System.Web.Mvc;

namespace NeemWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Using dependency injection
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        //public ActionResult Index()
        //{
        //    var employees = _employeeRepository.GetEmployee();
        //    return View(employees);
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadData()
        {
            var employees = _employeeRepository.GetEmployee();
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.InsertEmployee(employee);
                _employeeRepository.Save();

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = _employeeRepository.GetEmployeeByID(id.Value);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);
                _employeeRepository.Save();

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.GetEmployeeByID(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }

            _employeeRepository.DeleteEmployee(id.Value);
            _employeeRepository.Save();

            //return RedirectToAction("Index");

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }




    }
}
