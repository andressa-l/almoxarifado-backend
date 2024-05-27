using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<xAlmoxarifadoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDBSQL")));

builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<RequisicaoService>();
builder.Services.AddScoped<ItensReqService>();
builder.Services.AddScoped<EstoqueService>();

builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
builder.Services.AddScoped<IItensNotaRepository, ItensNotaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IRequisicaoRepository, RequisicaoRepository>();
builder.Services.AddScoped<IItensReqRepository, ItensReqRepository>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
