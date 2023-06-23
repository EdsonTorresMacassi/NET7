using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.etm.Features.Services;
using AFORO255.MS.TEST.Transaction.etm.Messages.EventHandlers;
using AFORO255.MS.TEST.Transaction.etm.Messages.Events;
using AFORO255.MS.TEST.Transaction.etm.Persistences;
using AFORO255.MS.TEST.Transaction.etm.Persistences.Settings;
using Carter;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

builder.Services.AddCarter();
builder.Services.Configure<Mongosettings>(opt =>
{
    opt.Connection = builder.Configuration.GetSection("cn:mongo").Value;
    opt.DatabaseName = builder.Configuration.GetSection("bd:mongo").Value;
});
builder.Services.AddScoped<IMongoBookDBContext, MongoBookDBContext>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddConsul();
builder.Services.AddFabio();

/*Start - RabbitMQ*/
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();

builder.Services.AddTransient<TransactionEventHandler>();
builder.Services.AddTransient<IEventHandler<TransactionCreatedEvent>, TransactionEventHandler>();
/*End - RabbitMQ*/


//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
app.MapCarter();
ConfigureEventBus(app);
app.UseConsul();
app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransactionCreatedEvent, TransactionEventHandler>();
}