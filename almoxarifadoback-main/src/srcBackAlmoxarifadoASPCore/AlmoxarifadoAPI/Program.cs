using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContextSQL>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDBSQL")));

//Carregando Classes de Repositories
builder.Services.AddScoped<GrupoService>();
builder.Services.AddScoped<IGrupoRepository,GrupoRepository>();



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
