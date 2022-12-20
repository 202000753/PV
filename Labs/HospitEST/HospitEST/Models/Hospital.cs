using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HospitEST.Models
{
    public class Hospital
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Local")]
        public string Localization { get; set; }

        [Display(Name = "Médicos")] 
        public List<Doctor>? Doctors { get; set; }
    }
}
