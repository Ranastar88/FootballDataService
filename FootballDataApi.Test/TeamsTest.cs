using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballDataApi.Models;

namespace FootballDataApi.Test
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
    public void Show_All_Fixtures_For_Certain_Team()
    {
      var f = mng.GetFixtureTeam(2017,IDTEAM,null,TimeFrame.Next,30);
      foreach (var item in f.fixtures)
      {
        Console.WriteLine("#" + item.id + " " + item.homeTeamName + " - " + item.awayTeamName);
      }
    }
  }
}
