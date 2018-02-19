using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballDataApi.Test
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
      Console.WriteLine(t.homeTeamName + " " + t.result.goalsHomeTeam + " - " + " " + t.result.goalsAwayTeam + t.awayTeamName);
    }
  }
}
