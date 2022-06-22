using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ChatEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
{
    public class DataContextSeed
    {
        public static void Initialize(IServiceProvider serviceProvider, ILogger<DataContextSeed> logger)
        {
            using var dataContext = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>());
            if (!dataContext.ChatEvents.Any())
            {
                dataContext.ChatEvents.AddRange(ConfigureChatEvents());
                dataContext.SaveChangesAsync();
                logger.LogInformation("Seed database for User associate with {typeof(DataContext).Name} successful.", typeof(DataContext).Name);
            }
        }

        private static IEnumerable<ChatEvent> ConfigureChatEvents()
        {
            return new List<ChatEvent>
            {
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "enter-the-room",
                    ChatBody = "Bob enters the room",
                    ChatTime = new DateTime(2022,01,01, 17,00,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "enter-the-room",
                    ChatBody = "Kate enters the room",
                    ChatTime = new DateTime(2022,01,01, 17,05,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "comment",
                    ChatBody = "Bob comments: 'Hey, Kate - high five?'",
                    ChatTime = new DateTime(2022,01,01, 17,15,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "high-five-another-user",
                    ChatBody = "Kate high-fives Bob",
                    ChatTime = new DateTime(2022,01,01, 17,17,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "leave-the-room",
                    ChatBody = "Bob leaves",
                    ChatTime = new DateTime(2022,01,01, 17,18,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "comment",
                    ChatBody = "Kate comments: 'Oh, typical'",
                    ChatTime = new DateTime(2022,01,01, 17,20,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "leave-the-room",
                    ChatBody = "Kate leaves",
                    ChatTime = new DateTime(2022,01,01, 17,21,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "enter-the-room",
                    ChatBody = "Bob enters the room",
                    ChatTime = new DateTime(2022,01,01, 18,00,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "enter-the-room",
                    ChatBody = "Kate enters the room",
                    ChatTime = new DateTime(2022,01,01, 18,05,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "comment",
                    ChatBody = "Bob comments: 'Hey, Kate - high five?'",
                    ChatTime = new DateTime(2022,01,01, 18,15,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "leave-the-room",
                    ChatBody = "Bob leaves",
                    ChatTime = new DateTime(2022,01,01, 18,18,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "comment",
                    ChatBody = "Kate comments: 'Oh, typical again'",
                    ChatTime = new DateTime(2022,01,01, 18,20,00)
                },
                new ChatEvent()
                {
                    Id = Guid.NewGuid(),
                    EventType = "leave-the-room",
                    ChatBody = "Kate leaves",
                    ChatTime = new DateTime(2022,01,01, 18,21,00)
                }
            };
        }
    }
}