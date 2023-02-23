using System.ComponentModel.DataAnnotations;

namespace ESTeSoccerMVC.Models;

public class Player
{
    [Display(Name = "Id")]
    public int PlayerId { get; set; }

    [Display(Name = "Team Id")]
    public int? TeamId { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
    [Display(Name = "Market Value")]
    public decimal MarketValue { get; set; }

    [Display(Name = "Team")]
    public Team? Team { get; set; }
}
