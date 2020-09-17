using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace _3dIntiriorClients.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
      
        public IActionResult Index()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View();
        }
    }
}
