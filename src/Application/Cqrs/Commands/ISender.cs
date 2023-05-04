using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Application.Cqrs.Commands
{
    /// <summary>
    /// Command bus
    /// </summary>
    public interface ISender
    {
        /// <summary>
        /// Dispatch a command that returns a response
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);

        /// <summary>
        /// Dispatch a command request that does not return anything
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task SendAsync(IRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Dispatch commands requests that does not return anything
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task SendAsync(IEnumerable<IRequest> request, CancellationToken cancellationToken);

        /// <summary>
        /// Dispatch commands requests that return something
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task<TResponse[]> SendAsync<TResponse>(IEnumerable<IRequest<TResponse>> commands, CancellationToken cancellationToken);

        /// <summary>
        /// Dispatch commands requests on a queue.
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="queueName">Queue name</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task DispatchOnQueue(IEnumerable<IRequest> commands, string queueName, CancellationToken cancellationToken);

        /// <summary>
        /// Dispatch a command request on a queue.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="queueName">Queue name</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task DispatchOnQueue(IRequest command, string queueName, CancellationToken cancellationToken);

        /// <summary>
        /// Dispatch a command request on a queue.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="command"></param>
        /// <param name="queueName">Queue name</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task<TResponse> DispatchOnQueue<TResponse>(IRequest<TResponse> command, string queueName, CancellationToken cancellationToken);

        /// <summary>
        /// Queue a command request to background service
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task QueueInBackground(IRequest command);
    }
}
