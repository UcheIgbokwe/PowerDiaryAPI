using Application.Contracts.Domain.DTOs;
using Domain.ChatEvents;
using MediatR;

namespace Application.Features.Queries
{
    public class GetChatByHourQuery : IRequest<List<ChatEventResponses>>
    {
    }
}