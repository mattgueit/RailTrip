using MediatR;

namespace RailTrip.Application.Abstractions.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
