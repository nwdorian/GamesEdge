using Infrastructure;
using Web.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

WebApplication app = builder.Build();

await app.ApplyMigrations();
await app.SeedDatabase();

app.UseWebApplicationMiddleware();

await app.RunAsync();
