using AxeraApi.Data;
using AxeraApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AxeraApi.Repositories;

public class SqlUserRepository : IUserRepository
{
    private readonly AxeraDbContext dbContext;

    public SqlUserRepository(AxeraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        await dbContext.User.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> DeleteAsync(Guid id)
    {
        var existingUser = await dbContext.User.FindAsync(id);

        if (existingUser == null)
        {
            return null;
        }

        existingUser.IsDeleted = true;
        await dbContext.SaveChangesAsync();
        dbContext.User.Remove(existingUser);
        await dbContext.SaveChangesAsync();

        return existingUser;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await dbContext.User
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> SoftDeleteAsync(Guid id)
    {
        var existingUser = await dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.IsDeleted = true;

        await dbContext.SaveChangesAsync();
        return existingUser;
    }

    public async Task<User?> UpdateAsync(Guid id, User user)
    {
        var existingUser = await dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.ParticipantFullName = user.ParticipantFullName;
        existingUser.Age = user.Age;
        existingUser.ParentFullName = user.ParentFullName;
        existingUser.Email = user.Email;
        existingUser.VerifiedUser = user.VerifiedUser;
        existingUser.IsNewsletterActive = user.IsNewsletterActive;
        existingUser.Allergies = user.Allergies;
        existingUser.ConsentToPersonalData = user.ConsentToPersonalData;
        existingUser.PrivacyPolicyAcknowledgement = user.PrivacyPolicyAcknowledgement;
        existingUser.PhoneNumber = user.PhoneNumber;

        await dbContext.SaveChangesAsync();
        return existingUser;
    }
}
