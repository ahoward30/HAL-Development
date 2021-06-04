using ITMatching.Controllers;
using ITMatching.Models;
using ITMatching.Models.Abstract;
using ITMatching.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITMatching.Tests
{
    public class MatchingControllerTests
    {
        // Would be easy to parameterize this with the username, email or id of the Identity user
        private static MatchingController GetMatchingControllerWithLoggedInUser()
        {
            // Mock the Itmuser repository
            Mock<IItmuserRepository> mockItmuserRepo = new Mock<IItmuserRepository>();
            mockItmuserRepo.Setup(m => m.GetByAspNetUserIdAsync("2a44c5fa-13a4-4477-82db-512da5e6f32a")).ReturnsAsync(
                 new Itmuser
                 {
                     Id = 2,
                     AspNetUserId = "2a44c5fa-13a4-4477-82db-512da5e6f32a",
                     FirstName = "Donald",
                     LastName = "Grad",
                     Email = "dgrad@im.com",
                     PhoneNumber = "3432345623",
                     UserName = "dgrad"
                 });

            // Mock the Expert repository
            Mock<IExpertRepository> mockExpertRepo = new Mock<IExpertRepository>();
            mockExpertRepo.Setup(m => m.GetByItmUserIdAsync(2)).ReturnsAsync(
                 new Expert
                 {
                     Id = 1,
                     ItmuserId = 2,
                     WorkSchedule = "Work Schedule",
                     IsAvailable = false
                 });
            mockExpertRepo.Setup(m => m.ToggleStatusAsync(1));

            // Mock the Meeting repository
            Mock<IMeetingRepository> mockMeetingRepo = new Mock<IMeetingRepository>();
            mockMeetingRepo.Setup(m => m.GetMatchingMeetingsByExpertIdAsync(1)).ReturnsAsync(new List<Meeting>() {
                 new Meeting
                 {
                     Id = 1,
                     Date = DateTime.UtcNow,
                     ClientId = 3,
                     ExpertId = 1,
                     HelpRequestId = 4,
                     Status = "open",
                     ClientTimestamp = DateTime.UtcNow,
                     ExpertTimestamp = DateTime.UtcNow,
                     MatchExpireTimestamp = DateTime.UtcNow
                 },
                 new Meeting
                 {
                     Id = 2,
                     Date = DateTime.UtcNow,
                     ClientId = 5,
                     ExpertId = 1,
                     HelpRequestId = 6,
                     Status = "open",
                     ClientTimestamp = DateTime.UtcNow,
                     ExpertTimestamp = DateTime.UtcNow,
                     MatchExpireTimestamp = DateTime.UtcNow
                 }
            });
            mockMeetingRepo.Setup(m => m.UpdateStatusAsync(1, "accept"));

            // Mock the HelpRequest repository
            Mock<IHelpRequestRepository> mockHelpRequestRepo = new Mock<IHelpRequestRepository>();
            mockHelpRequestRepo.Setup(m => m.GetListByIdsAsync(new List<int> { 4, 6 })).ReturnsAsync(new List<HelpRequest>() {
                 new HelpRequest
                 {
                     Id = 4,
                     ClientId = 3,
                     RequestTitle = "Title 1",
                     RequestDescription = "this is the description 1",
                     IsOpen = true
                 },
                 new HelpRequest
                 {
                     Id = 6,
                     ClientId = 5,
                     RequestTitle = "Title 1",
                     RequestDescription = "this is the description 2",
                     IsOpen = false
                 }
            });

            // Mock a user store, which the user manager needs to access the data layer, "contains methods for adding, removing and retrieving user claims."
            var mockStore = new Mock<IUserStore<IdentityUser>>();
            mockStore.Setup(x => x.FindByIdAsync("jame", CancellationToken.None))
                    .ReturnsAsync(new IdentityUser()
                    {
                        UserName = "jame@im.com",
                        Id = "2a44c5fa-13a4-4477-82db-512da5e6f32a"
                    });

            // Mock the user manager, only so far as it returns one valid user (can change this to return user not found for other tests)
            Mock<UserManager<IdentityUser>> mockUserManager = new Mock<UserManager<IdentityUser>>(mockStore.Object, null, null, null, null, null, null, null, null);

            //var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            //{
            //        new Claim(ClaimTypes.NameIdentifier, "1"),
            //}));

            // Set it up enough so it doesn't return null, i.e. just some user
            mockUserManager.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(
                    new IdentityUser
                    {
                        Id = "2a44c5fa-13a4-4477-82db-512da5e6f32a",
                        Email = "jame@im.com"
                    });
            mockUserManager.Setup(um => um.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns("2a44c5fa-13a4-4477-82db-512da5e6f32a");

            // Mock the HttpContext since quite a bit of functionality comes from it
            Mock<HttpContext> mockContext = new Mock<HttpContext>();
            mockContext.SetupGet(ctx => ctx.User.Identity.Name).Returns("jame@im.com");
            //mockContext.SetupGet(ctx => ctx.User).Returns(user);

            MatchingController controller = new MatchingController(null, mockUserManager.Object, null,
                mockItmuserRepo.Object, mockExpertRepo.Object, mockMeetingRepo.Object, mockHelpRequestRepo.Object, null, null)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = mockContext.Object
                }
            };

            return controller;
        }

        [Test]
        public async Task MatchingController_ExpertWaitingRoomViewModelHasListOfMeetings()
        {
            //Arrange
            MatchingController controller = GetMatchingControllerWithLoggedInUser();

            //Act
            IActionResult result = await controller.ExpertWaitingRoom();
            var vm = (result as ViewResult).ViewData.Model as ExpertWaitingRoomViewModel;

            //Assert
            Assert.That(vm.Meetings.Count(), Is.EqualTo(2));
            Assert.That(vm.Meetings.ElementAt(0).Key, Is.EqualTo(1));
            Assert.That(vm.Meetings.ElementAt(0).Value.Id, Is.EqualTo(4));
            Assert.That(vm.Meetings.ElementAt(0).Value.ClientId, Is.EqualTo(3));
            Assert.That(vm.Meetings.ElementAt(0).Value.RequestTitle, Is.EqualTo("Title 1"));
            Assert.That(vm.Meetings.ElementAt(0).Value.RequestDescription, Is.EqualTo("this is the description 1"));
            Assert.That(vm.Meetings.ElementAt(0).Value.IsOpen, Is.EqualTo(true));
        }

    }
}
