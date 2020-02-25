using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationJukebox.Data;
using WebApplicationJukebox.Models;
using WebApplicationJukebox.ViewModels.Album;

namespace WebApplicationJukebox.Repositories
{
    public class AlbumRepository
    {
        private readonly StoreDataContext _context;

        public AlbumRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<AlbumListView> Get()
        {
            return _context
                .Albuns
                .Include(x => x.Perfil)
                .Select(x => new AlbumListView
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    Imagem = x.Imagem,
                    GeneroId = x.Perfil.Id,
                    Genero = x.Perfil.Titulo
                })

                .AsNoTracking()
                .ToList();
        }

        public AlbumListView Get(int id)
        {
            return _context.Albuns
                .Include(x => x.Perfil)
                .Select(f => new AlbumListView
                {
                    Id = f.Id,
                    Titulo = f.Titulo,
                    Descricao = f.Descricao,
                    Imagem = f.Imagem,
                    GeneroId = f.Perfil.Id,
                    Genero = f.Perfil.Titulo

                }).Where(e => e.Id == id)
                           .FirstOrDefault();


        }
        public Album Search(int id)
        {
            return _context.Albuns.Find(id);
        }
        public void Save(Album album)
        {
            _context.Albuns.Add(album);
            _context.SaveChanges();
        }

        public void Update(Album album)
        {
            _context.Entry<Album>(album).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Album album)
        {
            _context.Albuns.Remove(album);
            _context.SaveChanges();
        }

    }
}
