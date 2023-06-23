using AFORO255.MS.TEST.Transaction.etm.Features.DTOs;
using AFORO255.MS.TEST.Transaction.etm.Features.Services;
using Carter;

namespace AFORO255.MS.TEST.Transaction.etm.Features
{
    public class TransactionModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/transaction/{idInvoice}", GetAccount)
               .Produces<TransactionResponse>()
               .Produces(StatusCodes.Status404NotFound);
        }

        private static async Task<IResult> GetAccount(int idInvoice, ITransactionService service)
        {
            var movements = await service.GetById(idInvoice);
            if (movements is null) return Results.NotFound();
            return Results.Ok(movements);
        }
    }
}
