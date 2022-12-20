﻿using System.ComponentModel.DataAnnotations;

namespace MediESTeca_v1.Models
{
    public class Utente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public int Telefone { get; set; }
    }
}
