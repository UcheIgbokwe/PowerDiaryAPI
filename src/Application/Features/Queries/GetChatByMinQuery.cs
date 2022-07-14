using Application.Contracts.Domain.DTOs;
using MediatR;

namespace Application.Features.Queries
{
    public class GetChatByMinQuery : IRequest<List<ChatEventResponses>>
    {
    }
}