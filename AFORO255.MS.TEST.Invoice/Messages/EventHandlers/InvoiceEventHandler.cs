using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.etm.Messages.Events;
using AFORO255.MS.TEST.Invoice.etm.Models;
using AFORO255.MS.TEST.Invoice.etm.Persistences;

namespace AFORO255.MS.TEST.Invoice.etm.Messages.EventHandlers
{
    public class InvoiceEventHandler : IEventHandler<InvoiceCreatedEvent>
    {
        private readonly ContextDatabase _contextDatabase;

        public InvoiceEventHandler(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

        public Task Handle(InvoiceCreatedEvent @event)
        {
            var consulta = _contextDatabase.Invoice.Where(x => x.Id == @event.IdInvoice).FirstOrDefault();
            if(@event.Amount >= consulta.Amount)
            {
                consulta.Amount = consulta.Amount - @event.Amount;
                consulta.State = 0;
            }
            else
            {
                consulta.Amount = consulta.Amount - @event.Amount;
            }            
            _contextDatabase.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
