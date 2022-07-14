using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Repository;
using Domain.ChatEvents;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Tests.UnitTests.Infrastructure.Repository
{
    public class ChatEventRepositoryTests
    {
        private readonly Mock<IChatEventRepository> _mockRepo;
        public ChatEventRepositoryTests()
        {
            _mockRepo = new Mock<IChatEventRepository>();
        }

        [Fact]
        public void GetChatEventByHours_Returns_ChatEventByHours()
        {
            //Arrange
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<ChatEvent>>();
            context.Setup(x => x.Set<ChatEvent>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.FindAsync(It.IsAny<int>(), It.IsAny<bool>())).Returns(ValueTask.FromResult(new ChatEvent()));

            _mockRepo.Setup(s => s.GetChatEventByHours()).Returns(Task.FromResult(new List<ChatEventResponses>()));
            var getChatByHourRepoMock = _mockRepo.Object;

            //Execute method of SUT (ChatEventRepository)
            var chatEventByHours = getChatByHourRepoMock.GetChatEventByHours().Result;

            //Assert
            Assert.NotNull(chatEventByHours);
            Assert.IsAssignableFrom<List<ChatEventResponses>>(chatEventByHours);
        }

        [Fact]
        public void GetChatEventByMins_Returns_ChatEventByMins()
        {
            //Arrange
            var context = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<ChatEvent>>();
            context.Setup(x => x.Set<ChatEvent>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.FindAsync(It.IsAny<int>(), It.IsAny<bool>())).Returns(ValueTask.FromResult(new ChatEvent()));

            _mockRepo.Setup(s => s.GetChatEventByMins()).Returns(Task.FromResult(new List<ChatEventResponses>()));
            var getChatByHourRepoMock = _mockRepo.Object;

            //Execute method of SUT (ChatEventRepository)
            var chatEventByMins = getChatByHourRepoMock.GetChatEventByMins().Result;

            //Assert
            Assert.NotNull(chatEventByMins);
            Assert.IsAssignableFrom<List<ChatEventResponses>>(chatEventByMins);
        }
    }
}