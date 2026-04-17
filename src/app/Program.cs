using app.Apis;
using app.Components;
using app.Data;
using app.Services;
using app.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=evently.db"));

var azureOpenAiSection = builder.Configuration.GetSection(AzureOpenAiSettings.SectionName);
builder.Services.Configure<AzureOpenAiSettings>(azureOpenAiSection);

var azureOpenAi = azureOpenAiSection.Get<AzureOpenAiSettings>();
if (azureOpenAi is not null)
{
    builder.Services.AddAzureOpenAIChatCompletion(
        azureOpenAi.DeploymentName,
        azureOpenAi.Endpoint,
        azureOpenAi.ApiKey,
        modelId: azureOpenAi.ModelId);
}

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    SeedData.Initialize(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapUploadEndpoints();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
