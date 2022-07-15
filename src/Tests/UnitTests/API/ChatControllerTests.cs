using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Controllers;
using Application.Contracts.Domain.DTOs;
using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.UnitTests.API
{
    public class ChatControllerTests
    {
        private readonly Mock<IMediator> mediator;
        public ChatControllerTests()
        {
            mediator = new Mock<IMediator>();
        }

        [Fact]
        public async void GetChatByMin_ShouldReturn_ChatByMin()
        {
            //Arrange
            mediator.Setup(mdtr => mdtr.Send(It.IsAny<GetChatByMinQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new List<ChatEventResponses>()));
            var chatController = new ChatController(mediator.Object);

            //Act
            var result = await chatController.GetChatByMin();

            //Assert
            var chatResponse = Array.Empty<ChatEventResponses>();
            var objectResult = Assert.IsAssignableFrom<ActionResult>(result);
            var model = Assert.IsAssignableFrom<OkObjectResult>(objectResult);
            Assert.Equal(chatResponse, model.Value);
        }

        [Fact]
        public async void GetChatByHour_ShouldReturn_ChatByHour()
        {
            //Arrange
            mediator.Setup(mdtr => mdtr.Send(It.IsAny<GetChatByHourQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(new List<ChatEventResponses>()));
            var chatController = new ChatController(mediator.Object);

            //Act
            var result = await chatController.GetChatByHour();

            //Assert
            var chatResponse = Array.Empty<ChatEventResponses>();
            var objectResult = Assert.IsAssignableFrom<ActionResult>(result);
            var model = Assert.IsAssignableFrom<OkObjectResult>(objectResult);
            Assert.Equal(chatResponse, model.Value);
        }
    }
}