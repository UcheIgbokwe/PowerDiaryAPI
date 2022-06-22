using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.UnitTests.API
{
    public class ChatControllerTests
    {
        private readonly ChatController  sut;
        private readonly Mock<IMediator> mediator;
        public ChatControllerTests()
        {
            mediator = new Mock<IMediator>();
            sut = new ChatController(mediator.Object);
        }

        [Fact]
        public async void GetChatByMin_ShouldReturn_Null()
        {
            var result = await sut.GetChatByMin();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetChatByHour_ShouldReturn_Null()
        {
            var result = await sut.GetChatByHour();

            Assert.IsType<NotFoundResult>(result);
        }
    }
}