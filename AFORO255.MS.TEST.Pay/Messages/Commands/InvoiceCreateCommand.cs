using Aforo255.Cross.Event.Src.Commands;

namespace AFORO255.MS.TEST.Pay.etm.Messages.Commands
{
    public class InvoiceCreateCommand : Command
    {
        public int IdInvoice { get; protected set; }
        public decimal Amount { get; protected set; }
        public DateTime Date { get; protected set; }

        public InvoiceCreateCommand(int idInvoice, decimal amount, DateTime date)
        {            
            IdInvoice = idInvoice;
            Amount = amount;
            Date = date;
        }
    }
}
