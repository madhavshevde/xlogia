using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xlogia.Domain.Abstract;
using Xlogia.Domain.Entities;

namespace Xlogia.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        // GET: Employee
        public ViewResult List()
        {
            return View(_repository.Employees);
        }

        public ViewResult Edit(int id)
        {
            Employee emp = _repository.Employees.FirstOrDefault(e=>e.ID == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                _repository.Save(employee);
                TempData["message"] = string.Format("{0} has been saved", employee.Name);
                return RedirectToAction("List");
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("List");
        }

        public ViewResult Create()
        {
            return View("Edit", new Employee());
        }
    }
}