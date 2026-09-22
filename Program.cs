using AppPapelaria1;
<<<<<<< HEAD
using AppPapelaria1.Components;
using AppPapelaria1.Components.Pages.DAO;
=======
>>>>>>> 65c121a0acc9cea91570d8a6d72bb9a9be6442dd
using AppPapelaria1.Config;
using AppPapelaria1.DAO;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços do Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

<<<<<<< HEAD
// Registra a Conexão e os DAOs
builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<CaixaDAO>();
builder.Services.AddScoped<FornecedorDAO>();
builder.Services.AddScoped<processoDAO>();

=======
////configuração da conexão com o banco de dados MYSQL
builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<ProcessoDAO>();
builder.Services.AddScoped<FornecedorDAO>();


// Cria a aplicação
>>>>>>> 65c121a0acc9cea91570d8a6d72bb9a9be6442dd
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

<<<<<<< HEAD
app.Run();
=======
// Inicializa a aplicação
app.Run();


>>>>>>> 65c121a0acc9cea91570d8a6d72bb9a9be6442dd
