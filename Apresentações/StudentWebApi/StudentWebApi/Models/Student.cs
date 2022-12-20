using System.ComponentModel.DataAnnotations;

namespace StudentWebApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(1, 9999)]
        public int? Number { get; set; }

    }
}
