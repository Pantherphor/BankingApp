using BankingApp.Core.Interfaces.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BankingApp.Core.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Publish<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
        {
            var handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();

            foreach (var handler in handlers)
            {
                await handler.Handle(domainEvent);
            }
        }
    }

}
