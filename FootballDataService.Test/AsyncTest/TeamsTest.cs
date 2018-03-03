using System;
using System.Threading.Tasks;
using FootballDataService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballDataService.Test.AsyncTest
{
  [TestClass]
  public class TeamsTest
  {
    private FootballDataAsync mng;
    private const int IDTEAM = 109;

    public TeamsTest()
    {
      mng = new FootballDataAsync("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public async Task Show_One_Team_Async()
    {
      var f = await mng.GetTeamAsync(IDTEAM);
      Console.WriteLine(f.shortName + " - " + f.name);
      Console.WriteLine(f.squadMarketValue);
    }

    [TestMethod]
    public async Task Show_All_Players_For_Certain_Team_Async()
    {
      var g = await mng.GetTeamPlayersAsync(IDTEAM);
      foreach (var item in g.players)
      {
        Console.WriteLine("#" + item.jerseyNumber + " " + item.name + " - " + item.position);
      }
    }

    [TestMethod]
    public async Task Show_All_Fixtures_For_Certain_Team_Async()
    {
      var f = await mng.GetFixturesTeamAsync(2017, IDTEAM, null, TimeFrame.Next, 30);
      foreach (var item in f.fixtures)
      {
        Console.WriteLine("#" + item.id + " " + item.homeTeamName + " - " + item.awayTeamName);
      }
    }
  }
}
