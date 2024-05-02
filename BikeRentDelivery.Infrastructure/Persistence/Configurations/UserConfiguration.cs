using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BikeRentDelivery.Common.Persistence.Configurations;

using BikeRentDelivery.Domain.Users;

namespace BikeRentDelivery.Infrastructure.Persistence.Configurations;

internal class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(b => b.BirthDate)
            .IsRequired();

        builder.OwnsOne(b => b.Cnpj,
            cnpj =>
            {
                cnpj.Property(c => c.Number)
                   .HasColumnName("Cnpj")
                   .HasMaxLength(14)
                   .IsRequired();

                cnpj.HasIndex(c => c.Number)
                   .IsUnique();
            });

        builder.OwnsOne(b => b.Email,
            email =>
            {
                email.Property(e => e.Address)
                     .HasColumnName("Email")
                     .HasMaxLength(100)
                     .IsRequired();

                email.HasIndex(e => e.Address)
                     .IsUnique();
            });

        builder.OwnsOne(b => b.Cnh,
            cnh =>
            {
                cnh.Property(c => c.Number)
                   .HasColumnName("CnhNumber")
                   .HasMaxLength(11)
                   .IsRequired();

                cnh.HasIndex(c => c.Number)
                   .IsUnique();
            });

        builder.OwnsOne(b => b.Cnh,
            cnh =>
            {
                cnh.Property(c => c.Type)
                   .HasColumnName("CnhType")
                   .IsRequired();
            });

        builder.OwnsOne(b => b.Cnh,
            cnh =>
            {
                cnh.Property(c => c.Image)
                   .HasColumnName("CnhImage");
            });

        builder.OwnsOne(b => b.Password,
            password =>
            {
                password.Property(p => p.Content)
                     .HasColumnName("Password")
                     .HasMaxLength(100)
                     .IsRequired();
            });

        builder.Property(b => b.Role)
            .HasMaxLength(25)
            .IsRequired();

        builder.Property(b => b.UpdatedAt);

        builder.Property(b => b.IsDeleted)
            .IsRequired();

        builder.HasMany(b => b.Rentals)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);

        builder.HasMany(b => b.Notifications)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);

        //builder.HasData(
        //    User.Create(
        //        "Admin",
        //        new DateTime(2000, 7, 27),
        //        "25.512.761/0001-53",
        //        "74006776657",
        //        CnhType.AB.ToString(),
        //        null,
        //        "admin@admin.com",
        //        "mudar@123",
        //        AuthConstants.Admin).Value);
    }
}