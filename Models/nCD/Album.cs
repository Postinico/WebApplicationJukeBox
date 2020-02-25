namespace WebApplicationJukebox.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int GeneroId { get; set; }
        public Genero Perfil { get; set; }
    }
}
