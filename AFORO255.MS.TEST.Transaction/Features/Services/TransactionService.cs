using AFORO255.MS.TEST.Transaction.etm.Features.DTOs;
using AFORO255.MS.TEST.Transaction.etm.Features.Models;
using AFORO255.MS.TEST.Transaction.etm.Persistences;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.etm.Features.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMongoBookDBContext _context;
        protected IMongoCollection<TransactionModel> _dbCollection;
        public TransactionService(IMongoBookDBContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<TransactionModel>(typeof(TransactionModel).Name);
        }

        public async Task<bool> Add(TransactionModel transactionModel)
        {
            await _dbCollection.InsertOneAsync(transactionModel);
            return true;
        }

        public async Task<IEnumerable<TransactionResponse>> GetById(int idInvoice)
        {
            var result = await _dbCollection.Find(x => x.IdInvoice == idInvoice).ToListAsync();
            var response = new List<TransactionResponse>();
            foreach (var item in result)
            {
                response.Add(new TransactionResponse()
                {
                    IdTransaccion = item.IdTransaccion,
                    IdInvoice = item.IdInvoice,
                    Amount = item.Amount,
                    Date = item.Date
                });
            }
            return response;
        }
    }
}
