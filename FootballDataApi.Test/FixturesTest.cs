using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballDataApi.Models;
using System.Collections.Generic;

namespace FootballDataApi.Test
{
  [TestClass]
  public class FixturesTest
  {
    private FootballData mng;
    public FixturesTest()
    {
      mng = new FootballData("3f217f062e6c473cb1546d0daca64372");
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
