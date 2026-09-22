using AppPapelaria1;
using AppPapelaria1.Components;
using AppPapelaria1.Components.Pages.DAO;
using AppPapelaria1.Config;
using AppPapelaria1.DAO;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços do Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registra a Conexão e os DAOs
builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<CaixaDAO>();
builder.Services.AddScoped<FornecedorDAO>();
builder.Services.AddScoped<processoDAO>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();