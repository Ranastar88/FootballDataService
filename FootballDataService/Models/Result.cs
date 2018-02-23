using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataService.Models
{
  public class Result
  {
    public int? goalsHomeTeam { get; set; }
    public int? goalsAwayTeam { get; set; }
    public Score halfTime { get; set; }
    public Score extraTime { get; set; }
    public Score penaltyShootout { get; set; }
  }
}
