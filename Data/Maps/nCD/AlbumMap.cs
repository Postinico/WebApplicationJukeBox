using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationJukebox.Models;

namespace WebApplicationJukebox.Data.Maps
{
    public class AlbumMap : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Imagem).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");

        }
    }
}
