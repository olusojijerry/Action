using System;

namespace Actio.Common.Event
{
    public interface IAuthenticateEvent : IEvent
    {
        Guid UserId { get; }
    }
}