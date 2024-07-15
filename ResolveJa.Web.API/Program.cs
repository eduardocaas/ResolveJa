using ResolveJa.Application.Api.Services.Implementations;
using ResolveJa.Application.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Inje��o de servi�os
builder.Services.AddTransient<IEmpresaApiService, EmpresaApiServiceImpl>();
builder.Services.AddTransient<ITicketApiService, TicketApiServiceImpl>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
