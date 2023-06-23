using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Pay.etm.Messages.Commands;
using AFORO255.MS.TEST.Pay.etm.Messages.Events;
using MediatR;

namespace AFORO255.MS.TEST.Pay.etm.Messages.CommandHandlers
{
    public class InvoiceCommandHandler : IRequestHandler<InvoiceCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public InvoiceCommandHandler(IEventBus bus) => _bus = bus;

        public Task<bool> Handle(InvoiceCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new InvoiceCreatedEvent(request.IdInvoice, request.Amount, request.Date));
            return Task.FromResult(true);
        }
    }
}
