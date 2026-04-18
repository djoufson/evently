using System.Runtime.CompilerServices;
using app.Apis;
using app.Data;
using app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.TextToImage;

namespace app.Services;

public class EventService(AppDbContext db, IChatCompletionService chat, ITextToImageService imageService, IFileUploadService fileUploadService) : IEventService
{
    public async Task<List<Event>> GetAllAsync()
    {
        return await db.Events
            .Include(e => e.Tags)
            .OrderByDescending(e => e.Date)
            .ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(int id)
    {
        return await db.Events
            .Include(e => e.Tags)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event> CreateAsync(Event evt, List<string> tagNames)
    {
        evt.Tags = await ResolveTagsAsync(tagNames);
        db.Events.Add(evt);
        await db.SaveChangesAsync();
        return evt;
    }

    public async Task UpdateAsync(Event evt, List<string> tagNames)
    {
        evt.Tags = await ResolveTagsAsync(tagNames);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var evt = await db.Events.FindAsync(id);
        if (evt is not null)
        {
            db.Events.Remove(evt);
            await db.SaveChangesAsync();
        }
    }

    public async Task<List<string>> GetAllTagNamesAsync()
    {
        return await db.Tags
            .Select(t => t.Name)
            .OrderBy(t => t)
            .ToListAsync();
    }

    public async Task<int> GetTagCountAsync()
    {
        return await db.Tags.CountAsync();
    }

    private async Task<List<Tag>> ResolveTagsAsync(List<string> tagNames)
    {
        var existingTags = await db.Tags
            .Where(t => tagNames.Contains(t.Name))
            .ToListAsync();

        var newTagNames = tagNames
            .Where(name => !existingTags.Any(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));

        var newTags = newTagNames.Select(name => new Tag { Name = name }).ToList();
        if (newTags.Count > 0)
            db.Tags.AddRange(newTags);

        return [.. existingTags, .. newTags];
    }

    public async IAsyncEnumerable<string> GenerateDescriptionAsync(GenerateDescriptionRequest payload, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var chatHistory = new ChatHistory();
        chatHistory.AddSystemMessage($"""
        Generate a 250 words clear description based on these information
            title: {payload.Title}
            tags: {string.Join(',', payload.Tags)}
        """);

        await foreach (var message in chat.GetStreamingChatMessageContentsAsync(chatHistory, cancellationToken: cancellationToken))
        {
            await Task.Delay(100, cancellationToken);
            yield return message.Content ?? string.Empty;
        }
    }

    public async Task<string> GenerateCoverAsync(GenerateCoverRequest payload, CancellationToken cancellationToken)
    {
        var images = await imageService.GetImageContentsAsync($"""
        Generate a cover image for this event
            title: {payload.Title}
            description: {payload.Description}
            tags: {string.Join(',', payload.Tags)}
        """,
        cancellationToken: cancellationToken);

        if (images is not { Count: > 0 } || images[0].Data is not { } data)
            return string.Empty;

        return await fileUploadService.UploadAsync(data, "cover.png");
    }
}
