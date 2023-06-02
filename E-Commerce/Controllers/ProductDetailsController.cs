using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
