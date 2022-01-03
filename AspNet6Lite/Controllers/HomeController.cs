using Microsoft.AspNetCore.Mvc;

namespace AspNet6Lite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
