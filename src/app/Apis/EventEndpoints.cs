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
    }
}

public record GenerateDescriptionRequest(string Title, string[] Tags);
