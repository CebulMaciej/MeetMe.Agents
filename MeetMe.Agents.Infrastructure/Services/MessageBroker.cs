using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Convey.MessageBrokers.RabbitMQ;
using MeetAgents.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MeetMe.Agents.Infrastructure.Services
{
    public class MessageBroker: IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;
        private readonly IMessagePropertiesAccessor _messagePropertiesAccessor;
        private readonly ILogger<IMessageBroker> _logger;

        public MessageBroker(IBusPublisher busPublisher,
            IMessagePropertiesAccessor messagePropertiesAccessor,
            ILogger<IMessageBroker> logger)
        {
            _busPublisher = busPublisher;
            _messagePropertiesAccessor = messagePropertiesAccessor;
            _logger = logger;
        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events is null)
            {
                return;
            }

            var messageProperties = _messagePropertiesAccessor.MessageProperties;
            var correlationId = messageProperties?.CorrelationId;
            
            foreach (var @event in events)
            {
                if (@event is null)
                {
                    continue;
                }

                var messageId = Guid.NewGuid().ToString("N");
                _logger.LogTrace($"Publishing integration event: {@event.GetType().Name} [id: '{messageId}'].");
                

                await _busPublisher.PublishAsync(@event, messageId, correlationId);
            }
        }
    }
}