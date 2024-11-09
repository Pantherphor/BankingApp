using BankingApp.Core.Events;
using System.Threading.Tasks;

namespace BankingApp.Core.Interfaces.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }

}
