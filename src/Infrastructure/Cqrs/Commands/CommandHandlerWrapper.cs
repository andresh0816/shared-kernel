using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application.Cqrs.Commands;
using SharedKernel.Application.Cqrs.Commands.Handlers;

namespace SharedKernel.Infrastructure.Cqrs.Commands
{
    internal abstract class CommandHandlerWrapper
    {
        public abstract Task Handle(IRequest commandRequest, IServiceProvider provider,
            CancellationToken cancellationToken);
    }

    internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper where TCommand : IRequest
    {
        public override Task Handle(IRequest commandRequest, IServiceProvider provider, CancellationToken cancellationToken)
        {
            var handler = (IRequestHandler<TCommand>) provider.CreateScope().ServiceProvider
                .GetRequiredService(typeof(IRequestHandler<TCommand>));

            return handler.HandleAsync((TCommand)commandRequest, cancellationToken);
        }
    }

    internal abstract class CommandHandlerWrapperResponse<TResponse>
    {
        public abstract Task<TResponse> Handle(IRequest<TResponse> commandRequest, IServiceProvider provider, CancellationToken cancellationToken);
    }


    internal class CommandHandlerWrapperResponse<TCommand, TResponse> : CommandHandlerWrapperResponse<TResponse> where TCommand: IRequest<TResponse>
    {
        public override Task<TResponse> Handle(IRequest<TResponse> commandRequest, IServiceProvider provider, CancellationToken cancellationToken)
        {
            var handler = (IRequestHandler<TCommand, TResponse>) provider.CreateScope().ServiceProvider
                .GetRequiredService(typeof(IRequestHandler<TCommand, TResponse>));

            return handler.HandleAsync((TCommand)commandRequest, cancellationToken);
        }
    }
}
