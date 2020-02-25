using Flunt.Notifications;
using Flunt.Validations;


namespace WebApplicationJukebox.ViewModels.Album
{
    public class AlbumPostView : Notifiable, IValidatable
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int GeneroId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Titulo, 120, "Título", "O título deve conter até 120 caracteres.")
                    .HasMinLen(Titulo, 3, "Título", "O título deve conter pelo menos 3 caracteres.")
                    .HasMaxLen(Descricao, 120, "Descrição", "A drescrição deve conter até 120 caracteres.")
                    .HasMinLen(Descricao, 3, "Descrição", "A descrição deve conter pelo menos 3 caracteres.")
                    .HasMaxLen(Imagem, 120, "Imagem", "A imagem deve conter até 120 caracteres.")
                    .HasMinLen(Imagem, 3, "Imagem", "A imagem deve conter pelo menos 3 caracteres.")

            );

        }
    }
}
