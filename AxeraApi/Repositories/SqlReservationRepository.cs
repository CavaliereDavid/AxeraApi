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

    public async Task<List<Reservation>> GetAllAsync()
    {
        return await dbContext.Reservation.ToListAsync();
    }

    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        return await dbContext.Reservation.FirstOrDefaultAsync(x => x.Id == id);
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
