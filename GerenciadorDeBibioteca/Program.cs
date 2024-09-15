using GerenciadorDeBibioteca.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione servi�os ao cont�iner, incluindo o DbContext
builder.Services.AddDbContext<BancoDeDados>();

// Adicione servi�os do MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padr�o do HSTS � 30 dias. Pode ser alterado para ambientes de produ��o.
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
