using FootballDataApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var mng = new FootballData("3f217f062e6c473cb1546d0daca64372");
      int idcomp = 456;
      Console.WriteLine("=========Competizione=========");
      var c = mng.GetTeamsOfCompetition(idcomp);
      foreach (var item in c.teams)
      {
        Console.WriteLine(item.id + " - " + item.name);
      }

      Console.WriteLine("=========Classifica=========");
      var d = mng.GetLeagueTable(idcomp);
      foreach (var item in d.standing)
      {
        Console.WriteLine(item.points + " - " + item.teamName);
      }

      Console.WriteLine("=========Squadra=========");
      var f = mng.GetTeam(109);
      Console.WriteLine(f.shortName + " - " + f.name);

      Console.WriteLine("=========Giocatori Squadra=========");
      var g = mng.GetTeamPlayers(109);
      foreach (var item in g.players)
      {
        Console.WriteLine("#" + item.jerseyNumber.GetValueOrDefault() + " " + item.name + " - " + item.position);
      }

      Console.WriteLine("=========Fixture 1=========");
      var h = mng.GetFixtures(idcomp,2);
      foreach (var item in h.fixtures)
      {
        Console.WriteLine(item.homeTeamName + " - " + item.awayTeamName);
      }
      Console.ReadLine();
    }
  }
}
