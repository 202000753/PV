﻿using HospitEST.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HospitEST.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [FutureDateValidation]
        [Display(Name = "Data de Nascimento")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Patologia")]
        public string? Pathology { get; set; }

        [Display(Name = "Médico")]
        public Doctor? Doctor { get; set; }
    }
}
