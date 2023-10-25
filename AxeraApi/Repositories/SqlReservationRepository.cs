using AxeraApi.Data;
using AxeraApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AxeraApi.Repositories;

public class SqlReservationRepository : IReservationRepository
{
    private readonly AxeraDbContext dbContext;

    public SqlReservationRepository(AxeraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        await dbContext.Reservation.AddAsync(reservation);
        await dbContext.SaveChangesAsync();
        return reservation;
    }

    public async Task<Reservation?> DeleteAsync(Guid id)
    {
        var existingReservation = await dbContext.Reservation.FindAsync(id);

        if (existingReservation == null)
        {
            return null;
        }

        existingReservation.IsDeleted = true;
        await dbContext.SaveChangesAsync();
        dbContext.Reservation.Remove(existingReservation);
        await dbContext.SaveChangesAsync();

        return existingReservation;
    }

    public async Task<List<Reservation>> GetAllAsync(string? filterOn = null, bool? filterQuery = false, string? filterBy = null)
    {
        var reservations =   dbContext.Reservation.Include("Meeting").Include(x => x.Meeting.Course).Include("User").AsQueryable();

        if (string.IsNullOrWhiteSpace(filterOn) == false)
        {
            if (filterOn.Equals("IsDeleted", StringComparison.OrdinalIgnoreCase))
            {
                reservations = filterQuery.HasValue ? reservations.Where(x => x.IsDeleted == filterQuery.Value) : reservations;
            }
        }
        if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterBy) == false) {
            if (filterOn.Equals("Course", StringComparison.OrdinalIgnoreCase))
            {
                reservations = reservations.Where(x => x.Meeting.Course.Name.Contains(filterBy));
            }
        }
            return await reservations.ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        return await dbContext.Reservation.Include("Meeting").Include("User").FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Reservation?> SoftDeleteAsync(Guid id)
    {
        var existingReservation = await dbContext.Reservation.FirstOrDefaultAsync(x => x.Id == id);
        if (existingReservation == null)
        {
            return null;
        }

        existingReservation.IsDeleted = true;

        await dbContext.SaveChangesAsync();
        return existingReservation;
    }

    public async Task<Reservation?> UpdateAsync(Guid id, Reservation reservation)
    {
        var existingReservation = await dbContext.Reservation.FirstOrDefaultAsync(x => x.Id == id);
        if (existingReservation == null)
        {
            return null;
        }

        existingReservation.Note = reservation.Note;
        existingReservation.VerifiedPayment = reservation.VerifiedPayment;
        existingReservation.Withdraw = reservation.Withdraw;
        existingReservation.MeetingID = reservation.MeetingID;
        existingReservation.UserID = reservation.UserID;

        await dbContext.SaveChangesAsync();
        return existingReservation;
    }
}
