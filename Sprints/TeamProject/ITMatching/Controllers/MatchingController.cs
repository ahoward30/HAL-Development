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
        public IActionResult ClientExpertMatching(Meeting meeting)
        {
            //Compile a list of IDs from all experts who are currently available for matching
            List<int> matchingOnlineExperts = context.Experts.Where(e => e.IsAvailable == true).Select(e => e.Id).ToList();

            //Compile a list of the IDs of the services tagged by the client for their help request
            List<int> helpRequestServiceIDs = context.RequestServices.Where(rs => rs.Id == meeting.HelpRequestId).Select(rs => rs.ServiceId).ToList();

            //Create a list to store IDs and matching scores of experts who meet the matching score threshold "List<(ExpertID, matchingScore)>"
            List<(int, double)> thresholdMeetingExperts = new List<(int, double)>();

            //Initializing values for generating matching score
            double threshold = 0.75;
            double expertMatchingScore = 0;
            int expertMatchingPoints = 0;
            int clientMaxPoints = GetMaxPointValue(helpRequestServiceIDs);
            (int, double) IdMatchingScorePair = (0, 0);


            //Algorithm First Pass (Trying to find online experts to meet with now)
            foreach (int id in matchingOnlineExperts)
            {
                //Compile list of the IDs of the services tagged by the expert
                List<int> ExpertServiceIDs = context.ExpertServices.Where(es => es.Id == id).Select(es => es.ServiceId).ToList();

                foreach (int i in helpRequestServiceIDs)
                {
                    if (ExpertServiceIDs.Contains(i)){

                        Service tag = context.Services.Where(s => s.Id == i).FirstOrDefault();

                        switch (tag.ServiceCategory)
                        {
                            case "OS":
                                expertMatchingPoints += 12;
                                break;

                            case "CommunicationMethod":
                                expertMatchingPoints += 15;
                                break;

                            default:
                                expertMatchingPoints += 10;
                                break;
                        }
                    }

                    //Determine matching score for each expert
                    expertMatchingScore = expertMatchingPoints / clientMaxPoints;
                    if (expertMatchingScore >= threshold)
                    {
                        IdMatchingScorePair = (i, expertMatchingScore);
                        thresholdMeetingExperts.Add(IdMatchingScorePair);
                    }
                }
            }

            if (thresholdMeetingExperts.Any())
            {
                //Create new list for Experts who meet the threshold sorted by descending order
                List<(int, double)> sortedExperts = thresholdMeetingExperts.OrderByDescending(t => t.Item2).ToList();

                //Iterate through each expert in the list, starting from highest matching score, until an expert accepts or the list is exhausted
                foreach ((int, double) ex in sortedExperts)
                {
                    int expertId = ex.Item1;
                    meeting.ExpertId = ex.Item1;
                    meeting.MatchExpireTimestamp = DateTime.Now.AddMinutes(2);
                    string meetingStatus;
                    context.Meetings.Update(meeting);
                    context.SaveChanges();
                    while (expertId != 0)
                    {
                        expertId = context.Meetings.Where(m => m.Id == meeting.Id).Select(e => e.ExpertId).SingleOrDefault();
                        meetingStatus = context.Meetings.Where(m => m.Id == meeting.Id).Select(s => s.Status).SingleOrDefault();
                        if (meetingStatus == "Matched")
                        {
                            return RedirectToAction("Meeting", "Matching", new { id = meeting.Id });
                        }

                        //Set timestamp for expert to verify that we are still around
                        meeting.ClientTimestamp = DateTime.UtcNow;

                        //If expert does not update timestamp for 30 seconds, they are assumed to be afk and are set to unavailable
                        if (ExpertIsNotThere(meeting.ExpertTimestamp))
                        {
                            Expert afkExpert = context.Experts.Where(e => e.Id == expertId).FirstOrDefault();
                            afkExpert.IsAvailable = false;
                            context.Update(afkExpert);
                            context.SaveChanges();
                            expertId = 0;
                        }

                        if (DateTime.Compare(DateTime.UtcNow, meeting.MatchExpireTimestamp) > 0)
                        {
                            expertId = 0;
                        }
                    }
                }
            }

            //Check Database to see if there are preferred hours for this help request then do one of two second passes depending on if any preferred hours are found

            return RedirectToAction("OfflineMatchList", "Matching");
        }

        public IActionResult OfflineMatchList()
        {
            List<int> expertIds = new List<int>();

            //Algorithm Second Pass (Trying to find offline experts to meet with later)

            //Check database 

            return View(expertIds);
        }

        public int GetMaxPointValue(List<int> serviceIDs)
        {
            int maxValue = 0;

            foreach (int hr in serviceIDs)
            {
                Service tag = context.Services.Where(s => s.Id == hr).FirstOrDefault();

                switch (tag.ServiceCategory)
                {
                    case "OS":
                        maxValue += 12;
                        break;

                    case "CommunicationMethod":
                        maxValue += 15;
                        break;

                    default:
                        maxValue += 10;
                        break;
                }
            }

            return maxValue;
        }

        public Boolean ClientIsNotThere(DateTime dbTime)
        {
            DateTime current = DateTime.UtcNow;
            TimeSpan span = current - dbTime;
            if (span.TotalSeconds > 30)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Boolean ExpertIsNotThere(DateTime dbTime)
        {
            DateTime current = DateTime.UtcNow;
            TimeSpan span = current - dbTime;
            if (span.TotalSeconds > 30)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
