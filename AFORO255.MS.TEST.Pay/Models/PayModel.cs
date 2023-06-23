using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.etm.Models
{
    [Table("pay")]
    public class PayModel
    {
        public PayModel(int idInvoice, decimal amount)
        {
            IdInvoice = idInvoice;
            Amount = amount;
            Date = DateTime.Now;            
        }

        [Column("id_operation")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("id_invoice")]
        public int IdInvoice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }        
    }
}
