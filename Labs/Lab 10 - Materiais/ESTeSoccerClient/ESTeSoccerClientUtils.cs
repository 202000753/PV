using ESTeSoccerMVC.Models;
using System.Text;

namespace ESTeSoccerClient;

public static class ESTeSoccerClientUtils
{
    public static string LeaguesList(this List<League> leagues)
    {
        StringBuilder stb = new("{");
        for (var i = 0; i < leagues.Count; i++)
        {
            var league = leagues[i];
            stb.Append(league.LeagueId);
            stb.Append('-');
            stb.Append(league.Name);
            stb.Append(", ");
            stb.Append(league.Country);

            // append comma on all except last
            if (i < leagues.Count - 1)
                stb.Append(", ");
        }
        stb.Append('}');
        return stb.ToString();
    }
}
