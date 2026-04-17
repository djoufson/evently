using app.Models;

namespace app.Services;

public interface IEventService
{
    Task<List<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task<Event> CreateAsync(Event evt, List<string> tagNames);
    Task UpdateAsync(Event evt, List<string> tagNames);
    Task DeleteAsync(int id);
    Task<List<string>> GetAllTagNamesAsync();
    Task<int> GetTagCountAsync();
}
