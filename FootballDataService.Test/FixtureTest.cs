﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballDataService;

namespace FootballDataService.Test
{
  [TestClass]
  public class FixtureTest
  {
    private FootballData mng;
    public FixtureTest()
    {
      mng = new FootballData("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public void Show_One_Fixture()
    {
      var t = mng.GetFixture(163876);
      Console.WriteLine(t.fixture.homeTeamName + " " + t.fixture.result.goalsHomeTeam + " - " + " " + t.fixture.result.goalsAwayTeam + t.fixture.awayTeamName);
    }
  }
}
