﻿using Expeditions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Expeditions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ExpeditionsContext context;
        public HomeController(ILogger<HomeController> logger, ExpeditionsContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Recent()
        {
            //context = new ExpeditionsContext();
            List<Expedition> expList = context.Expeditions.OrderByDescending(c => c.StartDate).ToList();
            List<Expedition> recentTwenty = new List<Expedition>();
            for (int i = 0; i < 20; i++)
            {
                Peak peak = context.Peaks.Find(expList[i].PeakId);
                expList[i].Peak = peak;
                TrekkingAgency trek = context.TrekkingAgencies.Find(expList[i].TrekkingAgencyId);
                expList[i].TrekkingAgency = trek;
                recentTwenty.Add(expList[i]);
            }


            return View(recentTwenty);
        }

        public IActionResult Details(int id)
        {
            //context = new ExpeditionsContext();
            Expedition exp = context.Expeditions.Find(id);
            Peak peak = context.Peaks.Find(exp.PeakId);
            TrekkingAgency trek = context.TrekkingAgencies.Find(exp.TrekkingAgencyId);
            exp.Peak = peak;
            exp.TrekkingAgency = trek;
            return View(exp);
        }

        public IActionResult Faq()
        {
            //context = new ExpeditionsContext();
            List<FAQ> qAndAList = context.FAQs.ToList();
            //List<FAQ> qAndAList = new List<FAQ>();
            //for (int i = 0; i < 5; i++)
            //{
            //    qAndAList.Add(expList[i]);
            //}

            return View(qAndAList);
        }

        public IActionResult Newsfeed()
        {
            //context = new ExpeditionsContext();
            List<Newsfeed> newsfeedList = context.Newsfeeds.ToList();

            return View(newsfeedList);
        }
        public IActionResult UnclimbedPeaks()
        {
            //context = new ExpeditionsContext();
            List<Peak> unclimbedList = context.Peaks.Where(p => p.ClimbingStatus == false).OrderBy(p => p.Height).ToList();
            List<Peak> newUnclimbedList = new List<Peak>();
            foreach(Peak p in unclimbedList)
            {
                if (p.Height > 0)
                {
                    newUnclimbedList.Add(p);
                }
            }

            return View(newUnclimbedList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
