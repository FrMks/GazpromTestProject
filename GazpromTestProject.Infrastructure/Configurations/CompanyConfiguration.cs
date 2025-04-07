using GazpromTestProject.Core.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GazpromTestProject.Infrastructure.Configurations;

public class CompanyConfiguration: IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("CompanyId");
        builder.Property(c => c.Name).HasColumnName("CompanyName");
        builder.ComplexProperty(c => c.MailingAddress, mailingAddressBuilder =>
        {
            mailingAddressBuilder.Property(a => a.Street).HasColumnName("Street");
            mailingAddressBuilder.Property(a => a.City).HasColumnName("City");
            mailingAddressBuilder.Property(a => a.PostalCode).HasColumnName("PostalCode");
        });
        builder.HasMany(c => c.Users)
            .WithOne(u => u.Company);
    }
}