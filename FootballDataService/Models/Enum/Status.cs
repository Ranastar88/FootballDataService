using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataService.Models.Enum
{
    public enum Status
    {
        SCHEDULED,
        LIVE,
        IN_PLAY,
        PAUSED,
        FINISHED,
        POSTPONED,
        SUSPENDED,
        CANCELED
    }
}
