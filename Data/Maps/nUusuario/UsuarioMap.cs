using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationJukebox.Models.nUsuarios;

namespace WebApplicationJukebox.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Imagem).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");

        }
    }
}
