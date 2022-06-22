using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ChatEvents
{
    public class ChatEvent
    {
        public Guid Id { get; set; }
        public string EventType { get; set; }
        public string ChatBody { get; set; }
        public DateTime ChatTime { get; set; }
    }
}