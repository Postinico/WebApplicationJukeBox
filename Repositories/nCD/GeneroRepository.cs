using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationJukebox.Data;
using WebApplicationJukebox.Models;
using WebApplicationJukebox.ViewModels.Genero;

namespace WebApplicationJukebox.Repositories
{
    public class GeneroRepository
    {
        private readonly StoreDataContext _context;

        public GeneroRepository(StoreDataContext context)
        {
            _context = context;

        }

        public IEnumerable<GeneroListaView> Get()
        {
            return _context
                .Generos
                .Select(x => new GeneroListaView
                {
                    Id = x.Id,
                    Titulo = x.Titulo
                })
                .AsNoTracking()
                .ToList();
        }
        public Genero Get(int id)
        {
            return _context.Generos.Find(id);
        }
        public void Save(Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
        }
        public void Update(Genero genero)
        {
            _context.Entry<Genero>(genero).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(Genero genero)
        {
            _context.Generos.Remove(genero);
            _context.SaveChanges();

        }

    }
}
