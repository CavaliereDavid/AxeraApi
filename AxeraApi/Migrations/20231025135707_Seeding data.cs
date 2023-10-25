using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AxeraApi.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("5c56b3f3-1fb2-4f99-80db-8ea2bbcdfe25"), "Create mobile apps for both Android and iOS platforms.", false, "Mobile App Development" },
                    { new Guid("a0203c2f-16d5-4f87-bc6f-6a1a4eb67002"), "Learn the basics of programming with this introductory course.", false, "Introduction to Programming" },
                    { new Guid("bc103b57-4e13-4ff8-9a18-2158d0ec41dd"), "Explore the fundamentals of web development.", false, "Web Development Fundamentals" },
                    { new Guid("ff1e8442-ff9b-4c19-9865-c77ad810c609"), "Master the essentials of data science and analysis.", false, "Data Science Essentials" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Allergies", "ConsentToPersonalData", "Email", "IsDeleted", "IsNewsletterActive", "ParentFullName", "ParticipantFullName", "PhoneNumber", "PrivacyPolicyAcknowledgement", "VerifiedUser" },
                values: new object[,]
                {
                    { new Guid("2c7f6f19-1647-4923-892a-77a6a825b0cf"), 27, "Shellfish", true, "michael.brown@email.com", false, true, "Karen Brown", "Michael Brown", 1234567893, true, true },
                    { new Guid("6f59a8e1-7c7e-4c0a-a139-0f423f068f95"), 25, "None", true, "alice.smith@email.com", false, false, "Bob Smith", "Alice Smith", 1234567891, true, true },
                    { new Guid("852bb3a4-2d4b-4dbf-aa18-cbe7f3e2f96d"), 30, "Peanuts", true, "john.doe@email.com", false, true, "Mary Doe", "John Doe", 1234567890, true, true },
                    { new Guid("d4a1ed96-7f9a-41ea-9a87-8f50c9aa50f7"), 22, "Gluten", true, "sarah.lee@email.com", false, true, "James Lee", "Sarah Lee", 1234567892, true, true }
                });

            migrationBuilder.InsertData(
                table: "Meeting",
                columns: new[] { "Id", "CourseID", "Duration", "IsDeleted", "MaxUsers", "MinUsers", "Note", "ScheduledMeeting" },
                values: new object[,]
                {
                    { new Guid("3f9e262a-1813-47f9-983d-716f053e7d4c"), new Guid("5c56b3f3-1fb2-4f99-80db-8ea2bbcdfe25"), 120, false, 20, 5, "Mobile App Development Workshop", new DateTime(2023, 11, 15, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9833) },
                    { new Guid("9a18e6f1-0343-4a0a-845e-86524cc95e67"), new Guid("a0203c2f-16d5-4f87-bc6f-6a1a4eb67002"), 90, false, 20, 5, "Introduction to Programming", new DateTime(2023, 11, 1, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9816) },
                    { new Guid("b0841f9d-6d0d-43e6-9429-20d7f3ac0ef7"), new Guid("ff1e8442-ff9b-4c19-9865-c77ad810c609"), 120, false, 15, 5, "Data Science Essentials", new DateTime(2023, 11, 4, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9830) },
                    { new Guid("f674b6e3-7e3d-4b7c-8ff4-0a66a39bb14b"), new Guid("bc103b57-4e13-4ff8-9a18-2158d0ec41dd"), 120, false, 15, 3, "Web Development Fundamentals", new DateTime(2023, 11, 8, 13, 57, 7, 274, DateTimeKind.Utc).AddTicks(9827) }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "IsDeleted", "MeetingID", "Note", "UserID", "VerifiedPayment", "Withdraw" },
                values: new object[,]
                {
                    { new Guid("0e373944-736f-4c37-958a-d7749c5a75d3"), false, new Guid("b0841f9d-6d0d-43e6-9429-20d7f3ac0ef7"), "Reserved for Sarah Lee", new Guid("d4a1ed96-7f9a-41ea-9a87-8f50c9aa50f7"), true, false },
                    { new Guid("82727523-ab6f-4115-9b73-72e03f0fda8a"), false, new Guid("f674b6e3-7e3d-4b7c-8ff4-0a66a39bb14b"), "Reserved for Alice Smith", new Guid("6f59a8e1-7c7e-4c0a-a139-0f423f068f95"), true, false },
                    { new Guid("8a1e2258-4315-4562-8fc6-a7fb32d147a9"), false, new Guid("9a18e6f1-0343-4a0a-845e-86524cc95e67"), "Reserved for John Doe", new Guid("852bb3a4-2d4b-4dbf-aa18-cbe7f3e2f96d"), true, false },
                    { new Guid("a42e51eb-eeef-4a07-aaac-bf80848f442a"), false, new Guid("3f9e262a-1813-47f9-983d-716f053e7d4c"), "Reserved for Michael Brown", new Guid("2c7f6f19-1647-4923-892a-77a6a825b0cf"), true, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("0e373944-736f-4c37-958a-d7749c5a75d3"));

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("82727523-ab6f-4115-9b73-72e03f0fda8a"));

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("8a1e2258-4315-4562-8fc6-a7fb32d147a9"));

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: new Guid("a42e51eb-eeef-4a07-aaac-bf80848f442a"));

            migrationBuilder.DeleteData(
                table: "Meeting",
                keyColumn: "Id",
                keyValue: new Guid("3f9e262a-1813-47f9-983d-716f053e7d4c"));

            migrationBuilder.DeleteData(
                table: "Meeting",
                keyColumn: "Id",
                keyValue: new Guid("9a18e6f1-0343-4a0a-845e-86524cc95e67"));

            migrationBuilder.DeleteData(
                table: "Meeting",
                keyColumn: "Id",
                keyValue: new Guid("b0841f9d-6d0d-43e6-9429-20d7f3ac0ef7"));

            migrationBuilder.DeleteData(
                table: "Meeting",
                keyColumn: "Id",
                keyValue: new Guid("f674b6e3-7e3d-4b7c-8ff4-0a66a39bb14b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2c7f6f19-1647-4923-892a-77a6a825b0cf"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6f59a8e1-7c7e-4c0a-a139-0f423f068f95"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("852bb3a4-2d4b-4dbf-aa18-cbe7f3e2f96d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d4a1ed96-7f9a-41ea-9a87-8f50c9aa50f7"));

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("5c56b3f3-1fb2-4f99-80db-8ea2bbcdfe25"));

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("a0203c2f-16d5-4f87-bc6f-6a1a4eb67002"));

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("bc103b57-4e13-4ff8-9a18-2158d0ec41dd"));

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: new Guid("ff1e8442-ff9b-4c19-9865-c77ad810c609"));
        }
    }
}
