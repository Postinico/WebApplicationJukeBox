using Flunt.Notifications;
using Flunt.Validations;

namespace WebApplicationJukebox.ViewModels.Album
{
    public class AlbumPutView : Notifiable, IValidatable
    {
        public int id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int GeneroId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                   .IsGreaterThan(id, 0, "id", "O ID deve ser maior que zero.")
                   .HasMaxLen(Titulo, 120, "Titulo", "O título deve conter até 120 caracteres.")
                    .HasMinLen(Titulo, 3, "Titulo", "O título deve conter pelo menos 3 caracteres.")
                    .HasMaxLen(Descricao, 120, "Descrição", "A drescrição deve conter até 120 caracteres.")
                    .HasMinLen(Descricao, 3, "Descrição", "A descrição deve conter pelo menos 3 caracteres.")
                    .HasMaxLen(Imagem, 120, "Imagem", "A imagem deve conter até 120 caracteres.")
                    .HasMinLen(Imagem, 3, "Imagem", "A imagem deve conter pelo menos 3 caracteres.")
            );

        }
    }
}
