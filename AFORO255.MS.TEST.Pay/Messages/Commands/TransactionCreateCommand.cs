using Aforo255.Cross.Event.Src.Commands;

namespace AFORO255.MS.TEST.Pay.etm.Messages.Commands
{
    public class TransactionCreateCommand : Command
    {
        public int IdOperation { get; protected set; }
        public int IdInvoice { get; protected set; }
        public decimal Amount { get; protected set; }
        public DateTime Date { get; protected set; }

        public TransactionCreateCommand(int idOperation, int idInvoice, decimal amount, DateTime date)
        {
            IdOperation = idOperation;
            IdInvoice = idInvoice;
            Amount = amount;
            Date = date;
        }
    }
}
