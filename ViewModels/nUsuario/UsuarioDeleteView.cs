
using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplicationJukeBox.ViewModels.nUsuario
{
    public class UsuarioDeletView : Notifiable, IValidatable
    {
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                   .IsGreaterThan(Id, 0, "id", "O ID deve ser maior que zero.")
            );

        }
    }
}
