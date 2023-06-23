using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.etm.Data;
using AFORO255.MS.TEST.Invoice.etm.Messages.EventHandlers;
using AFORO255.MS.TEST.Invoice.etm.Messages.Events;
using AFORO255.MS.TEST.Invoice.etm.Persistences;
using AFORO255.MS.TEST.Invoice.etm.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Reflection;

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
DbCreated.CreateDbIfNotExists(app);
ConfigureEventBus(app);
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
            options.UseNpgsql(builder.Configuration["cn:postgres"]);
        });
    services.AddScoped<IInvoiceService, InvoiceService>();
    services.AddConsul();
    services.AddFabio();

    services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
    services.AddRabbitMQ();
    services.AddTransient<InvoiceEventHandler>();
    services.AddTransient<IEventHandler<InvoiceCreatedEvent>, InvoiceEventHandler>();
}
void ConfigureMiddleware(IApplicationBuilder app, IServiceProvider services)
{
    app.UseAuthorization();
    app.UseConsul();
}
void ConfigureEndpoints(IEndpointRouteBuilder app, IServiceProvider services)
{
    app.MapControllers();
}

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<InvoiceCreatedEvent, InvoiceEventHandler>();
}