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
        //Attempt to meet with an online expert, and either navigate to a meeting room to talk to them, or to a list of expert information if no matching experts are available.
        public IActionResult ClientExpertMatching(Meeting meeting)
        {
            //Compile a list of IDs from all experts who are currently available for matching
            List<int> onlineExperts = context.Experts.Where(e => e.IsAvailable == true).Select(e => e.Id).ToList();

            //Compile a list of the IDs of the services tagged by the client for their help request
            List<int> helpRequestServiceIDs = context.RequestServices.Where(rs => rs.RequestId == meeting.HelpRequestId).Select(rs => rs.ServiceId).ToList();

            //Create a list to store IDs and matching scores of experts who meet the matching score threshold "List<(ExpertID, matchingScore)>"
            List<(int, double)> thresholdMeetingExperts = FindThresholdMeetingExperts(onlineExperts, helpRequestServiceIDs);

            //Attempt to meet with online experts who meet the matching score threshold for this help request
            if (thresholdMeetingExperts.Any())
            {
                //Create new list for Experts who meet the threshold sorted by descending order
                List<(int, double)> sortedExperts = thresholdMeetingExperts.OrderByDescending(t => t.Item2).ToList();

                //Iterate through each expert in the list, starting from highest matching score, until an expert accepts or the list is exhausted
                foreach ((int, double) ex in sortedExperts)
                {
                    int expertId = ex.Item1;
                    meeting.ExpertId = ex.Item1;
                    meeting.MatchExpireTimestamp = DateTime.UtcNow.AddMinutes(2);
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

                        //Set timestamp for expert waiting room to verify that we are still around
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

            //perform 2nd pass of algorithm since matching with a currently-available expert has failed

            //Check database to see if there are preferred hours for this help request then do one of two second passes depending on if any preferred hours are found
            bool helpRequestHasSchedule = false;
            helpRequestHasSchedule = context.RequestSchedules.Where(rs => rs.RequestId == meeting.HelpRequestId).Any();

            //Algorithm Second Pass (Trying to find offline experts to meet with later)
            List<(int, double)> offlineExpertIdsAndScores = FindUnavailableMatchingExperts(meeting, helpRequestHasSchedule, helpRequestServiceIDs);

            return View(offlineExpertIdsAndScores);
        }

        public List<(int, double)> FindThresholdMeetingExperts(List<int> expertIDs, List<int> helpRequestServiceIDs)
        {
            //Initialize values for generating matching score
            double threshold = 0.75;
            int clientMaxPoints = GetServicePoints(helpRequestServiceIDs);
            (int, double) IdMatchingScorePair = (0, 0);

            //Create list to fill with threshold meeting experts to then pass back
            List<(int, double)> thresholdMeetingExperts = new List<(int, double)>();

            foreach (int id in expertIDs)
            {
                //Set initial expert values to 0
                double expertMatchingScore = 0;

                //Compile list of the IDs of the services tagged by the expert
                List<int> ExpertServiceIDs = context.ExpertServices.Where(es => es.Id == id).Select(es => es.ServiceId).ToList();

                //
                List<int> matchingServiceIDs = ExpertServiceIDs.Where(id => helpRequestServiceIDs.Contains(id)).ToList();

                //Determine the value of tags that the current expert shares with the client's help request
                int expertMatchingPoints = GetServicePoints(matchingServiceIDs);

                //Calculate matching score for current expert
                expertMatchingScore = expertMatchingPoints / clientMaxPoints;
                if (expertMatchingScore >= threshold)
                {
                    IdMatchingScorePair = (id, expertMatchingScore);
                    thresholdMeetingExperts.Add(IdMatchingScorePair);
                }
            }
            return thresholdMeetingExperts;
        }

        //Returns a list of threshold-meeting experts who are unavailable to meet with right now
        public List<(int, double)> FindUnavailableMatchingExperts(Meeting meeting, bool helpRequestHasSchedule, List<int> helpRequestServiceIDs)
        {
            List<int> offlineExpertIds = context.Experts.Select(e => e.Id).ToList();

            List<(int, double)> thresholdMeetingExperts = FindThresholdMeetingExperts(offlineExpertIds, helpRequestServiceIDs);

            //Check if any experts meet the threshold 
            if (thresholdMeetingExperts.Any())
            {
                if (helpRequestHasSchedule)
                {
                    //Get schedule values that have a matching helpRequestId to our meeting's helpRequestId
                    List<RequestSchedule> requestSchedule = context.RequestSchedules.Where(rs => rs.RequestId == meeting.HelpRequestId).ToList();
                    int clientAvailableHoursCount = requestSchedule.Count();

                    for (int i = 0; i < thresholdMeetingExperts.Count; i++)
                    {
                        //Get schedule values that have a matching exp
                        List<WorkSchedule> expertSchedule = context.WorkSchedules.Where(ws => ws.ExpertId == thresholdMeetingExperts[i].Item1).ToList();
                        List<WorkSchedule> expertScheduleMatchingClientHours = new List<WorkSchedule>();
                        
                        //iterate through expert's work schedule and create a list of only the times that they share with the helpRequest
                        foreach(WorkSchedule ws in expertSchedule)
                        {
                            
                        }

                        int expertMatchingHoursWithClient = expertScheduleMatchingClientHours.Count();
                        double hoursPercentage = expertMatchingHoursWithClient / clientAvailableHoursCount;
                        double newMatchingScore = thresholdMeetingExperts[i].Item2 * hoursPercentage;
                        thresholdMeetingExperts[i] = (thresholdMeetingExperts[i].Item1, newMatchingScore);

                    }
                }

                //Compare 

                //Create new list for Experts who meet the threshold sorted by descending order
                List<(int, double)> sortedExperts = thresholdMeetingExperts.OrderByDescending(t => t.Item2).ToList();

                if (sortedExperts.Count > 10)
                {
                    double maxScore = sortedExperts[0].Item2;
                    List<(int, double)> tiedExperts = new List<(int, double)>();
                    tiedExperts.Add(sortedExperts[0]);

                    //check if and how many ties for highest matching score exist
                    for(int i = 1; i < sortedExperts.Count; i++)
                    {
                        if (sortedExperts[i].Item2 < maxScore)
                        {
                            break;
                        }

                        tiedExperts.Add(sortedExperts[i]);
                    }

                    //check if more than 10 experts tie for the highest matching score
                    if (tiedExperts.Count > 10)
                    {
                        //if more than 10 Experts tie for the highest matching score, they will be randomized to reduce alphabetical or other bias in listing them
                        Random random = new Random();
                        List<(int, double)> shuffledTiedExperts = tiedExperts.OrderBy(item => random.Next()).ToList();
                        List<(int, double)> top10ShuffledTiedExperts = shuffledTiedExperts.Take(10).ToList();
                        return top10ShuffledTiedExperts;
                    }

                    List<(int, double)> top10sortedExperts = sortedExperts.Take(10).ToList();
                    return top10sortedExperts;
                }

            }

                List<(int, double)> emptyList = new List<(int, double)>();
                return emptyList;
        }

        //Calculates the total point value of corresponding services from a list of serviceIDs
        public int GetServicePoints(List<int> serviceIDs)
        {
            int totalPoints = 0;

            foreach (int id in serviceIDs)
            {
                Service tag = context.Services.Where(s => s.Id == id).FirstOrDefault();

                switch (tag.ServiceCategory)
                {
                    case "OS":
                        totalPoints += 12;
                        break;

                    case "CommunicationMethod":
                        totalPoints += 15;
                        break;

                    default:
                        totalPoints += 10;
                        break;
                }
            }

            return totalPoints;
        }

        //Returns True if client has not updated their timestamp on a pending meeting object for over 30 seconds, likely indicating they are no longer in their waiting room
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

        //Returns True if expert has not updated their timestamp on a pending meeting object for over 30 seconds, likely indicating they are no longer in their waiting room

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
