using FootballDataService.BL;
using FootballDataService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FootballDataService
{
    public class FootballData
    {
        private string _authToken;
        private string _baseUrl = "https://api.football-data.org/v2/";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authtoken"></param>
        public FootballData(string authtoken)
        {
            _authToken = authtoken;
            if (string.IsNullOrEmpty(_authToken)) throw new Exception("Auth token empty!");
        }

        /// <summary>
        /// Call api resource: /competitions/?season=
        /// </summary>
        /// <param name="anno">Year of competitions</param>
        /// <returns>List of competitions of the year</returns>
        public List<Competition> GetCompetitions(int anno)
        {
            var result = new List<Competition>();
            var j = SendRequest("/competitions/?season=" + anno);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<List<Competition>>(j);
            }
            return result;
        }

        /// <summary>
        /// Call api resource: /competitions/{id}/teams	
        /// </summary>
        /// <param name="competitionid">int</param>
        /// <returns>List of competition's teams</returns>
        public Teams GetTeamsOfCompetition(int competitionid)
        {
            var result = new Teams();
            var j = SendRequest("/competitions/" + competitionid + "/teams");
            if (!string.IsNullOrEmpty(j))
            {
                result = ManagerTeams.ParseTeam(j);
            }
            return result;
        }

        /// <summary>
        /// Call api resource: /competitions/{competitionid}/leagueTable
        /// </summary>
        /// <param name="competitionid">int</param>
        /// <returns>LeagueTable</returns>
        public LeagueTable GetLeagueTable(int competitionid)
        {
            var result = new LeagueTable();
            var j = SendRequest("/competitions/" + competitionid + "/leagueTable");
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<LeagueTable>(j);
            }
            return result;
        }

        /// <summary>
        /// Call api resource: /competitions/{competitionid}/leagueTable/?matchday={matchday}
        /// </summary>
        /// <param name="competitionid">int</param>
        /// <param name="matchday">int</param>
        /// <returns>LeagueTable</returns>
        public LeagueTable GetLeagueTable(int competitionid, int matchday)
        {
            var result = new LeagueTable();
            var j = SendRequest("/competitions/" + competitionid + "/leagueTable?matchday=" + matchday);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<LeagueTable>(j);
            }
            return result;
        }

        /// <summary>
        /// Call api resource: /teams/{id}	
        /// </summary>
        /// <param name="teamid">int</param>
        /// <returns>Team</returns>
        public Team GetTeam(int teamid)
        {
            var result = new Team();
            var j = SendRequest("/teams/" + teamid);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<Team>(j);
            }
            return result;
        }

        /// <summary>
        /// Call api resource: /teams/{id}/players
        /// </summary>
        /// <param name="teamid">int</param>
        /// <returns>Players</returns>
        public Players GetTeamPlayers(int teamid)
        {
            var result = new Players();
            var j = SendRequest("/teams/" + teamid + "/players");
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<Players>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            return result;
        }

        /// <summary>
        /// List all fixtures for a certain competition.
        /// Call api resource: /competitions/{id}/fixtures	
        /// </summary>
        /// <param name="competitionid">int</param>
        /// <returns>Fixtures</returns>
        public Fixtures GetFixtures(int competitionid)
        {
            var result = new Fixtures();
            var j = SendRequest("/competitions/" + competitionid + "/fixtures");
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            return result;
        }

        /// <summary>
        /// List all fixtures for a certain competition.
        /// Call api resource: /competitions/{id}/fixtures/?matchday=
        /// </summary>
        /// <param name="competitionid">int</param>
        /// <param name="matchday">int</param>
        /// <returns>Fixtures</returns>
        public Fixtures GetFixtures(int competitionid, int matchday)
        {
            var result = new Fixtures();
            var j = SendRequest("/competitions/" + competitionid + "/fixtures/?matchday=" + matchday);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            return result;
        }

        /// <summary>
        /// List all fixtures for a certain competition.
        /// Call api resource: /competitions/{id}/fixtures/?timeFrame=
        /// </summary>
        /// <param name="competitionid"></param>
        /// <param name="tm">TimeFrame: Next or Past either in the past or future</param>
        /// <param name="dayrange">It is followed by a number in the range 1..99</param>
        /// <returns>Fixtures</returns>
        public Fixtures GetFixtures(int competitionid, TimeFrame tm, int dayrange)
        {
            string ext = "?timeFrame=" + TimeFrameToString(tm, dayrange);

            var result = new Fixtures();
            var j = SendRequest("/competitions/" + competitionid + "/fixtures/" + ext);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            return result;
        }

        /// <summary>
        /// List fixtures across a set of competitions.	
        /// Call api resource: /fixtures/?timeFrame=/p|n[1-9]{1,2}/&league=leagueCode
        /// </summary>
        /// <param name="competitionid"></param>
        /// <param name="tm"></param>
        /// <param name="dayrange"></param>
        /// <param name="elencoLeagueCode"></param>
        /// <returns></returns>
        public Fixtures GetFixtures(int competitionid, TimeFrame tm, int dayrange, List<string> elencoLeagueCode)
        {
            string ext = "?";

            if (elencoLeagueCode != null)
            {
                string l = "";
                foreach (var item in elencoLeagueCode)
                {
                    l += item + ",";
                }
                if (l.Length > 0) ext += "league=" + l.Substring(0, l.Length - 1) + "&";
            }

            if (dayrange > 99) dayrange = 99;
            if (dayrange < 1) dayrange = 1;
            switch (tm)
            {
                case TimeFrame.Next:
                    ext += "timeFrame=n" + dayrange;
                    break;
                case TimeFrame.Past:
                    ext += "timeFrame=p" + dayrange;
                    break;
            }
            var result = new Fixtures();
            var j = SendRequest("/fixtures/" + ext);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            return result;
        }

        /// <summary>
        /// Get single fixture
        /// </summary>
        /// <param name="fixtureid"></param>
        /// <param name="head2head"></param>
        /// <returns></returns>
        public SingleFixture GetFixture(int fixtureid, int head2head = 10)
        {
            var result = new SingleFixture();
            var j = SendRequest("/fixtures/" + fixtureid + "?head2head=" + head2head);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<SingleFixture>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            return result;
        }

        /// <summary>
        /// Show all fixtures for a certain team.
        /// Call api resource: /teams/{id}/fixtures/
        /// </summary>
        /// <param name="season">int</param>
        /// <param name="teamid">int</param>
        /// <param name="venue">home|away</param>
        /// <param name="tm">TimeFrame</param>
        /// <param name="dayrange">int</param>
        /// <returns>Fixtures</returns>
        public Fixtures GetFixturesTeam(int season, int teamid, Venue? venue, TimeFrame tm, int dayrange)
        {
            string ext = string.Empty;
            if (venue.HasValue) ext = "&venue=" + venue.ToString().ToLower();
            var result = new Fixtures();
            var j = SendRequest("/teams/" + teamid + "/fixtures/?season=" + season + "&timeFrame=" + TimeFrameToString(tm, dayrange) + ext);
            if (!string.IsNullOrEmpty(j))
            {
                result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
            }
            return result;
        }


        private string SendRequest(string link)
        {
            string result;
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + link);
            myHttpWebRequest.Headers.Add("X-Auth-Token", _authToken);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            using (Stream stream = myHttpWebResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            return result;
        }

        private string TimeFrameToString(TimeFrame tm, int dayrange)
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
