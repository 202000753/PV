using MediESTeca.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace MediESTeca.Models
{
    public class Requisicao
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public string UtenteId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da Requisição")]
        public DateTime DataRequisicao { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Entrega")]
        public DateTime DataEntrega { get; set; }

        public Livro Livro { get; set; }
        public Utente Utente { get; set; }
    }
}
