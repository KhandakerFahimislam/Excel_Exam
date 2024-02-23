using Microsoft.AspNetCore.Mvc;

namespace ExcelBD_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
