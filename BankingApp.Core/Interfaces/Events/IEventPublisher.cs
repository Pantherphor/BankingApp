using System.Threading.Tasks;

namespace BankingApp.Core.Events
{
    public interface IEventPublisher
    {
        Task Publish<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
    }
}
