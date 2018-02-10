using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
  public class Fixture
  {
    public Links _links { get; set; }

    public int id
    {
      get { return int.Parse(_links.self.href.Split(new[] { "v1/fixtures/" }, StringSplitOptions.None)[1]); }
      set { }
    }
    public int competitionid
    {
      get { return int.Parse(_links.competition.href.Split(new[] { "v1/competitions/" }, StringSplitOptions.None)[1]); }
      set { }
    }
    public int hometeamid {
      get { return int.Parse(_links.hometeam.href.Split(new[] { "v1/teams/" }, StringSplitOptions.None)[1]); }
      set { }
    }
    public int awayteamid
    {
      get { return int.Parse(_links.awayteam.href.Split(new[] { "v1/teams/" }, StringSplitOptions.None)[1]); }
      set { }
    }

    public DateTime date { get; set; }
    public string status { get; set; }
    public int matchday { get; set; }
    public string homeTeamName { get; set; }
    public string awayTeamName { get; set; }
    public Result result { get; set; }
    public Head2Head head2head { get; set; }
  }

  public class Links
  {
    public Link self { get; set; }
    public Link competition { get; set; }
    public Link hometeam { get; set; }
    public Link awayteam { get; set; }
  }
}
