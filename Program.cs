using Microsoft.EntityFrameworkCore;
using Psicologia.Context;
using Psicologiaa.Repositorios;
using Psicologiaa.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<EntidadesDbContext>(options => options.UseSqlServer(conString));

builder.Services.AddScoped<IDatosPersonalesRepository, DatosPersonalesRepository>();
builder.Services.AddScoped<IDatosPersonalesService, DatosPersonalesService>();

builder.Services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionService>();

builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IPacienteService, PacienteService>();

builder.Services.AddScoped<ISesionRepository, SesionRepository>();
builder.Services.AddScoped<ISesionService, SesionService>();

builder.Services.AddScoped<ITerapeutaRepository, TerapeutaRepository>();
builder.Services.AddScoped<ITerapeutaService, TerapeutaService>();


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
