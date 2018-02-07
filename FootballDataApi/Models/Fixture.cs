using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
  public class Fixture
  {
    public int id { get; set; }
    public int competitionid { get; set; }
    public int hometeamid { get; set; }
    public int awayteamid { get; set; }
    public DateTime date { get; set; }
    public string status { get; set; }
    public int matchday { get; set; }
    public string homeTeamName { get; set; }
    public string awayTeamName { get; set; }
    public Result result { get; set; }
  }
}
