using Microsoft.AspNetCore.Mvc;

namespace Employees.Mvc.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}