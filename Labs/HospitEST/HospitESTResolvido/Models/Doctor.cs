using System.ComponentModel.DataAnnotations;

namespace HospitEST.Models
{
    //Nivel 1
    public class Doctor
    {
        public Guid Id { get; set; }
        public Guid HospitalId { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Àrea profissional")]
        public string Practice { get; set; }

        [Required]
        [Range(0,int.MaxValue, ErrorMessage ="Os anos de prática não podem ser negativos")]
        [Display(Name = "Anos de prática")]
        public int PracticeYears { get; set; }
        
        [Display(Name="Pacientes")]
        public List<Patient>? Patients { get; set; }
        public Hospital? Hospital { get; set; }
    }
}
