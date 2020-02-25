using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplicationJukebox.ViewModels.nUsuario
{
    public class PerfilPostView : Notifiable, IValidatable
    {
        public string Descricao { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMinLen(Descricao, 3, "Descrição", "A 'Descrição' deve conter pelo menos 3 caracteres.")
                    .HasMaxLen(Descricao, 25, "Descrição", "A descrição deve conter até 25 caracteres.")
            );

        }
    }
}
