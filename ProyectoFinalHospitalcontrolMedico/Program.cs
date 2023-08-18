using Microsoft.EntityFrameworkCore;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;
using ProyectoFinalHospitalcontrolMedico.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var conn = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<SistemaMedicoAPIContext>(op => op.UseSqlServer(conn));

builder.Services.AddScoped<Imedico, GestorMedicoServices>();
builder.Services.AddScoped<Ipaciente, GestorPacienteServices>();
builder.Services.AddScoped<Ihabitaciones, GestorHabitacionServices>();
builder.Services.AddScoped<ICitaMedica, GestorCitaMedicaServices>();
builder.Services.AddScoped<Iingreso, GestorIngresoServices>();
builder.Services.AddScoped<IAlta, GestorAltaServices>();
builder.Services.AddScoped<IConsulta, GestorConsultaServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
