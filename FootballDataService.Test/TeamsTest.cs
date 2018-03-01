using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballDataService;
using FootballDataService.Models;

namespace FootballDataService.Test
{
  [TestClass]
  public class TeamsTest
  {
    private FootballData mng;
    private const int IDTEAM = 109;

    public TeamsTest()
    {
      mng = new FootballData("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public void Show_One_Team()
    {
      var f = mng.GetTeam(IDTEAM);
      Console.WriteLine(f.shortName + " - " + f.name);
    }

    [TestMethod]
    public void Show_All_Players_For_Certain_Team() {
      var g = mng.GetTeamPlayers(IDTEAM);
      foreach (var item in g.players)
      {
        Console.WriteLine("#" + item.jerseyNumber + " " + item.name + " - " + item.position);
      }
    }

    [TestMethod]
    public void Show_All_Fixtures_For_Certain_Team()
    {
      var f = mng.GetFixturesTeam(2017,IDTEAM,null,TimeFrame.Next,30);
      foreach (var item in f.fixtures)
      {
        Console.WriteLine("#" + item.id + " " + item.homeTeamName + " - " + item.awayTeamName);
      }
    }
  }
}
