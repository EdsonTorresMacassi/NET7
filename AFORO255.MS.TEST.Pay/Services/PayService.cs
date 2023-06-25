using AFORO255.MS.TEST.Pay.etm.Models;
using AFORO255.MS.TEST.Pay.etm.Persistences;

namespace AFORO255.MS.TEST.Pay.etm.Services
{
    public class PayService : IPayService
    {
        private readonly ContextDatabase _contextDatabase;
        public PayService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;

        public IEnumerable<PayModel> GetAll() => _contextDatabase.Pay.ToList();
        public PayModel Pay(PayModel transaction)
        {
            _contextDatabase.Pay.Add(transaction);
            _contextDatabase.SaveChanges();
            return transaction;
        }
    }
}
