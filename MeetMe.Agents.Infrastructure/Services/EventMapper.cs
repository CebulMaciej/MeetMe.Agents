using System.Collections.Generic;
using System.Linq;
using Convey.CQRS.Events;
using MeetAgents.Application.Services;
using MeetMe.Agents.Core.Events;

namespace MeetMe.Agents.Infrastructure.Services
{
    public class EventMapper : IEventMapper
    {
        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);

        public IEvent Map(IDomainEvent @event)
            => @event switch
            {
                _ => null
            };
    }
}