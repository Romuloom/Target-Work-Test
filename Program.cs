using Cadastro.Infrastructure.Data.Common;
using Cadastro.Infrastructure.ExtensionMethods;
using Cadastro.Infrastructure.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddRepositories().AddServices();

// Configura AutoMapper usando a classe de mapeamento definida no projeto
builder.Services.AddAutoMapper(typeof(AutoMapping));

// Configura o DbContext para usar um banco de dados em memória (para desenvolvimento/testes)
builder.Services.AddDbContext<RegisterContext>(options =>
    options.UseInMemoryDatabase("Register"));

// Adiciona suporte para controladores e views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware para redirecionamento HTTP para HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

// Configuração de roteamento
app.UseRouting();

// Middleware de autorização
app.UseAuthorization();

// Mapeamento de rotas padrão para os controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Executa a aplicação
app.Run();
