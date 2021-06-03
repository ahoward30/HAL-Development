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
using ITMatching.Data;

namespace ITMatching.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        ITMatchingAppContext context;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITMatchingAppContext ctx)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            context = ctx;
        }

        public async Task<IActionResult> Index()
        {
            // Information straight from the Controller (does not need to go to the database)
            bool isAdmin = User.IsInRole("Admin");
            bool isAuthenticated = User.Identity.IsAuthenticated;
            string name = User.Identity.Name;
            string authType = User.Identity.AuthenticationType;

            // Information from Identity through the user manager 
            string id = _userManager.GetUserId(User);   // reportedly does not need to go to the database
            IdentityUser user = await _userManager.GetUserAsync(User);  // does go to the database
            string email = user?.Email ?? "no email";
            string phone = user?.PhoneNumber ?? "no phone number";

            ViewBag.Message = $"User {name} is authenticated? {isAuthenticated} using type {authType} and is an Admin? {isAdmin}. ID from Identity is {id}, email is {email} and phone is {phone}";
            return View();
        }

        public IActionResult About()
        {

            bool isUserLoggedIn = _signInManager.IsSignedIn(User);
            bool isExpert = false;
            if (isUserLoggedIn)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert eUser = context.Experts.Where(eu => eu.ItmuserId == itUser.Id).FirstOrDefault();
                isExpert = eUser != null;

                if (isExpert)
                {
                    eUser.IsAvailable = false;
                    context.Experts.Update(eUser);
                    context.SaveChanges();
                }
            }

            return View();
        }

        public IActionResult FAQ()
        {
            bool isUserLoggedIn = _signInManager.IsSignedIn(User);
            bool isExpert = false;
            if (isUserLoggedIn)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert eUser = context.Experts.Where(eu => eu.ItmuserId == itUser.Id).FirstOrDefault();
                isExpert = eUser != null;

                if (isExpert)
                {
                    eUser.IsAvailable = false;
                    context.Experts.Update(eUser);
                    context.SaveChanges();
                }
            }

            List<Faq> qAndAList = context.Faqs.ToList();

            return View(qAndAList);
        }

        public IActionResult ServicesList()
        {
            bool isUserLoggedIn = _signInManager.IsSignedIn(User);
            bool isExpert = false;
            if (isUserLoggedIn)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert eUser = context.Experts.Where(eu => eu.ItmuserId == itUser.Id).FirstOrDefault();
                isExpert = eUser != null;

                if (isExpert)
                {
                    eUser.IsAvailable = false;
                    context.Experts.Update(eUser);
                    context.SaveChanges();
                }
            }

            List<Service> services = context.Services.ToList();
            return View(services);
        }

        public IActionResult Privacy()
        {
            bool isUserLoggedIn = _signInManager.IsSignedIn(User);
            bool isExpert = false;
            if (isUserLoggedIn)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert eUser = context.Experts.Where(eu => eu.ItmuserId == itUser.Id).FirstOrDefault();
                isExpert = eUser != null;

                if (isExpert)
                {
                    eUser.IsAvailable = false;
                    context.Experts.Update(eUser);
                    context.SaveChanges();
                }
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
