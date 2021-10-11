using Iftaa2.Data;
using Iftaa2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa2.Controllers
{
    public class EmployeesController : Controller
    {
        private AppDbContext db;
        public EmployeesController(AppDbContext _db)
        {
            db = _db;
        }


        public IActionResult Index()
        {
            return View(db.Employees.Where(x=>x.isDeleted==false && x.isActive==true).OrderByDescending(x => x.EmployeeId).Take(4));
        }

        public IActionResult ViewEmp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);





            //if (id == null)
            //{
            //    return NotFound();
            //}
            //var employee = (from emp in db.Employees
            //                where emp.EmployeeId == id
            //                select emp).FirstOrDefault();
            //if (employee == null)
            //{
            //    return NotFound();
            //}
            //return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.isActive = true;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Update(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.isDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}
