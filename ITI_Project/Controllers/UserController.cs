using ITI_Project.Context;
using ITI_Project.Models;
using ITI_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Controllers
{
    public class UserController : Controller
    {
        MyDbContext db = new MyDbContext();

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            var ExistEmail = db.Users.FirstOrDefault(e => e.Email == user.Email);
            if (ExistEmail != null)
            {
                ModelState.AddModelError("Email", "Email already exists, Please use a different email");
                return View();
            }
            if(user != null && ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if(login != null && ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(e => e.Email == login.Email && e.Password == login.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("UserName", user.FirstName + " " + user.LastName);
                    return RedirectToAction("Index", "Product");
                }
                ModelState.AddModelError("", "Invalid Email and Password");
            }           
            return View(login);

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
