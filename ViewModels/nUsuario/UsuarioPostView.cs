using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplicationJukeBox.ViewModels.nnUsuario
{
    public class UsuarioPostView : Notifiable, IValidatable
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        public int PerfilId { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Email, 120, "Email", "O email deve conter até 120 caracteres.")
                    .HasMinLen(Email, 3, "Email", "O Email deve conter pelo menos 3 caracteres.")
                    .HasMaxLen(Senha, 120, "Senha", "A senha deve conter até 120 caracteres.")
                    .HasMinLen(Senha, 3, "Sennha", "A senha deve conter pelo menos 3 caracteres.")
                    .HasMaxLen(Imagem, 120, "Imagem", "A imagem deve conter até 120 caracteres.")
                    .HasMinLen(Imagem, 3, "Imagem", "A imagem deve conter pelo menos 3 caracteres.")
            );

        }
    }
}
