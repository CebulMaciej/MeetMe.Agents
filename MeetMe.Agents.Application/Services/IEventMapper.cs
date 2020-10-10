using System.Collections.Generic;
using Convey.CQRS.Events;
using MeetMe.Agents.Core.Events;

namespace MeetAgents.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}