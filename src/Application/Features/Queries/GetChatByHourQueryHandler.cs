using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Repository;
using Domain.ChatEvents;
using MediatR;

namespace Application.Features.Queries
{
    public class GetChatByHourQueryHandler : IRequestHandler<GetChatByHourQuery, IEnumerable<ChatEventResponses>>
    {
        private readonly IChatEventRepository _chatEventRepository;
        public GetChatByHourQueryHandler(IChatEventRepository chatEventRepository)
        {
            _chatEventRepository = chatEventRepository;
        }
        public async Task<IEnumerable<ChatEventResponses>> Handle(GetChatByHourQuery request, CancellationToken cancellationToken)
        {
            return await _chatEventRepository.GetChatEventByHours();
        }
    }
}