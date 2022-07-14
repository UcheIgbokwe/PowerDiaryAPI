using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Behaviours;
using Application.Contracts.Domain.DTOs;
using Application.Contracts.Infrastructure.Repository;
using Domain.ChatEvents;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class ChatEventRepository : GenericRepository<ChatEvent>, IChatEventRepository
    {
        public ChatEventRepository(DataContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public async Task<List<ChatEventResponses>> GetChatEventByHours()
        {
            try
            {
                var result =  await _dbcontext.ChatEvents
                    .GroupBy(row => new { row.ChatTime.Date, row.ChatTime.Hour, row.EventType})
                    .Select(grp => grp.ToList())
                    .ToListAsync();

                var formattedResult = new List<ChatEventResponses>();

                foreach (var item in result)
                {
                    ChatEventResponses newMessage = new()
                    {
                        Message = $"{item[0].ChatTime:hh tt}: {item.Count}  {item[0].EventType}"
                    };
                    formattedResult.Add(newMessage);
                }

                return formattedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetChatEventByHours: {ex.Message}", ex.Message);
                throw new HandleDbException(ex.Message, ex);
            }
        }

        public async Task<List<ChatEventResponses>> GetChatEventByMins()
        {
            try
            {
                var result = await _dbcontext.ChatEvents.OrderBy(c => c.ChatTime).ToListAsync();
                var formattedResult = new List<ChatEventResponses>();
                foreach (var item in result)
                {
                    ChatEventResponses newMessage = new()
                    {
                        Message = $"{item.ChatTime:hh:mm tt}: {item.ChatBody}"
                    };
                    formattedResult.Add(newMessage);
                }
                return formattedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetChatEventByMins: {ex.Message}", ex.Message);
                throw new HandleDbException(ex.Message, ex);
            }
        }
    }
}