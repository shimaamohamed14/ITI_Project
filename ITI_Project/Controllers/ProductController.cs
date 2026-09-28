using ITI_Project.Context;
using ITI_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class ProductController : Controller
    {
        MyDbContext db = new MyDbContext();

        [HttpGet]
        public IActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = db.Products.Include(p=>p.Category).FirstOrDefault(p=>p.ProductId==id) ;
            if(product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories,"CategoryId","Name");
            return View();            
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product!=null && ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            var product = db.Products.Find(id);
            if(product != null)
            {
                ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(product);
            }
            return RedirectToAction("Index");
           
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product != null && ModelState.IsValid)
            {
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "Name");
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            if(product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
