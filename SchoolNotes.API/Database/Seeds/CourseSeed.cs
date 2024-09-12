using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Database.Seeds;

public class CourseSeed : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasData(
            new Course
            {
                ID = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Matematicas"
            },
            new Course
            {
                ID = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "Historia"
            },
            new Course
            {
                ID = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Ciencias"
            }
        );

    }
}
