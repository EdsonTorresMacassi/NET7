using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Transaction.etm.Features.DTOs
{
    public class TransactionResponse
    {
        public int IdTransaccion { get; set; }
        public int IdInvoice { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
