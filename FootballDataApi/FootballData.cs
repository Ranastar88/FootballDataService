using FootballDataApi.BL;
using FootballDataApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FootballDataApi
{
  public class FootballData
  {
    private string _authToken;
    private string _baseUrl = "https://api.football-data.org/";
    /// <summary>
    /// 
    /// </summary>
    /// <param name="authtoken"></param>
    public FootballData(string authtoken)
    {
      _authToken = authtoken;
      if (string.IsNullOrEmpty(_authToken)) throw new Exception("Auth token non presente!");
    }

    /// <summary>
    /// Call api resource: /v1/competitions/?season=
    /// </summary>
    /// <param name="anno">Year of competitions</param>
    /// <returns>List of competitions of the year</returns>
    public List<Competition> GetCompetitions(int anno) {
      var result = new List<Competition>();
      var j = SendRequest("/v1/competitions/?season=" + anno);
      if (!string.IsNullOrEmpty(j)) {
        result = JsonConvert.DeserializeObject<List<Competition>>(j);
      }
      return result;
    }

    /// <summary>
    /// Call api resource: /v1/competitions/{id}/teams	
    /// </summary>
    /// <param name="competitionid">int</param>
    /// <returns>List of competition's teams</returns>
    public Teams GetTeamsOfCompetition(int competitionid) {
      var result = new Teams();
      var j = SendRequest("/v1/competitions/" + competitionid + "/teams");
      if (!string.IsNullOrEmpty(j))
      {
        result = ManagerTeams.ParseTeam(j);
      }
      return result;
    }

    /// <summary>
    /// Call api resource: /v1/competitions/{competitionid}/leagueTable
    /// </summary>
    /// <param name="competitionid">int</param>
    /// <returns>LeagueTable</returns>
    public LeagueTable GetLeagueTable(int competitionid) {
      var result = new LeagueTable();
      var j = SendRequest("/v1/competitions/" + competitionid + "/leagueTable");
      if (!string.IsNullOrEmpty(j))
      {
        result = JsonConvert.DeserializeObject<LeagueTable>(j);
      }
      return result;
    }

    /// <summary>
    /// Call api resource: /v1/competitions/{competitionid}/leagueTable/?matchday={matchday}
    /// </summary>
    /// <param name="competitionid">int</param>
    /// <param name="matchday">int</param>
    /// <returns>LeagueTable</returns>
    public LeagueTable GetLeagueTable(int competitionid,int matchday)
    {
      var result = new LeagueTable();
      var j = SendRequest("/v1/competitions/" + competitionid + "/leagueTable?matchday=" + matchday);
      if (!string.IsNullOrEmpty(j))
      {
        result = JsonConvert.DeserializeObject<LeagueTable>(j);
      }
      return result;
    }

    /// <summary>
    /// Call api resource: /v1/teams/{id}	
    /// </summary>
    /// <param name="teamid">int</param>
    /// <returns>Team</returns>
    public Team GetTeam(int teamid)
    {
      var result = new Team();
      var j = SendRequest("/v1/teams/" + teamid);
      if (!string.IsNullOrEmpty(j))
      {
        result = JsonConvert.DeserializeObject<Team>(j);
      }
      return result;
    }

    /// <summary>
    /// Call api resource: /v1/teams/{id}/players
    /// </summary>
    /// <param name="teamid">int</param>
    /// <returns>Players</returns>
    public Players GetTeamPlayers(int teamid)
    {
      var result = new Players();
      var j = SendRequest("/v1/teams/" + teamid+ "/players");
      if (!string.IsNullOrEmpty(j))
      {
        result = JsonConvert.DeserializeObject<Players>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
      }
      return result;
    }

    /// <summary>
    /// List all fixtures for a certain competition.
    /// Call api resource: /v1/competitions/{id}/fixtures	
    /// </summary>
    /// <param name="competitionid">int</param>
    /// <returns>Fixtures</returns>
    public Fixtures GetFixtures(int competitionid)
    {
      var result = new Fixtures();
      var j = SendRequest("/v1/competitions/" + competitionid + "/fixtures");
      if (!string.IsNullOrEmpty(j))
      {
        result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
      }
      return result;
    }

    /// <summary>
    /// List all fixtures for a certain competition.
    /// Call api resource: /v1/competitions/{id}/fixtures/?matchday=
    /// </summary>
    /// <param name="competitionid">int</param>
    /// <param name="matchday">int</param>
    /// <returns>Fixtures</returns>
    public Fixtures GetFixtures(int competitionid,int matchday)
    {
      var result = new Fixtures();
      var j = SendRequest("/v1/competitions/" + competitionid + "/fixtures/?matchday=" + matchday);
      if (!string.IsNullOrEmpty(j))
      {
        result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
      }
      return result;
    }

    /// <summary>
    /// List all fixtures for a certain competition.
    /// Call api resource: /v1/competitions/{id}/fixtures/?timeFrame=
    /// </summary>
    /// <param name="competitionid"></param>
    /// <param name="tm">TimeFrame: Next or Past either in the past or future</param>
    /// <param name="dayrange">It is followed by a number in the range 1..99</param>
    /// <returns>Fixtures</returns>
    public Fixtures GetFixtures(int competitionid, TimeFrame tm,int dayrange)
    {
      if (dayrange > 99) dayrange = 99;
      if (dayrange < 1) dayrange = 1;
      string ext = "?";
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
      var j = SendRequest("/v1/competitions/" + competitionid + "/fixtures/" + ext);
      if (!string.IsNullOrEmpty(j))
      {
        result = JsonConvert.DeserializeObject<Fixtures>(j, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
      }
      return result;
    }

    private string SendRequest(string link) {
      string result;
      HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + link);
      HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
      using (Stream stream = myHttpWebResponse.GetResponseStream())
      {
        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        result = reader.ReadToEnd();
      }
      return result;
    }
  }
}
