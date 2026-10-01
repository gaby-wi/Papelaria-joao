using AppPapelaria1;
using AppPapelaria1.Components;
using AppPapelaria1.Config;
using AppPapelaria1.DAO;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços do Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Injeção de Dependência das classes DAO e Conexão
builder.Services.AddScoped<Conexao>();
builder.Services.AddScoped<CaixaDAO>();
builder.Services.AddScoped<ProcessoDAO>();
builder.Services.AddScoped<FornecedorDAO>();
builder.Services.AddScoped<FinanceiroDAO>();
builder.Services.AddScoped<ClienteDAO>();
builder.Services.AddScoped<CategoriaDAO>();
builder.Services.AddScoped<ProdutoDAO>();
builder.Services.AddScoped<FuncionarioDAO>();
builder.Services.AddScoped<EstoqueDAO>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

// Mapeia os arquivos estáticos (CSS, imagens, JS)
app.MapStaticAssets();

// MAPEAMENTO FUNDAMENTAL DO BLAZOR:
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();