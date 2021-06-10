using NUnit.Framework;
using ITMatching.Controllers;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace ITMatching.Tests
{
    public class ExpertIsNotThere_Tests
    {
        private static MatchingController GetMatchingController()
        {
            MatchingController controller = new MatchingController(null, null, null, null, null, null, null, null, null);
            return controller;
        }

        [Test]
        public void MatchingController_ExpertIsNotThere_MoreThan90Seconds_True()
        {
            MatchingController controller = GetMatchingController();

            TimeSpan seconds = new TimeSpan(0, 0, 0, 91, 0);
            DateTime time = DateTime.UtcNow.Subtract(seconds);

            bool isNotThere = controller.ExpertIsNotThere(time);

            Assert.That(isNotThere);
        }

        [Test]
        public void MatchingController_ExpertIsNotThere_MoreThan90Seconds_False()
        {
            MatchingController controller = GetMatchingController();

            TimeSpan seconds = new TimeSpan(0, 0, 0, 1, 0);
            DateTime time = DateTime.UtcNow.Subtract(seconds);

            bool isNotThere = controller.ExpertIsNotThere(time);

            Assert.That(!isNotThere);
        }
    }
}