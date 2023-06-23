using Aforo255.Cross.Event.Src.Events;

namespace AFORO255.MS.TEST.Pay.etm.Messages.Events
{
    public class TransactionCreatedEvent : Event
    {
        public TransactionCreatedEvent(int idOperation, int idInvoice, decimal amount, DateTime date)
        {
            IdOperation = idOperation;
            IdInvoice = idInvoice;
            Amount = amount;
            Date = date;
        }

        public int IdOperation { get; set; }
        public int IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}