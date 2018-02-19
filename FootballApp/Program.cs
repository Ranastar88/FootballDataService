using FootballDataApi;
using FootballDataApi.Models;
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
   

      Console.WriteLine("=========Fixture=========");
      var h = mng.GetFixtures(idcomp, TimeFrame.Next,25,new List<string>() { "SA","SB"});
      foreach (var item in h.fixtures)
      {
        Console.WriteLine(item.matchday + "##" + item.homeTeamName + " - " + item.awayTeamName);
      }
      Console.ReadLine();
    }
  }
}
