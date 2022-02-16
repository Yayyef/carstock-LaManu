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

        // Je rends les paramètres nullables pour mes ViewData.
        public IActionResult Catalogue(string? category, string? brand, string? type)
        {
            var carModels = from c in _context.Carmodels select c;

            // On évite les if avec des ternaires.
            carModels = (!String.IsNullOrEmpty(brand)) ? carModels.Where(b => b.Brand == brand) : carModels;
            carModels = (!String.IsNullOrEmpty(type)) ? carModels.Where(b => b.Type == type) : carModels;
            carModels = (!String.IsNullOrEmpty(category)) ? carModels.Where(b => b.Category == category) : carModels;

            // On instancie un objet du type de ma vue modale pour passer les informations pertinentes à la vue.
            ClientCatalogueViewModel clientCatalogueViewModel = new()
            {
                Carmodels = carModels,
                // On ne sélectionne que les voitures qui n'ont pas d'IdCustomer affecté. A TESTER.
                Cars = (from c in _context.Cars where c.IdCustomer == null select c).ToList(),
                SelectedBrand = brand,
                SelectedType = type,
                SelectedCategory = category,
                Brands = _context.Carmodels.Select(c => c.Brand).Distinct(),
                Types = _context.Carmodels.Select(c => c.Type).Distinct(),
                Categories = _context.Carmodels.Select(c => c.Category).Distinct()
            };
            
            return View(clientCatalogueViewModel);
        }

        public IActionResult Purchase(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Catalogue");
            }
            // On utilise First pour obtenir une voiture unique.
            var car = _context.Cars.Where(c => c.IdModel == id).Include(c => c.IdModelNavigation).First();

            //var car = _context.Cars.First(car => car.IdModel == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        public IActionResult Test()
        {
            var car = _context.Cars.Include(c => c.IdModelNavigation);

            return View(car);
        }

        [HttpPost, ActionName("Purchase")]
        [ValidateAntiForgeryToken]
        public IActionResult PurchaseConfirmation(int? carId)
        {

            if (carId == null)
            {
                return View();
            }
            var car = _context.Cars.Find(carId);

            _context.Cars.Remove(car);
            _context.SaveChanges();

            TempData["Confirmation"] = $"The car {car.IdCar} has been bought. Thank You!";
            return RedirectToAction("Catalogue");
        }

        //public IActionResult Catalogue(string? category = null, string? brand = null, string? type = null)
        //{
        //    // Je récupère les marques de voitures avec Select() mais seulement lorsqu'elles sont distinctes avec Distinct()
        //    var brands = _context.Carmodels.Select(b => b.Brand).Distinct();
        //    var types = _context.Carmodels.Select(t => t.Type).Distinct();
        //    var categories = _context.Carmodels.Select(c => c.Category).Distinct();

        //    ViewBag.Brands = brands;
        //    ViewBag.Types = types;
        //    ViewBag.Categories = categories;

        //    // Comment faire la même chose avec la syntaxe avec des Where?
        //    var carModels = from c in _context.Carmodels select c;

        //    // J'envoie sytématiquement le paramètre à la vue en ViewData pour permettre les un filtrage selon plusieurs critères. Il sont récupérés dans l'url grâce aux asp-route- dans le html.

        //    ViewData["selectedBrand"] = brand;
        //    ViewData["selectedType"] = type;
        //    ViewData["selectedCategory"] = category;
        //    // On évite les if avec des ternaires.
        //    carModels = (!String.IsNullOrEmpty(brand)) ? carModels.Where(b => b.Brand == brand) : carModels;
        //    carModels = (!String.IsNullOrEmpty(type)) ? carModels.Where(b => b.Type == type) : carModels;
        //    carModels = (!String.IsNullOrEmpty(category)) ? carModels.Where(b => b.Category == category) : carModels;

        //    return View(carModels);
        //}

    }
}
