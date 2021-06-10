using NUnit.Framework;
using ITMatching.Controllers;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace ITMatching.Tests
{
    public class ClientIsNotThere_Tests
    {
        private static MatchingController GetMatchingController()
        {
            MatchingController controller = new MatchingController(null, null, null, null, null, null, null, null, null);
            return controller;
        }

        [Test]
        public void MatchingController_ClientIsNotThere_MoreThan30Seconds_True()
        {
            MatchingController controller = GetMatchingController();

            TimeSpan seconds = new TimeSpan(0, 0, 0, 31, 0);
            DateTime time = DateTime.UtcNow.Subtract(seconds);

            bool isNotThere = controller.ClientIsNotThere(time);

            Assert.That(isNotThere);
        }

        [Test]
        public void MatchingController_ClientIsNotThere_LessThan30Seconds_False()
        {
            MatchingController controller = GetMatchingController();

            TimeSpan seconds = new TimeSpan(0, 0, 0, 1, 0);
            DateTime time = DateTime.UtcNow.Subtract(seconds);

            bool isNotThere = controller.ClientIsNotThere(time);

            Assert.That(!isNotThere);
        }
    }
}