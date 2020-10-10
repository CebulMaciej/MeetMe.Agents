using System.Threading.Tasks;
using MeetMe.Agents.Core.Events;

namespace MeetAgents.Application.Events
{
    public interface IDomainEventHandler<in T> where T : class, IDomainEvent
    {
        Task HandleAsync(T @event);
    }
}