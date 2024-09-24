using GerenciadorFinanceiro.Dominio.Interfaces;
using GerenciadorFinanceiro.Infra.DBContexto;
using GerenciadorFinanceiro.Infra.Repositorio;
using GerenciadorFinanceiro.Servico.Interface;
using GerenciadorFinanceiro.Servico.Servico;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region [Add services to the container.]

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Ignorar campos somente leitura na serializa��o JSON
        options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
    })
    .AddNewtonsoftJson(op =>
    {
        // Evitar loop de refer�ncia na serializa��o
        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar as depend�ncias de servi�os e reposit�rios
builder.Services.AddScoped<IRepositorioDespesa, RepositorioDespesa>();
builder.Services.AddScoped<IServicoDespesa, ServicoDespesa>();

// Configurar CORS para permitir qualquer origem, m�todo e cabe�alho
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Configurar o diret�rio est�tico do SPA (se houver um frontend SPA)
builder.Services.AddSpaStaticFiles(diretorio =>
{
    diretorio.RootPath = "GerenciadorFinanceiro-UI"; // Exemplo de diret�rio do frontend
});

#endregion

#region [Configure the HTTP request pipeline.]

var app = builder.Build();

// Configurar o CORS para usar a pol�tica criada
app.UseCors("AllowAll");

// Redirecionar requisi��es HTTP para HTTPS
app.UseHttpsRedirection();

// Configurar autoriza��o (se necess�rio)
app.UseAuthorization();

// Servir arquivos est�ticos
app.UseStaticFiles();
app.UseSpaStaticFiles();

// Configurar o pipeline do SPA (se houver)
//app.UseSpa(spa =>
//{
//    spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "/Frontend/GerenciadorFinanceiro-UI");

//    // Se estiver em desenvolvimento, use o proxy para o servidor do SPA
//    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // URL do servidor de desenvolvimento do SPA (exemplo com Angular)
//});

// Mapear os controladores da API
app.MapControllers();

// Iniciar a aplica��o
app.Run();

#endregion