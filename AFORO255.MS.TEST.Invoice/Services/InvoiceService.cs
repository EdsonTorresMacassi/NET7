using AFORO255.MS.TEST.Invoice.etm.Models;
using AFORO255.MS.TEST.Invoice.etm.Persistences;

namespace AFORO255.MS.TEST.Invoice.etm.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ContextDatabase _contextDatabase;

        public InvoiceService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

        public InvoiceModel Invoice(InvoiceModel transaction)
        {
            _contextDatabase.Invoice.Add(transaction);
            _contextDatabase.SaveChanges();
            return transaction;
        }

        public InvoiceModel InvoiceReverse(InvoiceModel transaction)
        {
            _contextDatabase.Invoice.Add(transaction);
            _contextDatabase.SaveChanges();
            return transaction;
        }
    }
}
