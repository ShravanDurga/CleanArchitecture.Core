using AutoMoqCore;
using CleanArchitecture.Core.Presentation.Admin.Home.Views;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace CleanArchitecture.Core.Presentation.Admin.Home
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private AutoMoqer _mocker;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _controller = _mocker.Create<HomeController>();
        }

        [Test]
        public void TestGetIndexShouldReturnView()
        {
            var result = _controller.Index();

            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
