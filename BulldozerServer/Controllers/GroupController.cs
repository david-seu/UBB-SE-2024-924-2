using Microsoft.AspNetCore.Mvc;

namespace BulldozerServer.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
