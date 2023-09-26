using Microsoft.AspNetCore.Mvc;

namespace MVCGoogleAuth.Controllers
{
    public class ManageNewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
