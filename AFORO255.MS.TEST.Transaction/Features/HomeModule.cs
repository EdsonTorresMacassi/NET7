using Carter;

namespace AFORO255.MS.TEST.Transaction.etm.Features
{
    public class HomeModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("ping", Ping)
               .Produces(StatusCodes.Status404NotFound);
        }

        private static IResult Ping(ILogger<HomeModule> logger)
        {
            logger.LogDebug("Ping ...");
            return Results.Ok();
        }
    }
}
