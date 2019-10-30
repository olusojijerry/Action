using System.Threading.Tasks;

namespace Actio.Common.Event
{
    public interface IEventhandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}