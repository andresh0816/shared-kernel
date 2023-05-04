using SharedKernel.Application.Cqrs.Commands;

namespace SharedKernel.Integration.Tests.Cqrs.Commands
{
    internal class SampleCommandWithResponse : IRequest<int>
    {
        public SampleCommandWithResponse(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
