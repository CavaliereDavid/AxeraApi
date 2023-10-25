using AxeraApi.Data;
using AxeraApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AxeraApi.Repositories;

public class SqlMeetingRepository : IMeetingRepository
{
    private readonly AxeraDbContext dbContext;

    public SqlMeetingRepository(AxeraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Meeting> CreateAsync(Meeting meeting)
    {
        await dbContext.Meeting.AddAsync(meeting);
        await dbContext.SaveChangesAsync();
        return meeting;
    }

    public async Task<Meeting?> DeleteAsync(Guid id)
    {
        var existingMeeting = await dbContext.Meeting.FirstOrDefaultAsync(x => x.Id == id);

        if (existingMeeting == null)
        {
            return null;
        }

        existingMeeting.IsDeleted = true;
        await dbContext.SaveChangesAsync();
        dbContext.Meeting.Remove(existingMeeting);
        await dbContext.SaveChangesAsync();

        return existingMeeting;
    }

    public async Task<List<Meeting>> GetAllAsync(string? filterOn = null, bool? filterQuery = false)
    {
        var meetings = dbContext.Meeting.Include("Course").AsQueryable();
        if(string.IsNullOrWhiteSpace(filterOn) == false)
        {
            if(filterOn.Equals("IsDeleted", StringComparison.OrdinalIgnoreCase))
            {
                meetings = filterQuery.HasValue ? meetings.Where(x => x.IsDeleted == filterQuery.Value) : meetings;
            }
        }
        return await meetings.ToListAsync();
    }

    public async Task<Meeting?> GetByIdAsync(Guid id)
    {
        return await dbContext.Meeting.Include("Course").FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Meeting?> SoftDeleteAsync(Guid id)
    {
        var existingMeeting = await dbContext.Meeting.FirstOrDefaultAsync(x => x.Id == id);
        if (existingMeeting == null)
        {
            return null;
        }


        existingMeeting.IsDeleted = true;

        await dbContext.SaveChangesAsync();
        return existingMeeting;
    }

    public async Task<Meeting?> UpdateAsync(Guid id, Meeting meeting)
    {
        var existingMeeting = await dbContext.Meeting.FirstOrDefaultAsync(x => x.Id == id);
        if (existingMeeting == null)
        {
            return null;
        }

        existingMeeting.ScheduledMeeting = meeting.ScheduledMeeting;
        existingMeeting.Duration = meeting.Duration;
        existingMeeting.Note = meeting.Note;
        existingMeeting.MaxUsers = meeting.MaxUsers;
        existingMeeting.MinUsers = meeting.MinUsers;
        existingMeeting.CourseID = meeting.CourseID;

        await dbContext.SaveChangesAsync();
        return existingMeeting;
    }
}
