using System.Collections.Generic;
using System.Threading.Tasks;
using MeetMe.Agents.Core.Events;

namespace MeetAgents.Application.Services
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}