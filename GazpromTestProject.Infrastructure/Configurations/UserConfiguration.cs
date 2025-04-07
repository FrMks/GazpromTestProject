using GazpromTestProject.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GazpromTestProject.Infrastructure.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("UserId");
        builder.ComplexProperty(u => u.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.First).HasColumnName("FirstName").HasMaxLength(150);
            nameBuilder.Property(n => n.Last).HasColumnName("LastName").HasMaxLength(150);
        });
        builder.ComplexProperty(u => u.DateOfBirth, dateOfBirthBuilder =>
        {
            dateOfBirthBuilder.Property(d => d.Value).HasColumnName("DateOfBirth");
        });
        builder.ComplexProperty(e => e.Email, emailBuilder =>
        {
            emailBuilder.Property(e => e.EmailValue).HasColumnName("Email");
        });
        builder.ComplexProperty(p => p.PhoneNumber, phoneNumberBuilder =>
        {
            phoneNumberBuilder.Property(p => p.PhoneNumberValue).HasColumnName("PhoneNumber");
        });
        builder.HasOne(u => u.Company)
            .WithMany(u => u.Users);
        builder.HasMany(u => u.Skills)
            .WithMany(s => s.Users);
    }
}