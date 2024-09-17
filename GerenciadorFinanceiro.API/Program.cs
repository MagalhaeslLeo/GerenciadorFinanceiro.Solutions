using GerenciadorFinanceiro.Infra.DBContexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region [Add services to the container.]

builder.Services.AddControllers();
builder.Services.AddDbContext<Contexto>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

#endregion

var app = builder.Build();

#region [Configure the HTTP request pipeline.]

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion 


