namespace WebApplicationJukebox.Models.nUsuarios
{
    public class Usuario
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
