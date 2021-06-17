using System;
using System.Collections.Generic;
using System.Text;

namespace BotAnalyst.Core.Events
{
    public class OnMessage : IEntity
    {
        public Guid Id { get;}
        public string SenderId { get; }
        public string Message { get; }

        public OnMessage(Guid id, string senderId, string message)
        {
            Id = id;
            SenderId = senderId;
            Message = message;
        }
    }
}
