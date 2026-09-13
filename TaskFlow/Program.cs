using TaskFlow.Components;
using TaskFlow.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

var foundCommands = new List<string>();
var repoType = typeof(InMemoryTaskRepository);
foreach (var method in repoType.GetMethods())
{
    var attr = method.GetCustomAttribute<CommandAttribute>();
    if (attr is not null)
    {
        foundCommands.Add($"{attr.Name} -> {method.Name}");
    }
}
builder.Services.AddSingleton(foundCommands);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();