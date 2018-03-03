using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootballDataService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballDataService.Test.AsyncTest
{
  [TestClass]
  public class FixturesTest
  {
    private FootballDataAsync mng;
    private const int IDCOMP = 456;
    private const int IDTEAM = 109;

    public FixturesTest()
    {
      mng = new FootballDataAsync("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public async Task List_All_Fixtures_For_Certain_Competition_Async()
    {
      var r = await mng.GetFixturesAsync(IDCOMP);
      foreach (var item in r.fixtures)
      {
        Console.WriteLine(item.id + "##" + item.homeTeamName + " - " + item.awayTeamName + " | " + item.result.goalsHomeTeam + " - " + item.result.goalsAwayTeam);
      }
    }

    [TestMethod]
    public async Task List_fixtures_across_competitions_Async()
    {
      var h = await mng.GetFixturesAsync(456, TimeFrame.Next, 25, new List<string>() { "SA", "SB" });
      foreach (var item in h.fixtures)
      {
        Console.WriteLine(item.id + "##" + item.homeTeamName + " - " + item.awayTeamName);
      }
    }

    [TestMethod]
    public async Task Show_All_Fixtures_For_Certain_Team_Async()
    {
      var h = await mng.GetFixturesTeamAsync(2017, IDTEAM, Venue.Home, TimeFrame.Next, 10);
      foreach (var item in h.fixtures)
      {
        Console.WriteLine(item.id + "##" + item.homeTeamName + " - " + item.awayTeamName);
      }
    }
  }
}
