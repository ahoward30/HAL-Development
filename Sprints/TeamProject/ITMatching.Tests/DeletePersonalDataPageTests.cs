using NUnit.Framework;
using ITMatching.Controllers;
using ITMatching.Areas.Identity.Pages.Account.Manage;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using ITMatching.Models.Abstract;
using ITMatching.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;
using MockQueryable.Moq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITMatching.Tests
{
    public class DeletePersonalDataPageTests
    {
        private DeletePersonalDataModel _pageModel;
        private Mock<ITMatchingAppContext> _mockITMatchingAppContext;

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Mock<ILogger<DeletePersonalDataModel>>();

            // Mock the ITMatchingAppContext 
            var itmUsers = new List<Itmuser>
            {
                new Itmuser { Id = 1, FirstName = "Test", LastName = "BBB", PhoneNumber = "9998524256", Email = "jame@im.com" , UserName = "jame@im.com", AspNetUserId = "2a44c5fa-13a4-4477-82db-512da5e6f32a" },
                new Itmuser { Id = 2, FirstName = "Test", LastName = "ZZZ", PhoneNumber = "9985242568", Email = "zzz@im.com" , UserName = "zzz@im.com", AspNetUserId = Guid.NewGuid().ToString()  },
                new Itmuser { Id = 3, FirstName = "Test", LastName = "AAA", PhoneNumber = "9985242526", Email = "aaa@im.com" , UserName = "aaa@im.com", AspNetUserId = Guid.NewGuid().ToString() },
            }.AsQueryable();

            var mockItmuserSet = itmUsers.AsQueryable().BuildMockDbSet();

            _mockITMatchingAppContext = new Mock<ITMatchingAppContext>();
            _mockITMatchingAppContext.Setup(m => m.Itmusers).Returns(mockItmuserSet.Object);

            _pageModel = new DeletePersonalDataModel(new FakeUserManager(), new FakeSignInManager(), mockLogger.Object, _mockITMatchingAppContext.Object);
        }

        [Test]
        public async Task DeletePersonalDataPage_DeleteAccount_Success()
        {
            //Arrange
            var userId = "2a44c5fa-13a4-4477-82db-512da5e6f32a";
            var userName = "jame@im.com";
            var updatedUserName = $"deleted@user-{userId}.com";
            _pageModel.Input = new DeletePersonalDataModel.InputModel { Password = "password", SecurityPhrase = userName };

            //Act
            IActionResult result = await _pageModel.OnPostAsync();

            //Assert
            var itmUser = await _mockITMatchingAppContext.Object.Itmusers.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            var updatedItmUser = await _mockITMatchingAppContext.Object.Itmusers.Where(u => u.UserName == updatedUserName).FirstOrDefaultAsync();

            Assert.That(itmUser, Is.Null);
            Assert.That(updatedItmUser, Is.Not.Null);
            Assert.That((result as PageResult), Is.Null);
            Assert.That((result as RedirectResult), Is.Not.Null);
            Assert.That((result as RedirectResult).Url, Is.EqualTo("~/"));
        }

        [Test]
        public async Task DeletePersonalDataPage_DeleteAccount_InvalidSecurityPhrase()
        {
            //Arrange
            var userId = "2a44c5fa-13a4-4477-82db-512da5e6f32a";
            var userName = "jame@im.com";
            var updatedUserName = $"deleted@user-{userId}.com";
            _pageModel.Input = new DeletePersonalDataModel.InputModel { Password = "password", SecurityPhrase = "wrong phrase" };

            //Act
            IActionResult result = await _pageModel.OnPostAsync();

            //Assert
            var itmUser = await _mockITMatchingAppContext.Object.Itmusers.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            var updatedItmUser = await _mockITMatchingAppContext.Object.Itmusers.Where(u => u.UserName == updatedUserName).FirstOrDefaultAsync();

            Assert.That(itmUser, Is.Not.Null);
            Assert.That(updatedItmUser, Is.Null);
            Assert.That(_pageModel.ModelState.IsValid, Is.False);
            Assert.That(_pageModel.ModelState.Count, Is.EqualTo(1));
            Assert.That(_pageModel.ModelState.ErrorCount, Is.EqualTo(1));
            Assert.That(_pageModel.ModelState.FirstOrDefault().Value.Errors.FirstOrDefault().ErrorMessage, Is.EqualTo("Incorrect security phrase."));
            Assert.That((result as RedirectResult), Is.Null);
            Assert.That((result as PageResult), Is.Not.Null);
        }
    }
}