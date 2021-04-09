
using Ista.Repository.EntityFramework.Users.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ista.Repository.EntityFramework.Users.Mappers
{
    internal class UserMapper : IEntityTypeConfiguration<UserTable>
    {


        void IEntityTypeConfiguration<UserTable>.Configure(EntityTypeBuilder<UserTable> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Uid);
            builder.Property(c => c.Uid).HasColumnName("uidUser");
            builder.Property(c => c.Name).HasColumnName("name");
            builder.Property(c => c.Login).HasColumnName("login");
        }
    }
}
