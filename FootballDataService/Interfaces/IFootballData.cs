using FootballDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataService.Interfaces
{
    public interface IFootballData
    {
        List<Competition> GetCompetitions();
        Competition GetCompetition(int id);
    }
}
