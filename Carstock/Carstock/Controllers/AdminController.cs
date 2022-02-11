using Microsoft.AspNetCore.Mvc;
using Carstock.Data;
using Carstock.Models;
using Microsoft.EntityFrameworkCore;

namespace Carstock.Controllers
{
    public class AdminController : Controller
    {

        private readonly carstockContext _context;

        // Constructeur
        public AdminController(carstockContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ;
            return View();
        }

        public IActionResult AdminList()
        {
            IEnumerable<Admin> admin = _context.Admins.OrderBy(Admin => Admin.Name);
            return View(admin);
        }

        // Add new admin
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAdmin(Admin Adm, int id)
        {
            if (ModelState.IsValid)
            {

                _context.Add(Adm);
                _context.SaveChanges();
                TempData["Succes"] = "Admin Added";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult RemoveAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveAdmin(Admin Adm, int id)
        {
            Adm.IdAdmin = id;
            _context.Admins.Remove(Adm);
            _context.SaveChanges();
            TempData["success"] = "Admin deleted";
            return RedirectToAction("Index");
        }

        //Display each car model stock
        public IActionResult DisplayStock() 
        {
            ViewData["Carmodel"] = _context.Carmodels.ToList();
            ViewData["Car"] = _context.Cars.ToList();
            return View(); 
        }
        
    }
}
