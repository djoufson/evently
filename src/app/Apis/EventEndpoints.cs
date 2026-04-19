using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Apis;

public static class EventEndpoints
{
    public static void MapEventEndpoints(this WebApplication app)
    {
        app.MapPost("/api/events/generate-description", ([FromBody] GenerateDescriptionRequest payload, IEventService eventService, CancellationToken cancellationToken) =>
        {
            var responseStream = eventService.GenerateDescriptionAsync(payload, cancellationToken);
            return Results.Stream(async stream =>
            {
                var writer = new StreamWriter(stream);
                await foreach (var chunk in responseStream)
                {
                    await writer.WriteAsync(chunk);
                    await writer.FlushAsync(cancellationToken);
                }
            }, contentType: "text/event-stream");
        });

        app.MapPost("/api/events/generate-cover", async ([FromBody] GenerateCoverRequest payload, IEventService eventService, CancellationToken cancellationToken) =>
        {
            var imageUrl = await eventService.GenerateCoverAsync(payload, cancellationToken);
            return Results.Ok(new { url = imageUrl });
        });
    }
}

public record GenerateDescriptionRequest(string Title, string[] Tags);
public record GenerateCoverRequest(string Title, string? Description, string[] Tags);
