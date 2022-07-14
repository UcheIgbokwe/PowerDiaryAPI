using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Repository;
using MediatR;

namespace Application.Features.Queries
{
    public class GetChatByMinQueryHandler : IRequestHandler<GetChatByMinQuery, List<ChatEventResponses>>
    {
        private readonly IChatEventRepository _chatEventRepository;
        public GetChatByMinQueryHandler(IChatEventRepository chatEventRepository)
        {
            _chatEventRepository = chatEventRepository;
        }
        public async Task<List<ChatEventResponses>> Handle(GetChatByMinQuery request, CancellationToken cancellationToken)
        {
            return await _chatEventRepository.GetChatEventByMins();
        }
    }
}