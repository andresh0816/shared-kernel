using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Application.Cqrs.Commands.Handlers
{
    /// <summary>
    /// Handler of a command that does not return anything
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface IRequestHandler<in TCommand> where TCommand : IRequest
    {
        /// <summary>
        /// The implementation of the command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Handler of a command that returns a response
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequestHandler<in TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
        /// <summary>
        /// The implementation of the command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns></returns>
        Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
