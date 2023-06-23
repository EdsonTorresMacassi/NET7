using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Transaction.etm.Features.Models
{
    public class TransactionModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [Column("id_transaccion")]
        public int IdTransaccion { get; set; }
        [Column("id_invoice")]
        public int IdInvoice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
