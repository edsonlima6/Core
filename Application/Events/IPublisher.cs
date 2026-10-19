using Application.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Events
{
    public interface IPublisher
    {
        Task PublishAsync(CreateUserDto message, CancellationToken cancellationToken = default);
    }
}