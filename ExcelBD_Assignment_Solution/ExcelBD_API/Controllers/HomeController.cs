using Microsoft.AspNetCore.Mvc;

namespace ExcelBD_API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
