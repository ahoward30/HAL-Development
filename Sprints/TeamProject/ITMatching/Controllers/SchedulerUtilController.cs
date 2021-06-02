using ITMatching.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Controllers
{
    public class SchedulerUtilController : Controller
    {
        static Dictionary<string, List<int>> scheduleHours;
        private readonly ITMatchingAppContext appContext;
        public SchedulerUtilController(ITMatchingAppContext context)
        {
            appContext = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public static Dictionary<string, List<int>> GetSchedule(List<WorkSchedule> wrkSch)
        {

            Dictionary<string, List<int>> hours = new Dictionary<string, List<int>>();
            List<int> Monday = new List<int>();
            List<int> Tuesday = new List<int>();
            List<int> Wednesday = new List<int>();
            List<int> Thursday = new List<int>();
            List<int> Friday = new List<int>();
            List<int> Saturday = new List<int>();
            List<int> Sunday = new List<int>();

            foreach (var item in wrkSch)
            {
                string day = item.Day;
                switch (day)
                {
                    case "Monday":
                        Monday.Add((int)item.Hour);
                        break;
                    case "Tuesday":
                        Tuesday.Add((int)item.Hour);
                        break;
                    case "Wednesday":
                        Wednesday.Add((int)item.Hour);
                        break;
                    case "Thursday":
                        Thursday.Add((int)item.Hour);
                        break;
                    case "Friday":
                        Friday.Add((int)item.Hour);
                        break;
                    case "Saturday":
                        Saturday.Add((int)item.Hour);
                        break;
                    case "Sunday":
                        Sunday.Add((int)item.Hour);
                        break;
                }
            }

            hours.Add("Monday", Monday);
            hours.Add("Tuesday", Tuesday);
            hours.Add("Wednesday", Wednesday);
            hours.Add("Thursday", Thursday);
            hours.Add("Friday", Friday);
            hours.Add("Saturday", Saturday);
            hours.Add("Sunday", Sunday);

            scheduleHours = hours;
            return hours;

        }

        [Authorize]
        public IActionResult Scheduler()
        {
            ViewBag.SchedulerData = scheduleHours;
            return View();
        }

        //Had to comment out the routing while trying to fix the view for the ExpertClientMatching. REMEMBER TO FIX
        //[Route("/ViewSchedule/{ExpertId}")]
        [Authorize]
        [HttpPost]
        public IActionResult ViewSchedule(int ExpertId)
        {
            Expert exp = appContext.Experts.Find(ExpertId);
            Itmuser itm = appContext.Itmusers.Find(exp.ItmuserId);
            List<WorkSchedule> workHr = appContext.WorkSchedules.Where(work => work.ExpertId == ExpertId).ToList();
            Dictionary<string, List<int>> hours = GetSchedule(workHr);
            ViewBag.ViewScheduleName = itm.FirstName;
            ViewBag.ViewSchedulerData = hours;
            return View(hours);
        }
    }
}
