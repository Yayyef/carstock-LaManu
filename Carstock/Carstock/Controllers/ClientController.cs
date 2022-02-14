using Carstock.Data;
using Carstock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carstock.Controllers
{
    public class ClientController : Controller
    {
        private readonly carstockContext _context;

        public ClientController(carstockContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Catalogue(string category, string brand, string type)
        {
            // Je récupère les marques de voitures avec Select() mais seulement lorsqu'elles sont distinctes avec Distinct()
            var brands = _context.Carmodels.Select(b => b.Brand).Distinct();
            var types = _context.Carmodels.Select(t => t.Type).Distinct();
            var categories = _context.Carmodels.Select(c => c.Category).Distinct();

            ViewBag.Brands = brands;
            ViewBag.Types = types;
            ViewBag.Categories = categories;

            // Comment faire la même chose avec la syntaxe avec des Where?
            var carModels = from c in _context.Carmodels select c;

            if (!String.IsNullOrEmpty(brand))
            {
                carModels = carModels.Where(b => b.Brand == brand);
                ViewData["selectedBrand"] = brand;
            }
            if (!String.IsNullOrEmpty(type))
            {
                carModels = carModels.Where(b => b.Type == type);
                ViewData["selectedType"] = type;
            }
            if (!String.IsNullOrEmpty(category))
            {
                carModels = carModels.Where(b => b.Category == category);
                ViewData["selectedCategory"] = category;
            }

           

            return View(carModels);
        }

    }
}
