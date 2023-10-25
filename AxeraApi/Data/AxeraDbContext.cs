using AxeraApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AxeraApi.Data;

public class AxeraDbContext : DbContext
{
    private readonly DbContextOptions dbContextOptions;

    public AxeraDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        this.dbContextOptions = dbContextOptions;
    }

    public DbSet<Course> Course { get; set; }
    public DbSet<Meeting> Meeting { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        List<Course> courses = new List<Course>()
        {
            new Course()
            {
                Id = Guid.Parse("a0203c2f-16d5-4f87-bc6f-6a1a4eb67002"),
                Name = "Introduction to Programming",
                Description = "Learn the basics of programming with this introductory course.",
                IsDeleted = false
            },
            new Course
            {
                Id = Guid.Parse("bc103b57-4e13-4ff8-9a18-2158d0ec41dd"),
                Name = "Web Development Fundamentals",
                Description = "Explore the fundamentals of web development.",
                IsDeleted = false
            },
            new Course
            {
                Id = Guid.Parse("ff1e8442-ff9b-4c19-9865-c77ad810c609"),
                Name = "Data Science Essentials",
                Description = "Master the essentials of data science and analysis.",
                IsDeleted = false
            },
            new Course
            {
                Id = Guid.Parse("5c56b3f3-1fb2-4f99-80db-8ea2bbcdfe25"),
                Name = "Mobile App Development",
                Description = "Create mobile apps for both Android and iOS platforms.",
                IsDeleted = false
            }
        };

        modelBuilder.Entity<Course>().HasData(courses);

        List<Meeting> meetings = new List<Meeting>()
        {
            new Meeting()
            {
                Id = Guid.Parse("9a18e6f1-0343-4a0a-845e-86524cc95e67"),
                ScheduledMeeting = DateTime.UtcNow.AddDays(7),
                Duration = 90,
                Note = "Introduction to Programming",
                MaxUsers = 20,
                MinUsers = 5,
                IsDeleted = false,
                CourseID = Guid.Parse("a0203c2f-16d5-4f87-bc6f-6a1a4eb67002")
            },
            new Meeting()
            {
                Id = Guid.Parse("f674b6e3-7e3d-4b7c-8ff4-0a66a39bb14b"),
                ScheduledMeeting = DateTime.UtcNow.AddDays(14),
                Duration = 120,
                Note = "Web Development Fundamentals",
                MaxUsers = 15,
                MinUsers = 3,
                IsDeleted = false,
                CourseID = Guid.Parse("bc103b57-4e13-4ff8-9a18-2158d0ec41dd")
            },
            new Meeting()
            {
                Id = Guid.Parse("b0841f9d-6d0d-43e6-9429-20d7f3ac0ef7"),
                ScheduledMeeting = DateTime.UtcNow.AddDays(10),
                Duration = 120,
                Note = "Data Science Essentials",
                MaxUsers = 15,
                MinUsers = 5,
                IsDeleted = false,
                CourseID = Guid.Parse("ff1e8442-ff9b-4c19-9865-c77ad810c609")
            },
            new Meeting()
            {
                Id = Guid.Parse("3f9e262a-1813-47f9-983d-716f053e7d4c"),
                ScheduledMeeting = DateTime.UtcNow.AddDays(21),
                Duration = 120,
                Note = "Mobile App Development Workshop",
                MaxUsers = 20,
                MinUsers = 5,
                IsDeleted = false,
                CourseID = Guid.Parse("5c56b3f3-1fb2-4f99-80db-8ea2bbcdfe25")
            }
        };

        modelBuilder.Entity<Meeting>().HasData(meetings);

        List<Reservation> reservations = new List<Reservation>()
        {
            new Reservation()
            {
                Id = Guid.NewGuid(),
                Note = "Reserved for John Doe",
                VerifiedPayment = true,
                Withdraw = false,
                IsDeleted = false,
                MeetingID = Guid.Parse("9a18e6f1-0343-4a0a-845e-86524cc95e67"),
                UserID = Guid.Parse("852bb3a4-2d4b-4dbf-aa18-cbe7f3e2f96d")
            },
            new Reservation()
            {
                Id = Guid.NewGuid(),
                Note = "Reserved for Alice Smith",
                VerifiedPayment = true,
                Withdraw = false,
                IsDeleted = false,
                MeetingID = Guid.Parse("f674b6e3-7e3d-4b7c-8ff4-0a66a39bb14b"),
                UserID = Guid.Parse("6f59a8e1-7c7e-4c0a-a139-0f423f068f95")
            },
            new Reservation()
            {
                Id = Guid.NewGuid(),
                Note = "Reserved for Sarah Lee",
                VerifiedPayment = true,
                Withdraw = false,
                IsDeleted = false,
                MeetingID = Guid.Parse("b0841f9d-6d0d-43e6-9429-20d7f3ac0ef7"),
                UserID = Guid.Parse("d4a1ed96-7f9a-41ea-9a87-8f50c9aa50f7")
            },
            new Reservation()
            {
                Id = Guid.NewGuid(),
                Note = "Reserved for Michael Brown",
                VerifiedPayment = true,
                Withdraw = false,
                IsDeleted = false,
                MeetingID = Guid.Parse("3f9e262a-1813-47f9-983d-716f053e7d4c"),
                UserID = Guid.Parse("2c7f6f19-1647-4923-892a-77a6a825b0cf")
            },
        };

        modelBuilder.Entity<Reservation>().HasData(reservations);

        List<User> users = new List<User>()
        {
            new User()
            {
                Id = Guid.Parse("852bb3a4-2d4b-4dbf-aa18-cbe7f3e2f96d"),
                ParticipantFullName = "John Doe",
                Age = 30,
                ParentFullName = "Mary Doe",
                Email = "john.doe@email.com",
                VerifiedUser = true,
                IsNewsletterActive = true,
                Allergies = "Peanuts",
                ConsentToPersonalData = true,
                PrivacyPolicyAcknowledgement = true,
                PhoneNumber = 1234567890,
                IsDeleted = false,
            },
            new User()
            {
                Id = Guid.Parse("6f59a8e1-7c7e-4c0a-a139-0f423f068f95"),
                ParticipantFullName = "Alice Smith",
                Age = 25,
                ParentFullName = "Bob Smith",
                Email = "alice.smith@email.com",
                VerifiedUser = true,
                IsNewsletterActive = false,
                Allergies = "None",
                ConsentToPersonalData = true,
                PrivacyPolicyAcknowledgement = true,
                PhoneNumber = 1234567891,
                IsDeleted = false,
            },
            new User()
            {
                Id = Guid.Parse("d4a1ed96-7f9a-41ea-9a87-8f50c9aa50f7"),
                ParticipantFullName = "Sarah Lee",
                Age = 22,
                ParentFullName = "James Lee",
                Email = "sarah.lee@email.com",
                VerifiedUser = true,
                IsNewsletterActive = true,
                Allergies = "Gluten",
                ConsentToPersonalData = true,
                PrivacyPolicyAcknowledgement = true,
                PhoneNumber = 1234567892,
                IsDeleted = false,
            },
            new User()
            {
                Id = Guid.Parse("2c7f6f19-1647-4923-892a-77a6a825b0cf"),
                ParticipantFullName = "Michael Brown",
                Age = 27,
                ParentFullName = "Karen Brown",
                Email = "michael.brown@email.com",
                VerifiedUser = true,
                IsNewsletterActive = true,
                Allergies = "Shellfish",
                ConsentToPersonalData = true,
                PrivacyPolicyAcknowledgement = true,
                PhoneNumber = 1234567893,
                IsDeleted = false,
            }
        };
        modelBuilder.Entity<User>().HasData(users);
    }
}
