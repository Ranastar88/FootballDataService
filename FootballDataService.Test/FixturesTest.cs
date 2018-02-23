using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FootballDataService;
using FootballDataService.Models;

namespace FootballDataService.Test
{
  [TestClass]
  public class FixturesTest
  {
    private FootballData mng;
    private const int IDCOMP = 456;

    public FixturesTest()
    {
      mng = new FootballData("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public void List_All_Fixtures_For_Certain_Competition() {
      var r = mng.GetFixtures(IDCOMP);
      foreach (var item in r.fixtures)
      {
        Console.WriteLine(item.id + "##" + item.homeTeamName + " - " + item.awayTeamName + " | " + item.result.goalsHomeTeam + " - " + item.result.goalsAwayTeam);
      }
    }

    [TestMethod]
    public void List_fixtures_across_competitions()
    {
      var h = mng.GetFixtures(456, TimeFrame.Next, 25, new List<string>() { "SA", "SB" });
      foreach (var item in h.fixtures)
      {
        Console.WriteLine(item.id + "##" + item.homeTeamName + " - " + item.awayTeamName);
      }
    }
  }
}
