namespace SimpleMusicStore.Infrastructure.Common.Events
{
    using Domain.Common;
    using System.Threading.Tasks;

    internal interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
