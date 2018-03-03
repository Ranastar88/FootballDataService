using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballDataService.Test.AsyncTest
{
  [TestClass]
  public class FixtureTest
  {
    private FootballDataAsync mng;
    public FixtureTest()
    {
      mng = new FootballDataAsync("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public async Task Show_One_Fixture_Async()
    {
      var t = await mng.GetFixtureAsync(163876);
      Console.WriteLine(t.fixture.homeTeamName + " " + t.fixture.result.goalsHomeTeam + " - " + " " + t.fixture.result.goalsAwayTeam + t.fixture.awayTeamName);
    }
  }
}
