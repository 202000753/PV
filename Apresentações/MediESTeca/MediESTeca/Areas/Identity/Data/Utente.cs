using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MediESTeca.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Utente class
public class Utente : IdentityUser
{
    [Required(ErrorMessage = "O {0} é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O {0} é obrigatório")]
    public int Telefone { get; set; }
}

