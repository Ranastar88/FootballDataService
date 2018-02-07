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
      var c = mng.GetTeamsOfCompetition(457);
      foreach (var item in c.teams)
      {
        Console.WriteLine(item.shortName + " - " + item.name);
      }
      Console.ReadLine();
    }
  }
}
