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

        [HttpGet]
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

        public IActionResult MeetingLogs()
        {
            if (ModelState.IsValid)
            {
                string id = _userManager.GetUserId(User);
                Itmuser itUser = context.Itmusers.Where(u => u.AspNetUserId == id).FirstOrDefault();
                Expert eUser = context.Experts.Where(e => e.ItmuserId == itUser.Id).FirstOrDefault();
                bool isExpert = eUser != null;

                //MeetingLogsViewModel meetingLogsVM = new MeetingLogsViewModel();
                HelpRequest tempHelpRequest = new HelpRequest();
                Itmuser tempItmuser = new Itmuser();
                Expert tempeUser = new Expert();
                List<RequestService> tempRequestServices = new List<RequestService>();

                //if (isExpert)
                //{
                //    meetingLogsVM.CurrentUser = itUser;
                List<Meeting> meetings = context.Meetings.Where(m => m.ExpertId == eUser.Id && m.Status == "Closed").ToList();

                //    foreach (Meeting m in meetingLogsVM.Meetings)
                //    {

                //        tempHelpRequest = context.HelpRequests.Where(hr => hr.Id == m.HelpRequestId).FirstOrDefault();
                //        meetingLogsVM.HelpRequests.Add(tempHelpRequest);
                //        tempRequestServices = context.RequestServices.Where(rs => rs.RequestId == tempHelpRequest.Id).ToList();
                //        meetingLogsVM.RequestServices.AddRange(tempRequestServices);

                //        tempItmuser = context.Itmusers.Where(it => it.Id == m.ClientId).FirstOrDefault();
                //        meetingLogsVM.MatchedUsers.Add(tempItmuser);
                //    }
                //    meetingLogsVM.MatchedUsers = meetingLogsVM.MatchedUsers.Distinct().ToList();
                //    meetingLogsVM.HelpRequests = meetingLogsVM.HelpRequests.Distinct().ToList();

                //}
                //else
                //{
                //    meetingLogsVM.CurrentUser = itUser;
                //    meetingLogsVM.Meetings = context.Meetings.Where(m => m.ClientId == itUser.Id && m.Status == "Closed").ToList();
                //    meetingLogsVM.HelpRequests = context.HelpRequests.Where(hr => hr.ClientId == itUser.Id && hr.IsOpen == false).ToList();

                //    foreach (Meeting m in meetingLogsVM.Meetings)
                //    {
                //        tempeUser = context.Experts.Where(e => e.Id == m.ExpertId).FirstOrDefault();
                //        tempItmuser = context.Itmusers.Where(it => it.Id == tempeUser.ItmuserId).FirstOrDefault();
                //        meetingLogsVM.MatchedUsers.Add(tempItmuser);

                //    }

                //    meetingLogsVM.MatchedUsers = meetingLogsVM.MatchedUsers.Distinct().ToList();

                //    foreach (HelpRequest hr in meetingLogsVM.HelpRequests)
                //    {
                //        tempRequestServices = context.RequestServices.Where(rs => rs.RequestId == hr.Id).ToList();
                //        meetingLogsVM.RequestServices.AddRange(tempRequestServices);
                //    }

                //}
                MeetingLogModel tempMeetingLogModel = new MeetingLogModel();
                List<MeetingLogModel> meetingInfo = new List<MeetingLogModel>();

                foreach(Meeting m in meetings)
                {
                    tempHelpRequest = context.HelpRequests.Where(hr => hr.Id == m.HelpRequestId).FirstOrDefault();
                    tempMeetingLogModel.RequestTitle = tempHelpRequest.RequestTitle;
                    tempMeetingLogModel.RequestDescription = tempHelpRequest.RequestDescription;
                    tempMeetingLogModel.meetingId = m.Id;
                    tempMeetingLogModel.isExpert = isExpert;

                    if(isExpert)
                    {
                        tempItmuser = context.Itmusers.Where(it => it.Id == m.ClientId).FirstOrDefault();
                        tempMeetingLogModel.MatchedUserName = tempItmuser.FirstName + " " + tempItmuser.LastName;
                        tempMeetingLogModel.MatchedUserEmail = tempItmuser.Email;
                    }
                    else
                    {
                        tempeUser = context.Experts.Where(e => e.Id == m.ExpertId).FirstOrDefault();
                        tempItmuser = context.Itmusers.Where(it => it.Id == tempeUser.ItmuserId).FirstOrDefault();
                        tempMeetingLogModel.MatchedUserName = tempItmuser.FirstName + " " + tempItmuser.LastName;
                        tempMeetingLogModel.MatchedUserEmail = tempItmuser.Email;
                    }
                    tempMeetingLogModel.TimeOfMeeting = m.Date;
                    tempRequestServices = context.RequestServices.Where(rs => rs.RequestId == tempHelpRequest.Id).ToList();

                    Service tempService = new Service();
                    foreach(RequestService rs in tempRequestServices)
                    {
                        tempService = context.Services.Where(s => s.Id == rs.ServiceId).FirstOrDefault();
                        tempMeetingLogModel.HelpRequestTags.Add(tempService);
                    }

                    meetingInfo.Add(tempMeetingLogModel);
                }

                //meetingLogsVM.Services = context.Services.ToList();

                return View(meetingInfo);
            }
            return RedirectToPage("/Account/Manage/MeetingLogs", new { area = "Identity" }); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
