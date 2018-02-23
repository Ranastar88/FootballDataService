using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataService.Models
{
  public class StandingTeam
  {
    public int rank { get; set; }
    public string teamName { get; set; }
    public int teamId { get; set; }
    public int playedGames { get; set; }
    public string crestURI { get; set; }
    public int points { get; set; }
    public int goals { get; set; }
    public int goalsAgainst { get; set; }
    public int goalDifference { get; set; }
  }
}
