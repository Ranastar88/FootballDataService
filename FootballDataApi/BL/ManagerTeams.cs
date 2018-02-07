using FootballDataApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballDataApi.BL
{
  public class ManagerTeams
  {
    public static Teams ParseTeam(string json) {
      var r = JsonConvert.DeserializeObject<_Teams>(json);
      return new Teams() {
        count = r.count,
        teams = r.teams.Select(x => new Team() {
          id = int.Parse(x._links.self.href.Split(new[] { "v1/teams/" }, StringSplitOptions.None)[1]),
          name = x.name,
          shortName = x.shortName,
          squadMarketValue = x.squadMarketValue,
          crestUrl = x.crestUrl
        }).ToList()
      };
    }

    private class _Teams
    {
      public int count { get; set; }
      public List<_Team> teams { get; set; }
    }
    private class _Team
    {
      public _Links _links { get; set; }
      public int id { get; set; }
      public string name { get; set; }
      public string shortName { get; set; }
      public string squadMarketValue { get; set; }
      public string crestUrl { get; set; }
    }
    private class _Links {
      public _Link self { get; set; }
    }
    private class _Link{
      public string href { get; set; }
    }
  }
}
