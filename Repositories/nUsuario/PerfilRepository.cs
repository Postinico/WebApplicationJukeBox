using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplicationJukebox.Data;
using WebApplicationJukebox.Models.nUsuarios;
using WebApplicationJukebox.ViewModels.nUsuario;

namespace WebApplicationJukebox.Repositories.nUsuario
{
    public class PerfilRepository
    {

        private readonly StoreDataContext _context;

        public PerfilRepository(StoreDataContext context)
        {
            _context = context;

        }

        public IEnumerable<PerfilListView> Get()
        {
            return _context
                .Perfils
                .Select(x => new PerfilListView
                {
                    Id = x.Id,
                    Descricao = x.Descricao
                })
                .AsNoTracking()
                .ToList();
        }
        public Perfil Get(int id)
        {
            return _context.Perfils.Find(id);
        }
        public void Save(Perfil perfil)
        {
            _context.Perfils.Add(perfil);
            _context.SaveChanges();
        }
        public void Update(Perfil perfil)
        {
            _context.Entry<Perfil>(perfil).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(Perfil perfil)
        {
            _context.Perfils.Remove(perfil);
            _context.SaveChanges();

        }

    }
}
