using AxeraApi.Domain.Models;

namespace AxeraApi.Repositories;

public interface IReservationRepository
{
    Task<List<Reservation>> GetAllAsync(string? filterOn = null, bool? filterQuery = false, string? filterBy = null);
    Task<Reservation?> GetByIdAsync(Guid id);
    Task<Reservation> CreateAsync(Reservation reservation);
    Task<Reservation?> UpdateAsync(Guid id, Reservation reservation);
    Task<Reservation?> SoftDeleteAsync(Guid id);
    Task<Reservation?> DeleteAsync(Guid id);
}
