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
            return View();
        }


/**********************************************************************************************************************************
 *                                                      GESTION ADMINS
 *********************************************************************************************************************************/
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

/**********************************************************************************************************************************
*                                                              GESTION STOCKS
**********************************************************************************************************************************/
       
        // Display stock
        public IActionResult DisplayStock()
        {
            var stock = _context.Cars.Include(c => c.IdModelNavigation).Where(x => x.IdCustomer == null).OrderBy(x => x.IdModelNavigation.Brand);
            return View(stock);
        }

        //Add car
        public IActionResult AddCar()
		{
            ViewData["Carmodel"] = _context.Carmodels.ToList();
            return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCar(int id, Car c)
        {
                c.IdCar = id;
                _context.Cars.Add(c);
                _context.SaveChanges();
                TempData["success"] = "Car added";
                return RedirectToAction("Index");
        }


        // Remove car from stock
        public IActionResult RemoveCar(int id)
		{
            var deletecar = _context.Cars.Include(c => c.IdModelNavigation).Where(x => x.IdCar == id);
            return View(deletecar);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveCar(int id, Car c)
		{
            c.IdCar = id;
            _context.Remove(c);
            _context.SaveChanges();
            TempData["success"] = "Car deleted";
            return RedirectToAction("Index");
		}



/**********************************************************************************************************************************
 *                                                              GESTION CUSTOMERS
 * *******************************************************************************************************************************/


        //Remove customer
        public IActionResult RemoveCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveCustomer(Customer custom, int id)
        {
            custom.IdCustomer = id;
            _context.Customers.Remove(custom);
            _context.SaveChanges();
            TempData["success"] = "Customer deleted";
            return RedirectToAction("Index");
        }

        //Display all customers
        public IActionResult DisplayCustomers()
        {
            ViewData["Customers"] = GetCustomers();
            return View();

        }


/**********************************************************************************************************************************
*                                                              CAR MODELS
**********************************************************************************************************************************/

        // New car model
        public IActionResult AddModel()
        {
            ViewData["carmodel"] = GetCarmodels();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddModel(int id, Carmodel carmod)
        {
            if (ModelState.IsValid)
            {
                carmod.IdModel = id;
                _context.Carmodels.Add(carmod);
                _context.SaveChanges();
                TempData["success"] = "New car model created";
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditModel()
		{
            return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditModel(int id, Carmodel carmod)
        {
            if (ModelState.IsValid)
            {
                carmod.IdModel = id;
                _context.Carmodels.Update(carmod);
                _context.SaveChanges();
                TempData["success"] = "Model edited";
            }
            return RedirectToAction("Index");
        }

/**********************************************************************************************************************************
*                                                              PURCHASES
**********************************************************************************************************************************/


        // Display purchases
        public IActionResult DisplayPurchases()
        {
            var purchases = _context.Cars.Include(c => c.IdModelNavigation).Include(a => a.IdCustomerNavigation).Where(x => x.IdCustomer != null).OrderBy(x => x.IdModelNavigation.Brand);
            return View(purchases);
        }



/**********************************************************************************************************************************
*                                                              GET
**********************************************************************************************************************************/


        // Getter customers
        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // Getter carmodel
        public List<Carmodel> GetCarmodels()
        {
            return _context.Carmodels.ToList();
        }

        // Getter cars
        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }
    }
}
