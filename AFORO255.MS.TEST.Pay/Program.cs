using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

using Aforo255.Cross.Event.Src;
using AFORO255.MS.TEST.Pay.etm.Data;
using AFORO255.MS.TEST.Pay.etm.Messages.CommandHandlers;
using AFORO255.MS.TEST.Pay.etm.Messages.Commands;
using AFORO255.MS.TEST.Pay.etm.Persistences;
using AFORO255.MS.TEST.Pay.etm.Services;
using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

ConfigureConfiguration(builder.Configuration);
ConfigureServices(builder.Services);

var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
ConfigureMiddleware(app, app.Services);
ConfigureEndpoints(app, app.Services);
app.UseConsul();
DbCreated.CreateDbIfNotExists(app);
app.Run();

void ConfigureConfiguration(ConfigurationManager configuration)
{

}

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    //services.AddEndpointsApiExplorer();
    //services.AddSwaggerGen();

    services.AddDbContext<ContextDatabase>(
        options =>
        {
            options.UseMySQL(builder.Configuration["cn:mysql"]);
        });
    services.AddScoped<IPayService, PayService>();
    builder.Services.AddConsul();
    builder.Services.AddFabio();

    services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
    services.AddRabbitMQ();
    services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
    services.AddTransient<IRequestHandler<InvoiceCreateCommand, bool>, InvoiceCommandHandler>();
}

void ConfigureMiddleware(IApplicationBuilder app, IServiceProvider services)
{
    app.UseAuthorization();
}
void ConfigureEndpoints(IEndpointRouteBuilder app, IServiceProvider services)
{
    app.MapControllers();
}
