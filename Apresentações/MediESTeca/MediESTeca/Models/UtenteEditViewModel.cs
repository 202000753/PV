using System.ComponentModel.DataAnnotations;

namespace MediESTeca.Models
{
    public class UtenteEditViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }


        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public int Telefone { get; set; }
    }
}
