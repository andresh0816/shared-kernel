using SharedKernel.Application.Cqrs.Commands.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Integration.Tests.Cqrs.Commands
{
    internal class DelayCommandHandler : IRequestHandler<DelayCommand>
    {
        public Task HandleAsync(DelayCommand command, CancellationToken cancellationToken)
        {
            return Task.Delay(command.Seconds * 1000, cancellationToken);
        }
    }
}
