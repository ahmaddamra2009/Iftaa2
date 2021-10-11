using Iftaa2.Data;
using Iftaa2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa2.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext db;
        public UserController(AppDbContext _db)
        {
            db = _db;
        }



        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var chkUser = db.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password));
            if (chkUser.Any())
            {
                if (chkUser.FirstOrDefault().isActive == true)
                {
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ViewBag.err = "Your account is locked contact admin";
                    return View(user);
                }
            }
            ViewBag.err = "Invalid User/ password";
            return View(user);
        }

    }
}
