using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.etm.Models
{
    [Table("invoice")]
    public class InvoiceModel
    {
        public InvoiceModel() { }
        public InvoiceModel(decimal amount, int state)
        {
            //Id = idInvoice;
            Amount = amount;
            State = state;
        }

        [Column("id_invoice")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }        
        [Column("state")]
        public int State { get; set; }
    }
}