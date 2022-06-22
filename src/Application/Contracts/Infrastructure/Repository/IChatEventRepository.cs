using Application.Contracts.Domain.DTOs;
using Domain.ChatEvents;

namespace Application.Contracts.Infrastructure.Repository
{
    public interface IChatEventRepository
    {
        Task<IEnumerable<ChatEventResponses>> GetChatEventByMins();
        Task<IEnumerable<ChatEventResponses>> GetChatEventByHours();
    }
}