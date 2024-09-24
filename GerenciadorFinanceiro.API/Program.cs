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
        // Ignorar campos somente leitura na serialização JSON
        options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
    })
    .AddNewtonsoftJson(op =>
    {
        // Evitar loop de referência na serialização
        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar as dependências de serviços e repositórios
builder.Services.AddScoped<IRepositorioDespesa, RepositorioDespesa>();
builder.Services.AddScoped<IServicoDespesa, ServicoDespesa>();

// Configurar CORS para permitir qualquer origem, método e cabeçalho
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Configurar o diretório estático do SPA (se houver um frontend SPA)
builder.Services.AddSpaStaticFiles(diretorio =>
{
    diretorio.RootPath = "GerenciadorFinanceiro-UI"; // Exemplo de diretório do frontend
});

#endregion

#region [Configure the HTTP request pipeline.]

var app = builder.Build();

// Configurar o CORS para usar a política criada
app.UseCors("AllowAll");

// Redirecionar requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Configurar autorização (se necessário)
app.UseAuthorization();

// Servir arquivos estáticos
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

// Iniciar a aplicação
app.Run();

#endregion