using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    public class practicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
