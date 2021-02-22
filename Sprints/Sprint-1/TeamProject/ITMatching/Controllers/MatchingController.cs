using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ITMatching.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ITMatching.Controllers
{
    public class MatchingController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public MatchingController(ILogger<AccountController> logger, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult RequestForm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
