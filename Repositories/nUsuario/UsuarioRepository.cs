using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplicationJukebox.Data;
using WebApplicationJukebox.Models.nUsuarios;
using WebApplicationJukebox.ViewModels.nUsuario;
namespace WebApplicationJukebox.Repositories.doUsuario
{
    public class UsuarioRepository
    {
        private readonly StoreDataContext _context;

        public UsuarioRepository(StoreDataContext context)
        {
            _context = context;

        }

        public IEnumerable<UsuarioListView> Get()
        {
            return _context
                .Usuarios
                .Select(x => new UsuarioListView
                {
                    Id = x.id,
                    Email = x.Email,
                    Senha = x.Senha,
                    Imagem = x.Imagem,
                    PerfilId = x.PerfilId,
                    Perfil = x.Perfil.Descricao
                })
                .AsNoTracking()
                .ToList();
        }

        public UsuarioListView Get(int id)
        {
            return _context.Usuarios
                .Include(x => x.Perfil)
                .Select(f => new UsuarioListView
                {
                    Id = f.id,
                    Email = f.Email,
                    Senha = f.Senha,
                    Imagem = f.Imagem,
                    PerfilId = f.PerfilId,
                    Perfil = f.Perfil.Descricao

                }).Where(e => e.Id == id)
                           .FirstOrDefault();

        }

        public Usuario Search(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Save(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Entry<Usuario>(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
