
using MediESTeca_v2.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MediESTeca_v2.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Remote(action: "IsbnExists", controller: "Livros")]
        [CheckIsbn(ErrorMessage = "O {0} é inválido")]  // Definido nesta aplicação
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Isbn { get; set; }

        [Display(Name = "Título")]
        [StringLength(160, ErrorMessage = "O {0} não deve ter mais do que {1} caracteres")]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Titulo { get; set; }

        [StringLength(160, ErrorMessage = "O {0} não deve ter mais do que {1} caracteres")]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Autor { get; set; }

        [Display(Name = "Ano de Edição")]
        [Range(1582, Int32.MaxValue, ErrorMessage = "O {0} deve ser posterior a 1582")]
        public int? AnoEdicao { get; set; }
    }
}
