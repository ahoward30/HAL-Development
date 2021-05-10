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
                Expert eUser = context.Experts.Where(e => e.ItmuserId == itUser.Id).FirstOrDefault();

                Debug.WriteLine("Length of TagIds Array is " + TagIds.Length);
                foreach (int i in TagIds)
                {
                    Debug.WriteLine("Tag ID is " + i);
                    ExpertService entry = new ExpertService();
                    entry.ExpertId = eUser.Id;
                    entry.ServiceId = i;

                    int matchingExpertServiceCount = context.ExpertServices.Where(es => es.ExpertId == eUser.Id && es.ServiceId == i).Count();

                    if (matchingExpertServiceCount == 0)
                    {
                        context.ExpertServices.Add(entry);
                    }
                }

                List<int> expertServiceIDsInDataTable = context.ExpertServices.Select(es => es.ServiceId).ToList();

                foreach (int i in expertServiceIDsInDataTable)
                {
                    if (!TagIds.Contains(i))
                    {
                        ExpertService serviceToRemove = context.ExpertServices.Where(es => es.ServiceId == i && es.ExpertId == eUser.Id).FirstOrDefault();
                        if (serviceToRemove != null)
                        {
                            context.ExpertServices.Remove(serviceToRemove);
                        }
                    }

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
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert eUser = context.Experts.Where(e => e.ItmuserId == itUser.Id).FirstOrDefault();

                List<int> checkedServiceBoxes = context.ExpertServices.Where(es => es.ExpertId == eUser.Id).Select(id => id.ServiceId).ToList();

                EditTagsFormViewModel viewModel = new EditTagsFormViewModel();
                viewModel.Services = context.Services.ToList();
                viewModel.checkedBoxes = checkedServiceBoxes;

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
