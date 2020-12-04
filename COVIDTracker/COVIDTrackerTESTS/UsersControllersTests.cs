using Moq;
using NUnit.Framework;
using COVIDTracker.Controllers;
using COVIDTracker.Services;

namespace COVIDTrackerTESTS
{
    public class UsersControllerShould
    {
        [Test]
        public void BeAbleToConstructTheUsersController()
        {
            var mockUserService = new Mock<IUserService>();
            var sut = new UsersController(mockUserService.Object);

            Assert.That(sut, Is.InstanceOf<UsersController>());
        }
    }
}