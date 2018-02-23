using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataService.Models
{
   public class Fixtures
    {
    public DateTime? timeFrameStart { get; set; }
    public DateTime? timeFrameEnd { get; set; }
    public int count { get; set; }
    public List<Fixture> fixtures { get; set; }
  }
}
