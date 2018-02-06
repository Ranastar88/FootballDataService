using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
  public class Team
  {
    public int id { get; set; }
    public string name { get; set; }
    public string shortName { get; set; }
    public string squadMarketValue { get; set; }
    public string crestUrl { get; set; }
  }
}
