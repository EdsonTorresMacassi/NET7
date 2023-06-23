using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.etm.Features.Models;
using AFORO255.MS.TEST.Transaction.etm.Features.Services;
using AFORO255.MS.TEST.Transaction.etm.Messages.Events;

namespace AFORO255.MS.TEST.Transaction.etm.Messages.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly ITransactionService _transactionService;

        public TransactionEventHandler(ITransactionService transactionService) => _transactionService = transactionService;

        public Task Handle(TransactionCreatedEvent @event)
        {
            _transactionService.Add(new TransactionModel()
            {
                IdTransaccion = @event.IdOperation,
                IdInvoice = @event.IdInvoice,
                Amount = @event.Amount,                
                Date = @event.Date
            });
            return Task.CompletedTask;
        }
    }
}
