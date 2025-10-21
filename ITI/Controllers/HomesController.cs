using Microsoft.AspNetCore.Mvc;

namespace ITI.Controllers
{
    public class HomesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
