using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FootballDataService.Test.AsyncTest
{
  [TestClass]
  public class CompetitionsTest
  {
    private FootballDataAsync mng;
    private const int IDCOMP = 456;

    public CompetitionsTest()
    {
      mng = new FootballDataAsync("3f217f062e6c473cb1546d0daca64372");
    }

    [TestMethod]
    public async Task List_All_Available_Competitions_Async()
    {
      var b = await mng.GetCompetitionsAsync(2017);
      foreach (var item in b)
      {
        Console.WriteLine("ID : " + item.id);
        Console.WriteLine("Code : " + item.league);
        Console.WriteLine("Nome : " + item.caption);
        Console.WriteLine("***********************");
      }
    }

    [TestMethod]
    public async Task List_All_Teams_For_Certain_Competition_Async()
    {
      var c = await mng.GetTeamsOfCompetitionAsync(IDCOMP);
      foreach (var item in c.teams)
      {
        Console.WriteLine("ID : " + item.id);
        Console.WriteLine("Short Name : " + item.shortName);
        Console.WriteLine("Nome : " + item.name);
        Console.WriteLine("***********************");
      }
    }

    [TestMethod]
    public async Task Show_League_Table_Async()
    {
      var d = await mng.GetLeagueTableAsync(IDCOMP);
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
