
using Ista.Repository.EntityFramework.Cards.Tables;
using Ista.Repository.EntityFramework.Users.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ista.Repository.EntityFramework.Cards.Mappers
{
    internal class CardListMapper : IEntityTypeConfiguration<CardListTable>
    {
        void IEntityTypeConfiguration<CardListTable>.Configure(EntityTypeBuilder<CardListTable> builder)
        {
            builder.ToTable("CardList");
            builder.HasKey(c => c.Uid);
            builder.Property(c => c.Uid).HasColumnName("uidCardList");
            builder.Property(c => c.Name).HasColumnName("name");
            builder.Property(c => c.Scope).HasColumnName("idScope");
            builder.Property(c => c.UserOwnerId).HasColumnName("uidUserOwner");
            builder.HasOne(c => c.Owner).WithMany().HasForeignKey(c => c.UserOwnerId);

            builder.HasMany(c => c.Cards)
                .WithOne(c=>c.CardList)
                .HasForeignKey(c => c.IdCardList);
        }
    }
}
