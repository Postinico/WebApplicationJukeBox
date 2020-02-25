using System;

namespace WebApplicationJukebox.ViewModels.Album
{
    public class AlbumListView
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int GeneroId { get; set; }
        public String Genero { get; set; }
    }
}
