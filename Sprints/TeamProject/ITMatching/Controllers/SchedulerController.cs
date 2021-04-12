using ITMatching.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ITMatching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedularController : Controller
    {
        private readonly ITMatchingAppContext _context;
        public SchedularController(ITMatchingAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Post(Schedule sch)
        {
            string[] Mon = sch.Monday;
            string[] Tue = sch.Tuesday;
            string[] Wed = sch.Wednesday;
            string[] Thu = sch.Thursday;
            string[] Fri = sch.Friday;
            string[] Sat = sch.Saturday;
            string[] Sun = sch.Sunday;

            List<WorkSchedule> workHr = _context.WorkSchedules.Where(work => work.ExpertId == sch.UserId).ToList();
            if (workHr != null)
            {
                foreach (var item in workHr)
                {
                    _context.WorkSchedules.Remove(item);
                }
                _context.SaveChanges();
            }
            List<WorkSchedule> schedules = new List<WorkSchedule>();
            foreach (var item in Mon)
            {
                int h = item.IndexOf('_');

                WorkSchedule sc = new WorkSchedule()
                {
                    ExpertId = sch.UserId,
                    Day = "Monday",
                    Hour = Int32.Parse(item.Substring(h + 1))
                };
                //_context.WorkSchedules.Add(sc);
                schedules.Add(sc);
            }
            foreach (var item in Tue)
            {
                int h = item.IndexOf('_');

                WorkSchedule sc = new WorkSchedule()
                {
                    ExpertId = sch.UserId,
                    Day = "Tuesday",
                    Hour = Int32.Parse(item.Substring(h + 1))
                };
                //_context.WorkSchedules.Add(sc);
                schedules.Add(sc);
            }
            foreach (var item in Wed)
            {
                int h = item.IndexOf('_');

                WorkSchedule sc = new WorkSchedule()
                {
                    ExpertId = sch.UserId,
                    Day = "Wednesday",
                    Hour = Int32.Parse(item.Substring(h + 1))
                };
                //_context.WorkSchedules.Add(sc);
                schedules.Add(sc);
            }
            foreach (var item in Thu)
            {
                int h = item.IndexOf('_');

                WorkSchedule sc = new WorkSchedule()
                {
                    ExpertId = sch.UserId,
                    Day = "Thursday",
                    Hour = Int32.Parse(item.Substring(h + 1))
                };
                //_context.WorkSchedules.Add(sc);
                schedules.Add(sc);
            }
            foreach (var item in Fri)
            {
                int h = item.IndexOf('_');

                WorkSchedule sc = new WorkSchedule()
                {
                    ExpertId = sch.UserId,
                    Day = "Friday",
                    Hour = Int32.Parse(item.Substring(h + 1))
                };
                //_context.WorkSchedules.Add(sc);
                schedules.Add(sc);
            }
            foreach (var item in Sat)
            {
                int h = item.IndexOf('_');

                WorkSchedule sc = new WorkSchedule()
                {
                    ExpertId = sch.UserId,
                    Day = "Saturday",
                    Hour = Int32.Parse(item.Substring(h + 1))
                };
                //_context.WorkSchedules.Add(sc);
                schedules.Add(sc);
            }
            foreach (var item in Sun)
            {
                int h = item.IndexOf('_');

                WorkSchedule sc = new WorkSchedule()
                {
                    ExpertId = sch.UserId,
                    Day = "Sunday",
                    Hour = Int32.Parse(item.Substring(h + 1))
                };
                //_context.WorkSchedules.Add(sc);
                schedules.Add(sc);
            }
            /* using(ITMatchingAppContext context = new ITMatchingAppContext())
             {
                 context.WorkSchedules.AddRange(schedules);
                 context.SaveChanges();
             }*/
            _context.WorkSchedules.AddRange(schedules);
            _context.SaveChanges();
            return Ok();

        }

        [NonAction]
        public WorkSchedule ParseWorkSchedule(int userId, string day, int h, Schedule sch)
        {
            return null;
        }


    }
}