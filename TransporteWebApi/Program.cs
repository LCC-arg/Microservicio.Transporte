using Application.Interfaces.ICaracteristica;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Interfaces.ICompaniaTransporte;
using Application.Interfaces.ITipoTransporte;
using Application.Interfaces.ITransporte;
using Application.UseCase;
using Infraestructure;
using Infraestructure.Command;
using Infraestructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<TransporteContext>(options => options.UseSqlServer(connectionString));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<ICaracteristicaService, CaracteristicaService>();
builder.Services.AddScoped<ICaracteristicaCommand, CaracteristicaCommand>();
builder.Services.AddScoped<ICaracteristicaQuery, CaracteristicaQuery>();

builder.Services.AddScoped<ITransporteService, TransporteService>();
builder.Services.AddScoped<ITransporteCommand, TransporteCommand>();
builder.Services.AddScoped<ITransporteQuery, TransporteQuery>();

builder.Services.AddScoped<ICaracteristicaTransporteService, CaracteristicaTransporteService>();
builder.Services.AddScoped<ICaracteristicaTransporteCommand, CaracteristicaTransporteCommand>();
builder.Services.AddScoped<ICaracteristicaTransporteQuery, CaracteristicaTransporteQuery>();

builder.Services.AddScoped<ICompaniaTransporteService, CompaniaTransporteService>();
builder.Services.AddScoped<ICompaniaTransporteCommand, CompaniaTransporteCommand>();
builder.Services.AddScoped<ICompaniaTransporteQuery, CompaniaTransporteQuery>();

builder.Services.AddScoped<ITipoTransporteService, TipoTransporteService>();
builder.Services.AddScoped<ITipoTransporteCommand, TipoTransporteCommand>();
builder.Services.AddScoped<ITipoTransporteQuery, TipoTransporteQuery>();

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
