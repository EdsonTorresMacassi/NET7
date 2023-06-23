using AFORO255.MS.TEST.Transaction.etm.Features.DTOs;
using AFORO255.MS.TEST.Transaction.etm.Features.Models;

namespace AFORO255.MS.TEST.Transaction.etm.Features.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionResponse>> GetById(int idInvoice);

        Task<bool> Add(TransactionModel transactionModel);
    }
}
