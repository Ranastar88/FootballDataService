using System;
using System.Collections.Generic;
using System.Text;

namespace FootballDataService.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public Area Area { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Plan { get; set; }
        public Season CurrentSeason { get; set; }
        public Season Season { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
