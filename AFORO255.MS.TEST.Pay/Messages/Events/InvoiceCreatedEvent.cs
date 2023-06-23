using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Pay.etm.Messages.Events
{
    public class InvoiceCreatedEvent : Event
    {
        public InvoiceCreatedEvent(int idInvoice, decimal amount, DateTime date)
        {
            IdInvoice = idInvoice;
            Amount = amount;
            Date = date;
        }

        public int IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
