using Microsoft.AspNetCore.Mvc;

namespace Carstock.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
