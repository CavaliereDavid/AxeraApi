using AxeraApi.Domain.Models;

namespace AxeraApi.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync(string? filterOn = null, bool? filterQuery = false);
    Task<User?> GetByIdAsync(Guid id);
    Task<User> CreateAsync(User user);
    Task<User?> UpdateAsync(Guid id, User user);
    Task<User?> SoftDeleteAsync(Guid id);
    Task<User?> DeleteAsync(Guid id);
}
