using AFORO255.MS.TEST.Invoice.etm.Models;

namespace AFORO255.MS.TEST.Invoice.etm.Services
{
    public interface IInvoiceService
    {
        IEnumerable<InvoiceModel> GetAll();
        InvoiceModel Invoice(InvoiceModel transaction);
    }
}
