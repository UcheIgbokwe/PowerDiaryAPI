using Application.Contracts.Domain.DTOs;
using Domain.ChatEvents;

namespace Application.Contracts.Infrastructure.Repository
{
    public interface IChatEventRepository
    {
        Task<List<ChatEventResponses>> GetChatEventByMins();
        Task<List<ChatEventResponses>> GetChatEventByHours();
    }
}