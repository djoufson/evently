using app.Data;
using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Services;

public class EventService(AppDbContext db) : IEventService
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
}
