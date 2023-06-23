using MediatR;

using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.etm.Messages.Commands;
using AFORO255.MS.TEST.Pay.etm.Messages.Events;

namespace AFORO255.MS.TEST.Pay.etm.Messages.CommandHandlers
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransactionCommandHandler(IEventBus bus) => _bus = bus;

        public Task<bool> Handle(TransactionCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransactionCreatedEvent(request.IdOperation, request.IdInvoice, request.Amount, request.Date));
            return Task.FromResult(true);
        }
    }
}
