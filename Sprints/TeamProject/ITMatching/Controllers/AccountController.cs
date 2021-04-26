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
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        ITMatchingAppContext context;

        public AccountController(ILogger<AccountController> logger, UserManager<IdentityUser> userManager, ITMatchingAppContext ctx)
        {
            _userManager = userManager;
            context = ctx;
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult helpRequestHistory()
        {
            return View();
        }

        public IActionResult ExpertTags(int?[] TagIds)
        {
            if (ModelState.IsValid)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert thisExpert = context.Experts.Where(e => e.ItmuserId == itUser.Id).FirstOrDefault();

                Debug.WriteLine("Length of TagIds Array is " + TagIds.Length);
                foreach (int i in TagIds)
                {
                    Debug.WriteLine("Tag ID is " + i);
                    ExpertService entry = new ExpertService();
                    //entry.ExpertId = itUser.Id;     //Might have to check later
                    entry.ExpertId = thisExpert.Id;
                    entry.ServiceId = i;

                    if (context.ExpertServices.Find(i) == null)
                    {
                        context.ExpertServices.Add(entry);
                    }

                    //List<int> expertServiceIds = context.ExpertServices.Where(es => es.ExpertId == thisExpert.Id).Select(i => i.ServiceId).ToList();
                    //if (!expertServiceIds.contains(entry.ServiceId))
                    //{
                    //  context.Update(entry);
                    //}

                }
                context.SaveChanges();
                return RedirectToPage("/Account/Manage/ExpertTags", new { area = "Identity" });
            }
            return RedirectToAction("EditTagsForm", "Account"); //Changed but does not redirect back to form and instead to account profile
        }

        [Authorize]
        public IActionResult EditTagsForm()
        {
            if (ModelState.IsValid)
            {
                EditTagsFormViewModel viewModel = new EditTagsFormViewModel();

                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert thisExpert = context.Experts.Where(e => e.ItmuserId == itUser.Id).FirstOrDefault();

                viewModel.ExpertServicesIDs = context.ExpertServices.Where(es => es.ExpertId == thisExpert.Id).Select(i => i.ServiceId).ToList();
                viewModel.Services = context.Services.ToList();

                return View(viewModel);
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
