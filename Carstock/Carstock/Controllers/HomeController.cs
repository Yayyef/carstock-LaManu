using Carstock.Data;
using Carstock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Carstock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly carstockContext _db;

        public HomeController(ILogger<HomeController> logger, carstockContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Carmodel> Carstock = _db.Carmodels;
            return View(Carstock);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}