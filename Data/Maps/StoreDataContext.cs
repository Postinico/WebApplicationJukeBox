using Microsoft.EntityFrameworkCore;
using WebApplicationJukebox.Models;
using WebApplicationJukebox.Data.Maps;
using WebApplicationJukebox.Models.nUsuarios;

namespace WebApplicationJukebox.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,32769;Database=dbJukeBox;User ID=SA;Password=@ACESSO BALTAIO");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GeneroMap());
            builder.ApplyConfiguration(new AlbumMap());
            builder.ApplyConfiguration(new PerfilMap());
            builder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
