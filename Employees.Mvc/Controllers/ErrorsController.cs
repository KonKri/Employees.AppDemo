using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Mvc.Controllers
{
    /// <summary>
    /// Custom error pages.
    /// </summary>
    public class ErrorsController : Controller
    {
        [Route("Error/500")]
        public IActionResult InternalServerError()
        {
            return View();
        }

        [Route("Errorss/404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}