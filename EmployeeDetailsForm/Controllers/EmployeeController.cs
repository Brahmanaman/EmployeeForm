using EmployeeDetailsForm.Data;
using EmployeeDetailsForm.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsForm.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext db; 
        public EmployeeController(EmployeeContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Employee.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var data = new Employee
                {
                    Name = employee.Name,
                    City = employee.City,
                    State = employee.State,
                    salary = employee.salary,

                };
                db.Employee.Add(data);
                db.SaveChanges();
                TempData["error"] = "Data Successfully saved.";
                return RedirectToAction("Index");
                
            }

            else
            {
                TempData["error"] = "Empty field can't submit.";
                return View(employee);
            }
            
        }

        public IActionResult Edit(int id)
        {
            var data = db.Employee.Where(x => x.Id == id).FirstOrDefault();
            var result = new Employee()
            {
                Name = data.Name,
                City = data.City,
                salary = data.salary,
                State = data.State,
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var data = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                City = employee.City,
                State = employee.State,
                salary = employee.salary,
            };
            db.Employee.Update(data);
            db.SaveChanges();
            TempData["error"] = "Record Successfully updated.";
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var data = db.Employee.Where(x => x.Id == id).FirstOrDefault();
            db.Remove(data);
            db.SaveChanges();
            TempData["error"] = "Record Successfully deleted.";
            return RedirectToAction("Index");
        }
    }
}
