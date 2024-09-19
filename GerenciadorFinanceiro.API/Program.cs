using GerenciadorFinanceiro.Dominio.Interfaces;
using GerenciadorFinanceiro.Infra.DBContexto;
using GerenciadorFinanceiro.Infra.Repositorio;
using GerenciadorFinanceiro.Servico.Interface;
using GerenciadorFinanceiro.Servico.Servico;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region [Add services to the container.]

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<Contexto>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IRepositorioDespesa, RepositorioDespesa>();

builder.Services.AddScoped<IServicoDespesa, ServicoDespesa>();

#endregion

var app = builder.Build();

#region [Configure the HTTP request pipeline.]

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion 


