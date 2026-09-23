using AppPapelaria1;
using AppPapelaria1.Components.Pages;
using AppPapelaria1.Config;
using AppPapelaria1.DAO;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<CaixaDAO>();
builder.Services.AddScoped<ProcessoDAO>();
builder.Services.AddScoped<FornecedorDAO>();
builder.Services.AddScoped<CaixaDAO>();
builder.Services.AddScoped<ClienteDAO>();
builder.Services.AddScoped<CategoriaDAO>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.Run();