using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext employeeContext;
       
        public HomeController(EmployeeContext ec)
        {
            employeeContext = ec;
            
        }
        //view list of employees
        public IActionResult Index()
        {
            return View(employeeContext.Employee);
        }

        // Add/ Edit employee
        public IActionResult Create(int? id)
        {
            if(id != null)
            {
                ViewBag.Title = "Edit Employee";
                return View(employeeContext.Employee.Where(a => a.EmployeeId == id).FirstOrDefault());
            }
            ViewBag.Title = "Create Employee";
            return View(new Employee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if(employee.EmployeeId > 0)
                {
                    
                    employeeContext.Employee.Update(employee);
                }
                else
                {
                    employeeContext.Employee.Add(employee);
                }
                
                employeeContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

     

     //Delete employee
        public IActionResult Delete(int id)
        {
            var teacher = employeeContext.Employee.Where(a => a.EmployeeId == id).FirstOrDefault();
            employeeContext.Employee.Remove(teacher);
            employeeContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
