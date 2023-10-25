using AxeraApi.Domain.Models;

namespace AxeraApi.Repositories;

public interface IMeetingRepository
{
    Task<List<Meeting>> GetAllAsync();
    Task<Meeting?> GetByIdAsync(Guid id);
    Task<Meeting> CreateAsync(Meeting meeting);
    Task<Meeting?> UpdateAsync(Guid id, Meeting meeting);
    Task<Meeting?> DeleteAsync(Guid id);
    Task<Meeting?> SoftDeleteAsync(Guid id);
}
