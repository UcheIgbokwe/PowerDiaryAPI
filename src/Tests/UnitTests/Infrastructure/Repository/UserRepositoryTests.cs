using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure.Repository;
using Domain.Users;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Tests.UnitTests.Infrastructure.Repository
{
    public class UserRepositoryTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        public UserRepositoryTests()
        {
            _mockRepo = new Mock<IUserRepository>();
        }

        [Fact]
        public void CreateUser_Returns_User()
        {
            //Arrange
            var testObject = new User();
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<User>>();
            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.FindAsync(It.IsAny<int>(), It.IsAny<bool>())).Returns(ValueTask.FromResult(new User()));

            _mockRepo.Setup(s => s.AddUser(new User()));
            var userRepoMock = _mockRepo.Object;
            userRepoMock.Add(testObject);

            //Assert
            Assert.NotNull(testObject);
            Assert.IsAssignableFrom<User>(testObject);
        }
    }
}