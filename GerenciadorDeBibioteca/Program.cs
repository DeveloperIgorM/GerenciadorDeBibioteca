using GerenciadorDeBibioteca.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner, incluindo o DbContext
builder.Services.AddDbContext<BancoDeDados>();

// Adicione serviços do MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrão do HSTS é 30 dias. Pode ser alterado para ambientes de produção.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
