using GazpromTestProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GazpromTestProject.Infrastructure.Configurations;

public class SkillConfiguration: IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills").HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("SkillId");
        builder.Property(s => s.Name).HasColumnName("SkillName");
        builder.HasMany(s => s.Users)
            .WithMany(u => u.Skills);
    }
}