using SharedKernel.Domain.Events;

namespace SharedKernel.Application.Cqrs.Commands
{
    /// <summary>
    /// Command request that does not return anything
    /// </summary>
    public interface IRequest : IBaseRequest
    {
    }

    /// <summary>
    /// Command request that returns a response
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    // ReSharper disable once UnusedTypeParameter
    public interface IRequest<out TResponse> : Middlewares.IRequest<TResponse>
    {
    }
}
