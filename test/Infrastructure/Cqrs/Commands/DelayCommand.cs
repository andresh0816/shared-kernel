using SharedKernel.Application.Cqrs.Commands;

namespace SharedKernel.Integration.Tests.Cqrs.Commands
{
    internal class DelayCommand : IRequest
    {
        public DelayCommand(int seconds)
        {
            Seconds = seconds;
        }

        public int Seconds { get; }
    }
}
