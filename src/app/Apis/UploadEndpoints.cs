using app.Services;

namespace app.Apis;

public static class UploadEndpoints
{
    public static void MapUploadEndpoints(this WebApplication app)
    {
        app.MapPost("/api/uploads", async (HttpRequest request, IFileUploadService uploadService) =>
        {
            var form = await request.ReadFormAsync();
            var file = form.Files.FirstOrDefault();
            if (file is null || file.Length == 0)
                return Results.BadRequest("No file uploaded.");

            await using var stream = file.OpenReadStream();
            var url = await uploadService.UploadAsync(stream, file.FileName);

            return Results.Ok(new { url });
        }).DisableAntiforgery();
    }
}
