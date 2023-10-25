using AxeraApi.Domain.Models;

namespace AxeraApi.Repositories;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync(string? filterOn = null, string? filterQuery = null);
    Task<Course?> GetByIdAsync(Guid id);
    Task<Course> CreateAsync(Course course);
    Task<Course?> UpdateAsync(Guid id, Course course);
    Task<Course?> SoftDeleteAsync(Guid id);
    Task<Course?> DeleteAsync(Guid id);
}
