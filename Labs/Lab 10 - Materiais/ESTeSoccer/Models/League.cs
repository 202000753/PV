using System.ComponentModel.DataAnnotations;

namespace ESTeSoccerMVC.Models;

public class League
{

    [Display(Name = "Id")]
    public int LeagueId { get; set; }

    [Required]
    [MaxLength(20)]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    [Display(Name = "Country")]
    public string Country { get; set; }

    public List<Team> Teams { get; set; } = new List<Team>();
}
