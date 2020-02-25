using WebApplicationJukebox.Models.nUsuarios;

namespace WebApplicationJukebox.ViewModels.nUsuario
{
    public class UsuarioListView
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public int PerfilId { get; set; }
        public string Perfil { get; set; }
    }
}
