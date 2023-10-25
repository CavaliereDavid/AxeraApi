using AxeraApi.Data;
using AxeraApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AxeraApi.Repositories;

public class SqlCourseRepository : ICourseRepository
{
    private readonly AxeraDbContext dbContext;

    public SqlCourseRepository(AxeraDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Course> CreateAsync(Course course)
    {
        await dbContext.Course.AddAsync(course);
        await dbContext.SaveChangesAsync();

        return course;
    }

    public async Task<Course?> DeleteAsync(Guid id)
    {
        var existingCourse = await dbContext.Course.FindAsync(id);

        if (existingCourse == null)
        {
            return null;
        }
        existingCourse.IsDeleted = true;
        await dbContext.SaveChangesAsync();
        dbContext.Course.Remove(existingCourse);
        await dbContext.SaveChangesAsync();

        return existingCourse;
    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await dbContext.Course
            .ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        var course =  await dbContext.Course.FirstOrDefaultAsync(x => x.Id == id);
        if (course == null)
        {
            course = null;
        }
        return course;
    }

    public async Task<Course?> SoftDeleteAsync(Guid id)
    {
        var existingCourse = await dbContext.Course.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCourse == null)
        {
            return null;
        }
        existingCourse.IsDeleted = true ;

        await dbContext.SaveChangesAsync();
        return existingCourse;
    }

    public async Task<Course?> UpdateAsync(Guid id, Course course)
    {
        var existingCourse = await dbContext.Course.FirstOrDefaultAsync(x =>x.Id == id);
        if(existingCourse == null)
        {
            return null;
        }
        existingCourse.Name = course.Name;
        existingCourse.Description = course.Description;

        await dbContext.SaveChangesAsync();
        return existingCourse;
    }
}
