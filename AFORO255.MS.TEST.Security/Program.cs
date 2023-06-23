using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Token.Src;
using AFORO255.MS.TEST.Security.etm.Data;
using AFORO255.MS.TEST.Security.etm.Persistences;
using AFORO255.MS.TEST.Security.etm.Services;
using Microsoft.EntityFrameworkCore;
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
            options.UseSqlServer(builder.Configuration["cn:sql"]);
        });
    services.AddScoped<IAccessService, AccessService>();
    services.Configure<JwtOptions>(builder.Configuration.GetSection("jwt"));
    services.AddConsul();
    services.AddFabio();
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