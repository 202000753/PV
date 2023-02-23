using System.ComponentModel.DataAnnotations;

namespace ESTeSoccerMVC.Models;

public class Team
{
    [Display(Name = "Id")]
    public int TeamId { get; set; }

    [Display(Name = "LeagueId")]
    public int LeagueId { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required]
    [StringLength(3)]
    [Display(Name = "Initials")]
    public string Initials { get; set; }

    [Display(Name = "Founding Date")]
    public DateTime? FoundingDate { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
    [Display(Name = "Number Of Titles")]
    public int NumberOfTitles { get; set; }

    [Display(Name = "Main Color")]
    public string? MainColor { get; set; }

    public virtual List<Player>? Players { get; set; }

    [Display(Name = "League")]
    public League? League { get; set; }
}
