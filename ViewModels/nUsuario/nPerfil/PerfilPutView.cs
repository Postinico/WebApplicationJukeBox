using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplicationJukebox.ViewModels.nUsuario
{
    public class PerfilPutView : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                     .IsGreaterThan(Id, 0, "id", "O ID deve ser maior que zero.")
                     .HasMinLen(Descricao, 3, "Descrição", "A 'Descrição' deve conter pelo menos 3 caracteres.")
                     .HasMaxLen(Descricao, 25, "Descrição", "A descrição deve conter até 25 caracteres.")
            );

        }
    }
}
