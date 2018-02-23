using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataService.Models
{
  public class Player
  {
    public int id { get; set; }
    public string name { get; set; }
    public string position { get; set; }
    public int? jerseyNumber { get; set; }
    public DateTime dateOfBirth { get; set; }
    public string nationality { get; set; }
    public DateTime? contractUntil { get; set; }
    public string marketValue { get; set; }
  }
}
