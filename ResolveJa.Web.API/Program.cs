using Microsoft.EntityFrameworkCore;
using ResolveJa.Application.Api.Services.Implementations;
using ResolveJa.Application.Api.Services.Interfaces;
using ResolveJa.Infrastructure.Data.Persistence;
using ResolveJa.Infrastructure.IoC;

var allowLocalOrigins = "_allowLocalOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(CorsConfiguration.Configure(allowLocalOrigins));

// Injeção de serviços
builder.Services.AddTransient<IEmpresaApiService, EmpresaApiServiceImpl>();
builder.Services.AddTransient<ITicketApiService, TicketApiServiceImpl>();

var connectionString = builder.Configuration.GetConnectionString("LocalConnectionTest");
builder.Services.AddDbContext<ResolveJaDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ResolveJa.Infrastructure.Data")), ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(allowLocalOrigins);
app.MapControllers();

app.Run();
