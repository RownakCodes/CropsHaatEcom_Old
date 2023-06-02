using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
