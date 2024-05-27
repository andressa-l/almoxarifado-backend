using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;
using static AlmoxarifadoInfrastructure.Data.Repositories.ConexaoRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddSingleton<PrimeiraConexao>(cr => new PrimeiraConexao(builder.Configuration));
builder.Services.AddSingleton<ReplicaConexao>(cr => new ReplicaConexao(builder.Configuration));

builder.Services.AddSingleton<AlmoxarifadoInfrastructure.Data.ConexaoService>();

builder.Services.AddDbContext<xAlmoxarifadoContext>((serviceProvider, options) => 
{
    var conexaoService = serviceProvider.GetRequiredService<AlmoxarifadoInfrastructure.Data.ConexaoService>();
    var connectionString = conexaoService.GetConnectionString();
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<xAlmoxarifadoContext>();


builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<IItensNotaRepository, ItensNotaRepository>();
builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<IRequisicaoRepository, RequisicaoRepository>();
builder.Services.AddScoped<RequisicaoService>();
builder.Services.AddScoped<IItensReqRepository, ItensReqRepository>();
builder.Services.AddScoped<ItensReqService>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<EstoqueService>();

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
