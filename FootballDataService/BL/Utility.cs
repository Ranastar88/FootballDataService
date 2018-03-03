using FootballDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataService.BL
{
  internal static class Utility
  {

    public static string TimeFrameToString(TimeFrame tm, int dayrange)
    {
      if (dayrange > 99) dayrange = 99;
      if (dayrange < 1) dayrange = 1;
      string result = "";
      switch (tm)
      {
        case TimeFrame.Next:
          result = "n" + dayrange;
          break;
        case TimeFrame.Past:
          result = "p" + dayrange;
          break;
      }
      return result;
    }
  }
}
