using AppPapelaria1.Components;

// Cria e configura a aplicação Blazor
var builder = WebApplication.CreateBuilder(args);

// Adiciona os componentes Razor e habilita a interatividade
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Cria a aplicação
var app = builder.Build();

// Configura tratamento de erros em ambiente de produção
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Proteção contra ataques CSRF
app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Inicializa a aplicação
app.Run();
