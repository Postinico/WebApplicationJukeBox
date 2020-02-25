using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplicationJukebox.ViewModels
{
    public class GeneroPostView : Notifiable, IValidatable
    {
        public string Titulo { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMinLen(Titulo, 3, "Titulo", "O título deve conter pelo menos 3 caracteres.")
            );

        }
    }
}
