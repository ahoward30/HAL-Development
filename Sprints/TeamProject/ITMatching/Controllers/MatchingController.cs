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
using ITMatching.ViewModels;

namespace ITMatching.Controllers
{
    public class MatchingController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        ITMatchingAppContext context;

        public MatchingController(ILogger<MatchingController> logger, UserManager<IdentityUser> userManager, ITMatchingAppContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        [Authorize]
        public IActionResult RequestForm()
        {
            RequestFormViewModel viewModel = new RequestFormViewModel();
            viewModel.Services = context.Services.ToList();
            viewModel.HelpRequest = new HelpRequest();

            return View(viewModel);
        }

        [Authorize]
        public IActionResult HelpRequestAdded()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HelpRequest(HelpRequest helpRequest, int?[] TagIds)
        {
            if (ModelState.IsValid)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                helpRequest.ClientId = itUser.Id;
                helpRequest.IsOpen = true; 
                context.HelpRequests.Add(helpRequest);


                Debug.WriteLine("Length of TagIds Array is " + TagIds.Length);
                int ID = context.HelpRequests.Count();
                Debug.WriteLine("Total rows in HelpRequests table is " + ID);
                foreach (int i in TagIds)
                {
                    Debug.WriteLine("Tag ID is " + i);
                    RequestService entry = new RequestService();
                    entry.RequestId = ID + 1;
                    entry.ServiceId = i;
                    context.RequestServices.Add(entry);
                }
                context.SaveChanges();
                return RedirectToAction("HelpRequestAdded");
            }

            return RedirectToAction("RequestForm", "Matching");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HelpRequestWithSchedule(HelpRequest helpRequest, int?[] TagIds)
        {
            if (ModelState.IsValid)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                helpRequest.ClientId = itUser.Id;
                helpRequest.IsOpen = true;
                context.HelpRequests.Add(helpRequest);


                Debug.WriteLine("Length of TagIds Array is " + TagIds.Length);
                int ID = context.HelpRequests.Count();
                Debug.WriteLine("Total rows in HelpRequests table is " + ID);
                foreach (int i in TagIds)
                {
                    Debug.WriteLine("Tag ID is " + i);
                    RequestService entry = new RequestService();
                    entry.RequestId = ID + 1;
                    entry.ServiceId = i;
                    context.RequestServices.Add(entry);
                }
                context.SaveChanges();
                return RedirectToAction("RequestScheduler");
            }

            return RedirectToAction("RequestForm", "Matching");
        }

        public IActionResult RequestScheduler()
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
