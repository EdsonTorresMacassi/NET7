using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.etm.DTOs
{
    public class InvoiceRequest
    {
        //public int Id { get; set; }
        public decimal Amount { get; set; }
        public int State { get; set; }
    }
}