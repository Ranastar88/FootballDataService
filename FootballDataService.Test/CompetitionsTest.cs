using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballDataService;

namespace FootballDataService.Test
{
  [TestClass]
  public class CompetitionsTest
  {
    private FootballData mng;
    private const int IDCOMP = 456;

    public CompetitionsTest()
    {
      mng = new FootballData("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public void List_All_Available_Competitions()
    {
      var b = mng.GetCompetitions(2017);
      foreach (var item in b)
      {
        Console.WriteLine("ID : " + item.id);
        Console.WriteLine("Code : " + item.league);
        Console.WriteLine("Nome : " + item.caption);
        Console.WriteLine("***********************");
      }
    }

    [TestMethod]
    public void List_All_Teams_For_Certain_Competition() {
      var c = mng.GetTeamsOfCompetition(IDCOMP);
      foreach (var item in c.teams)
      {
        Console.WriteLine("ID : " + item.id);
        Console.WriteLine("Short Name : " + item.shortName);
        Console.WriteLine("Nome : " + item.name);
        Console.WriteLine("***********************");
      }
    }

    [TestMethod]
    public void Show_League_Table() {
      var d = mng.GetLeagueTable(IDCOMP);
      Console.WriteLine(d.leagueCaption);
      Console.WriteLine("***********************");
      foreach (var item in d.standing)
      {
        Console.WriteLine(item.points + " " + item.teamName);
      }
      Console.WriteLine("***********************");
    }
  }
}
