using app.Components;
using app.Data;
using app.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=evently.db"));

builder.Services.AddScoped<IEventService, EventService>();

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

var uploadsPath = Path.Combine(app.Environment.WebRootPath, "uploads");
Directory.CreateDirectory(uploadsPath);

app.MapPost("/api/uploads", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();
    var file = form.Files.FirstOrDefault();
    if (file is null || file.Length == 0)
        return Results.BadRequest("No file uploaded.");

    var extension = Path.GetExtension(file.FileName);
    var filename = $"{Guid.NewGuid()}{extension}";
    var filePath = Path.Combine(uploadsPath, filename);

    await using var stream = new FileStream(filePath, FileMode.Create);
    await file.CopyToAsync(stream);

    return Results.Ok(new { url = $"/uploads/{filename}" });
}).DisableAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
