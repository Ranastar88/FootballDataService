using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataApi.Models
{
  public class Teams
  {
    public int count { get; set; }
    public List<Team> teams { get; set; }
  }
}
