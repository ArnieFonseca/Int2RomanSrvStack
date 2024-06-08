using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Int2Roman.Models;
using Int2Roman.ServiceInterface;

using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Mvc;

using RouteAttribute = ServiceStack.RouteAttribute;

namespace Int2Roman.Controllers
{
    public class HomeController : ServiceStackController
    {
        /// <summary>
        /// Handles the default route
        /// </summary>
        /// <returns>View Index</returns>
        public IActionResult Index()
        {

            // Instantiate the page model
            RomanNumberModel model = new();

            // Show the view
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
