
using Ista.Repository.EntityFramework.Cards.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ista.Repository.EntityFramework.Cards.Mappers
{
    internal class CardMapper : IEntityTypeConfiguration<CardTable>
    {
        void IEntityTypeConfiguration<CardTable>.Configure(EntityTypeBuilder<CardTable> builder)
        {
            builder.ToTable("Card");
            builder.HasKey(c => c.Uid);
            builder.Property(c => c.Uid).HasColumnName("uidCard");
            builder.Property(c => c.TextFront).HasColumnName("textFront");
            builder.Property(c => c.TextBack).HasColumnName("textBack");
            builder.Property(c => c.IdCardList).HasColumnName("uidCardList");            
        }
    }
}
